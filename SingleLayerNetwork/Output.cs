using System;
using System.Collections;
using System.Collections.Generic;

namespace SingleLayerNetwork
{
	public class Output
	{
		public List<Link> Links {get; set;}
		
		public Output ()
		{
			Links = new List<Link>();
		}
		
		public void link(Input input)
		{
			Links.Add(new Link(input, this));
		}
		
		public double calculate() {
			double result = 0;
			foreach (Link link in Links) {
				result += link.Input.Value * link.Weight;
			}
			return result;
		}
		
		public void learn(double learningRate, double difference) {
			foreach (Link link in Links) {
				//Console.WriteLine("Weight += " + learningRate + " * " + difference + " * " + link.Input.Value);
				link.Weight += learningRate * difference * link.Input.Value;
				//Console.WriteLine("New Weight: " + link.Weight);
			}
		}
	}
}

