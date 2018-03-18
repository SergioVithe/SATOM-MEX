using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satom_mex
{
    public partial class frmClientes : UserControl
    {
        public int peso;
        public double estatura;
        public frmClientes()
        {
          
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
      
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            ClsClientes Instancia = new ClsClientes();

                Instancia.Nombre = txtNombre.Text.Trim();
                Instancia.Apellidos = txtApellidos.Text.Trim();
                Instancia.Direccion = txtDomicilio.Text.Trim();
                Instancia.Correo = txtCorreo.Text.Trim();
                Instancia.Telefono = txtTelefono.Text.Trim();
                Instancia.FechaN = dtpFecha.Format.ToString();
                Instancia.IMC = Convert.ToDouble(lbl_Imc.Text);
                Instancia.Estado = 1;
               

                int respuesta = ClsClientes.Guardar(Instancia);
                if (respuesta > 0)
                {
                    MessageBox.Show("Datos guardados con exito!!", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvClientes();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar los datos del cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //limpia_cajas();
                         
        }
        public void MostrarDatos_dgvClientes()
        {
            dgvClientes.DataSource = ClsClientes.MostrarDatos();
            this.dgvClientes.Columns["IdCliente"].Visible = false;
           
            //Estilo titulo
            this.dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 39, 40);  //(44, 62, 80); //argb
            this.dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10);
            this.dgvClientes.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10);
            //Estilo seleccion 
            this.dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            this.dgvClientes.DefaultCellStyle.SelectionForeColor = Color.White;
            //Estilo borde celda 
            this.dgvClientes.GridColor = Color.FromArgb(41, 39, 40); //(44, 62, 80);
            //Ajustable
            this.dgvClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvClientes.ScrollBars = ScrollBars.Both;
            this.dgvClientes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            MostrarDatos_dgvClientes();
            OpcionCancelar();
        }

        private void txtEstatura_Leave(object sender, EventArgs e)
        {
            peso=Convert.ToInt16(txtpeso.Text);
            estatura=Convert.ToDouble(txtEstatura.Text);
            lbl_Imc.Text = (Math.Round(peso / (estatura * estatura),1)).ToString();
            //calIMC = peso / (estatura * estatura);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opcionNuevo();
        }
        public void OpcionCancelar()
        {
            txtApellidos.Enabled = false;
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            txtDomicilio.Enabled = false;
            txtCorreo.Enabled = false;
            txtEstatura.Enabled = false;
            txtpeso.Enabled = false;
            dtpFecha.Enabled = false;

            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDomicilio.Text = "";
            txtCorreo.Text = "";
            txtEstatura.Text="";
            txtpeso.Text="";
            lbl_Imc.Text = "";
      

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }
        public void opcionNuevo()
        {
            txtApellidos.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDomicilio.Enabled = true;
            txtCorreo.Enabled = true;
            txtEstatura.Enabled = true;
            txtpeso.Enabled = true;
            dtpFecha.Enabled = true;

            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDomicilio.Text = "";
            txtCorreo.Text = "";
            txtEstatura.Text = "";
            txtpeso.Text = "";
            lbl_Imc.Text = "";
            btnGuardar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OpcionCancelar();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgvClientes.Rows[e.RowIndex];
                txt_Id.Text = row.Cells["IdCliente"].Value.ToString();

                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = row.Cells["Apellidos"].Value.ToString();
                txtDomicilio.Text = row.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = row.Cells["Correo"].Value.ToString();
                dtpFecha.Text = row.Cells["FechaN"].Value.ToString();
                lbl_Imc.Text = row.Cells["IMC"].Value.ToString();
                txt_est.Text = row.Cells["Estado"].Value.ToString();

            }
            catch (Exception)
            {

                //    throw;
            }

            //    txtSucursal.Text = row.Cells["Sucursal"].Value.ToString();
            //textBox1.Text = row.Cells["IdSucursal"].Value.ToString();

            //cuando se selecciona la fila el boton guardar se desactiva  
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            HabilitaCajas();
        }
        public void HabilitaCajas()
        {
            txtApellidos.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDomicilio.Enabled = true;
            txtCorreo.Enabled = true;
            txtEstatura.Enabled = true;
            txtpeso.Enabled = true;
            dtpFecha.Enabled = true;
        }
        public void limpiarcajas()
        {
            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDomicilio.Text = "";
            txtCorreo.Text = "";
            txtEstatura.Text = "";
            txtpeso.Text = "";
            lbl_Imc.Text = "";
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsClientes Instancia = new ClsClientes();

            Instancia.IdCliente =Convert.ToInt32(txt_Id.Text.Trim());
            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Apellidos = txtApellidos.Text.Trim();
            Instancia.Direccion = txtDomicilio.Text.Trim();
            Instancia.Correo = txtCorreo.Text.Trim();
            Instancia.Telefono = txtTelefono.Text.Trim();
            Instancia.FechaN = dtpFecha.Format.ToString();
            Instancia.IMC = Convert.ToDouble(lbl_Imc.Text);
            Instancia.Estado = 1;
               
            if (ClsClientes.Actualizar(Instancia) > 0)
            {
                MessageBox.Show("Datos actualizados con exito!!", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatos_dgvClientes();
                limpiarcajas();
            }
            else
            {
                MessageBox.Show("Datos no actualizados", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
