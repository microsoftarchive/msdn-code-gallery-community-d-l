using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CSharpDynamicUnitTest
{
    public class CustomizedDynamicObject : DynamicObject
    {
        /// <summary>
        /// Allowed simple types to be called directly with "ToString()" in the "GetRealString".
        /// </summary>
        private readonly static Type[] _allowedTypes = new Type[]
            {
            typeof(int),typeof(uint),typeof(long),typeof(ulong),typeof(float),typeof(double),typeof(decimal)
            };
        /// <summary>
        /// We use a Name-Value collection so that we can mock an object in javascript.
        /// </summary>
        private IDictionary<string, dynamic> _propertyValuesCollection = new Dictionary<string, dynamic>();

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _propertyValuesCollection.Keys;
        }

        #region Try to get/set value by key
        private bool TryGetValueByKey(string keyName, out object result)
        {
            bool isSuccess = true;

            if (!_propertyValuesCollection.ContainsKey(keyName))
            {
                result = null;
                isSuccess = false;
            }
            else
            {
                result = _propertyValuesCollection[keyName];
            }

            return isSuccess;
        }

        private bool TrySetValueByKey(string keyName, object result)
        {
            _propertyValuesCollection[keyName] = result;
            return true;
        }
        #endregion


        /// <summary>
        /// This method means you can exclipitly convert the dynamic value to a string by assigning it.
        /// Notice that this only supports converted to string.
        /// </summary>
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type != typeof(string))
            {
                result = null;
                return false;
            }
            result = ToString();
            return true;
        }
        /// <summary>
        /// Fetch the existing member.
        /// </summary>
        /// <param name="binder">
        /// The contenxt binder where we can get the inputted properties names.
        /// </param>
        /// <param name="result">
        /// The result as a return type for the assigned property value.
        /// </param>
        /// <returns>
        /// true: Successfully assigned.
        /// false: exception will be thrown out.
        /// </returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return TryGetValueByKey(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return TrySetValueByKey(binder.Name, value);
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            return TryGetValueByKey(indexes[0].ToString(), out result);
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            return TrySetValueByKey(indexes[0].ToString(), value);
        }

        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            return _propertyValuesCollection.Remove(binder.Name);
        }

        public override bool TryDeleteIndex(DeleteIndexBinder binder, object[] indexes)
        {
            return _propertyValuesCollection.Remove(indexes[0].ToString());
        }

        #region To override the ToString method to return a js object formation
        /// <summary>
        /// This method will check whether the current looped value is of simple type, an IEnumerable value or something else.
        /// 1) For simple types such as string, numeric types, directly call ToString.
        /// 2) For any array type that implements IEnumerable, we can just use "[]" to output each value. Considering that each value in the array may vary, so a recursive is a MUST here.
        /// </summary>
        private string GetRealString(object value)
        {
            if (value.GetType() == typeof(string))
            {
                return "'" + value.ToString() + "'";
            }
            else if (Array.IndexOf(_allowedTypes, value.GetType()) != -1)
            {
                return value.ToString();
            }
            IEnumerable p = value as IEnumerable;
            if (p != null)
            {
                StringBuilder sbu = new StringBuilder();
                IEnumerator accessor = p.GetEnumerator();
                sbu.Append("[");

                if (accessor.MoveNext())
                {
                    sbu.Append(GetRealString(accessor.Current));
                }
                while (accessor.MoveNext())
                {
                    sbu.Append(",");
                    sbu.Append(GetRealString(accessor.Current));
                }

                sbu.Append("]");
                return sbu.ToString();
            }
            return value.ToString();
        }
        /// <summary>
        /// This method will output a string value as a simple json formation.
        /// Notice the algorithm will call GetRealString, and GetRealString will call the method by exchange recursive.
        /// </summary>
        /// <returns>
        /// A simple js-based object.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sbu = new StringBuilder(_propertyValuesCollection.Count);

            sbu.Append("{");

            if (_propertyValuesCollection.Count > 0)
            {
                IEnumerator<KeyValuePair<string, object>> pointer = _propertyValuesCollection.GetEnumerator();

                if (pointer.MoveNext())
                {
                    sbu.Append(pointer.Current.Key + ":" + GetRealString(pointer.Current.Value));
                }

                while (pointer.MoveNext())
                {
                    sbu.Append(",");
                    sbu.Append(pointer.Current.Key + ":" + GetRealString(pointer.Current.Value));
                }

            }

            sbu.Append("}");

            return sbu.ToString();
        }
        #endregion
    }
}
