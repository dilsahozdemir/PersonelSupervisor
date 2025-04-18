using SQLitePCL;
using System.Configuration;
using System.Data;
using System.Windows;
using System;

namespace PersonelSupervisor.App
{
    public partial class App : Application
    {
        // Uygulama başlatıldığında yapılacak işlemler buraya eklenebilir.
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Burada başlangıç işlemleri yapılabilir (örneğin, kullanıcı doğrulama vb.)
        }
    }
}
