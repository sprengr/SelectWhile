using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectWhile
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> SelectWhile<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool> condition, Func<TSource, TResult> selector)
        {
            IList<TResult> results = new List<TResult>();

            foreach (var item in source)
            {
                var @continue = condition(item);
                if (!@continue) break;
                var result = selector(item);
                results.Add(result);
            }
            return results;
        }

        public static IEnumerable<TResult> SelectWhile<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, Func<TResult, bool> condition)
        {
            IList<TResult> results = new List<TResult>();

            foreach (var item in source)
            {
                var result = selector(item);
                var @continue = condition(result);
                if (!@continue) break;
                results.Add(result);
            }
            return results;
        }
    }
}
