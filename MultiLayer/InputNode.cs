using System;
using System.Collections;
using System.Collections.Generic;

namespace MultiLayer
{
	public class InputNode : Node
	{
		
		public InputNode (String name, int Value) : base(name, Value) 
		{
			// Result is never calculated, so it is always the same as Value.
			Result = Value;
		}
		
		public new bool backwardSweep(double learningRate, double idleness) {
			// Do nothing.
			return true;
		}
	}
}

