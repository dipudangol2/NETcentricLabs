using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	internal class ClassAndObject
	{
		//Write a program to demonstrate the basics of class and object.
		//Properties
		public int Id { get; private set; } 
		public string Name { get; private set; } 

		//Constructor of the class 
		public ClassAndObject(int id, string name)
		{
			this.Id = id;
			this.Name = name;
		}

		public void Print()
		{
			Console.WriteLine($"Id:{this.Id}\tName:{this.Name}");
		}

		public static ClassAndObject Create(int id, string name)
		{
			return new ClassAndObject(id, name);
		}

	}
}
