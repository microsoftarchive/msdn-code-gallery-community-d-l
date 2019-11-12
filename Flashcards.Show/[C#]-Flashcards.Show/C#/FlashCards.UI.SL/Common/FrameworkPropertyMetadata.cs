/* Copyright (c) 2010, Dr. WPF
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted provided that the following conditions are met:
*
*   * Redistributions of source code must retain the above copyright
*     notice, this list of conditions and the following disclaimer.
* 
*   * Redistributions in binary form must reproduce the above copyright
*     notice, this list of conditions and the following disclaimer in the
*     documentation and/or other materials provided with the distribution.
* 
*   * The name Dr. WPF may not be used to endorse or promote products
*     derived from this software without specific prior written permission.
*
* THIS SOFTWARE IS PROVIDED BY Dr. WPF ``AS IS'' AND ANY
* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
* DISCLAIMED. IN NO EVENT SHALL Dr. WPF BE LIABLE FOR ANY
* DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
* SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace System.Windows
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class SilverlightCoercionHelper : Attribute
    {
        #region constructor

        public SilverlightCoercionHelper(string methodName)
        {
            MethodName = methodName;
        }

        #endregion

        #region properties

        public string MethodName
        {
            get;
            private set;
        }

        #endregion

#if SILVERLIGHT

        #region methods

        public static void CoerceValue(DependencyObject d, DependencyProperty dp)
        {
            FrameworkPropertyMetadata.DoExplicitCoercion(d, dp);
        }

        public static void InitializeTypeForValueCoercion(Type type)
        {
            foreach (FieldInfo fi in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                SilverlightCoercionHelper coercionInfo = fi.GetCustomAttributes(typeof(SilverlightCoercionHelper), false).FirstOrDefault() as SilverlightCoercionHelper;
                if (coercionInfo != null)
                {
                    DependencyProperty dp = fi.GetValue(null) as DependencyProperty;
                    if (dp != null)
                    {
                        FrameworkPropertyMetadata.AssociatePropertyWithCoercionMethod(dp, type, coercionInfo.MethodName);
                    }
                }
            }
        }

        #endregion
#endif
    }

#if SILVERLIGHT

    [Flags]
    public enum FrameworkPropertyMetadataOptions : int
    {
        None = 0x0,
        AffectsMeasure = 0x1,
        AffectsArrange = 0x2,
        AffectsParentMeasure = 0x4,
        AffectsParentArrange = 0x8,
    }

    public delegate object CoerceValueCallback(DependencyObject d, object baseValue);

    public class FrameworkPropertyMetadata : PropertyMetadata
    {
        #region constructors

        public FrameworkPropertyMetadata() :
            base(DependencyProperty.UnsetValue)
        {
        }

        public FrameworkPropertyMetadata(object defaultValue)
            : base(defaultValue)
        {
        }

        public FrameworkPropertyMetadata(
            PropertyChangedCallback propertyChangedCallback)
            : base(propertyChangedCallback)
        {
        }

        public FrameworkPropertyMetadata(
            object defaultValue,
            PropertyChangedCallback propertyChangedCallback)
            : base(defaultValue, propertyChangedCallback)
        {
        }

        public FrameworkPropertyMetadata(
            PropertyChangedCallback propertyChangedCallback,
            CoerceValueCallback coerceValueCallback)
            : base(new PropertyChangedCallback(new PropertyChangeHook(FrameworkPropertyMetadataOptions.None, propertyChangedCallback, coerceValueCallback).OnPropertyChanged))
        {
        }

        public FrameworkPropertyMetadata(
            object defaultValue,
            PropertyChangedCallback propertyChangedCallback,
            CoerceValueCallback coerceValueCallback)
            : base(defaultValue, new PropertyChangedCallback(new PropertyChangeHook(FrameworkPropertyMetadataOptions.None, propertyChangedCallback, coerceValueCallback).OnPropertyChanged))
        {
        }

        public FrameworkPropertyMetadata(
            object defaultValue,
            FrameworkPropertyMetadataOptions flags)
            : base(defaultValue, new PropertyChangedCallback(new PropertyChangeHook(flags, null, null).OnPropertyChanged))
        {
        }

        public FrameworkPropertyMetadata(
            object defaultValue,
            FrameworkPropertyMetadataOptions flags,
            PropertyChangedCallback propertyChangedCallback)
            : base(defaultValue, new PropertyChangedCallback(new PropertyChangeHook(flags, propertyChangedCallback, null).OnPropertyChanged))
        {
        }

        public FrameworkPropertyMetadata(
            object defaultValue,
            FrameworkPropertyMetadataOptions flags,
            PropertyChangedCallback propertyChangedCallback,
            CoerceValueCallback coerceValueCallback)
            : base(defaultValue, new PropertyChangedCallback(new PropertyChangeHook(flags, propertyChangedCallback, coerceValueCallback).OnPropertyChanged))
        {
        }

        #endregion

        #region dependency properties

        #region CoercionData

        /// <summary>
        /// CoercionData Attached Dependency Property
        /// </summary>
        private static readonly DependencyProperty CoercionDataProperty =
            DependencyProperty.RegisterAttached("CoercionData", typeof(CoercionData), typeof(FrameworkPropertyMetadata),
                new PropertyMetadata((CoercionData)null));

        /// <summary>
        /// Gets the CoercionData property. This dependency property 
        /// is attached to any dependency object that contains coerced property values.
        /// </summary>
        private static CoercionData GetCoercionData(DependencyObject d)
        {
            return (CoercionData)d.GetValue(CoercionDataProperty);
        }

        /// <summary>
        /// Sets the CoercionData property. This dependency property 
        /// is attached to any dependency object that contains coerced property values.
        /// </summary>
        private static void SetCoercionData(DependencyObject d, CoercionData value)
        {
            d.SetValue(CoercionDataProperty, value);
        }

        #endregion

        #endregion

        #region methods

        #region internal

        internal static void AssociatePropertyWithCoercionMethod(DependencyProperty dp, Type type, string methodName)
        {
            AssociatePropertyWithCoercionMethod(dp, PropertyChangeHook.GetValueCoercionCallback(type, methodName));
        }

        internal static void AssociatePropertyWithCoercionMethod(DependencyProperty dp, CoerceValueCallback coerceValueCallback)
        {
            if (!_dependencyPropertyCoercionMap.ContainsKey(dp))
            {
                _dependencyPropertyCoercionMap[dp] = coerceValueCallback;
            }
        }

        internal static void DoExplicitCoercion(DependencyObject d, DependencyProperty dp)
        {
            CoerceValueCallback coerceValueCallback;
            if (_dependencyPropertyCoercionMap.TryGetValue(dp, out coerceValueCallback))
            {
                CoercionData cd;
                CoercedPropertyInfo cpi;
                object effectiveValue = d.GetValue(dp);
                EnsureCoercionDataForProperty(d, dp, effectiveValue, out cd, out cpi);

                // avoid reentrancy
                if (cpi.IsCoercingValue) return;

                cpi.IsExplicitCoercion = true;
                try
                {
                    bool ignored = false;
                    DoCoercion(d, dp, coerceValueCallback, cpi.BaseValue, false, out ignored);
                }
                finally
                {
                    cpi.IsExplicitCoercion = false;
                }
            }
        }

        #endregion

        #region private

        private static object DoCoercion(DependencyObject d, DependencyProperty dp, CoerceValueCallback coerceValueCallback, object defaultBaseValue, bool forceNewBaseValue, out bool isReentrantImplicitCoercion)
        {
            // get the current property value
            object effectiveValue = d.GetValue(dp);

            CoercionData cd;
            CoercedPropertyInfo cpi;
            EnsureCoercionDataForProperty(d, dp, defaultBaseValue, out cd, out cpi);

            // note whether this is a reentrant call to implicitly coerce the property
            isReentrantImplicitCoercion = (cpi.IsCoercingValue && !cpi.IsExplicitCoercion);

            // avoid reentrancy during value coercion
            if (!cpi.IsCoercingValue)
            {
                if (forceNewBaseValue)
                {
                    cpi.BaseValue = defaultBaseValue;
                }

                object baseValue = cpi.BaseValue;
                object coercedValue = baseValue;
                cpi.IsCoercingValue = true;
                try
                {
                    // coerce the value
                    coercedValue = coerceValueCallback(d, baseValue);

                    // if the coerced value is different from the effective value, update the property
                    if (effectiveValue == null ? coercedValue != null : !effectiveValue.Equals(coercedValue))
                    {
                        d.SetValue(dp, coercedValue);
                        effectiveValue = coercedValue;
                    }
                }
                finally
                {
                    cpi.IsCoercingValue = false;
                }

                // if setting a new base value and the coerced value equals that base value, there is no need to store it
                if (forceNewBaseValue && (baseValue == null ? coercedValue != null : !baseValue.Equals(coercedValue)))
                {
                    cd.Remove(dp);
                    if (cd.Count == 0)
                    {
                        d.ClearValue(CoercionDataProperty);
                    }
                }
            }

            // return the effective property value
            return effectiveValue;
        }

        private static void EnsureCoercionDataForProperty(DependencyObject d, DependencyProperty dp, object defaultBaseValue, out CoercionData cd, out CoercedPropertyInfo cpi)
        {
            cd = GetCoercionData(d);
            cpi = null;
            if (cd == null)
            {
                cd = new CoercionData();
                SetCoercionData(d, cd);
            }
            else
            {
                cd.TryGetValue(dp, out cpi);
            }

            if (cpi == null)
            {
                cpi = new CoercedPropertyInfo();
                cpi.BaseValue = defaultBaseValue;
                cd[dp] = cpi;
            }
        }

        #endregion

        #endregion

        #region private classes

        #region CoercedPropertyInfo Class

        private class CoercedPropertyInfo
        {
            #region properties

            public object BaseValue { get; set; }

            public bool IsCoercingValue
            {
                get { return ReadFlag(CoercionOptions.IsCoercingValue); }
                set { WriteFlag(CoercionOptions.IsCoercingValue, value); }
            }

            public bool IsExplicitCoercion
            {
                get { return ReadFlag(CoercionOptions.IsExplicitCoercion); }
                set { WriteFlag(CoercionOptions.IsExplicitCoercion, value); }
            }

            #endregion

            #region methods

            private bool ReadFlag(CoercionOptions id)
            {
                return (id & _flags) != 0;
            }

            private void WriteFlag(CoercionOptions id, bool value)
            {
                if (value) _flags |= id;
                else _flags &= (~id);
            }

            #endregion

            #region fields

            [Flags]
            private enum CoercionOptions : int
            {
                IsCoercingValue = 0x1,
                IsExplicitCoercion = 0x2,
            }

            private CoercionOptions _flags;

            #endregion
        }

        #endregion

        #region CoercionData Class

        private class CoercionData : Dictionary<DependencyProperty, CoercedPropertyInfo>
        {
        }

        #endregion

        #region PropertyChangeHook Class

        private class PropertyChangeHook
        {
            #region constructor

            internal PropertyChangeHook(FrameworkPropertyMetadataOptions flags, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
            {
                TranslateFlags(flags);
                _propertyChangedCallback = propertyChangedCallback;
                _coerceValueCallback = coerceValueCallback;
                if (coerceValueCallback != null)
                {
                    Type ownerType = coerceValueCallback.Method.DeclaringType;
                    Dictionary<string, CoerceValueCallback> coercionMethodsForType;
                    if (!_knownValueCoercionMethods.TryGetValue(ownerType, out coercionMethodsForType))
                    {
                        coercionMethodsForType = new Dictionary<string, CoerceValueCallback>();
                        _knownValueCoercionMethods[ownerType] = coercionMethodsForType;
                    }
                    coercionMethodsForType[coerceValueCallback.Method.Name] = coerceValueCallback;
                }
            }

            #endregion

            #region properties

            private bool AffectsArrange
            {
                get { return ReadFlag(FrameworkPropertyMetadataOptions.AffectsArrange); }
                set { WriteFlag(FrameworkPropertyMetadataOptions.AffectsArrange, value); }
            }

            private bool AffectsMeasure
            {
                get { return ReadFlag(FrameworkPropertyMetadataOptions.AffectsMeasure); }
                set { WriteFlag(FrameworkPropertyMetadataOptions.AffectsMeasure, value); }
            }

            private bool AffectsParentArrange
            {
                get { return ReadFlag(FrameworkPropertyMetadataOptions.AffectsParentArrange); }
                set { WriteFlag(FrameworkPropertyMetadataOptions.AffectsParentArrange, value); }
            }

            private bool AffectsParentMeasure
            {
                get { return ReadFlag(FrameworkPropertyMetadataOptions.AffectsParentMeasure); }
                set { WriteFlag(FrameworkPropertyMetadataOptions.AffectsParentMeasure, value); }
            }

            #endregion

            #region methods

            #region public

            public void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                object priorValue = e.OldValue;
                object effectiveValue = e.NewValue;

                // if necessary, coerce the value
                if (_coerceValueCallback != null)
                {
                    // ensure that the coercion method is associated with the DP
                    AssociatePropertyWithCoercionMethod(e.Property, _coerceValueCallback);

                    // perform the coercion
                    bool isReentrantImplicitCoercion = false;
                    effectiveValue = DoCoercion(d, e.Property, _coerceValueCallback, effectiveValue, true, out isReentrantImplicitCoercion);

                    // ignore reentrant calls
                    if (isReentrantImplicitCoercion) return;
                }

                // if the effective value is not equal to the prior value, then this is a true property change
                if ((effectiveValue == null ? priorValue != null : !effectiveValue.Equals(priorValue)))
                {
                    // perform any necessary invalidations
                    if ((uint)_flags != 0 && d is FrameworkElement)
                    {
                        FrameworkElement fe = d as FrameworkElement;
                        if (AffectsMeasure)
                        {
                            fe.InvalidateMeasure();
                        }

                        if (AffectsArrange)
                        {
                            fe.InvalidateArrange();
                        }

                        if (AffectsParentMeasure && fe.Parent is FrameworkElement)
                        {
                            (fe.Parent as FrameworkElement).InvalidateMeasure();
                        }

                        if (AffectsParentArrange && fe.Parent is FrameworkElement)
                        {
                            (fe.Parent as FrameworkElement).InvalidateArrange();
                        }
                    }

                    // NOTE: In the event that the value was changed due to coercion, the e.NewValue that will be received in
                    // the supplied PropertyChangedCallback will not contain the "effective" value of the property.
                    // Rather, it will contain the desired "base" value of the property (a.k.a., the uncoerced value).
                    // 
                    // This is a Silverlight limitation.  The constructor for DependencyPropertyChangedEventArgs 
                    // is internal so we can't simply create a new object with the correct NewValue and OldValue properties.
                    // The solution is to use d.GetValue(e.Property) instead of e.NewValue within the property changed callback.
                    // My Silverlight snippets do this by default.
                    //
                    // If you prefer to see the glass as half full, this limitation does allow a control to easily know if
                    // a property has been coerced, and if so, it provides easy access to the base value.

                    if (_propertyChangedCallback != null)
                        _propertyChangedCallback(d, e);
                }
            }

            #endregion

            #region internal

            internal static CoerceValueCallback GetValueCoercionCallback(Type ownerType, string methodName)
            {
                CoerceValueCallback result = null;
                Dictionary<string, CoerceValueCallback> coercionMethodsForType;
                if (_knownValueCoercionMethods.TryGetValue(ownerType, out coercionMethodsForType))
                {
                    coercionMethodsForType.TryGetValue(methodName, out result);
                }
                return result;
            }

            #endregion

            #region private

            private static bool IsFlagSet(FrameworkPropertyMetadataOptions flag, FrameworkPropertyMetadataOptions flags)
            {
                return (flags & flag) != 0;
            }

            private bool ReadFlag(FrameworkPropertyMetadataOptions id)
            {
                return (id & _flags) != 0;
            }

            private void TranslateFlags(FrameworkPropertyMetadataOptions flags)
            {
                if (IsFlagSet(FrameworkPropertyMetadataOptions.AffectsMeasure, flags))
                {
                    AffectsMeasure = true;
                }

                if (IsFlagSet(FrameworkPropertyMetadataOptions.AffectsArrange, flags))
                {
                    AffectsArrange = true;
                }

                if (IsFlagSet(FrameworkPropertyMetadataOptions.AffectsParentMeasure, flags))
                {
                    AffectsParentMeasure = true;
                }

                if (IsFlagSet(FrameworkPropertyMetadataOptions.AffectsParentArrange, flags))
                {
                    AffectsParentArrange = true;
                }
            }

            private void WriteFlag(FrameworkPropertyMetadataOptions id, bool value)
            {
                if (value) _flags |= id;
                else _flags &= (~id);
            }

            #endregion

            #endregion

            #region fields

            private static Dictionary<Type, Dictionary<string, CoerceValueCallback>> _knownValueCoercionMethods = new Dictionary<Type, Dictionary<string, CoerceValueCallback>>();

            private CoerceValueCallback _coerceValueCallback;
            private FrameworkPropertyMetadataOptions _flags;
            private PropertyChangedCallback _propertyChangedCallback;

            #endregion
        }

        #endregion

        #endregion

        #region fields

        private static Dictionary<DependencyProperty, CoerceValueCallback> _dependencyPropertyCoercionMap = new Dictionary<DependencyProperty, CoerceValueCallback>();

        #endregion
    }

#endif

}
