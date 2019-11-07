using System;
using System.Reflection;

namespace MasaSam.Data.Mapping
{
    /// <summary>
    /// Class that represents mapping between two members.
    /// </summary>
    public sealed class MapItem
    {
        #region Fields

        private readonly object mutex = new object();
        private string key;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes new instance of the <see cref="MapItem"/> class.
        /// </summary>
        /// <param name="source">The <see cref="MappingItem"/> representing source member.</param>
        /// <param name="destination">The <see cref="MappingItem"/> representing destination member.</param>
        /// <param name="map">The <see cref="Map"/> this item belongs to.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="source"/>, <paramref name="destination"/> or <paramref name="map"/> is <c>null</c>.</exception>
        internal MapItem(Item source, Item destination, Map map)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (destination == null)
                throw new ArgumentNullException("destination");

            if (map == null)
                throw new ArgumentNullException("map");

            this.Source = source;
            this.Destination = destination;
            this.IsIgnored = false;
            this.IsComplex = false;
            this.Map = map;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets <see cref="Item"/> representing source member.
        /// </summary>
        public Item Source { get; private set; }

        /// <summary>
        /// Gets <see cref="Item"/> representing destination member.
        /// </summary>
        public Item Destination { get; private set; }

        /// <summary>
        /// Gets <see cref="Map"/> where this
        /// mapping belongs to. Returns <c>null</c>, if removed
        /// from map.
        /// </summary>
        public IMap Map { get; private set; }

        /// <summary>
        /// Gets whether or not mapping is ignored.
        /// </summary>
        public bool IsIgnored { get; internal set; }

        /// <summary>
        /// Gets or sets whether or not complex conversion
        /// should be performed.
        /// </summary>
        internal bool IsComplex { get; set; }

        /// <summary>
        /// Gets the value to use as dictionary key.
        /// </summary>
        internal string Key
        {
            get
            {
                if (key == null)
                {
                    key = String.Concat(Source.Type.FullName, ";", Destination.Type.FullName);
                }

                return key;
            }
        }

        #endregion

        #region Item class

        /// <summary>
        /// Class that represents member in <see cref="MapItem"/>.
        /// </summary>
        public sealed class Item
        {
            #region Fields

            private MemberType? memberType = null;
            private Type type = null;

            #endregion

            #region Ctor

            /// <summary>
            /// Initializes new instance of the <see cref="MapItem.Item"/> class.
            /// </summary>
            /// <param name="memberInfo">The <see cref="MemberInfo"/> representing the mapped member.</param>
            /// <param name="isSource"><c>true</c> if represents mapping of the source member; <c>false</c> otherwise.</param>
            /// <exception cref="ArgumentNullException">If <paramref name="memberInfo"/> is <c>null</c>.</exception>
            internal Item(MemberInfo memberInfo, bool isSource)
            {
                if (memberInfo == null)
                    throw new ArgumentNullException("memberInfo");

                this.Name = memberInfo.Name;
                this.IsSourceMember = isSource;
                this.MemberInfo = memberInfo;
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets the name of the mapped member.
            /// </summary>
            public string Name { get; private set; }

            /// <summary>
            /// Gets the <see cref="MemberType"/> of the mapped member.
            /// </summary>
            /// <exception cref="InvalidOperationException">If <see cref="MemberInfo"/> does not represent property or method.</exception>
            public MemberType Member
            {
                get
                {
                    //// determine the member type
                    if (this.memberType == null)
                    {
                        this.memberType = DetermineMemberType(MemberInfo);
                    }

                    return this.memberType.Value;
                }
            }

            /// <summary>
            /// Gets the <see cref="Type"/> of the mapped member.
            /// </summary>
            public Type Type
            {
                get
                {
                    //// determine the type
                    if (this.type == null)
                    {
                        this.type = DetermineType(MemberInfo, Member, IsSourceMember);
                    }

                    return this.type;
                }
            }

            /// <summary>
            /// Gets whether or not this item represents the
            /// source member of the mapping.
            /// </summary>
            public bool IsSourceMember { get; private set; }

            /// <summary>
            /// Gets whether or not this item represents the
            /// destination member of the mapping.
            /// </summary>
            public bool IsDestinationMember
            {
                get { return !IsSourceMember; }
            }

            /// <summary>
            /// Gets the <see cref="MemberInfo"/> of the mapped member.
            /// </summary>
            /// <remarks>
            /// Can be casted to <see cref="PropertyInfo"/>, if <see cref="Member"/> is <see cref="MemberType.Property"/>.
            /// -or-
            /// Can be casted to <see cref="MethodInfo"/>, if <see cref="Member"/> is <see cref="MemberType.Method"/>.
            /// </remarks>
            public MemberInfo MemberInfo { get; private set; }

            #endregion

            #region Methods

            /// <summary>
            /// Determines the <see cref="MemberType"/> of provider <see cref="MemberInfo"/>.
            /// </summary>
            /// <param name="info">A <see cref="MemberInfo"/> representing either property or method.</param>
            /// <returns>A <see cref="MemberType"/> of info.</returns>
            /// <exception cref="InvalidOperationException">If <paramref name="info"/> does not represent property or method.</exception>
            private static MemberType DetermineMemberType(MemberInfo info)
            {
                PropertyInfo property = info as PropertyInfo;

                if (property != null)
                {
                    return MemberType.Property;
                }

                MethodInfo method = info as MethodInfo;

                if (method != null)
                {
                    return MemberType.Method;
                }

                throw new InvalidOperationException(String.Format("Mapped member, {0}, must be either property or method.", info.Name));
            }

            /// <summary>
            /// Determines type of the mapped member.
            /// </summary>
            /// <param name="member">The <see cref="MemberInfo"/> representing either property or method.</param>
            /// <param name="memberType">The <see cref="MemberType"/> of the member.</param>
            /// <param name="isSource"><c>true</c> if is source member; <c>false</c> otherwise.</param>
            /// <returns>A determined type of the mapped member.</returns>
            /// <exception cref="InvalidOperationException">
            /// If source member is method and returns void.
            /// -or-
            /// If source member is method and is not parameterless.
            /// -or-
            /// If destination member is method and parameter count is not 1.
            /// </exception>
            private static Type DetermineType(MemberInfo member, MemberType memberType, bool isSource)
            {
                Type type;

                if (memberType == MemberType.Property)
                {
                    type = ((PropertyInfo)member).PropertyType;
                }
                else
                {
                    MethodInfo method = (MethodInfo)member;

                    var parameters = method.GetParameters();

                    if (isSource)
                    {
                        type = method.ReturnType;

                        //// method to get value should not return void
                        if (type.Equals(typeof(void)))
                            throw new InvalidOperationException("Source method returns void.");

                        //// method to get value should not have parameters
                        if (parameters.Length > 0)
                            throw new InvalidOperationException("Expected get method is not parameterless.");
                    }
                    else
                    {
                        //// method to set value should have 1 and only 1 parameter
                        if (parameters.Length != 1)
                            throw new InvalidOperationException("Expected parameter count of set method is not 1.");

                        type = parameters[0].ParameterType;
                    }
                }

                return type;
            }

            #endregion
        }

        #endregion

        #region MemberType enum

        /// <summary>
        /// Supported members.
        /// </summary>
        public enum MemberType
        {
            /// <summary>
            /// Properties
            /// </summary>
            Property,

            /// <summary>
            /// Methods
            /// </summary>
            Method
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets <see cref="Map"/> to null when removed from map.
        /// </summary>
        internal void Remove()
        {
            this.Map = null;
        }

        #endregion
    }
}
