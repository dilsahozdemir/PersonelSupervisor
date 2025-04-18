using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;

public static class DatabaseHelper
{
    private static string dbFile = "personel.db";

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection($"Data Source={dbFile}");
    }

    public static void InitializeDatabase()
    {
        if (!File.Exists(dbFile))
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        PasswordHash TEXT NOT NULL,
                        Role TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Personel (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Department TEXT,
                        Email TEXT
                    );
                ";
                command.ExecuteNonQuery();
            }
        }
    }
}
