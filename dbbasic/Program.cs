using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; //Needed to connect to sql db

namespace dbbasic
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Dipu Dangol(28669/078)");
			int choice, flag = 0;
			using (SqlConnection con = ConnectDB())
			{
				try

				{
					con.Open();

					while (true)
					{
						Console.WriteLine("Enter your choice\n");
						Console.Write("1. Insert\t");
						Console.Write("2. Display all\t");
						Console.Write("3. Search\t");
						Console.Write("4. Update\t");
						Console.Write("5. Delete\t");
						Console.Write("6. Exit\t");
						choice = Convert.ToInt32(Console.ReadLine());
						switch (choice)
						{
							case 1:
								Insert(con);
								break;
							case 2:
								DisplayAll(con);
								break;
							case 3:
								Search(con);
								break;
							case 4:
								Update(con);
								break;
							case 5:
								Delete(con);
								break;
							case 6:
								flag = 1;
								break;
							default:
								Console.WriteLine("Wrong choice!");
								break;

						}
						if (flag == 1)
						{
							break;
						}

					}

				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
				}

			}
			Console.ReadLine();
		}

		private static SqlConnection ConnectDB()
		{
			string connectionString = "Data Source=dipudangol\\SQLEXPRESS01;Initial Catalog=HamroStoreDB;Integrated Security=True;TrustServerCertificate=True;";
			return new SqlConnection(connectionString);
		}

		private static void DisplayAll(SqlConnection con)
		{
			try
			{
				string query = "SELECT * FROM Products";
				using (SqlCommand cmd = new SqlCommand(query, con))
				using (SqlDataReader sdr = cmd.ExecuteReader())
				{
					Console.WriteLine("The products are:");
					while (sdr.Read())
					{
						Console.WriteLine($"ID: {sdr.GetInt32(0)}");
						Console.WriteLine($"Name: {sdr.GetString(1)}");
						Console.WriteLine($"Description: {sdr.GetString(2)}");
						Console.WriteLine($"Price: {sdr.GetDouble(3)}");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error displaying products: {ex.Message}");
			}
		}

		private static void Insert(SqlConnection con)
		{
			try
			{
				Console.WriteLine("Enter product details:");
				Console.Write("Name: ");
				string name = Console.ReadLine();

				Console.Write("Description: ");
				string description = Console.ReadLine();

				Console.Write("Price: ");
				if (!double.TryParse(Console.ReadLine(), out double price))
				{
					Console.WriteLine("Invalid price. Please enter a valid number.");
					return;
				}

				string query = "INSERT INTO Products(Name, Description, Price) VALUES (@name, @description, @price)";
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@name", name);
					cmd.Parameters.AddWithValue("@description", description);
					cmd.Parameters.AddWithValue("@price", price);

					cmd.ExecuteNonQuery();
					Console.WriteLine("Inserted successfully.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error inserting product: {ex.Message}");
			}
		}

		private static void Update(SqlConnection con)
		{
			try
			{
				Console.WriteLine("Enter the ID of the product you want to update:");
				if (!int.TryParse(Console.ReadLine(), out int id))
				{
					Console.WriteLine("Invalid ID. Please enter a valid number.");
					return;
				}

				// Retrieve current details
				string selectQuery = "SELECT * FROM Products WHERE Id = @id";
				using (SqlCommand selectCmd = new SqlCommand(selectQuery, con))
				{
					selectCmd.Parameters.AddWithValue("@id", id);

					using (SqlDataReader sdr = selectCmd.ExecuteReader())
					{
						if (!sdr.HasRows)
						{
							Console.WriteLine("No product found with the specified ID.");
							return;
						}

						sdr.Read();
						Console.WriteLine("\nCurrent details:");
						Console.WriteLine($"ID: {sdr.GetInt32(0)}");
						Console.WriteLine($"Name: {sdr.GetString(1)}");
						Console.WriteLine($"Description: {sdr.GetString(2)}");
						Console.WriteLine($"Price: {sdr.GetDouble(3)}");

						// Close the reader before proceeding
						sdr.Close();
					}
				}

				// Prompt user for updated details
				Console.WriteLine("Enter new details (leave blank to keep current value):");

				Console.Write("New Name: ");
				string newName = Console.ReadLine();

				Console.Write("New Description: ");
				string newDescription = Console.ReadLine();

				Console.Write("New Price: ");
				string newPriceInput = Console.ReadLine();

				// Build the UPDATE query dynamically based on inputs
				string updateQuery = "UPDATE Products SET ";
				List<string> updates = new List<string>();
				if (!string.IsNullOrWhiteSpace(newName)) { updates.Add("Name = @newName"); }
				if (!string.IsNullOrWhiteSpace(newDescription)) { updates.Add("Description = @newDescription"); }
				if (!string.IsNullOrWhiteSpace(newPriceInput) && double.TryParse(newPriceInput, out double newPrice)) { updates.Add("Price = @newPrice"); }

				if (updates.Count == 0)
				{
					Console.WriteLine("No updates made.");
					return;
				}

				updateQuery += string.Join(", ", updates) + " WHERE Id = @id";

				using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
				{
					updateCmd.Parameters.AddWithValue("@id", id);
					if (!string.IsNullOrWhiteSpace(newName)) updateCmd.Parameters.AddWithValue("@newName", newName);
					if (!string.IsNullOrWhiteSpace(newDescription)) updateCmd.Parameters.AddWithValue("@newDescription", newDescription);
					if (!string.IsNullOrWhiteSpace(newPriceInput) && double.TryParse(newPriceInput, out newPrice))
						updateCmd.Parameters.AddWithValue("@newPrice", newPrice);

					int rowsAffected = updateCmd.ExecuteNonQuery();
					Console.WriteLine(rowsAffected > 0 ? "Product updated successfully." : "No changes made.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating product: {ex.Message}");
			}
		}

		private static void Delete(SqlConnection con)
		{
			try
			{
				Console.WriteLine("Enter the id of the product to delete:");
				int id = Convert.ToInt32(Console.ReadLine());
				string selectRow = "SELECT * FROM Products WHERE id=@id";
				using (SqlCommand cmd = new SqlCommand(selectRow, con))
				{
					cmd.Parameters.AddWithValue("@id", id);
					using (SqlDataReader sdr = cmd.ExecuteReader())
					{
						if (!sdr.HasRows)
						{
							Console.WriteLine("No data found with the given id.");
							return;

						}
						Console.WriteLine("The selected Data is:\n");
						while (sdr.Read())
						{
							Console.WriteLine($"ID: {sdr.GetInt32(0)}");
							Console.WriteLine($"Name: {sdr.GetString(1)}");
							Console.WriteLine($"Description: {sdr.GetString(2)}");
							Console.WriteLine($"Price: {sdr.GetDouble(3)}\n");

						}
					}
				}
				Console.WriteLine("Are you sure you want to delete the selected data? This cannot be reversed.(press y to delete/n to abort)");
				string confirm = Console.ReadLine();
				if (confirm == "n") { return; }
				else if (confirm == "y")
				{ 
					string query = "DELETE FROM Products WHERE id=@id";
					using (SqlCommand cmd = new SqlCommand(query, con))
					{
						cmd.Parameters.AddWithValue("@id", id);
						cmd.ExecuteNonQuery();
						Console.WriteLine("Data deleted sucessfully.");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error deleting product: {ex.Message}");
			}
		}
		private static void Search(SqlConnection con)
		{
			return;
		}
	}
}
