using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satom_mex
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtPassword.Text != "")
            {
                ClsAcceso acceso = new ClsAcceso();
                acceso.pass = txtPassword.Text;
                acceso.usuario = txtUsuario.Text;

                string mensaje = "";
                switch (acceso.segurity())
                {
                    case "1":
                        //    mensaje = "Bienvenido Administrador";
                        //  System.Windows.Forms.MessageBox.Show(mensaje);
                        //frmPrincipal principal = new frmPrincipal();
                        Form1 a = new   Form1();
                        a.Show();
                        //principal.Show();
                        Hide();

                        break;
                    case "":
                        mensaje = "Usuario no encontrado";
                        System.Windows.Forms.MessageBox.Show(mensaje);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                string notificacion = "Ingrese el usuario y la contraseña";
                System.Windows.Forms.MessageBox.Show(notificacion);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
