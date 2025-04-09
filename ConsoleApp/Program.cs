/* 
 Write a program to convert input strings
 from lower to upper and upper to lower case.
 */
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace ConsoleApp

{

	class Program
	{
		public static async Task Main(string[] args)
		{
			Console.WriteLine("Dipu Dangol(28669/078)");
			string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
			Console.WriteLine("Executable Path: " + path);
			//Qno 1 execution
			//LowerToUpper qno1 = new LowerToUpper();
			//qno1.Output();

			//Qno 2 execution
			//CharacterInterchange qno2 = new CharacterInterchange();
			//qno2.Output();

			//Qno 3 execution
			//Console.WriteLine("Write a program to demonstrate the basics of class and object");
			//ClassAndObject stu1 = new ClassAndObject(1, "Ram");
			//stu1.Print();
			//// Static method to create an object
			//ClassAndObject.Create(2, "Shyam").Print();
			//Console.WriteLine(stu1.Name);

			//Qno4 execution
			//Console.WriteLine("Write a program to illustrate encapsulation with properties and indexers.");
			//EncapPropIndexers qno4 = new EncapPropIndexers(2);
			//qno4[0] = "Ram";
			//qno4[1] = "Hari";
			//for (int i = 0; i < qno4.length; i++)
			//{
			//	Console.WriteLine(qno4[i]);
			//}

			//Qno5 execution
			//Console.WriteLine("Write a program that reflects the overloading and overriding of constructor and function");
			//Person person1 = new Person();
			//Person person2 = new Person("Hari");
			//person1.Greet();
			//person1.Greet("Hi!");
			//person1.Work();
			//person2.Greet();
			//person2.Greet("Howdy!");
			//person2.Work();
			//Merchant merchant = new Merchant("Dhan Bahadur");
			//merchant.Greet("Hello sir!");
			//merchant.Work();

			//Qno6 execution
			//Console.WriteLine("Write a program to implement multiple inheritance with the use of interfaces.");
			//Employee employee = new Employee();
			//employee.Greet();
			//employee.Walk();
			//employee.Introduce();
			//employee.Work();

			//Qno7 execution
			//Console.WriteLine("Write a program to show how to handle exception in C#");
			//char choice;
			//double num1, num2;
			//do
			//{
			//	Console.WriteLine("\nInput two numbers to perform division:");
			//	num1 = double.Parse(Console.ReadLine());
			//	num2 = double.Parse(Console.ReadLine());
			//	ExceptionHandling exception = new ExceptionHandling(num1, num2);
			//	exception.ShowDemonstration();
			//	Console.WriteLine("Press 1 to continue/ anything to stop");
			//	choice = Console.ReadKey().KeyChar;

			//} while (choice == '1');
			//Console.WriteLine("\nStopping...");


			//Qno8 execution
			//Console.WriteLine("Write a program to demonstrate use of Delegate and Events.");
			//Procedure procedure = new Procedure();
			//Consumer consumer = new Consumer();
			//procedure.ProcedureCompleted += consumer.ShowMessage;

			//procedure.BeginProcedure();

			////Qno9 execution
			//Console.WriteLine("Write a program to show the use of generic classes and methods.");
			////Generic classes
			//Compare<int>.CompareThings(1, 1);
			//Compare<int>.CompareThings(1, 5);
			//Compare<int>.CompareThings(5, 1);
			//Compare<string>.CompareThings("hello", "hi");
			//Compare<string>.CompareThings("hi", "hi");
			//Compare<string>.CompareThings("hi", "hello");
			////Generic Methods
			//ArrayDisplay.DisplayElements<int>([1, 2, 3, 4, 5]);
			//ArrayDisplay.DisplayElements<double>([1.4, 2.55, 3.3, 4.20, 5.05]);
			//ArrayDisplay.DisplayElements<string>(["RAM", "MOTHERBOARD", "CPU", "GPU"]);

			//Qno10 execution
			//Console.WriteLine("Write a program to demonstrate the use of the method as a condition in the LINQ.");
			//MethodInLINQ method = new MethodInLINQ();
			//method.Demonstrate();

			//Qno11 execution
			Console.WriteLine("Demonstrate Asynchronous programming with async, await, Task in C#.");
			await AsyncTasks.AsyncMethod();





			//Console.WriteLine("Enter the input string:");
			//input = Console.ReadLine();

			//string[] brokenGreeting = { "hello", "world" };
			//Console.WriteLine(brokenGreeting);
			//var greeting = string.Join(" ", brokenGreeting);
			//Console.WriteLine(greeting);
			Console.ReadLine();




		}

	}
}
