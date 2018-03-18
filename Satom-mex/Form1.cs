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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            mostrar();
            pag_11.BringToFront();
            pag_11.Enabled = true;
            pag_11.Visible = true;
                
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pag_11.Visible = false;
            sucursal_11.Visible = false;
            label2.Text = "Bienvenido";
            PanelSeleccion();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            mostrar();
            sucursal_11.Enabled = true;
            sucursal_11.Visible = true;
            sucursal_11.BringToFront();
            
           
        }

        public void mostrar()
        {
            sucursal_11.Visible = false;
            sucursal_11.Enabled = false;

            frmClientes1.Enabled = false;
            frmClientes1.Visible = false;

            frmEmpleado1.Enabled = false;
            frmEmpleado1.Visible = false;

            frmJefedpto1.Enabled = false;
            frmJefedpto1.Visible = false;

            frmModopago1.Enabled = false;
            frmModopago1.Visible = false;

            frmProveedor1.Enabled = false;
            frmProveedor1.Visible = false;

            frmEstadistica1.Enabled = false;
            frmEstadistica1.Visible = false;

        }

        private void btnMenuPrincipal2_Click(object sender, EventArgs e)
        {
            label2.Text = "Bienvenido";
            mostrar();
            
            PanelSeleccion();
            panel4.Visible = true;
        }

        private void btnMenuSucursal_Click(object sender, EventArgs e)
        {
            label2.Text = "Categorías";
            mostrar();
            sucursal_11.Enabled = true;
            sucursal_11.Visible = true;
            sucursal_11.BringToFront();

            PanelSeleccion();
            panel5.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMenuClientes_Click(object sender, EventArgs e)
        {
            label2.Text = "Clientes";
            PanelSeleccion();
            panel6.Visible = true;
            frmClientes1.BringToFront();
            frmClientes1.Enabled = true;
            frmClientes1.Visible = true;
              

        }

        private void btnMenuEmpleados_Click(object sender, EventArgs e)
        {
            label2.Text = "Empleados";
            frmEmpleado1.BringToFront();
            frmEmpleado1.Enabled = true;
            frmEmpleado1.Visible = true;
              
            PanelSeleccion();
            panel7.Visible = true;
        }
        public void PanelSeleccion()
        {
            
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            label2.Text = "Jefe Dpto";
            frmJefedpto1.BringToFront();
            frmJefedpto1.Enabled = true;
            frmJefedpto1.Visible = true;

            PanelSeleccion();
            panel8.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label2.Text = "Modo de pago";
            frmModopago1.BringToFront();
            frmModopago1.Enabled = true;
            frmModopago1.Visible = true;

            PanelSeleccion();
            panel9.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "Proveedores";
            frmProveedor1.BringToFront();
            frmProveedor1.Enabled = true;
            frmProveedor1.Visible = true;

            PanelSeleccion();
            panel10.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "Estadística";
            frmEstadistica1.BringToFront();
            frmEstadistica1.Enabled = true;
            frmEstadistica1.Visible = true;

            PanelSeleccion();
            panel11.Visible = true;
        }
    }
}
