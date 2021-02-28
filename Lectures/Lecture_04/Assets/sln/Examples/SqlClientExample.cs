using System;
using System.Data.SqlClient;

namespace Examples
{
    public class SqlClientExample
    {
        private static void Main()
        {
            const string connectionString = "Data Source=(local);Initial Catalog=Northwind;"
                                            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            const string queryString = "SELECT ProductID, UnitPrice, ProductName from dbo.products "
                                       + "WHERE UnitPrice > @pricePoint "
                                       + "ORDER BY UnitPrice DESC;";

            // Specify the parameter value.
            const int paramValue = 5;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using var connection = new SqlConnection(connectionString);
            // Create the Command and Parameter objects.
            var command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@pricePoint", paramValue);

            // Open the connection in a try/catch block. 
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}",
                        reader[0], reader[1], reader[2]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}