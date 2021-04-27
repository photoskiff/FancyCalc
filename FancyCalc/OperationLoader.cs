using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FancyCalc
{
    public static class OperationLoader
    {
        public static Dictionary<int, Operation> LoadOperations(string filename)
        {
            Dictionary<int, Operation> opearions = new();
            using var fs = File.OpenRead(filename);
            using var reader = new StreamReader(fs);
            var line = reader.ReadLine();
            while (line != null)
            {
                var values = line.Split(' ').Select(c => c.Trim().TrimEnd(':')).ToList();
                var labels = values.Skip(2).Select(l => int.Parse(l)).ToArray();
                opearions[int.Parse(values[0])] = new Operation(Enum.Parse<Token>(values[1]), labels);
                line = reader.ReadLine();
            }
            return opearions;
        }
    }
}
