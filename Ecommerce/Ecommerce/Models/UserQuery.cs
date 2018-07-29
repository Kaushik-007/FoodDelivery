using Ecommerce.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Ecommerce.Model
{
    public class UserQuery
    {
        static object locker = new object();
        SQLiteConnection s;
        public UserQuery()
        {
            s = SQLLiteType.GetDb();
        }
       

        //Insert 
        public int   InsertDetails(UserDB userDB)
        {
            lock (locker)
            {
                List<UserDB> items = (from p in s.Table<UserDB>() where p.UserName == userDB.UserName select p).ToList();
                if (items.Count > 0)
                {
                    return -1;
                }
                else
                {
                    var r=s.Insert(userDB);
                    return r;
                }
            }
        }

        //Get specific customer by ID
        public UserDB GetCustName(string name)
        {
            lock (locker)
            {
                return s.Table<UserDB>().LastOrDefault(t => t.UserName.Equals(name));
            }
        }
    }
}
