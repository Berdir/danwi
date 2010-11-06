using System;
namespace SingleLayerNetwork
{
	public class Network
	{
		public Input[] Inputs {get;set;}
		
		public Output[] Outputs {get;set;}
		
		public double LearningRate {get;set;}
		
		
		public Network (int numInputs, int numOutputs)
		{
			LearningRate = 0.1;
			
			Inputs = new Input[numInputs];
			for (int i = 0; i < numInputs; i++) {
				Inputs[i] = new Input();
			}
			Outputs = new Output[numOutputs];
			for (int i = 0; i < numOutputs; i++) {
				Outputs[i] = new Output();
			}
		}
		
		public void link(int inputIndex, int outputIndex) {
			Outputs[outputIndex].link(Inputs[inputIndex]);
		}
		
		public void link() {
			foreach (Output o in Outputs) {
				foreach (Input i in Inputs) {
					o.link(i);
				}
			}
		}
		
		public int[] calculate(double[] input, int[] expectedOutput)
		{
			int i = 0;
			double result;
			int[] resultArray = new int[expectedOutput.Length];
			foreach (Input inputNode in Inputs) {
				inputNode.Value = input[i++];
			}
			
			i = 0;
			foreach (Output outputNode in Outputs) {
				result = outputNode.calculate();
				//Console.WriteLine("Result: " + result);
				resultArray[i] = result >= 0 ? 1 : -1;
				
				int difference = expectedOutput[i] - resultArray[i];
				if (difference != 0) {
					outputNode.learn(LearningRate, difference);
				}
				i++;
			}
			
			return resultArray;
		}
	}
}