using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cards.DataBase.SQLite;
using Cards.Droid.Databse.SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Cards.Droid.Databse.SQLite
{
  public class SQLite_Android: ISQLite
    {

        #region ISQLite implementation


        public string GetPath()

        {
            try
            {

                var dbName = "CardsOne.db3";
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var path = Path.Combine(documentsPath, dbName);
                return path;


            }
            catch (Exception f)
            {
                var error = f.ToString();
                return (error);
            }
        }
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }
        #endregion
    }
}