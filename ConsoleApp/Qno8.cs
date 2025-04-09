using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	//Write a program to demonstrate use of Delegate and Events.

	//define a Delegate
	public delegate void Notify();


    class Procedure
    {
		public event Notify? ProcedureCompleted;

		public void BeginProcedure()
		{
			Console.WriteLine("Beginning Procedure...");
			Thread.Sleep(3000);
			Console.WriteLine("Procedure Completed!");

			//Raising an event after completion
			OnProcedureCompletion();
		}

		public void OnProcedureCompletion()
		{
			if (ProcedureCompleted != null)
			{
				ProcedureCompleted();
			}
		}

	}

	class Consumer
	{
		public void ShowMessage()
		{
			Console.WriteLine("Recieved notification: Procedure completed!");
		}
	}
}
