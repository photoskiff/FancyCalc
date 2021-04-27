using System;

namespace FancyCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var ops = OperationLoader.LoadOperations("input.txt");
            var result = Calculator.Calculate(ops);
            Console.WriteLine(result);
        }
    }
}
