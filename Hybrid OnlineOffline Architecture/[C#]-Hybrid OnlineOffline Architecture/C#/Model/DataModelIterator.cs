using System.Collections.Generic;

namespace Model
{
    public static class DataModelIterator
    {
        public static T StartTrackingAll<T>(this T entity) where T : IObjectWithChangeTracker
        {
            EntitiesIterator.Execute(entity, (IObjectWithChangeTracker e) => { e.StartTracking(); });
            return entity;
        }

        public static T StopTrackingAll<T>(this T entity) where T : IObjectWithChangeTracker
        {
            EntitiesIterator.Execute(entity, (IObjectWithChangeTracker e) => { e.StopTracking(); });
            return entity;
        }

        public static IEnumerable<T> StartTrackingAll<T>(this IEnumerable<T> entities) where T : IObjectWithChangeTracker
        {
            foreach (var entity in entities)
                entity.StartTrackingAll();
            return entities;
        }

        public static IEnumerable<T> StopTrackingAll<T>(this IEnumerable<T> entities) where T : IObjectWithChangeTracker
        {
            foreach (var entity in entities)
                entity.StopTrackingAll();
            return entities;
        }
    }
}