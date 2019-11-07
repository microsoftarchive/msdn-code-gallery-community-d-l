using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MasaSam.Data.Mapping
{
    /// <summary>
    /// Class to store and modify mappings between source and destination type
    /// </summary>
    internal sealed class Map : IMap
    {
        #region Fields

        private Type sourceType;
        private Type destinationType;
        private List<MapItem> items;
        private Dictionary<string, Map> subMaps;

        #endregion

        #region Ctor

        internal Map(Type sourceType, Type destinationType)
        {
            if (sourceType == null)
                throw new ArgumentNullException("sourceType");

            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            this.sourceType = sourceType;
            this.destinationType = destinationType;
            this.items = new List<MapItem>();
            this.subMaps = new Dictionary<string, Map>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets <see cref="IEnumerable{Mapping}"/> to enumerate
        /// all the mappings in current setup.
        /// </summary>
        public IEnumerable<MapItem> Items
        {
            get { return this.items; }
        }

        #endregion

        #region Simple mapping

        /// <summary>
        /// Create simple mapping between members in source and destination type.
        /// </summary>
        /// <typeparam name="TSourceMember"></typeparam>
        /// <typeparam name="TDestinationMember"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public IMap Add<TSourceMember, TDestinationMember>(TSourceMember source, TDestinationMember destination)
            where TSourceMember : MemberInfo
            where TDestinationMember : MemberInfo
        {
            return AddItem<TSourceMember, TDestinationMember>(source, destination, false);
        }

        /// <summary>
        /// Create simple mapping between members in source and destination type.
        /// </summary>
        /// <typeparam name="TSource">The type of an source object.</typeparam>
        /// <typeparam name="TDestination">The type of an destination object.</typeparam>
        /// <param name="sourceMemberName">The name of the source member.</param>
        /// <param name="destinationMemberName">The name of the destination member.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        /// <exception cref="ArgumentNullException">If <see cref="sourceMemberName"/> or <see cref="destinationMemberName"/> is null, empty or whitespace.</exception>
        /// <exception cref="ArgumentException">If member name is not name of the property or method.</exception>
        public IMap Add<TSource, TDestination>(string sourceMemberName, string destinationMemberName) where TDestination : new()
        {
            Type sourceType = typeof(TSource);
            Type destinationType = typeof(TDestination);

            return Add(sourceMemberName, sourceType, destinationMemberName, destinationType);
        }

        /// <summary>
        /// Create simple mapping between members in source and destination type.
        /// </summary>
        /// <param name="sourceMemberName">The name of the source member.</param>
        /// <param name="sourceType">The type of an source object.</param>
        /// <param name="destinationMemberName">The name of the destination member.</param>
        /// <param name="destinationType">The type of an destination object.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <see cref="sourceMemberName"/> or <see cref="destinationMemberName"/> is null, empty or whitespace.
        /// -or-
        /// If <paramref name="sourceType"/> or <paramref name="destinationType"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">If member name is not name of the property or method.</exception>
        public IMap Add(string sourceMemberName, Type sourceType, string destinationMemberName, Type destinationType)
        {
            return AddItem(sourceMemberName, sourceType, destinationMemberName, destinationType, false);
        }

        /// <summary>
        /// Create simple mapping between members in source and destination type.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="sourceMember"></param>
        /// <param name="destinationMember"></param>
        /// <returns></returns>
        public IMap Add<TSource, TDestination>(Expression<Func<TSource, object>> sourceMember, Expression<Func<TDestination, object>> destinationMember) where TDestination : new()
        {
            string sourceMemberName = ExtractMemberName(sourceMember);
            string destinationMemberName = ExtractMemberName(destinationMember);

            return Add<TSource, TDestination>(sourceMemberName, destinationMemberName);
        }

        #endregion

        #region Complex mapping

        /// <summary>
        /// Creates complex mapping between members in source and destination type.
        /// </summary>
        /// <typeparam name="TSourceMember">The type of the source <see cref="MemberInfo"/>.</typeparam>
        /// <typeparam name="TDestinationMember">The type of the destination <see cref="MemberInfo"/>.</typeparam>
        /// <param name="source">A instance of <typeparamref name="TSourceMember"/>.</param>
        /// <param name="destination">A instance of <typeparamref name="TDestinationMember"/>.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        public IMap Complex<TSourceMember, TDestinationMember>(TSourceMember source, TDestinationMember destination)
            where TSourceMember : MemberInfo
            where TDestinationMember : MemberInfo
        {
            return AddItem<TSourceMember, TDestinationMember>(source, destination, true);
        }

        /// <summary>
        /// Creates complex mapping between members in source and destination type.
        /// </summary>
        /// <typeparam name="TSource">The type of the source instance.</typeparam>
        /// <typeparam name="TDestination">The type of the destination instance.</typeparam>
        /// <param name="sourceMemberName">The source member name.</param>
        /// <param name="destinationMemberName">The destination member name.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="sourceMemberName"/> or <see cref="destinationMemberName"/> is null, empty or whitespace.
        /// </exception>
        public IMap Complex<TSource, TDestination>(string sourceMemberName, string destinationMemberName) where TDestination : new()
        {
            Type sourceType = typeof(TSource);
            Type destinationType = typeof(TDestination);

            return Complex(sourceMemberName, sourceType, destinationMemberName, destinationType);
        }

        /// <summary>
        /// Create complex mapping between members in source and destination type.
        /// </summary>
        /// <param name="sourceMemberName">The source member name.</param>
        /// <param name="sourceType">The source type.</param>
        /// <param name="destinationMemberName">The destination member name.</param>
        /// <param name="destinationType">The destination type.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="sourceMemberName"/> or <see cref="destinationMemberName"/> is null, empty or whitespace.
        /// -or-
        /// If <paramref name="sourceType"/> or <paramref name="destinationType"/> is <c>null</c>.
        /// </exception>
        public IMap Complex(string sourceMemberName, Type sourceType, string destinationMemberName, Type destinationType)
        {
            return AddItem(sourceMemberName, sourceType, destinationMemberName, destinationType, true);
        }

        /// <summary>
        /// Create complex mapping between members in source and destination type.
        /// </summary>
        /// <typeparam name="TSource">The type of the source instance.</typeparam>
        /// <typeparam name="TDestination">The type of the destination instance.</typeparam>
        /// <param name="sourceMember">The expression to select source member.</param>
        /// <param name="destinationMember">The expression to select destination member.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="sourceMember"/> or <paramref name="destinationMember"/> is <c>null</c>.
        /// </exception>
        public IMap Complex<TSource, TDestination>(Expression<Func<TSource, object>> sourceMember, Expression<Func<TDestination, object>> destinationMember) where TDestination : new()
        {
            string sourceMemberName = ExtractMemberName(sourceMember);
            string destinationMemberName = ExtractMemberName(destinationMember);

            return Complex<TSource, TDestination>(sourceMemberName, destinationMemberName);
        }

        #endregion

        #region Ignorance

        /// <summary>
        /// Marks the mappings where provided member is either source or destination as ignored. If you want to remove mapping completely,
        /// use <see cref="Remove"/> method.
        /// </summary>
        /// <typeparam name="TMember">The type of an member to ignore; either <see cref="PropertyInfo"/> or <see cref="MethodInfo"/>.</typeparam>
        /// <param name="member">A source or destination member to ignore.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="member"/> is <c>null</c>.</exception>
        /// <exception cref="NotSupportedException">If <paramref name="member"/> does not represent <see cref="PropertyInfo"/> or <see cref="MethodInfo"/>.</exception>
        public IMap Ignore<TMember>(TMember member) where TMember : MemberInfo
        {
            if (member == null)
                throw new ArgumentNullException("member");

            if (member is PropertyInfo || member is MethodInfo)
            {
                return Ignore(member.Name);
            }
            else
            {
                throw new NotSupportedException(String.Format("Mapping of {0} is not supported.", member.GetType().FullName));
            }
        }

        /// <summary>
        /// Marks the mapping where provided source or destination member name is equal to
        /// provided member name as ignored. If you want to remove mapping completely, 
        /// use <see cref="Remove"/> method.
        /// </summary>
        /// <param name="memberName">A name of the source or destination member to mark as ignored.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="memberName"/> is <c>null</c>, empty string or whitespace.</exception>
        public IMap Ignore(string memberName)
        {
            if (String.IsNullOrWhiteSpace(memberName))
                throw new ArgumentNullException("memberName");

            var mapping = Items.Where(x => x.Source.Name == memberName || x.Destination.Name == memberName)
                               .FirstOrDefault();

            if (mapping != null)
            {
                mapping.IsIgnored = true;
            }

            return this;
        }

        /// <summary>
        /// Marks the mapping as ignored. If you want to remove mapping completely,
        /// use <see cref="Remove"/> method.
        /// </summary>
        /// <param name="item">A mapping to mark ignored.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="item"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="item"/> is not from this setup instance.</exception>
        public IMap Ignore(MapItem item)
        {
            if (item == null)
                throw new ArgumentNullException("mapping");

            if (item.Map != this)
                throw new ArgumentException("mapping is not from this setup.", "mapping");

            item.IsIgnored = true;

            return this;
        }

        /// <summary>
        /// Marks the mapping as ignored. If you want to remove mapping completely,
        /// use <see cref="Remove"/> method.
        /// </summary>
        /// <typeparam name="T">The type of the source or destination.</typeparam>
        /// <param name="expression">The member selector expression.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        public IMap Ignore<T>(Expression<Func<T, object>> expression)
        {
            string name = ExtractMemberName(expression);

            return Ignore(name);
        }

        /// <summary>
        /// Restores previously ignored member.
        /// </summary>
        /// <typeparam name="TMember">The type of an member to ignore; either <see cref="PropertyInfo"/> or <see cref="MethodInfo"/>.</typeparam>
        /// <param name="member">A source or destination member to ignore.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        public IMap Unignore<TMember>(TMember member) where TMember : MemberInfo
        {
            if (member == null)
                throw new ArgumentNullException("member");

            if (member is PropertyInfo || member is MethodInfo)
            {
                return Unignore(member.Name);
            }
            else
            {
                throw new NotSupportedException(String.Format("Mapping of {0} is not supported.", member.GetType().FullName));
            }
        }

        /// <summary>
        /// Restores previously ignored member.
        /// </summary>
        /// <param name="memberName">The name of the member.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        public IMap Unignore(string memberName)
        {
            if (String.IsNullOrWhiteSpace(memberName))
                throw new ArgumentNullException("memberName");

            var mapping = Items.Where(x => x.Source.Name == memberName || x.Destination.Name == memberName)
                               .FirstOrDefault();

            if (mapping != null)
            {
                mapping.IsIgnored = false;
            }

            return this;
        }

        /// <summary>
        /// Restores previously ignored member.
        /// </summary>
        /// <param name="mapping">The <see cref="MapItem"/> to unignore.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        public IMap Unignore(MapItem mapping)
        {
            if (mapping == null)
                throw new ArgumentNullException("mapping");

            if (mapping.Map != this)
                throw new ArgumentException("mapping is not from this setup.", "mapping");

            mapping.IsIgnored = false;

            return this;
        }

        /// <summary>
        /// Restores previously ignored member.
        /// </summary>
        /// <typeparam name="T">The type of the source or destination.</typeparam>
        /// <param name="expression">The member selector expression.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        public IMap Unignore<T>(Expression<Func<T, object>> expression)
        {
            string memberName = ExtractMemberName(expression);

            return Unignore(memberName);
        }

        /// <summary>
        /// Unignores all ignored mappings.
        /// </summary>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        public IMap UnignoreAll()
        {
            var ignored = Items.Where(x => x.IsIgnored);

            foreach (var item in ignored)
            {
                item.IsIgnored = false;
            }

            return this;
        }

        #endregion

        #region Removing

        /// <summary>
        /// Clears map from all the mappings.
        /// </summary>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        public IMap Clear()
        {
            this.items.Clear();
            this.subMaps.Clear();

            return this;
        }

        /// <summary>
        /// Removes provided item from the map.
        /// </summary>
        /// <param name="item">A mapping to remove.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="item"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="item"/> is not from this setup instance.</exception>
        public IMap Remove(MapItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (item.Map != this)
                throw new ArgumentException("MapItem is not from this setup.", "item");

            int index = this.items.IndexOf(item);

            if (index >= 0)
            {
                this.items.RemoveAt(index);
                item.Remove();
            }

            return this;
        }

        /// <summary>
        /// Removes mapping by the provided source or destination member name.
        /// </summary>
        /// <param name="memberName">A name of the source or destination member to remove.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="memberName"/> is <c>null</c>, empty string or whitespace.</exception>
        public IMap Remove(string memberName)
        {
            if (String.IsNullOrWhiteSpace(memberName))
                throw new ArgumentNullException("memberName");

            for (int i = items.Count - 1; i >= 0; i--)
            {
                MapItem m = items[i];

                if (m.Source.Name == memberName ||
                    m.Destination.Name == memberName)
                {
                    //// if item is complex, remove the sub map
                    if (m.IsComplex)
                    {
                        subMaps.Remove(m.Key);
                    }

                    items.RemoveAt(i);
                    m.Remove();
                }
            }

            return this;
        }

        /// <summary>
        /// Removes mapping by the provided source or destination member
        /// </summary>
        /// <typeparam name="TMember">The type of an member to ignore; either <see cref="PropertyInfo"/> or <see cref="MethodInfo"/>.</typeparam>
        /// <param name="member">A source or destination member to remove.</param>
        /// <returns>A changed <see cref="Map"/> instance.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="member"/> is <c>null</c>.</exception>
        /// <exception cref="NotSupportedException">If <paramref name="member"/> does not represent <see cref="PropertyInfo"/> or <see cref="MethodInfo"/>.</exception>
        public IMap Remove<TMember>(TMember member) where TMember : MemberInfo
        {
            if (member == null)
                throw new ArgumentNullException("member");

            if (member is PropertyInfo || member is MethodInfo)
            {
                return Remove(member.Name);
            }
            else
            {
                throw new NotSupportedException(String.Format("Mapping of {0} is not supported.", member.GetType().FullName));
            }
        }

        /// <summary>
        /// Remove mapping by provided selector expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IMap Remove<T>(Expression<Func<T, object>> expression)
        {
            string name = ExtractMemberName(expression);

            return Remove(name);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets sub map for the provided complex map item.
        /// </summary>
        /// <param name="item">The complex map item.</param>
        /// <returns>A sub map between complex types.</returns>
        internal Map GetSubMap(MapItem item)
        {
            Debug.Assert(item != null);
            Debug.Assert(item.Map == this);
            Debug.Assert(item.IsComplex);

            Map subMap;

            if (subMaps.TryGetValue(item.Key, out subMap))
            {
                return subMap;
            }

            return null;
        }

        /// <summary>
        /// Extracts member name from the expression.
        /// </summary>
        /// <returns>A name of the member or empty string.</returns>
        private static string ExtractMemberName<T>(Expression<Func<T, object>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            var unaryExpression = expression.Body as UnaryExpression;

            MemberExpression memberExpression = null;

            if (unaryExpression != null)
            {
                var methodCall = unaryExpression.Operand as MethodCallExpression;

                if (methodCall != null)
                {
                    return methodCall.Method.Name;
                }
                else
                {
                    memberExpression = unaryExpression.Operand as MemberExpression;

                    if (memberExpression != null)
                    {
                        return memberExpression.Member.Name;
                    }
                }
            }

            memberExpression = expression.Body as MemberExpression;

            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }

            return String.Empty;
        }

        /// <summary>
        /// Add simple or complex item that maps source member to destination member.
        /// </summary>
        private Map AddItem<TSourceMember, TDestinationMember>(TSourceMember source, TDestinationMember destination, bool complex)
            where TSourceMember : MemberInfo
            where TDestinationMember : MemberInfo
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (destination == null)
                throw new ArgumentNullException("destination");

            var sourceItem = new MapItem.Item(source, true);
            var destinationItem = new MapItem.Item(destination, false);

            MapItem mapping = new MapItem(sourceItem, destinationItem, this);
            this.items.Add(mapping);

            if (complex)
            {
                Map subMap = MapResolver.Resolve(sourceItem.Type, destinationItem.Type);
                
                mapping.IsComplex = true;

                subMaps.Add(mapping.Key, subMap);
            }

            return this;
        }

        /// <summary>
        /// Add simple or complex item that maps source member to destination member.
        /// </summary>
        private Map AddItem(string sourceMemberName, Type sourceType, string destinationMemberName, Type destinationType, bool complex)
        {
            if (String.IsNullOrWhiteSpace(sourceMemberName))
                throw new ArgumentNullException("sourceMemberName");

            if (String.IsNullOrWhiteSpace(destinationMemberName))
                throw new ArgumentNullException("destinationMemberName");

            if (sourceType == null)
                throw new ArgumentNullException("sourceType");

            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            MemberInfo sm = sourceType.GetMember(sourceMemberName).FirstOrDefault();
            MemberInfo dm = destinationType.GetMember(destinationMemberName).FirstOrDefault();
            MapItem.Item sourceItem = null;
            MapItem.Item destinationItem = null;
            MapItem mapping = null;

            if (sm != null && dm != null)
            {
                sourceItem = new MapItem.Item(sm, true);
                destinationItem = new MapItem.Item(dm, false);
                mapping = new MapItem(sourceItem, destinationItem, this);

                this.items.Add(mapping);
            }
            
            if (mapping != null)
            {
                if (complex)
                {
                    Map subMap = MapResolver.Resolve(sourceItem.Type, destinationItem.Type);

                    mapping.IsComplex = true;

                    subMaps.Add(mapping.Key, subMap);
                }
            }

            return this;
        }

        #endregion
    }
}
