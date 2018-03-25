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
    public partial class frmModopago : UserControl
    {
        public frmModopago()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opcionNuevo();
        }
        public void opcionNuevo()
        {
            txtDesc.Enabled = true;
            txtNombre.Enabled = true;
                   
            txtNombre.Text = "";
            txtDesc.Text = "";
          
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OpcionCancelar();
        }
        public void OpcionCancelar()
        {
            txtDesc.Enabled = true;
            txtNombre.Enabled = true;

            txtNombre.Text = "";
            txtDesc.Text = "";

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsMPago Instancia = new ClsMPago();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Desc = txtDesc.Text.Trim();
           


            int respuesta = ClsMPago.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Datos guardados con exito!!", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatos_dgvPago();
                txtNombre.Text = "";
                txtDesc.Text = "";
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos del cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
              
        }
        public void MostrarDatos_dgvPago()
        {
            dgvPago.DataSource = ClsMPago.MostrarDatos();

            dgvPago.Columns[0].HeaderText = "IdEmpleado";
            dgvPago.Columns[1].HeaderText = "Nombre";
            dgvPago.Columns[2].HeaderText = "Descripcion";
        

            dgvPago.Columns[0].Visible = false;

        }

        private void frmModopago_Load(object sender, EventArgs e)
        {
            MostrarDatos_dgvPago();
        }

        private void dgvPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgvPago.Rows[e.RowIndex];
                txtIdPago.Text = dgvPago.Rows[e.RowIndex].Cells[0].Value.ToString();

                txtNombre.Text = dgvPago.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDesc.Text = dgvPago.Rows[e.RowIndex].Cells[2].Value.ToString();

             


                //cuando se selecciona la fila el boton guardar se desactiva  
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;

                txtNombre.Enabled = true;
                txtDesc.Enabled = true;
            }
            catch (Exception)
            {

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsMPago Instancia = new ClsMPago();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Desc = txtDesc.Text.Trim();
        
            Instancia.IdModo = Convert.ToInt32(txtIdPago.Text);


            int respuesta = ClsMPago.Actualizar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Los datos del Jefe se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatos_dgvPago();
                txtDesc.Text = "";
                txtNombre.Text = "";
                txtIdPago.Text = "";
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MostrarDatos_dgvPago();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Modo de pago Actual", "Esta Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsMPago Instancia = new ClsMPago();
                Instancia.IdModo = Convert.ToInt32(txtIdPago.Text);

                if (ClsMPago.Eliminar(Instancia.IdModo) > 0)
                {
                    MessageBox.Show("Modo de pago Eliminado Correctamente!", "Modo de pago Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvPago();
                    //  OpcionEliminar();
                    txtDesc.Text = "";
                    txtNombre.Text = "";
                    txtIdPago.Text = "";
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Modo de pago", "Modo de pago No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }
    }
}
