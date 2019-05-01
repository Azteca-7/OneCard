
using System;
using System.Collections.Generic;
using System.Text;

namespace Cards.DataBase.SQLite
{
    public class UserApp
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }//[IdUser] NUMERIC(18)   IDENTITY(1, 1) NOT NULL,
        public string Usuario { get; set; }// [Usuario]  NVARCHAR(MAX) NULL,
        public string Password { get; set; }//[Password] NVARCHAR(MAX) NULL,
        public string ConfirPassword { get; set; }// [Saldo] NUMERIC(18)   NULL,
        public string Tarjeta { get; set; }//[Tarjeta] NVARCHAR(MAX) NULL,
        //public int Saldo { get; set; }// [Saldo] NUMERIC(18)   NULL,
        //public int Cuenta { get; set; }//[Cuenta] NUMERIC(18)   NULL
    }
    
}
// firs change sqlite  crudsqlite_obj.AddUserAppSqlite(Email_v,Pass_v, ConfirPass_v, Card_v);