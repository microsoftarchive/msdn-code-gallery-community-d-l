using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MasaSam.Data.Mapping
{
    #region MapResolver

    /// <summary>
    /// Class to resolve <see cref="Map"/> between source and destination objects.
    /// </summary>
    internal static class MapResolver
    {
        #region Fields

        private static readonly object mutex = new object();

        /// <summary>
        /// Cached maps between types.
        /// </summary>
        private static readonly Dictionary<string, Map> maps = new Dictionary<string, Map>();

        #endregion

        #region Resolving the mappings

        /// <summary>
        /// Resolves the mapping between <typeparamref name="TSource"/> and <typeparamref name="TDestination"/>. This method only resolves mappings between
        /// public get properties in source type and public set properties on destination type. Possible indexer properties
        /// are ignored. To add additional mappings after initial resolve use <see cref="Map.Add"/> method.
        /// </summary>
        /// <typeparam name="TSource">The type of an source object.</typeparam>
        /// <typeparam name="TDestination">The type of an destination object.</typeparam>
        /// <returns>A <see cref="Map"/> of resolved member mappings.</returns>
        public static Map Resolve<TSource, TDestination>(MapResolveOptions options = MapResolveOptions.None) where TDestination : new()
        {
            Type sourceType = typeof(TSource);
            Type destinationType = typeof(TDestination);

            return Resolve(sourceType, destinationType, options);
        }

        /// <summary>
        /// Resolves the mapping between source and destination type. This method only resolves mappings between
        /// public get properties in source type and public set properties on destination type. Possible indexer properties
        /// are ignored. To add additional mappings after initial resolve use <see cref="Map.Add"/> method.
        /// </summary>
        /// <param name="sourceType">A source type.</param>
        /// <param name="destinationType">A destination type.</param>
        /// <returns>A <see cref="Map"/> of resolved member mappings.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="sourceType"/> or <paramref name="destinationType"/> is <c>null</c>.</exception>
        public static Map Resolve(Type sourceType, Type destinationType, MapResolveOptions options = MapResolveOptions.None)
        {
            if (sourceType == null)
                throw new ArgumentNullException("sourceType");

            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            string key = sourceType.FullName + ";" + destinationType.FullName;

            Map map;

            if (!maps.TryGetValue(key, out map))
            {
                lock (mutex)
                {
                    if (!maps.TryGetValue(key, out map))
                    {
                        map = new Map(sourceType, destinationType);

                        //// get properties in source type
                        var getProperties = GetProperties(sourceType, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);

                        //// set properties in destination type
                        var setProperties = GetProperties(destinationType, BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);

                        foreach (var getProperty in getProperties)
                        {
                            //// get set property matching by name
                            var setProperty = setProperties.Where(x => x.Name.Equals(getProperty.Name))
                                                           .FirstOrDefault();

                            //// add mapping only if both properties match and
                            //// set can be written to.
                            if (setProperty != null && setProperty.CanWrite)
                            {
                                //// check if provite setter can be used
                                bool usePrivateSetter = options.HasFlag(MapResolveOptions.UsePrivateSetter);

                                if (!usePrivateSetter && !setProperty.GetSetMethod(true).IsPublic)
                                {
                                    continue;
                                }

                                //// add mapping
                                map.Add<PropertyInfo, PropertyInfo>(getProperty, setProperty);
                            }
                        }

                        maps.Add(key, map);
                    }
                }
            }

            return map;
        }

        /// <summary>
        /// Removes mapping between source and destination type.
        /// </summary>
        /// <typeparam name="TSource">The type of an source object.</typeparam>
        /// <typeparam name="TDestination">The type of an destination object.</typeparam>
        /// <returns><c>true</c> if mapping was removed; <c>false</c> otherwise.</returns>
        public static bool Remove<TSource, TDestination>()
        {
            Type sourceType = typeof(TSource);
            Type destinationType = typeof(TDestination);

            return Remove(sourceType, destinationType);
        }

        /// <summary>
        /// Removes mapping between source and destination type.
        /// </summary>
        /// <param name="sourceType">A source type.</param>
        /// <param name="destinationType">A destination type.</param>
        /// <returns><c>true</c> if mapping was removed; <c>false</c> otherwise.</returns>
        public static bool Remove(Type sourceType, Type destinationType)
        {
            if (sourceType == null)
                throw new ArgumentNullException("sourceType");

            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            string key = sourceType.FullName + ";" + destinationType.FullName;

            lock (mutex)
            {
                return maps.Remove(key);
            }
        }

        /// <summary>
        /// Gets properties of the type.
        /// </summary>
        private static IEnumerable<PropertyInfo> GetProperties(Type type, BindingFlags flags)
        {
            var properties = type.GetProperties(flags);

            foreach (var property in properties)
            {
                //// if property is not indexer, return it
                if (!IsIndexerProperty(property))
                {
                    yield return property;
                }
            }

            yield break;
        }

        /// <summary>
        /// Check if <see cref="PropertyInfo"/> represents indexer property.
        /// </summary>
        /// <param name="property">A <see cref="PropertyInfo"/> to check.</param>
        /// <returns><c>true</c> if <paramref name="property"/> is indexer; <c>false</c> otherwise.</returns>
        private static bool IsIndexerProperty(PropertyInfo property)
        {
            var parameters = property.GetIndexParameters();

            if (parameters != null && parameters.Length > 0)
            {
                return true;
            }

            return false;
        }

        #endregion
    }

    #endregion

    #region MapResolveOptions

    /// <summary>
    /// Supported options resolving map.
    /// </summary>
    [Flags]
    public enum MapResolveOptions : int
    {
        /// <summary>
        /// None. Private setter is not used.
        /// </summary>
        None = 0,

        /// <summary>
        /// To use private setter of the property.
        /// </summary>
        UsePrivateSetter = 1
    }

    #endregion
}
