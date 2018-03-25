using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Satom_mex
{
    class ClsInicio
    {



        string sFileName = "";
        public string datosBaseDatos()
        {
            
            
                sFileName = @"C:\datos\feedback.ini";
            

            string cadenas = "";

            if (File.Exists(sFileName))
            {
                ClsConexion conexion = new ClsConexion();
                ClsDatos datos = new ClsDatos();
                FileStream fs = new FileStream(sFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                string sContent = sr.ReadToEnd();
                conexion.cadenadesencriptada = datos.Desencriptar(sContent);
                cadenas = conexion.cadenadesencriptada;
                fs.Close();
                sr.Close();
            }
            return cadenas;
        }


        public string datosBaseDatosLeer(string ruta)
        {
            string sFileNames = "";
            sFileNames = @ruta;


            string cadenas = "";

            if (File.Exists(sFileNames))
            {
                ClsConexion conexion = new ClsConexion();
                ClsDatos datos = new ClsDatos();
                FileStream fs = new FileStream(sFileNames, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                string sContent = sr.ReadToEnd();
                conexion.cadenadesencriptada = datos.Desencriptar(sContent);
                cadenas = conexion.cadenadesencriptada;
                fs.Close();
                sr.Close();
            }
            return cadenas;
        }

        public void abrir()
        {
            
            if (File.Exists(sFileName))
            {
                frmLogin Logueo = new frmLogin();
                Logueo.Show();
            }
        }
    }
}
