using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace PersonelSupervisor.App.Database
{
    public class DatabaseService
    {
        private static string dbFile = "personel.db";  // Veritabanı dosyasının adı

        // Veritabanı dosyasını oluştur
        public void CreateDatabase()
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), dbFile);  // Veritabanı dosyasının yolu

            if (!File.Exists(dbPath))
            {
                try
                {
                    // SQLite veritabanını oluştur
                    SqliteConnection.CreateFile(dbPath);
                    Console.WriteLine("Veritabanı dosyası oluşturuldu: " + dbPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Veritabanı dosyası zaten var.");
            }
        }

        // Kullanıcılar tablosunu oluştur
        public void CreateTableIfNotExists()
        {
            try
            {
                string connectionString = $"Data Source={dbFile}";
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL,
                            PasswordHash TEXT NOT NULL,
                            Role TEXT NOT NULL
                        )";
                    var command = connection.CreateCommand();
                    command.CommandText = createTableQuery;
                    command.ExecuteNonQuery();
                    Console.WriteLine("Tablo oluşturuldu veya zaten mevcut.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
        }
    }
}
