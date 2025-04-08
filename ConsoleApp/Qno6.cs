using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	//Write a program to implement multiple inheritance with the use of interfaces
	interface PersonInterface
	{
		public void Greet();
		public void Walk();
	}
	interface EmployeeInterface
	{
		public void Work();
		public void Introduce();
	}
	class Employee: PersonInterface, EmployeeInterface
    {
		public void Greet()
		{
			Console.WriteLine("Hello!");
		}
		public void Walk()
		{
			Console.WriteLine("Employee is walking.");
		}
		public void Work()
		{
			Console.WriteLine("Employee is working.");
		}
		public void Introduce()
		{
			Console.WriteLine("I am an Employee.");
		}
    }
}
