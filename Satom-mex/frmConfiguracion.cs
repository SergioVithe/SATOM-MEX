using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satom_mex
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void txtConectar_Click(object sender, EventArgs e)
        {
            string sFileName = @"C:\datos\sysinit.ini";
            ClsConexion conexion = new ClsConexion();
            conexion.bd = txtBaseDatos.Text;
            conexion.pass = txtPassword.Text;
            conexion.servidor = txtServidor.Text;
            conexion.user = txtUsuario.Text;

            string cadena = "Server=" + conexion.servidor + ";Database=" + conexion.bd + "; User Id=" + conexion.user + ";Password=" + conexion.pass;

            conexion.cadenadesencriptada = cadena;

            if (conexion.conexion())
            {
                File.Delete(sFileName);
                lblEstado.ForeColor = System.Drawing.Color.DarkGreen;
                lblEstado.Text = "Conexión estable";

                conexion.creararchivo();

               // frmLogin login = new frmLogin();
                //login.Show();
                Hide();
            }
            else if (conexion.conexion() == false)
            {
                lblEstado.ForeColor = System.Drawing.Color.DarkRed;
                lblEstado.Text = "Conexión no establecida";
            }
 
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            ClsConexion conexion = new ClsConexion();
            if (txtBaseDatos.Text == string.Empty)
            {
                txtBaseDatos.Focus();
            }
            else
            {

                string cadena = "Server=" + txtServidor.Text + ";Database=" + txtBaseDatos.Text + "; User Id=" + txtUsuario.Text + ";Password=" + txtPassword.Text;
                conexion.cadenadesencriptada = cadena;
                if (conexion.conexion())
                {
                    lblEstado.ForeColor = System.Drawing.Color.DarkGreen;
                    lblEstado.Text = "Conexión estable";
                }
                else if (conexion.conexion() == false)
                {
                    lblEstado.ForeColor = System.Drawing.Color.DarkRed;
                    lblEstado.Text = "Conexión no establecida";
                }
            }
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            string sFileName = @"C:\datos\sysinit.ini;";

            ClsDatos datos = new ClsDatos();
            if (File.Exists(sFileName))
            {
                StreamReader ar = new StreamReader(@"C:\datos\sysinit.ini;");
                string linea = ar.ReadLine();
                ar.Close();
                string[] cadenas = { };
                ClsInicio inicio = new ClsInicio();
                cadenas = inicio.datosBaseDatos().Split('=', ';');
                ClsConexion conexion = new ClsConexion();
                conexion.bd = cadenas[3];
                conexion.pass = cadenas[7];
                conexion.servidor = cadenas[1];
                conexion.user = cadenas[5];
                string cadena = "Server=" + conexion.servidor + ";Database=" + conexion.bd + "; User Id=" + conexion.user + ";Password=" + conexion.pass;

                conexion.cadenadesencriptada = datos.Desencriptar(cadena);
                if (conexion.conexion())
                {


                 //   frmLogin login = new frmLogin();
                   // login.Show();
                    Hide();
                }
                else if (conexion.conexion() == false)
                {
                    lblEstado.ForeColor = System.Drawing.Color.DarkRed;
                    lblEstado.Text = "Conexión no establecida";
                }

            }
        }
    }
}
