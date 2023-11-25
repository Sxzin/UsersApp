using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using UsersApp.Model;

namespace UsersApp.Model
{
    [Table("Users")]
    internal class ApplicationContext : DbContext   
    {
        public static UsersAppDataBaseEntities db = new UsersAppDataBaseEntities();
        public DbSet<Users> Users { get; set; }
        public ApplicationContext() : base("UsersAppDataBaseEntities") { }
    }
}
