using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	//Write a program to show the use of generic classes and methods.
	//Generic classes
	class Compare<Thing> where Thing: IComparable<Thing>
    {
		public static void CompareThings(Thing thing1, Thing thing2)
		{
			int result = thing1.CompareTo(thing2);

			if(result < 0)
			{
				Console.WriteLine($"{thing1} is smaller than {thing2}");
			}
			else if(result > 0)
			{
				Console.WriteLine($"{thing1} is greater than {thing2}");
			}
			else
			{
				Console.WriteLine("Both are equal");
			}
			
		}
    }
	//Generic method
	class ArrayDisplay
	{
		public static void DisplayElements<T>(T[] arr)
		{
			Console.Write($"Array elements of type({typeof(T)}): ");
			foreach (T item in arr)
			{
				Console.Write(item + " ");
			}
			Console.WriteLine("\n");

		}
	}
}
