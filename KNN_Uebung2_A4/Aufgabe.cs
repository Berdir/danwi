using System;
using MultiLayer;

namespace KNN_Uebung2_A4
{
	public class Aufgabe
	{
		public static void Main()
		{
			InputNode x1 = new InputNode("x1", 1);
			InputNode x2 = new InputNode("x2", 1);
			Node h1 = new Node("h1");
			Node h2 = new Node("h2");
			OutputNode y = new OutputNode("y");
			h1.link(1.5);
			h2.link(0.5);
			h1.link(x1, -1);
			h1.link(x2, -1);
			h2.link(x1, -1);
			h2.link(x2, -1);
			y.link(-0.5);
			y.link(h1, 1);
			y.link(h2, -1);
			bool converged = false;
			int iterations = 0;
			while (!converged && iterations < 10) {
				Console.WriteLine("======== ITERATION {0} =========", ++iterations);
				y.forwardCalculate();
				converged = y.backwardSweep(1, 0.3, 0);
			}
		}
	}
}

