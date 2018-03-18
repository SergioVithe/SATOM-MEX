using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace Satom_mex
{
    class ClsConexion
    {
        public MySqlConnection conectar;
        public string servidor;
        public string bd;
        public string user;
        public string pass;
        public string cadenadesencriptada;

        public string recservidor
        {
            get { return servidor; }
            set { servidor = value; }
        }

        public string recbd
        {
            get { return bd; }
            set { bd = value; }
        }

        public string recuser
        {
            get { return user; }
            set { user = value; }
        }

        public string recpass
        {
            get { return pass; }
            set { pass = value; }
        }

        public string reccadenadesencriptada
        {
            get { return cadenadesencriptada; }
            set { cadenadesencriptada = value; }
        }


        public Boolean conexion()
        {
            try
            {
                conectar = new MySqlConnection(cadenadesencriptada);
                //System.Windows.Forms.MessageBox.Show("Conexion Establecida !!!");
                conectar.Open();

                return true;
            }
            catch (Exception)
            {
                return false;
                //System.Windows.Forms.MessageBox.Show("No se pudo conectar!!!");
            }
        }

        public static MySqlConnection ObtenerConexion()
        {
            string[] cadenas = { };
            ClsInicio inicio = new ClsInicio();
            cadenas = inicio.datosBaseDatos().Split('=', ';');
            MySqlConnection conectar = new MySqlConnection("Server=" + cadenas[1] + ";Database=" + cadenas[3] + "; User Id=" + cadenas[5] + ";Password=" + cadenas[7]);
            conectar.Open();
            return conectar;
        }

        public void creararchivo()
        {
            ClsDatos datos = new ClsDatos();
            string cadena;
            string filename = @"C:\datos\sysinit.ini";
            FileStream Stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(Stream);
            cadena = "Server=" + servidor + ";Database=" + bd + "; User Id=" + user + ";Password=" + pass;
            string cadenaencriptada = datos.Encriptar(cadena);
            writer.WriteLine(cadenaencriptada);
            writer.Close();
        }
    }
}
