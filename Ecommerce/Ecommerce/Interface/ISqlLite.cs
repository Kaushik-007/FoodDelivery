using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Ecommerce.Interface
{


    public class SQLLiteType
    {
        public static SQLiteConnection GetDb()
        {
            SQLiteConnection db = null;
            var databasePath = "";
            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ecommerce.db");
            }
            else
            {
                databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer), "Ecommerce.db");
            }
            db = new SQLiteConnection(databasePath);
            return db;
        }
    }
}
