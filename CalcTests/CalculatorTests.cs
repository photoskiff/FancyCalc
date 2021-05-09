using FancyCalc;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalcTests
{
    public class Tests
    {
        public Operation Op(Token t, params int[] labels) => new Operation(t, labels);

        [Test]
        public void ShouldAddValues()
        {
            var input = new Dictionary<int, Operation>();
            input[0] = Op(Token.Add, 1, 5, 6);
            input[1] = Op(Token.Value, 5);
            input[5] = Op(Token.Value, 11);
            input[6] = Op(Token.Value, 3);

            var result = Calculator.Calculate(input);
            Assert.That(result, Is.EqualTo(19));
        }

        [Test]
        public void ShouldMultiplyValues()
        {
            var input = new Dictionary<int, Operation>();
            input[0] = Op(Token.Mult, 1, 5, 6);
            input[1] = Op(Token.Value, 5);
            input[5] = Op(Token.Value, 10);
            input[6] = Op(Token.Value, 3);

            var result = Calculator.Calculate(input);
            Assert.That(result, Is.EqualTo(150));
        }

        [Test]
        public void ShouldAddAndMultiplyValues()
        {
            var input = new Dictionary<int, Operation>();
            input[0] = Op(Token.Add, 1, 5);
            input[1] = Op(Token.Value, 5);
            input[5] = Op(Token.Mult, 1, 6);
            input[6] = Op(Token.Value, 3);
            var result = Calculator.Calculate2(input);
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void ShouldLoadTextFile()
        {
            var ops = OperationLoader.LoadOperations("test.txt");
            Assert.That(ops, Is.Not.Empty);
            Assert.That(ops.Count, Is.EqualTo(6));
        }
    }
}