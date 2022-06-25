using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _2.VillainNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Server=localhost;Database=MinionsDB;User Id=sa;Password=123Nikola321!;Encrypt=false;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine(GetVilliansWithMoreThan3Minions(sqlConnection));
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private static string GetVilliansWithMoreThan3Minions(SqlConnection sqlConnection)
        {
            string query = @"SELECT 
                                [v].[Name]
                                ,COUNT([mv].[VillainId]) AS [MinionsCount]
                            FROM [Villains] AS [v]
                            JOIN [MinionsVillains] AS [mv]
                            ON [v].[Id] = [mv].[VillainId] 
                            GROUP BY [v].[Id], [v].[Name] 
                            HAVING COUNT([mv].[VillainId]) > 3 
                            ORDER BY COUNT([mv].[VillainId])";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            StringBuilder output = new StringBuilder();
            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                output.AppendLine($"{sqlDataReader["Name"]} - {sqlDataReader["MinionsCount"]}");
            }

            sqlDataReader.Close();
            sqlDataReader.Dispose();
            sqlCommand.Dispose();
            return output.ToString().TrimEnd();
        }
    }
}
