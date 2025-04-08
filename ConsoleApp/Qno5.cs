using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp
{
	//Write a program that reflects the overloading and overriding of constructor and function
	class Person
	{
		protected string name;
		//This is constructor overloading
		public Person()
		{
			name = "Unknown";
		}
		public Person(string name)
		{
			this.name = name;
		}

		//This is method overloading
		public void Greet()
		{
			Console.WriteLine("Hello!");
		}

		public void Greet(string message)
		{
			Console.WriteLine(message);
		}

		//Virtual function for override
		public  virtual void Work()
		{
			Console.WriteLine($"{this.name} does thier work.");
		}

	}

	class Merchant: Person
	{
		public Merchant()
		{
			this.name = "Unknown Merchant";
		}
		public Merchant(string name) : base()
		{

		}
		public override void Work()
		{
			Console.WriteLine($"{this.name} is selling goods. He is a merchant");
		}

	}
}
