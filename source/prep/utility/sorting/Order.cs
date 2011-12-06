using System;
using System.Collections.Generic;
using prep.collections;

namespace prep.utility.sorting
{
    public static class Order<ItemType>
    {
        public static IComparer<ItemType> by_descending<PropertyType>(Func<ItemType, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new PropertyComparer<ItemType, PropertyType>(new DescendingComparer<PropertyType>(), accessor);
        }

        public static IComparer<ItemType> by_ascending<PropertyType>(Func<ItemType, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new PropertyComparer<ItemType, PropertyType>(new AscendingComparer<PropertyType>(), accessor);
        }

        public static IComparer<ItemType> by_studio(Func<ItemType, ProductionStudio> accessor)
        {
            return new PropertyComparer<ItemType, ProductionStudio>(new StudioComparer(), accessor);
        }
    }

    public class StudioComparer : IComparer<ProductionStudio>
    {
        public int Compare(ProductionStudio x, ProductionStudio y)
        {
            var studio_ratings = new Dictionary<ProductionStudio, int>
                                     {
                                         {ProductionStudio.MGM, 1},
                                         {ProductionStudio.Pixar, 2},
                                         {ProductionStudio.Dreamworks, 3},
                                         {ProductionStudio.Universal, 4},
                                         {ProductionStudio.Disney, 5},
                                     };

            return studio_ratings[x].CompareTo(studio_ratings[y]);
        }
    }

    public static class OrderingExtensions
    {
        public static IComparer<ItemType> then_by<ItemType, PropertyType>(this IComparer<ItemType> comparer, Func<ItemType, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ThenByComparer<ItemType>(comparer, new PropertyComparer<ItemType, PropertyType>(new AscendingComparer<PropertyType>(), accessor));        
        }
    }



    public class ThenByComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> comparer;
        private readonly IComparer<T> then_by;

        public ThenByComparer(IComparer<T> comparer, IComparer<T> then_by)
        {
            this.comparer = comparer;
            this.then_by = then_by;
        }

        public int Compare(T x, T y)
        {
            var compared_result = comparer.Compare(x, y);
            return compared_result == 0 ? then_by.Compare(x, y) : compared_result;
        }
    }

    public class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }

    public class AscendingComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }

    public class PropertyComparer<ItemType, PropertyType> : IComparer<ItemType>
    {
        private readonly IComparer<PropertyType> comparer;
        private readonly Func<ItemType, PropertyType> accessor;

        public PropertyComparer(IComparer<PropertyType> comparer, Func<ItemType, PropertyType> accessor)
        {
            this.comparer = comparer;
            this.accessor = accessor;
        }

        public int Compare(ItemType x, ItemType y)
        {
            return comparer.Compare(accessor(x), accessor(y));
        }
    }
}