using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Satom_mex
{
    class ClsAcceso
    {
        public string usuario = "";
        public string pass = "";



        public string segurity()
        {
            string output = "";
            string[] cadenas = { };
            ClsInicio inicio = new ClsInicio();
            cadenas = inicio.datosBaseDatos().Split('=', ';');

            MySqlConnection con = new MySqlConnection("Server=" + cadenas[1] + ";Database=" + cadenas[3] + "; User Id=" + cadenas[5] + ";Password=" + cadenas[7]);

            using (con)
            {
                string query = "select tblUsuario.intIdNivel from tblUsuario where vchNombre='" + usuario + "' and vchContrasenia='" + pass + "'";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                try
                {
                    output = cmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {

                    return output = "";

                }
                return output;

            }

        }
    }
}
