using Microsoft.Data.SqlClient;
using System;

namespace _4.AddMinion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string villainName = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries)[1];

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
                InsertMinionVillain(minionInfo, villainName, sqlConnection, sqlTransaction);
            }
            catch (Exception exception)
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

        private static void InsertMinionVillain(string[] minionInfo, string villainName, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTownName = minionInfo[2];

            int? townId = GetTown(minionTownName, sqlConnection, sqlTransaction);
            if (townId is null)
            {
                InsertTown(minionTownName, sqlConnection, sqlTransaction);
                townId = GetTown(minionTownName, sqlConnection, sqlTransaction);
            }

            int? villainId = GetVillain(villainName, sqlConnection, sqlTransaction);
            if (villainId is null)
            {
                InserVillain(villainName, sqlConnection, sqlTransaction);
                villainId = GetVillain(villainName, sqlConnection, sqlTransaction);
            }

            InsertMinion(minionName, minionAge, townId, sqlConnection, sqlTransaction);
            int minionId = GetMinion(minionName, sqlConnection, sqlTransaction);
            
            string query = @"INSERT INTO [MinionsVillains] ([MinionId], [VillainId]) VALUES (@MinionId, @VillainId)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlCommand.Parameters.AddWithValue("MinionId", minionId);
            sqlCommand.Parameters.AddWithValue("VillainId", villainId);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static int GetMinion(string minionName, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            string query = @"SELECT [Id] FROM [Minions] WHERE [Name] = @MinionName";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlCommand.Parameters.AddWithValue("MinionName", minionName);
            int minionId = (int) sqlCommand.ExecuteScalar();
            sqlCommand.Dispose();
            return minionId;
        }

        private static void InsertMinion(string minionName, int minionAge, int? townId, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            string query = @"INSERT INTO [Minions] ([Name], [Age], [TownId]) VALUES (@MinionName, @MinionAge, @TownId)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlCommand.Parameters.AddWithValue("MinionName", minionName);
            sqlCommand.Parameters.AddWithValue("MinionAge", minionAge);
            sqlCommand.Parameters.AddWithValue("TownId", townId);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
        }

        private static void InserVillain(string villainName, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            string query = @"INSERT INTO [Villains] ([Name], [EvilnessFactorId]) VALUES (@VillainName, 4)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlCommand.Parameters.AddWithValue("VillainName", villainName);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine($"Villain {villainName} was added to the database.");
            sqlCommand.Dispose();
        }

        private static int? GetVillain(string villainName, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            string query = @"SELECT [Id] FROM [Villains] WHERE [Name] = @VillainName";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlCommand.Parameters.AddWithValue("VillainName", villainName);
            int? villainsId = (int?) sqlCommand.ExecuteScalar();
            sqlCommand.Dispose();
            return villainsId;
        }

        private static void InsertTown(string townName, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            string query = @"INSERT INTO [Towns] ([Name]) VALUES (@TownName)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlCommand.Parameters.AddWithValue("TownName", townName);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine($"Town {townName} was added to the database.");
            sqlCommand.Dispose();
        }

        private static int? GetTown(string townName, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            string query = @"SELECT [Id] FROM [Towns] WHERE [Name] = @TownName";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
            sqlCommand.Parameters.AddWithValue("TownName", townName);
            int? townsId = (int?) sqlCommand.ExecuteScalar();
            sqlCommand.Dispose();
            return townsId;
        }
    }
}
