/*
 Write a program to create a new string from a given string where first and last 
characters will be interchanged. 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	internal class CharacterInterchange
	{
		//Write a program to create a new string from a given string where first and last characters will be interchanged.
		private string ExchangeLetters(string message)
		{
			char[] letters = message.ToCharArray();
			char temp = letters[0];
			letters[0] = letters[^1];
			letters[^1] = temp;
			return new String(letters);
		}
		public void Output()
		{
			Console.WriteLine("Write a program to create a new string from a given string where first and last characters will be interchanged.");
			Console.WriteLine("Enter a string:");
			string? message = Console.ReadLine();

			if (!string.IsNullOrWhiteSpace(message))
			{
				message = message.Trim();
				if (message.Length >= 2)
				{
					string exchangedLetters = ExchangeLetters(message);
					Console.WriteLine(exchangedLetters);
				}
				else
					Console.WriteLine($"Error: Message is smaller than 2 characters!");

			}

			else
			{
				Console.WriteLine("Error: Input is empty or only whitespaces!");
			}
			//Console.WriteLine(message[^1]);

			//Console.WriteLine("Output");
			Console.ReadLine();
		}
	}
}
