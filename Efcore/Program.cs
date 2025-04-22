using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efcore
{
	class Program
	{
		private static EmployeeContext _context = new EmployeeContext();
		static void Main(string[] args)
		{
			CreateEmployee("Dipu Dangol","Kalimati");
			RetrieveEmployee(1);
			Console.ReadLine();

		}

		private static void RetrieveEmployee(int id)
		{
			var employees = _context.Employees.ToList();
			Console.WriteLine("Employees:");
			foreach(var employee in employees)
			{

				Console.WriteLine("Name: " + employee.Name);
				Console.WriteLine("Address" + employee.Address);
			}

		}

		private static void CreateEmployee(string name, string address)
		{

			Employee employee = new Employee { Name = name , Address=address};
			_context.Add(employee);
			_context.SaveChanges();

		}
	}
}