using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UsersApp.Model;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено не коректно";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Это поле введено не коректно";
                passBox.Background = Brushes.DarkRed;
            }
            else 
            {
                passBox.ToolTip = null;
                passBox.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = null;
                textBoxLogin.Background = Brushes.Transparent;
            }

            Users authUser = null;
            using (var db = new UsersAppDataBaseEntities())
            {
                authUser = db.Users.Where(b => b.login == login && b.pass == pass).FirstOrDefault();
            }

            if (authUser != null)
                MessageBox.Show("It's OK");
            else
                MessageBox.Show("Something went wrong");

            UserPageWindow userPageWindow = new UserPageWindow();
            userPageWindow.Show();
            Close();
        }

        private void Button_Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        
    }
}
