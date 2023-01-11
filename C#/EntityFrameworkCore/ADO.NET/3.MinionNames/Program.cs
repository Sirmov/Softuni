using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _3.MinionNames
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

            int villainId = int.Parse(Console.ReadLine());
            Console.WriteLine(GetVillainMinions(villainId, sqlConnection));

            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private static string GetVillainMinions(int villainId, SqlConnection sqlConnection)
        {
            string villainName = GetVillanName(villainId, sqlConnection);

            if (string.IsNullOrWhiteSpace(villainName))
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            string query = @"SELECT 
                                ROW_NUMBER() OVER (ORDER BY [m].[Name]) as [RowNum]
                                ,[m].[Name]
                                ,[m].[Age]
                            FROM [MinionsVillains] AS [mv]
                            JOIN [Minions] AS [m]
                            ON [mv].[MinionId] = [m].[Id]
                            WHERE [mv].[VillainId] = @VillainId
                            ORDER BY [m].[Name]";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("VillainId", villainId);
            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Villain: {villainName}");


            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    output.AppendLine($"{sqlDataReader["RowNum"]}. {sqlDataReader["Name"]} {sqlDataReader["Age"]}");
                }
            }
            else
            {
                output.AppendLine("(no minions)");
            }

            sqlDataReader.Close();
            sqlDataReader.Dispose();
            return output.ToString().TrimEnd();
        }

        private static string GetVillanName(int villianId, SqlConnection sqlConnection)
        {
            string query = @"SELECT [Name] FROM [Villains] WHERE [Id] = @VillianId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("VillianId", villianId);
            string name = (string) sqlCommand.ExecuteScalar();
            sqlCommand.Dispose();
            return name;
        }
    }
}
