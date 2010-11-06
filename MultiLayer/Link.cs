using System;
namespace MultiLayer
{
	public class Link
	{
		public Node LeftNode {get; set;}
		public Node RightNode {get; set;}
		public double Weight {get; set;}
		public double OldWeight {get; set;}
		
		
		public Link (Node leftNode, Node rightNode, double weight)
		{
			LeftNode = leftNode;
			RightNode = rightNode;
			Weight = weight;
			
			LeftNode.RightLinks.Add(this);
			RightNode.LeftLinks.Add(this);
			Console.WriteLine("Connected {0} with {1} (Weight: {2})", LeftNode.Name, RightNode.Name, Weight);
		}

		public Link (Node leftNode, Node rightNode) : this(leftNode, rightNode, new Random().NextDouble())
		{
		}
	}
}

