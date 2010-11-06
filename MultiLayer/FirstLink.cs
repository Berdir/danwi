using System;
namespace MultiLayer
{
	public class FirstLink : Link
	{
		
		public FirstLink (Node rightNode, double weight) : base(new Node("1", 1), rightNode, weight)
		{
		}

		public FirstLink (Node rightNode) : this(rightNode, new Random().NextDouble())
		{
		}
	}
}

