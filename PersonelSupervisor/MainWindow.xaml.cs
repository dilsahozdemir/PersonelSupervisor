using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace PersonelSupervisor.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Kullanıcı adı ve şifreyi al
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Burada kullanıcı adı ve şifreyi kontrol et
            if (IsValidLogin(username, password))
            {
                // Eğer doğruysa, giriş başarılı, yeni sayfaya yönlendir
                MessageBox.Show("Giriş Başarılı!");
                // Burada yeni sayfaya geçiş işlemi yapabilirsiniz.
            }
            else
            {
                // Hatalı giriş
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
            }
        }

        // Kullanıcı adı ve şifreyi kontrol etme fonksiyonu
        private bool IsValidLogin(string username, string password)
        {
            // Bu örnek için basit bir kontrol kullanıyoruz. Gerçek dünyada veritabanı ile kontrol edilir.
            // Örneğin, veritabanından kullanıcıyı aramak yerine, burada sabit değerler kullanacağız.
            return username == "admin" && password == "admin"; // Örnek giriş bilgileri
        }
    }
}

