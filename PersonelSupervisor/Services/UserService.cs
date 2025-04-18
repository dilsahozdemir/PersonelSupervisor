using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using PersonelSupervisor.App.Models;
using System;

namespace PersonelSupervisor.Services
{
    public class UserService
    {
        private static string dbFile = "personel.db";  // Veritabanı dosyasının adı

        // Yeni kullanıcı eklemek
        public void AddUser(string username, string passwordHash, string role)
        {
            string connectionString = $"Data Source={dbFile}";
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)";
                var command = connection.CreateCommand();
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                command.Parameters.AddWithValue("@Role", role);
                command.ExecuteNonQuery();
            }
        }

        // Kullanıcıyı ad ile bulma
        public User GetUserByUsername(string username)
        {
            string connectionString = $"Data Source={dbFile}";
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE Username = @Username";
                var command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@Username", username);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            PasswordHash = reader.GetString(2),
                            Role = reader.GetString(3)
                        };
                    }
                }
            }
            return null; // Kullanıcı bulunamadı
        }
    }
}

