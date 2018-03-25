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
    public partial class frmProveedor : UserControl
    {
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opcionNuevo();
        }
        public void opcionNuevo()
        {
            txtCP.Enabled = true;
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtRFC.Enabled = true;

            txtNombre.Text = "";
            txtCP.Text = "";
            txtDireccion.Text = "";
            txtRFC.Text = "";

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OpcionCancelar();
        }
        public void OpcionCancelar()
        {
            txtCP.Enabled = true;
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtRFC.Enabled = true;

            txtNombre.Text = "";
            txtCP.Text = "";
            txtDireccion.Text = "";
            txtRFC.Text = "";

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsProveedor Instancia = new ClsProveedor();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.RFC = txtRFC.Text.Trim();
            Instancia.CP = txtCP.Text.Trim();



            int respuesta = ClsProveedor.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Datos guardados con exito!!", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatos_dgvProveedor();
                txtNombre.Text = "";
                txtCP.Text = "";
                txtDireccion.Text = "";
                txtRFC.Text = "";
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos del cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void MostrarDatos_dgvProveedor()
        {
            dgvProveedor.DataSource = ClsProveedor.MostrarDatos();

            dgvProveedor.Columns[0].HeaderText = "IdProveedor";
            dgvProveedor.Columns[1].HeaderText = "Nombre";
            dgvProveedor.Columns[2].HeaderText = "Ubicacion";
            dgvProveedor.Columns[3].HeaderText = "RFC";
            dgvProveedor.Columns[4].HeaderText = "CP";


            dgvProveedor.Columns[0].Visible = false;

        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            MostrarDatos_dgvProveedor();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsProveedor Instancia = new ClsProveedor();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.RFC = txtRFC.Text.Trim();
            Instancia.CP = txtCP.Text.Trim();

            Instancia.IdProveedor = Convert.ToInt32(txtIdp.Text);


            int respuesta = ClsProveedor.Actualizar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Los datos del Jefe se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatos_dgvProveedor();
                txtNombre.Text = "";
                txtCP.Text = "";
                txtDireccion.Text = "";
                txtRFC.Text = "";
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
              if (MessageBox.Show("Esta Seguro que desea eliminar el Proveedor Actual", "Esta Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsProveedor Instancia = new ClsProveedor();
                Instancia.IdProveedor = Convert.ToInt32(txtIdp.Text);

                if (ClsProveedor.Eliminar(Instancia.IdProveedor) > 0)
                {
                    MessageBox.Show("Proveedor Eliminado Correctamente!", "Proveedor Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvProveedor();
                    txtNombre.Text = "";
                    txtCP.Text = "";
                    txtDireccion.Text = "";
                    txtRFC.Text = "";
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Proveedor", "Proveedor No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgvProveedor.Rows[e.RowIndex];
                txtIdp.Text = dgvProveedor.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNombre.Text = dgvProveedor.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDireccion.Text = dgvProveedor.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtRFC.Text = dgvProveedor.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCP.Text = dgvProveedor.Rows[e.RowIndex].Cells[4].Value.ToString();

        
                //cuando se selecciona la fila el boton guardar se desactiva  
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;

               txtCP.Enabled = true;
               txtNombre.Enabled = true;
               txtDireccion.Enabled = true;
               txtRFC.Enabled = true;
            }
            catch (Exception)
            {

            }
        }
        }
    }

