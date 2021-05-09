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

            //result = Calculator.Calculate1(ops);
            //Console.WriteLine(result);

            //result = Calculator.Calculate2(ops);
            //Console.WriteLine(result);

            //Console.WriteLine(Calculator.FibMemoized(50));
            //Console.WriteLine(Calculator.FibCont(15));
        }
    }
}
