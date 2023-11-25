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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using UsersApp.Model;
using static System.Net.Mime.MediaTypeNames;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       
        public MainWindow()
        {
           
            InitializeComponent();
          
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass2 = passBox2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

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
            else if (pass != pass2)
            {
                passBox2.ToolTip = "Это поле введено не коректно";
                passBox2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Это поле введено не коректно";
                textBoxEmail.Background = Brushes.DarkRed;
            }

            else 
            {
                textBoxEmail.ToolTip = null;
                textBoxEmail.Background = Brushes.Transparent;
                textBoxLogin.ToolTip = null;
                textBoxLogin.Background = Brushes.Transparent;
                passBox2.ToolTip = null;
                passBox2.Background = Brushes.Transparent;
                passBox.ToolTip = null;
                passBox.Background = Brushes.Transparent;

                MessageBox.Show("All good");

           
                Users newUser = new Users()
                {

                    login = login,
                    email = email,
                    pass = pass

                };

                using (var db = new UsersAppDataBaseEntities())
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();

                    AuthWindow authWindow = new AuthWindow();
                    authWindow.Show();
                    Close();
                }
            }
            
        }

        private void Button_Come_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }
    }
}
