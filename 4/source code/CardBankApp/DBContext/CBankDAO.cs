
using System.Data;
using System.Data.SqlClient;

namespace CardBankApp.DBContext
{
	public class CBankDAO
	{
		public static DataTable ExecuteDatatable(string query)
		{
			try
			{
				// Get database connection string from appsettings.json
				IConfigurationRoot configuration = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json", optional: false)
					.Build();
				string connectionString = configuration.GetConnectionString("DefaultConnection");

				// Create database connection and command objects
				using (SqlConnection connection = new SqlConnection(connectionString))
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					connection.Open();

					// Create DataTable and load data from SqlDataReader
					DataTable dataTable = new DataTable();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						dataTable.Load(reader);
					}

					return dataTable;
				}
			}
			catch (Exception)
			{
				throw;
			}


		}

	}
}
