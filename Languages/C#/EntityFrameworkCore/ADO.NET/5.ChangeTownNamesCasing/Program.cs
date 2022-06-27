using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5.ChangeTownNamesCasing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Server=localhost;
                                            Database=MinionsDB;
                                            User Id=username;
                                            Password=password;
                                            Encrypt=false";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string countryName = Console.ReadLine();
            int townsAffected = UppercaseTownNamesForCountry(countryName, sqlConnection);
            if (townsAffected > 0)
            {
                Console.WriteLine($"{townsAffected} town names were affected.");
                Console.WriteLine(GetTownsInCountry(countryName, sqlConnection));
            }
            else
            {
                Console.WriteLine("No town names were affected.");
            }

            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private static string GetTownsInCountry(string countryName, SqlConnection sqlConnection)
        {
            string query = @"SELECT [t].[Name]
                            FROM [Towns] AS [t]
                            JOIN [Countries] AS [c]
                            ON [c].[Id] = [t].[CountryCode]
                            WHERE [c].[Name] = @CountryName";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("CountryName", countryName);
            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<string> townNames = new List<string>();
            while (sqlDataReader.Read())
            {
                townNames.Add(sqlDataReader["Name"].ToString());
            }

            sqlCommand.Dispose();
            sqlDataReader.Close();
            sqlDataReader.Dispose();
            return $"[{string.Join(", ", townNames)}]";
        }

        private static int UppercaseTownNamesForCountry(string countryName, SqlConnection sqlConnection)
        {
            string query = @"UPDATE [Towns]
                            SET [Name] = UPPER([Name])
                            WHERE [CountryCode] = (
                                                        SELECT [Id]
                                                        FROM [Countries]
                                                        WHERE [Name] = @CountryName
                                                  )";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("CountryName", countryName);
            int affectedRows = (int) sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            return affectedRows;
        }
    }
}
