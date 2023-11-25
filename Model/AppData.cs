using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Model
{
    [Table("Users")]
    internal class AppData 
    {
            public int Id { get; set; }
            private string login;
            private string email;
            private string pass;

            public string Login
            {
                get { return login; }
                set { login = value; }
            }
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            public string Pass
            {
                get { return pass; }
                set { pass = value; }
            }

            public AppData() { }

            public AppData(string login, string email, string pass)
            {
                this.login = login;
                this.email = email;
                this.pass = pass;
            }
        }
}
