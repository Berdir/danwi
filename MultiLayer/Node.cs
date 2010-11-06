using System;
using System.Collections;
using System.Collections.Generic;

namespace MultiLayer
{
	public class Node
	{
		public List<Link> RightLinks {get; set;}
		public List<Link> LeftLinks {get; set;}
		public int Value {get; set;}
		public double Result {get; set;}
		public String Name {get; set;}
		
		public Node(String name) : this(name, 0) {
		}
		
		public Node(String name, int givenValue) {
			RightLinks = new List<Link>();
			LeftLinks = new List<Link>();
			Name = name;
			this.Value = givenValue;
		}
		
		public Link link(Node leftNode, double weight) {
			return new Link(leftNode, this, weight);
		}
		
		public Link link(Node leftNode) {
			return link(leftNode, new Random().NextDouble());
		}
		
		public Link link(double weight) {
			return link(new InputNode("1", 1), weight);
		}
		
		public Link Link() {
			return link(new InputNode("1", 1), new Random().NextDouble());
		}
		
		public void forwardCalculate() {
			
			// If there are no links on the lift side, just return the value.
			// There is nothing to calculate..
			if (LeftLinks.Count == 0) {
				return;
			}
			
			// Calculate all linked nodes first (recursive)
			foreach (Link l in LeftLinks) {
				l.LeftNode.forwardCalculate();
			}
			Result = 0;
			// Sum weight of each link.
			Console.Write("Calculating {0} = ", Name);
			int i = 0;
			foreach (Link l in LeftLinks) {
				if (i++ == 0) {
					Console.Write("{0} ({1}) * {2} ", l.LeftNode.Value, l.LeftNode.Name, l.Weight);
				}
				else {
					Console.Write("+ {0} ({1}) * {2} ", l.LeftNode.Value, l.LeftNode.Name, l.Weight);
				}
				Result += l.Weight * l.LeftNode.Value;
			}
			Value = Result >= 0 ? 1 : 0;
			Console.WriteLine("= {0} -> {1}", Result, Value);
			return;
		}
		
		public bool backwardSweep(double learningRate, double idleness) {
			// @todo: This assumes a singe link to the right side.
			Link link = RightLinks[0];
			double delta = Result * (1 - Result) * link.OldWeight * link.RightNode.Result;
			Console.WriteLine("Delta = Result * (1 - Result) * oldWeight * rightResult = {0} * (1 - {1}) * {2} * {3} = {4}", Result, Result, link.OldWeight, link.RightNode.Result, delta);
			
			foreach (Link l in LeftLinks) {
				Console.WriteLine("Calculating new weight for link to {0} weight {1} += learningRate * Result * leftNodeResult = {2} * {3} * {4} = {5} => {6}", l.LeftNode.Name, l.Weight, learningRate, Result, l.LeftNode.Result, learningRate * Result * l.LeftNode.Result, l.Weight + learningRate * Result * l.LeftNode.Result);
				l.Weight += learningRate * Result * l.LeftNode.Result;
			}
			
			return false;
		}
	}
}

