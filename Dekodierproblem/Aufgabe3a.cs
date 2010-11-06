using System;
using SingleLayerNetwork;

namespace Dekodierproblem
{
	public class Aufgabe3a
	{
		public static void Main()
		{
			Console.WriteLine("=== Start ===");
			
			Console.Write("Initialising network...");
			Network n = new Network(4, 10);
			n.LearningRate = 0.3;
			n.link();
			
			Console.WriteLine("done.");
			
			Console.WriteLine("Write 4bit input string:");
			
			
			double[] input = new double[4];
			int[] expectedResult = new int[10];
			while (true) {
				Char[] line = Console.ReadLine().ToCharArray();
				//String[] line = "0000".Split();
				
				Console.WriteLine(line.Length);
				if (line.Length != 4) {
					Console.WriteLine("Invalid Length, repeat: ");
					continue;
				}
				
				int numResult = 0;
				for (int i = 3; i >= 0; i-- ) {
					input[i] = line[i] == '1' ? 1 : -1;
					Console.WriteLine(input[i]);
					if (input[i] == 1) {
						numResult += (int)Math.Pow(2, i - 1);
						Console.WriteLine(numResult);
					}
				}
				
				Console.Write("Expected result: ");
				for (int i = 0; i < 10; i++) {
					expectedResult[i] = (i < numResult) ? 1 : -1;
					Console.Write(expectedResult[i] > 0 ? 1 : 0);
				}
				Console.WriteLine();
				
				int[] result = n.calculate(input, expectedResult);
				Console.Write("Result: ");
				foreach (int resultBit in result) {
					Console.Write(resultBit > 0 ? 1 : 0);
				}
				Console.WriteLine();
				
				Console.WriteLine("Write 4bit input string:");
			}
		}
	}
}

