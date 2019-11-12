using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MasaSam.Data.Mapping
{
    /// <summary>
    /// Class that perform actual mapping.
    /// </summary>
    public static class DataMapper
    {
        /// <summary>
        /// Resolves <see cref="IMap"/> between source and destination type.
        /// </summary>
        /// <returns>A resolved map.</returns>
        public static IMap Resolve<TSource, TDestination>(MapResolveOptions options = MapResolveOptions.None) where TDestination : new()
        {
            return MapResolver.Resolve<TSource, TDestination>(options);
        }

        /// <summary>
        /// Resolves <see cref="IMap"/> between source and destination type.
        /// </summary>
        /// <returns>A resolved map.</returns>
        public static IMap Resolve(Type sourceType, Type destinationType, MapResolveOptions options = MapResolveOptions.None)
        {
            return MapResolver.Resolve(sourceType, destinationType, options);
        }

        /// <summary>
        /// Removes map between source and destination type.
        /// </summary>
        /// <returns>true if map was removed; false otherwise.</returns>
        public static bool RemoveMap<TSource, TDestination>() where TDestination : new()
        {
            return MapResolver.Remove<TSource, TDestination>();
        }

        /// <summary>
        /// Removes map between source and destination type.
        /// </summary>
        /// <returns>true if map was removed; false otherwise.</returns>
        public static bool RemoveMap(Type sourceType, Type destinationType)
        {
            return MapResolver.Remove(sourceType, destinationType);
        }

        /// <summary>
        /// Maps source object to destination object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="destinationType">The type of an destination object.</param>
        /// <returns>A destination object instance or null or default.</returns>
        public static object Map(object source, Type destinationType)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            Type sourceType = source.GetType();

            //// create destination instance
            object destination = Activator.CreateInstance(destinationType);

            if (destination == null)
                throw new InvalidOperationException(String.Format("Could not create instance of {0}.", destinationType.FullName));

            //// perform mapping
            Map(source, destination, sourceType, destinationType);

            return destination;
        }

        /// <summary>
        /// Maps source object to destination object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>A destination object instance or null or default.</returns>
        public static TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
        {
            if (source == null)
                throw new ArgumentNullException("source");

            TDestination destination = new TDestination();

            Type sourceType = typeof(TSource);
            Type destinationType = typeof(TDestination);

            Map(source, destination, sourceType, destinationType);

            return destination;
        }

        /// <summary>
        /// Maps enumerable of <typeparamref name="TSource"/> to enumerable of <typeparamref name="TDestination"/>.
        /// </summary>
        /// <param name="enumerable">The source enumerable.</param>
        /// <returns>A enumerable of <typeparamref name="TDestination"/>.</returns>
        public static IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> enumerable) where TDestination : new()
        {
            foreach (TSource source in enumerable)
            {
                if (source == null)
                {
                    continue;
                }

                TDestination destination = Map<TSource, TDestination>(source);

                yield return destination;
            }

            yield break;
        }

        /// <summary>
        /// Maps source object to destination object.
        /// </summary>
        private static void Map(object source, object destination, Type sourceType, Type destinationType)
        {
            //// get new or previously resolved map
            Map map = MapResolver.Resolve(sourceType, destinationType);

            //// map source to destination
            Map(map, source, destination, sourceType, destinationType);
        }

        /// <summary>
        /// Maps source object to destination object using provided map.
        /// </summary>
        private static void Map(Map map, object source, object destination, Type sourceType, Type destinationType)
        {
            //// map each resolved mapping
            foreach (MapItem item in map.Items)
            {
                //// if mapping should be ignored,
                //// continue to next mapping
                if (item.IsIgnored)
                {
                    continue;
                }

                object sourceValue = GetSourceValue(item.Source, source);
                object destinationValue = null;

                //// if source value is null
                if (sourceValue == null)
                {
                    //// and destination value is struct
                    if (item.Destination.Type.IsSubclassOf(typeof(System.ValueType)))
                    {
                        //// leave value to zero
                        continue;
                    }
                }
                else
                {
                    //// check if type is complex
                    if (item.IsComplex)
                    {
                        //// get resolved sub map between complex types
                        Map subMap = map.GetSubMap(item);

                        //// create instance of the destination type, expects that type has default constructor
                        destinationValue = Activator.CreateInstance(item.Destination.Type);

                        //// map source complex type to destination complex type by making recursive call
                        Map(subMap, sourceValue, destinationValue, sourceValue.GetType(), destinationValue.GetType());
                    }
                    else
                    {
                        //// convert source value
                        destinationValue = ValueConverter.Convert(item, sourceValue);
                    }
                }

                //// set value to the instance
                SetDestinationValue(item.Destination, destination, destinationValue);
            }
        }

        /// <summary>
        /// Gets source object member value.
        /// </summary>
        /// <returns>A value returned by member.</returns>
        private static object GetSourceValue(MapItem.Item mapping, object source)
        {
            object value;

            //// check whether to get property value or invoke method
            if (mapping.Member == MapItem.MemberType.Property)
            {
                value = ((PropertyInfo)mapping.MemberInfo).GetValue(source, null);
            }
            else
            {
                //// expected get method has no parameters
                value = ((MethodInfo)mapping.MemberInfo).Invoke(source, null);
            }

            return value;
        }

        /// <summary>
        /// Sets destination object member value.
        /// </summary>
        private static void SetDestinationValue(MapItem.Item mapping, object destination, object value)
        {
            //// check whether to set property value or invoke method
            if (mapping.Member == MapItem.MemberType.Property)
            {
                ((PropertyInfo)mapping.MemberInfo).SetValue(destination, value, null);
            }
            else
            {
                //// expected set method has 1 parameter
                ((MethodInfo)mapping.MemberInfo).Invoke(destination, new object[] { value });
            }
        }
    }
}
