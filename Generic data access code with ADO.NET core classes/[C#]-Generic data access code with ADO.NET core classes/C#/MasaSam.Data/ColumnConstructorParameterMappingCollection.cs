using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MasaSam.Data
{
    /// <summary>
    /// Collection of <see cref="ColumnConstructorParameterMapping"/> instances for the specified <see cref="ConstructorInfo"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ColumnConstructorParameterMappingCollection<T> : ICollection<ColumnConstructorParameterMapping> where T : class
    {
        #region Fields

        private readonly Dictionary<int, ColumnConstructorParameterMapping> mappings;
        private readonly ConstructorInfo ctor;
        private readonly ParameterInfo[] parameters;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes new instance of the class.
        /// </summary>
        /// <param name="ctorParameterTypes">Array of constructor arguments types.</param>
        public ColumnConstructorParameterMappingCollection(Type[] ctorParameterTypes)
        {
            Type[] types = ctorParameterTypes;

            if (types == null || types.Length == 0)
            {
                types = Type.EmptyTypes;
            }

            mappings = new Dictionary<int, ColumnConstructorParameterMapping>();
            ctor = typeof(T).GetConstructor(types);

            if (ctor == null)
                throw new ArgumentException(String.Format("{0} does not have ctor with provided parameter types.", typeof(T).FullName), "ctorParameterTypes");

            if (ctor.IsPrivate)
                throw new ArgumentException("Constructor of provided types is private.", "ctorParameterTypes");

            this.parameters = ctor.GetParameters();
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets whether or not constructor has parameters.
        /// </summary>
        public bool HasParameters
        {
            get { return Count > 0; }
        }

        /// <summary>
        /// Gets the <see cref="ConstructorInfo"/>.
        /// </summary>
        public ConstructorInfo Constructor
        {
            get { return ctor; }
        }

        /// <summary>
        /// Gets a enumerable of <see cref="ParameterInfo"/> of constructor parameters.
        /// </summary>
        public IEnumerable<ParameterInfo> Parameters
        {
            get { return parameters; }
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Add mapping between database column and constructor argument.
        /// </summary>
        /// <param name="columnName">The name of the column.</param>
        /// <param name="position">The position of the argument.</param>
        /// <param name="canBeNull"><c>true</c> if <c>null</c> can be passed; <c>false</c> otherwise.</param>
        /// <returns>A added <see cref="ColumnConstructorParameterMapping"/> instance.</returns>
        public ColumnConstructorParameterMapping Add(string columnName, int position, bool canBeNull = false)
        {
            var parameter = parameters[position];

            return Add(columnName, parameter, canBeNull);
        }

        /// <summary>
        /// Add mapping between database column and constructor argument.
        /// </summary>
        /// <param name="columnName">The name of the column.</param>
        /// <param name="parameter">The <see cref="ParameterInfo"/> to create mappings.</param>
        /// <param name="canBeNull"><c>true</c> if <c>null</c> can be passed; <c>false</c> otherwise.</param>
        /// <returns>A added <see cref="ColumnConstructorParameterMapping"/> instance.</returns>
        public ColumnConstructorParameterMapping Add(string columnName, ParameterInfo parameter, bool canBeNull = false)
        {
            if (String.IsNullOrWhiteSpace(columnName))
                throw new ArgumentNullException("columnName");

            if (parameter == null)
                throw new ArgumentNullException("parameter");

            if (!ContainsParameter(parameter))
                throw new ArgumentException("Not from this collection parameter.", "parameter");

            var mapping = new ColumnConstructorParameterMapping(columnName, parameter, Constructor, canBeNull);

            Add(mapping);

            return mapping;
        }

        /// <summary>
        /// Determines if contains mapping for the argument in specified position.
        /// </summary>
        /// <param name="position">The argument position.</param>
        /// <returns><c>true</c> if has mapping for the argument at position; <c>false</c> otherwise.</returns>
        public bool HasMapping(int position)
        {
            return mappings.ContainsKey(position);
        }

        private bool RemoveMappingAt(int position)
        {
            return mappings.Remove(position);
        }

        private bool ContainsParameter(ParameterInfo parameter)
        {
            foreach (var p in Parameters)
            {
                if (p == parameter)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region ICollection

        public void Add(ColumnConstructorParameterMapping mapping)
        {
            if (mapping == null)
                throw new ArgumentNullException("mapping");

            if (!HasParameters)
                throw new InvalidOperationException("Constuctor has not parameters.");

            if (IsReadOnly)
                throw new InvalidOperationException("Collection contains mappings for all parameters.");

            if (!Contains(mapping))
            {
                mappings.Add(mapping.ConstructorParameterIndex, mapping);
            }
            else
            {
                throw new ArgumentException("Collection already contains mapping.", "mapping");
            }
        }

        /// <summary>
        /// Clears all the mappings.
        /// </summary>
        public void Clear()
        {
            mappings.Clear();
        }

        /// <summary>
        /// Determines if contains mapping.
        /// </summary>
        /// <param name="mapping">The mapping to check.</param>
        /// <returns><c>true</c> if contains <paramref name="mapping"/>; <c>false</c> otherwise.</returns>
        public bool Contains(ColumnConstructorParameterMapping mapping)
        {
            if (mapping != null)
            {
                return mappings.ContainsKey(mapping.ConstructorParameterIndex);
            }

            return false;
        }

        /// <summary>
        /// Gets count of arguments in constructor.
        /// </summary>
        public int Count
        {
            get { return parameters.Length; }
        }

        /// <summary>
        /// Gets whether or not collection is read-only. The collection becomes read-only
        /// when mappings for each contructor parameter is set.
        /// </summary>
        public bool IsReadOnly
        {
            get { return mappings.Count >= Count; }
        }

        /// <summary>
        /// Removes the mapping.
        /// </summary>
        /// <param name="mapping">The mapping to remove.</param>
        /// <returns><c>true</c> if removed; <c>false</c> otherwise.</returns>
        public bool Remove(ColumnConstructorParameterMapping mapping)
        {
            if (mapping != null)
            {
                return RemoveMappingAt(mapping.ConstructorParameterIndex);
            }

            return false;
        }

        public IEnumerator<ColumnConstructorParameterMapping> GetEnumerator()
        {
            return mappings.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        void ICollection<ColumnConstructorParameterMapping>.CopyTo(ColumnConstructorParameterMapping[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
