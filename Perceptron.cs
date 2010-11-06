using System;
 
namespace Perceptron
{
    public class Perceptron
    {
        [STAThread]
        static void Main()
        {
            // Load sample input patterns.
            double[,] inputs = new double[,] {
                { 0.72, 0.82 }, { 0.91, -0.69 }, { 0.46, 0.80 },
                { 0.03, 0.93 }, { 0.12, 0.25 }, { 0.96, 0.47 },
                { 0.79, -0.75 }, { 0.46, 0.98 }, { 0.66, 0.24 },
                { 0.72, -0.15 }, { 0.35, 0.01 }, { -0.16, 0.84 },
                { -0.04, 0.68 }, { -0.11, 0.10 }, { 0.31, -0.96 },
                { 0.00, -0.26 }, { -0.43, -0.65 }, { 0.57, -0.97 },
                { -0.47, -0.03 }, { -0.72, -0.64 }, { -0.57, 0.15 },
                { -0.25, -0.43 }, { 0.47, -0.88 }, { -0.12, -0.90 },
                { -0.58, 0.62 }, { -0.48, 0.05 }, { -0.79, -0.92 },
                { -0.42, -0.09 }, { -0.76, 0.65 }, { -0.77, -0.76 } };
 
            // Load sample output patterns.
            int[] outputs = new int[] {
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int patternCount = inputs.GetUpperBound(0) + 1;
 
            // Randomise weights.
            Random r = new Random();
            double[] weights = { r.NextDouble(), r.NextDouble() };
 
            // Set learning rate.
            double learningRate = 0.3;
 
            int iteration = 0;
            double globalError;
 
            do
            {
                globalError = 0;
                for (int p = 0; p < patternCount; p++)
                {
                    // Calculate output.
                    int output = Output(weights, inputs[p, 0], inputs[p, 1]);
 
                    // Calculate error.
                    double localError = outputs[p] - output;
 
                    if (localError != 0)
                    {
                        // Update weights.
                        for (int i = 0; i < 2; i++)
                        {
                            weights[i] += learningRate * localError * inputs[p, i];
                        }
                    }
 
                    // Convert error to absolute value.
                    globalError += Math.Abs(localError);
                }
 
                Console.WriteLine("Iteration {0}\tError {1}", iteration, globalError);
                iteration++;
 
            } while (globalError != 0);
 
            // Display network generalisation.
            Console.WriteLine();
            Console.WriteLine("X, Y, Output");
            for (double x = -1; x <= 1; x += .5)
            {
                for (double y = -1; y <= 1; y += .5)
                {
                    // Calculate output.
                    int output = Output(weights, x, y);
                    Console.WriteLine("{0}, {1}, {2}", x, y, (output == 1) ? "Blue" : "Red");
                }
            }
            Console.ReadKey();
        }
 
        private static int Output(double[] weights, double x, double y)
        {
            double sum = x * weights[0] + y * weights[1];
            return (sum >= 0) ? 1 : -1;
        }
    }
}