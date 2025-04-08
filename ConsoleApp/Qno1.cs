using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	internal class LowerToUpper
	{
		//Write a program to convert input strings from lower to upper and upper to lower case.
		private string ChangeCase(string message)
		{
			return new string(message.Select(letter => char.IsLower(letter) ? char.ToUpper(letter) : char.ToLower(letter)).ToArray());
		}
		public void Output()
		{
			Console.WriteLine("C# program to convert lowercase letters into uppercase and upppercase into lowercase of the given string.");
			Console.WriteLine("Enter the string:");
			string? input = Console.ReadLine();
			try
			{
				if (string.IsNullOrWhiteSpace(input))
				{
					throw new Exception("Input is empty!");
				}
				string convertedString = ChangeCase(input);
				Console.WriteLine($"The converted string of \"{input}\" is \"{convertedString}\".");

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.WriteLine("Program terminated.");
			}
			Console.ReadLine();
		}
	}
}
