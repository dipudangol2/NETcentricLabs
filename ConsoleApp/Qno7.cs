using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ExceptionHandling
    {
		//Write a program to show how to handle exception in C#
			private readonly double num1, num2;
			double result;
		public ExceptionHandling(double num1, double num2)
		{
			this.num1 = num1;
			this.num2 = num2;
		}
		public void ShowDemonstration()
		{
			result = double.NaN;
			try
			{
				if (num2 == 0)
				{
					throw new DivideByZeroException("Divisor is Zero!");
				}
				result = num1/num2;
				Console.WriteLine($"The result is {this.result}");
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Exception occured:{ex.ToString()}");
			}
			finally
			{
				Console.WriteLine($@"Calculation completed. Result:{(double.IsNaN(result) ? "undefined" : result.ToString())}");
			}
		}
	}
}
