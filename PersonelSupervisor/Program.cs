using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonelSupervisor.App.Database;


namespace PersonelSupervisor
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbService = new DatabaseService();
            dbService.CreateDatabase();  // Veritabanı dosyasını oluştur
            dbService.CreateTableIfNotExists();  // Kullanıcılar tablosunu oluştur

            // Uygulamanın giriş penceresini başlatma
            var app = new App();
            app.Run(new MainWindow());
        }
    }
}

