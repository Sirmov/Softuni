using Microsoft.Data.SqlClient;
using System;

namespace _6.RemoveVillain
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
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                int villainId = int.Parse(Console.ReadLine());
                string villainName = GetVillainName(villainId, sqlTransaction, sqlConnection);
                int minionsReleased = DeleteMinionsByVillain(villainId, sqlTransaction, sqlConnection);
                int villainsDeleted = DeleteVillain(villainId, sqlTransaction, sqlConnection);

                if (villainsDeleted == 0 && minionsReleased == 0)
                {
                    Console.WriteLine("No such villain was found.");
                }
                else if (villainsDeleted == 1)
                {
                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{minionsReleased} minions were released.");
                }
                else if (villainsDeleted > 1 || (villainsDeleted == 0 && minionsReleased > 0))
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                throw;
            }
            finally
            {
                sqlTransaction.Commit();
            }

            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private static string GetVillainName(int villainId, SqlTransaction sqlTransaction, SqlConnection sqlConnection)
        {
            string query = @"SELECT [Name] FROM [Villains] WHERE [Id] = @VillainId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlCommand.Parameters.AddWithValue("VillainId", villainId);
            string villainName = (string) sqlCommand.ExecuteScalar();
            sqlCommand.Dispose();
            return villainName;
        }

        private static int DeleteVillain(int villainId, SqlTransaction sqlTransaction, SqlConnection sqlConnection)
        {
            string query = @"DELETE FROM [Villains]
                            WHERE [Id] = @VillainId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlCommand.Parameters.AddWithValue("VillainId", villainId);
            int affectedRows = sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            return affectedRows;
        }

        private static int DeleteMinionsByVillain(int villainId, SqlTransaction sqlTransaction, SqlConnection sqlConnection)
        {
            string query = @"DELETE FROM [MinionsVillains] 
                            WHERE [VillainId] = @VillainId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlCommand.Parameters.AddWithValue("VillainId", villainId);
            int affectedRows = sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            return affectedRows;
        }
    }
}
