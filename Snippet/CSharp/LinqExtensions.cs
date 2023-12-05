using System;
using System.Collections.Generic;
using System.Linq;

namespace EgoParadise.Utility.Extension
{
    public static class LinqExtensions
    {
        private sealed class CommonSelector<T, TKey> : IEqualityComparer<T>
        {
            private readonly Func<T, TKey> Selector;

            public CommonSelector(Func<T, TKey> selector)
            {
                this.Selector = selector;
            }

            public bool Equals(T x, T y) => this.Selector(x).Equals(this.Selector(y));

            public int GetHashCode(T obj) => this.Selector(obj).GetHashCode();
        }

        public static IEnumerable<T> FilterNull<T>(this IEnumerable<T> source) => source.Where(m => m == null);

        public static string ToArrayString(this IEnumerable<string> source) => "[" + string.Join(", ", source) + "]";

        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector) => source.Distinct(new CommonSelector<T, TKey>(selector));
    }
}
