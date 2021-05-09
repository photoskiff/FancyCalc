using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FancyCalc
{
    public enum Token { Add, Mult, Value };
    public record Operation(Token Op, int[] Labels);

    public static class Calculator
    {
        public static long Calculate(Dictionary<int, Operation> operations)
        {
            var Compute = Extensions.Memoized<int, long>((сompute, label) =>
            {
                var op = operations[label];
                return op.Op switch
                {
                    Token.Value => op.Labels[0],
                    Token.Add => op.Labels.Aggregate(0L, (a, b) => a + сompute(b)),
                    _ => op.Labels.Aggregate(1L, (a, b) => a * сompute(b))
                };
            });
            return Compute(operations.Keys.First());
        }

        public static long Calculate1(Dictionary<int, Operation> operations)
        {
            var count = 0;
            Func<int, long> Compute = Extensions.Memoized<int, long>((сompute, label) =>
            {
                ++count;
                var op = operations[label];
                return op.Op switch
                {
                    Token.Value => op.Labels[0],
                    Token.Add => op.Labels.Aggregate(0L, (a, b) => a + сompute(b)),
                    _ => op.Labels.Aggregate(1L, (a, b) => a * сompute(b))
                };
            });
            var sw = new Stopwatch();
            sw.Start();
            var result = Compute(operations.Keys.First());
            sw.Stop();
            var formatted = string.Format("{0:n0}", count);
            Console.WriteLine($"memoized function calls: {formatted}");
            Console.WriteLine($"time spent: {(double)sw.ElapsedMilliseconds / 1000} seconds");
            return result;
        }

        public static long Calculate2(Dictionary<int, Operation> operations)
        {
            bool baseCase(int label) => operations[label].Op == Token.Value;
            long baseCaseValue(int label) => operations[label].Labels[0];
            long initialValue(int label) => operations[label].Op == Token.Add ? 0 : 1;
            int[] labels(int label) => operations[label].Labels;
            Func<long, long, long> action(int label) => operations[label].Op == Token.Add ? (a, b) => a + b : (a, b) => a * b;
            var count = 0;
            long compute(int label)
            {
                ++count;
                if (baseCase(label))
                    return baseCaseValue(label);
                var result = initialValue(label);
                var act = action(label);
                foreach (var l in labels(label))
                    result = act(result, compute(l));
                return result;
            };
            var sw = new Stopwatch();
            sw.Start();
            var result = compute(operations.Keys.First());
            sw.Stop();
            var formatted = string.Format("{0:n0}", count);
            Console.WriteLine($"non-memoized function calls: {formatted}");
            Console.WriteLine($"time spent: {(double)sw.ElapsedMilliseconds / 1000} seconds");
            return result;
        }




    }
}
