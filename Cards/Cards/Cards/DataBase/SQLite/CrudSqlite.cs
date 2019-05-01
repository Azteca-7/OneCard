
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cards.DataBase.SQLite
{
    public class CrudSqlite
    {
        private SQLiteConnection _connection;
        private static CrudSqlite _instance;
        public static CrudSqlite Instance => _instance ?? (_instance = new CrudSqlite());
        public CrudSqlite()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();

            _connection.CreateTable<UserApp>();
        }

        public async Task<IEnumerable<UserApp>> GetDUserApp()
        {
            return (from t in _connection.Table<UserApp>()
                    select t).ToList();
        }

        public UserApp GetUserApp_(int id)
        {

            return _connection.Table<UserApp>().FirstOrDefault(t => t.ID == id);


        }

        public void DeleteUserApp(int id)
        {
            try
            {
                _connection.Delete<UserApp>(id);
            }
            catch (Exception f)
            {
                var error = f.ToString();
            }
        }

        #region Add user in the date base sqilite

        public async void AddUserAppSqlite(string usuario_p, string password_p, string ConfirPassword_p, string Tarjeta_p)
        {
            try
            {

                var newUserApp = new UserApp
                {
                    Usuario = usuario_p,
                    Password = password_p,
                    ConfirPassword = ConfirPassword_p,
                    Tarjeta = Tarjeta_p,
                };

                _connection.Insert(newUserApp);
                // get list data
                var listEnumerable = await CrudSqlite.Instance.GetDUserApp();

            }
            // insert line of code example 
            catch (Exception f)
            {
                var error = f.ToString();
            }
        }
        #endregion

        #region Deleate user in sqlite

        public void DeleateAppSqlite(string usuario_p, string password_p, string ConfirPassword_p, string Tarjeta_p)
        {
            try
            {
                var DelateUserApp = new UserApp
                {
                    Usuario = usuario_p,
                    Password = password_p,
                    ConfirPassword = ConfirPassword_p,
                    Tarjeta = Tarjeta_p,
                };

                _connection.Delete(DelateUserApp);
            }
            catch (Exception f)
            {
                var error = f.ToString();
            }
        }
        #endregion

        #region create new table One Card
        //Validation table One Card
        public void CreatenewtableOneCard(int Card_p, string Cuenta_p)
        {
           


            try
            {

                SQLiteCommand command = new SQLiteCommand(_connection);
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CardsOne.db3");
                var db = new SQLiteConnection(databasePath);
                TableMapping map = new TableMapping(typeof(SqlDbType));
                object[] ps = new object[0];
                Int32 tableCount = _connection.Query(map, "SELECT * FROM sqlite_master WHERE type = 'table' AND name = 'OneCard'", ps).Count;
                if (tableCount == 0)
                {
                    // db.Query<DBAgenda>("CREATE TABLE TableCalendarDroid (ID, IDV int(20), HInicio DateTime, HFin DateTime )");
                    //  db.Query<DBAgenda>("INSERT INTO TableCalendarDroid (IDV, HInicio, HFin) VALUES ('" + IDC + "', '" + FI + "','" + FF + "');");
                    db.Query<OneCard>("CREATE TABLE OneCard (Tarjeta int(20), Cuenta string )");
                    //var db_ = new SQLiteConnection(databasePath);
                    //DataSet ds = new DataSet();
                    //var query = db.Query<OneCard>("INSERT INTO OneCard (Tarjeta,Cuenta) VALUES (023007,"1084379");
                    //foreach ()
                    //{
                        var NewCalendarDroid = new OneCard
                        {

                            Tarjeta = Card_p,
                            Cuenta = Cuenta_p

                        };
                    //}
                    _connection.Insert(NewCalendarDroid);

                }
                else if (tableCount == 1)
                {

                    var NewCalendarDroid = new OneCard
                    {
                        //IDV = IDC,
                        //HInicio = FechaInicio,
                        //HFin = FechaFin
                        Tarjeta = Card_p,
                        Cuenta = Cuenta_p
                    };
                    _connection.Insert(NewCalendarDroid);
                }
                else
                {
                    throw new Exception("More than one table by the name of " + " exists in the database.", null);
                }
              
                _connection.Close();
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
        }

       
        #endregion

    }
}
