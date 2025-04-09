using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

	//Write a program to demonstrate the use of the method as a condition in the LINQ.
	class MethodInLINQ
	{
		private bool IsEven(int num)
		{
			return num % 2 == 0;
		}
		public void Demonstrate()
		{
			List<int> list = new List<int> { 3,4,6,8,34,23,12,2,77,89};
			Console.Write("All the list elements:");
			foreach(int num in list)
			{
				Console.Write(num + " ");
			}
			Console.WriteLine();
			IEnumerable<int> evenNums = from n in list
								 where IsEven(n)
								orderby n descending select n;
			Console.Write("Even numbers in the list in descending order:");
			foreach (int num in evenNums)
			{
				Console.Write(num + " ");
			}
			Console.WriteLine();
		}
	}
}
