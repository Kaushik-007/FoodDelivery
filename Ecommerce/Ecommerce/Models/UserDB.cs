using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Ecommerce.Model
{
    public class UserDB
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserDB()
        {

        }
    }
}
