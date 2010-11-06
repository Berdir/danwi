using System;
using System.Collections;
using System.Collections.Generic;

namespace MultiLayer
{
	public class OutputNode : Node
	{
		public OutputNode (String name) : base(name)
		{
		}
		
		public bool backwardSweep(int expectedValue, double learningRate, double idleness) {
			double e = expectedValue - Result;
			Console.WriteLine("Expected {0}, got {1}, difference {2} for {3}", expectedValue, Result, e, Name);
			
			if (e == 0) {
				Console.WriteLine("No difference!");
				return true;
			}
			
			double delta = Result * (1 - Result) * (expectedValue - Result);
			Console.WriteLine("Delta = Result * (1 - Result) * (expectedValue - Result) = {0} * (1 - {1}) * ({2} - {3}) = {4}", Result, Result, expectedValue, Result, delta);
			
			foreach (Link l in LeftLinks) {
				l.OldWeight = l.OldWeight;
				Console.WriteLine("Calculating new weight for link to {0} weight {1} += learningRate * Result * leftNodeResult = {2} * {3} * {4} = {5} => {6}", l.LeftNode.Name, l.Weight, learningRate, Result, l.LeftNode.Result, learningRate * Result * l.LeftNode.Result, l.Weight + learningRate * Result * l.LeftNode.Result);
				l.Weight += learningRate * Result * l.LeftNode.Result;
			}
			
			// go back.
			foreach (Link l in LeftLinks) {
				l.LeftNode.backwardSweep(learningRate, idleness);
			}
			
			return false;
		}
	}
}

