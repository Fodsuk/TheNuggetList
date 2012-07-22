using System;
using System.Collections;

namespace EventAggregator
{
    public static class TypeExtensions
    {
        public static void CallOn<T>(this object target, Action<T> action) where T : class
        {
            var subject = target as T;
            if (subject != null)
            {
                action(subject);
            }
        }

        public static void CallOnEach<T>(this IEnumerable enumerable, Action<T> action) where T : class
        {
            foreach (var o in enumerable)
            {
                o.CallOn(action);
            }
        }
    }
}