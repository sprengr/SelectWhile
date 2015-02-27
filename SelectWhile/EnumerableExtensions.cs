using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectWhile
{
    public enum SelectMode
    {
        IncludeLast,
        ExcludeLast
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> SelectWhile<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool> condition, Func<TSource, TResult> selector, SelectMode selectMode = SelectMode.ExcludeLast)
        {
            IList<TResult> results = new List<TResult>();

            foreach (var item in source)
            {
                var @continue = condition(item);
                if (selectMode == SelectMode.ExcludeLast && !@continue) break;
                var result = selector(item);
                results.Add(result);
                if (selectMode == SelectMode.IncludeLast && !@continue) break;
            }
            return results;
        }

        public static IEnumerable<TResult> SelectWhile<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, Func<TResult, bool> condition, SelectMode selectMode = SelectMode.ExcludeLast)
        {
            IList<TResult> results = new List<TResult>();

            foreach (var item in source)
            {
                var result = selector(item);
                var @continue = condition(result);
                if (selectMode == SelectMode.ExcludeLast && !@continue) break;
                results.Add(result);
                if (selectMode == SelectMode.IncludeLast && !@continue) break;
            }
            return results;
        }
    }
}
