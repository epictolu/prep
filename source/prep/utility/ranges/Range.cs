using System;

namespace prep.utility.ranges
{
  public interface Range<T> where T : IComparable<T>
  {
    bool contains(T value);
  }

    public static class Create
    {
        public static Range<T> a_range<T>() where T : IComparable<T>
        {
            return new Universe<T>();
        }
    }

    public static class RangeExtensions
    {
        public static Range<T> GreaterThan<T>(this Range<T> range, T value) where T : IComparable<T>
        {
            return new Intersect<T>(range, new LowerBound<T>(value));
        }

        public static Range<T> GreaterThanOrEqual<T>(this Range<T> range, T value) where T : IComparable<T>
        {
            return new Intersect<T>(range, new Union<T>(new LowerBound<T>(value), new Includes<T>(value)));
        }

        public static Range<T> LessThanOrEqual<T>(this Range<T> range, T value) where T : IComparable<T>
        {
            return new Intersect<T>(range, new Union<T>(new UpperBound<T>(value), new Includes<T>(value)));
        }
    }

    public class Intersect<T> : Range<T> where T : IComparable<T>
    {
        private readonly Range<T> first;
        private readonly Range<T> second;

        public Intersect(Range<T> first, Range<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public bool contains(T value)
        {
            return first.contains(value) && second.contains(value);
        }
    }

    public class Union<T> : Range<T> where T : IComparable<T>
    {
        private readonly Range<T> first;
        private readonly Range<T> second;

        public Union(Range<T> first, Range<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public bool contains(T value)
        {
            return first.contains(value) || second.contains(value);
        }
    }

    public class Includes<T> : Range<T> where T : IComparable<T>
    {
        T value;

        public Includes(T value)
        {
            this.value = value;
        }

        public bool contains(T value)
        {
            return this.value.CompareTo(value) == 0;
        }
    }

    public class UpperBound<T> : Range<T> where T : IComparable<T>
    {
        T bound;

        public UpperBound(T bound)
        {
            this.bound = bound;
        }

        public bool contains(T value)
        {
            return bound.CompareTo(value) > 0;
        }
    }

    public class LowerBound<T> : Range<T> where T : IComparable<T>
    {
        T bound;

        public LowerBound(T bound)
        {
            this.bound = bound;
        }

        public bool contains(T value)
        {
            return bound.CompareTo(value) < 0;
        }
    }

    public class Universe<T> : Range<T> where T : IComparable<T>
    {
        public bool contains(T value)
        {
            return true;
        }
    }
}