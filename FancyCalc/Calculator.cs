using System;
using System.Collections.Generic;
using System.Linq;

namespace FancyCalc
{
    public enum Token { Add, Mult, Value };
    public record Operation(Token Op, int[] Labels);

    public static class Calculator
    {
        public static long Calculate(Dictionary<int, Operation> operations)
        {
            Func<int, long> Compute = Extensions.Memoized<int, long>((сompute, label) =>
            {
                var op = operations[label];
                if (op.Op == Token.Value)
                    return op.Labels[0];
                return op.Op == Token.Add
                    ? op.Labels.Aggregate(0L, (a, b) => a + сompute(b))
                    : op.Labels.Aggregate(1L, (a, b) => a * сompute(b));
            });
            return Compute(operations.Keys.First()); 
            
        }
    }
}
