using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Satom_mex
{
    public class Clsconf : System.Windows.Forms.ApplicationContext
    {
       
        public Clsconf()
        {

            // frmConfiguracion confi = new frmConfiguracion();
            //confi.Show();
            ClsDatos datos = new ClsDatos();
            ClsInicio inicio = new ClsInicio();
            ClsConexion conexion = new ClsConexion();
           
            string sFileName = @"C:\datos\feedback.ini";


            if (File.Exists(sFileName))
            {
                FileStream fs = new FileStream(sFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs);

                string sContent;
                sContent = sr.ReadLine();

                conexion.cadenadesencriptada = datos.Desencriptar(sContent);
                String cad = conexion.cadenadesencriptada;
                fs.Close();
                sr.Close();
                string[] cadenas = { };

                cadenas = cad.Split('=', ';');

                conexion.bd = cadenas[3];
                conexion.pass = cadenas[7];
                conexion.servidor = cadenas[1];
                conexion.user = cadenas[5];
                string cadena = "Server=" + conexion.servidor + ";Database=" + conexion.bd + "; User Id=" + conexion.user + ";Password=" + conexion.pass;

                conexion.cadenadesencriptada = cadena;
                if (conexion.conexion())
                {
                    //frmsplash splash = new frmsplash();
                    //splash.Show();

                    frmLogin log = new frmLogin();
                    log.Show();
                   

                }
                else if (conexion.conexion() == false)
                {
                    frmConfiguracion s = new frmConfiguracion();
                    s.Show();

                }

            }
            else
            {
                frmConfiguracion confi = new frmConfiguracion();
                confi.Show();
            }



        }
    }
}
