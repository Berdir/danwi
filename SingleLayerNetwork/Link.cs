using System;
namespace SingleLayerNetwork
{
	public class Link
	{
		public Input Input {get; set;}
		public Output Output {get;set;}
		public double Weight {get;set;}
		
		public Link (Input input, Output output)
		{
			this.Input = input;
			this.Output = output;
			this.Weight = new Random().NextDouble();
			Console.WriteLine("Weight: " + Weight);
		}
	}
}

