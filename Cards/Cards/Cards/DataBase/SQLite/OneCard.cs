
using System;
using System.Collections.Generic;
using System.Text;

namespace Cards.DataBase.SQLite
{
    public class OneCard
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Tarjeta { get; set; }//[Tarjeta] NVARCHAR(255) NULL,
        public string Cuenta { get; set; }// [Cuenta] NVARCHAR(255) NULL,





        public string Tipo { get; set; }//  [Tipo] NVARCHAR(255) NULL,
        public string Estatus { get; set; }// [Estatus] NVARCHAR(255) NULL,
        public string Nombres { get; set; }//[Nombres] NVARCHAR(255) NULL,
        public string ApePat { get; set; }//[ApePat] NVARCHAR(255) NULL,
        public string ApeMat { get; set; }//[ApeMat] NVARCHAR(255) NULL,
        public string Sucursal { get; set; }//[Sucursal] NVARCHAR(255) NULL,
        public string Empleado { get; set; }//[Empleado] NVARCHAR(255) NULL,
        public string RFC { get; set; }//[RFC] NVARCHAR(255) NULL,
        public string CURP { get; set; }//[CURP] NVARCHAR(255) NULL,
        public string NSS { get; set; }// [NSS] NVARCHAR(255) NULL,
        public string FNac { get; set; }//[FNac] NVARCHAR(255) NULL,
        public string Saldo { get; set; }// [Saldo] NVARCHAR(255) NULL


    }
}
