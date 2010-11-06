using System;
namespace Dekodierproblem
{
	public class SingleLayerNetwork
	{
		protected double[] weights;
		
		protected int errors = 0;
		
		public double LearningRate {get;set;}

		public SingleLayerNetwork (int numInput)
		{
			// Randomise weights.
            Random r = new Random();
			weights = new double[numInput];
			for (int i = 0; i < weights.Length; i++) {
				weights[i] = r.NextDouble();
 			}
			
			// Default learning rate.
			LearningRate = 0.1;
		}
		
		public double learn(double[] input, double expectedOutput) {
			
		}	
	}
}

