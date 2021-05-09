using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace FancyCalc
{
    public static class Extensions
    {
        public static Func<TArgs, TResult> Memoized<TArgs, TResult>(Func<Func<TArgs, TResult>, TArgs, TResult> factory,
            IEqualityComparer<TArgs> comparer = null)
        {
            long test(int a) => test(a);
            var cache = new ConcurrentDictionary<TArgs, TResult>(comparer ?? EqualityComparer<TArgs>.Default);
            TResult FunctionImpl(TArgs args) => cache.GetOrAdd(args, _ => factory(FunctionImpl, args));
            //uncomment for testing non-cashed solution (very slow)
            //TResult FunctionImpl(TArgs args) => factory(FunctionImpl, args);
            return FunctionImpl;
        }
    }
}
