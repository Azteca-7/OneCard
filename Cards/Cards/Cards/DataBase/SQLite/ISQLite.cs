
using System;
using System.Collections.Generic;
using System.Text;

namespace Cards.DataBase.SQLite
{
   
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
