//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains core classes used by all BizTalk components and projects
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.BizTalk.Core.PipelineComponents
{
    #region Using references
    using System;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Resources;
    using System.ComponentModel;
    using System.Globalization;
    using System.Diagnostics;
    using System.Security.Principal;
    using System.Drawing;

    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Message.Interop;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.ActivityTracking;
    using Contoso.Cloud.Integration.BizTalk.Core.ActivityTracking;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Provides a base class from which any type of custom pipeline components must be derived.
    /// </summary>
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    public abstract class PipelineComponentBase : BaseCustomTypeDescriptor, IBaseComponent, IPersistPropertyBag, IComponentUI
    {
        #region Private members
        private readonly ResourceManager resourceManager;
        private IntPtr componentIcon = IntPtr.Zero;
        private string componentName, componentDesc;
        private readonly object instanceLock = new object();
        private IActivityTrackingEventStream pipelineEventStream;
        private PipelineComponentBenchmarkActivity benchmarkActivity;

        /// <summary>
        /// Returns a cached value containing the name of the current machine on which this component is being executed.
        /// </summary>
        protected readonly static string MachineName = Environment.MachineName;

        /// <summary>
        /// Returns a cached value containing the name of the current user under which this component is being executed.
        /// </summary>
        protected readonly static string WindowsIdentityName = WindowsIdentity.GetCurrent().Name;

        /// <summary>
        /// Returns the reference to a tracing component that provides instrumentation and logging services ot this component.
        /// </summary>
        protected readonly static ITraceEventProvider PipelineTraceManager = TraceManager.PipelineComponent;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineComponentBase"/> using the specified resource manager.
        /// </summary>
        /// <param name="resourceManager">The resource manager object providing access to the component resources.</param>
        protected PipelineComponentBase(ResourceManager resourceManager)
            : base(new ResourceManagerWrapper(resourceManager))
        {
            this.resourceManager = resourceManager;
        }
        #endregion

        #region Global component properties
        /// <summary>
        /// Gets or sets a flag indicating whether or not full details (such as stack trace and all inner exceptions) 
        /// will be included when reporting on runtime exceptions.
        /// </summary>
        [Browsable(true)]
        [BtsPropertyName(GlobalComponentPropertyName.EnableDetailedExceptionsProp)]
        [BtsDescription(GlobalComponentPropertyName.EnableDetailedExceptionsDesc)]
        [BtsCategory(GlobalComponentPropertyName.SharedPipelineComponentPropsCategory)]
        public bool EnableDetailedExceptions
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets a flag indicating whether or not default BAM activity tracking is enabled for this component.
        /// It allows capturing performance and activity-related metrics each time when this pipeline component is invoked by the BizTalk Messaging Engine.
        /// </summary>
        [Browsable(true)]
        [BtsPropertyName(GlobalComponentPropertyName.EnableActivityTrackingProp)]
        [BtsDescription(GlobalComponentPropertyName.EnableActivityTrackingDesc)]
        [BtsCategory(GlobalComponentPropertyName.SharedPipelineComponentPropsCategory)]
        public bool EnableActivityTracking
        {
            get;
            set;
        }
        #endregion

        #region IBaseComponent interface implementation
        /// <summary>
        /// Gets the pipeline component's name.
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get
            {
                if (null == this.componentName)
                {
                    lock (this.instanceLock)
                    {
                        if (null == this.componentName)
                        {
                            BtsComponentNameAttribute nameAttr = FrameworkUtility.GetDeclarativeAttribute<BtsComponentNameAttribute>(this);

                            if (nameAttr != null)
                            {
                                this.componentName = this.resourceManager.GetString(nameAttr.ComponentName);
                            }

                            if (null == this.componentName)
                            {
                                this.componentName = this.GetType().Name;
                            }
                        }
                    }
                }
                return this.componentName;
            }
            set
            {
                this.componentName = value;
            }
        }

        /// <summary>
        /// Gets the pipeline component's description.
        /// </summary>
        [Browsable(false)]
        public string Description
        {
            get
            {
                if (null == this.componentDesc)
                {
                    lock (this.instanceLock)
                    {
                        if (null == this.componentDesc)
                        {
                            BtsDescriptionAttribute descAttr = FrameworkUtility.GetDeclarativeAttribute<BtsDescriptionAttribute>(this);

                            if (descAttr != null)
                            {
                                this.componentDesc = this.resourceManager.GetString(descAttr.Description);
                            }
                        }
                    }
                }

                return this.componentDesc;
            }
            set
            {
                this.componentDesc = value;
            }
        }

        /// <summary>
        /// Gets the pipeline component's version.
        /// </summary>
        [Browsable(false)]
        public string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            set
            {
            }
        }
        #endregion

        #region IPersistPropertyBag interface implementation
        /// <summary>
        /// Returns the ClassID of this component for usage from native code.
        /// </summary>
        /// <param name="classID">The <see cref="System.Guid"/> value of the component.</param>
        public void GetClassID(out Guid classID)
        {
            classID = GetType().GUID;
        }

        /// <summary>
        /// Initializes a new property bag.
        /// </summary>
        void IPersistPropertyBag.InitNew()
        {
        }

        /// <summary>
        /// Loads configuration property for component.
        /// </summary>
        /// <param name="propertyBag">The configuration property bag.</param>
        /// <param name="errorLog">Error status (not in use).</param>
        void IPersistPropertyBag.Load(IPropertyBag propertyBag, int errorLog)
        {
            // The outer try/catch block is intended to catch an exception related of incorrect tracing configuration or missing tracing component assembly.
            try
            {
                var callToken = PipelineTraceManager.TraceIn();

                try
                {
                    IDictionary<string, object> props = GetConfigurableProperties();

                    if (props != null && props.Count > 0)
                    {
                        using (DisposableObjectWrapper dispObjects = new DisposableObjectWrapper(propertyBag, props))
                        {
                            ICollection<string> propertyNameList = new List<string>(props.Keys);

                            foreach (string propName in propertyNameList)
                            {
                                // Read the component property value from property bag provided.
                                object value = PropertyHelper.ReadPropertyBag(propertyBag, propName);

                                // Only change the value if it was returned from the property bag to prevent detaults from being wiped out.
                                if (value != null)
                                {
                                    props[propName] = value;
                                }
                            }

                            // Update the instance properties which are marked with a Browsable attribute.
                            ApplyConfigurableProperties(props);

                            // Invoke the user implementation of the Load method in case there are any custom properties require loading.
                            Load(propertyBag, errorLog);
                        }
                    }

                    PipelineTraceManager.TraceOut(callToken);
                }
                catch (Exception e)
                {
                    // Put component name as a source in this exception so that the error message could reflect this.
                    e.Source = this.Name;

                    // Trace the exception details.
                    PipelineTraceManager.TraceError(e, EnableDetailedExceptions, callToken);

                    // Re-throw the exception so that it can be handled by the caller.
                    throw;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ExceptionTextFormatter.Format(ex));
            }
        }

        /// <summary>
        /// Loads configuration property for component. This method can be overridden by user code to load additional properties
        /// which cannot be reflected through the declarative attributes.
        /// </summary>
        /// <param name="propertyBag">The configuration property bag.</param>
        /// <param name="errorLog">Error status (not in use).</param>
        public virtual void Load(IPropertyBag propertyBag, int errorLog)
        {
        }

        /// <summary>
        /// Saves properties to the property bag.
        /// </summary>
        /// <param name="propertyBag">The property bag to manipulate.</param>
        /// <param name="clearDirty">Indicates if we should reset the IsDirty flag.</param>
        /// <param name="saveAllProperties">Indicates whether all properties should be saved.</param>
        void IPersistPropertyBag.Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            var callToken = PipelineTraceManager.TraceIn();

            try
            {
                IDictionary<string, object> props = GetConfigurableProperties();

                if (props != null && props.Count > 0)
                {
                    using (DisposableObjectWrapper dispObjectWrapper = new DisposableObjectWrapper(propertyBag, props))
                    {
                        foreach (KeyValuePair<string, object> prop in props)
                        {
                            // Write the configuration property values into a property bag provided.
                            PropertyHelper.WritePropertyBag(propertyBag, prop.Key, prop.Value);
                        }

                        // Invoke the user implementation of the Save method in case there are any custom properties require storing.
                        Save(propertyBag, clearDirty, saveAllProperties);
                    }
                }

                PipelineTraceManager.TraceOut(callToken);
            }
            catch (Exception e)
            {
                // Put component name as a source in this exception so that the error message could reflect this.
                e.Source = this.Name;

                // Trace the exception details.
                PipelineTraceManager.TraceError(e, EnableDetailedExceptions, callToken);

                // Re-throw the exception so that it can be handled by the caller.
                throw;
            }
        }

        /// <summary>
        /// Saves properties to the property bag. This method can be overridden by user code to save additional properties
        /// which cannot be reflected through the declarative attributes.
        /// </summary>
        /// <param name="propertyBag">The property bag to manipulate.</param>
        /// <param name="clearDirty">Indicates if we should reset the IsDirty flag.</param>
        /// <param name="saveAllProperties">Indicates whether all properties should be saved.</param>
        public virtual void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
        }
        #endregion

        #region IComponentUI implementation
        /// <summary>
        /// Returns the pipeline component's icon to be displayed in the BizTalk Pipeline Designer.
        /// </summary>
        [Browsable(false)]
        public IntPtr Icon
        {
            get
            {
                try
                {
                    if (IntPtr.Zero == this.componentIcon)
                    {
                        lock (this.instanceLock)
                        {
                            if (IntPtr.Zero == this.componentIcon)
                            {
                                BtsComponentToolboxIconAttribute toolboxIconAttr = FrameworkUtility.GetDeclarativeAttribute<BtsComponentToolboxIconAttribute>(this);

                                if (toolboxIconAttr != null)
                                {
                                    object iconObject = this.resourceManager.GetObject(toolboxIconAttr.IconResourceName);

                                    if (iconObject != null)
                                    {
                                        this.componentIcon = ((Bitmap)iconObject).GetHicon();
                                    }
                                    else
                                    {
                                        PipelineTraceManager.TraceWarning(ExceptionMessages.ComponentResourceIconNotFound, toolboxIconAttr.IconResourceName);
                                    }
                                }

                                if (IntPtr.Zero == this.componentIcon)
                                {
                                    this.componentIcon = PipelineComponentResources.DefaultIcon.GetHicon();
                                }
                            }
                        }
                    }

                    return this.componentIcon;
                }
                catch (Exception ex)
                {
                    PipelineTraceManager.TraceError(ex);
                }

                return IntPtr.Zero;
            }
            set
            {
                this.componentIcon = value;
            }
        }

        /// <summary>
        /// The Validate method is called by the BizTalk Pipeline Designer during the build of a BizTalk project.
        /// </summary>
        /// <param name="projectSystem">An Object containing the configuration properties.</param>
        /// <returns>The IEnumerator enables the caller to enumerate through a collection of strings containing error messages.
        /// These error messages appear as compiler error messages. To report successful property validation, the method should return an empty enumerator.</returns>
        public virtual IEnumerator Validate(object projectSystem)
        {
            ArrayList errors = new ArrayList();

            // Validate whether the component correctly implements IBaseComponent (this requires name and description at a minimum)
            if (String.IsNullOrEmpty(Name))
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.MissingComponentName, this.GetType().FullName));
            }

            if (String.IsNullOrEmpty(Description))
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.MissingComponentDescription, this.GetType().FullName));
            }

            // Validate whether the component correctly returns its GUID
            Guid componentGuid = Guid.Empty;
            GetClassID(out componentGuid);

            if (Guid.Empty.CompareTo(componentGuid) == 0)
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.MissingComponentGuid, this.GetType().FullName));
            }

            return errors.Count > 0 ? errors.GetEnumerator() : null;
        }
        #endregion

        #region PipelineComponentBase members
        /// <summary>
        /// Returns the pipeline context that us available for this instance of the component.
        /// </summary>
        protected abstract IPipelineContext PipelineContext { get; }

        /// <summary>
        /// Returns a collection of configuration properties supported by this component.
        /// </summary>
        /// <returns>A collection containing key/value pairs where the key represents a property name and the value is the current property value.</returns>
        protected virtual IDictionary<string, object> GetConfigurableProperties()
        {
            Type thisType = this.GetType();
            PropertyInfo[] publicProperties = thisType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            if (publicProperties != null && publicProperties.Length > 0)
            {
                object[] browsableAttrList = null;
                IDictionary<string, object> propList = new Dictionary<string, object>(publicProperties.Length);

                foreach (PropertyInfo prop in publicProperties)
                {
                    browsableAttrList = prop.GetCustomAttributes(typeof(BrowsableAttribute), true);

                    if (browsableAttrList != null && browsableAttrList.Length > 0)
                    {
                        BrowsableAttribute browsableAttr = browsableAttrList[0] as BrowsableAttribute;

                        if (browsableAttr != null && browsableAttr.Browsable)
                        {
                            propList[prop.Name] = prop.GetValue(this, null);
                        }
                    }

                    browsableAttrList = null;
                }

                return propList.Count > 0 ? propList : null;
            }
            else return null;
        }

        /// <summary>
        /// Modifies the configuration properties of the pipeline component using the specified collection of properties and their values.
        /// </summary>
        /// <param name="props">The collection of properties to be modified along with their new values.</param>
        protected virtual void ApplyConfigurableProperties(IDictionary<string, object> props)
        {
            if (props != null && props.Count > 0)
            {
                Type thisType = this.GetType();
                PropertyInfo[] publicProperties = thisType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                if (publicProperties != null && publicProperties.Length > 0)
                {
                    foreach (PropertyInfo prop in publicProperties)
                    {
                        if (props.ContainsKey(prop.Name))
                        {
                            prop.SetValue(this, props[prop.Name], null);
                        }
                    }
                }
            }
        }
        #endregion

        #region Core BAM activity tracking logic
        /// <summary>
        /// Returns the BAM activity instance that is used for benchmarking.
        /// </summary>
        protected ActivityBase BenchmarkActivity
        {
            get
            {
                return this.benchmarkActivity;
            }
        }

        /// <summary>
        /// Returns an instance of the object implementing <see cref="IActivityTrackingEventStream"/> that provides interface into BAM activity tracking event stream.
        /// </summary>
        protected IActivityTrackingEventStream PipelineEventStream
        {
            get
            {
                if (null == this.pipelineEventStream)
                {
                    lock (this.instanceLock)
                    {
                        if (null == this.pipelineEventStream)
                        {
                            this.pipelineEventStream = ActivityTrackingEventStreamFactory.CreateEventStream(PipelineContext);
                        }
                    }
                }
                return this.pipelineEventStream;
            }
        }

        /// <summary>
        /// Begins a BAM activity that is used for benchmarking.
        /// </summary>
        /// <param name="pContext">A reference to <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> object that contains a references to the messaging event stream.</param>
        /// <param name="activityID">The unique ID of the benchmarking activity.</param>
        /// <returns>The activity instance that can be used further in the code.</returns>
        protected ActivityBase BeginBenchmarkActivity(IPipelineContext pContext, string activityID)
        {
            Guard.ArgumentNotNull(pContext, "pContext");
            Guard.ArgumentNotNullOrEmptyString(activityID, "activityID");

            if (null == this.benchmarkActivity)
            {
                this.benchmarkActivity = new PipelineComponentBenchmarkActivity(activityID);

                this.benchmarkActivity.ComponentName = this.Name;
                this.benchmarkActivity.PipelineID = pContext.PipelineID.ToString();
                this.benchmarkActivity.StageID = pContext.StageID.ToString();
                this.benchmarkActivity.MachineName = MachineName;
                this.benchmarkActivity.WindowsIdentityName = WindowsIdentityName;

                PipelineEventStream.BeginActivity(this.benchmarkActivity);
            }

            return this.benchmarkActivity;
        }
        #endregion
    } 
}
