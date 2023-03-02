using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Libreria--------
//Revisión Rene Barrientos 0901-19-12640 fecha 2/03/2023
using System.Data.Odbc;

namespace NavegadorModelo
{
    class Conexion
    {
        //Clase de conexion --------------
        public OdbcConnection conexion()
        {
            //creacion de la conexion via ODBC
            OdbcConnection conn = new OdbcConnection("Dsn=colchoneria");
            try
            {
                conn.Open();
            }
            catch (OdbcException)
            {
                Console.WriteLine("Sin conexión");
            }
            return conn;
        }

        //metodo para cerrar la conexion
        public void cerrar_conexion(OdbcConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("conexion cerrada");
            }
        }
    }
}
