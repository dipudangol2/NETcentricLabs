using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Efcore
{
    class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=dipudangol\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True;TrustServerCertificate=True");
		}
	}
}
