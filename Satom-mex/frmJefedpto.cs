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
    public partial class frmJefedpto : UserControl
    {
        public frmJefedpto()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opcionNuevo();
        }
        public void opcionNuevo()
        {
            txtApellidos.Enabled = true;
            txtNombre.Enabled = true;

            dtpFecha.Enabled = true;

            txtApellidos.Text = "";
            txtNombre.Text = "";

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        public void OpcionCancelar()
        {
            txtApellidos.Enabled = false;
            txtNombre.Enabled = false;

            dtpFecha.Enabled = false;

            txtApellidos.Text = "";
            txtNombre.Text = "";


            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }
        public void MostrarDatos_dgvJefe()
        {
            dgvJefe.DataSource = ClsJefeDpto.MostrarDatos();

            dgvJefe.Columns[0].HeaderText = "IdEmpleado";
            dgvJefe.Columns[1].HeaderText = "Nombre";
            dgvJefe.Columns[2].HeaderText = "Apellidos";
            dgvJefe.Columns[3].HeaderText = "Fecha Nacimiento";

            dgvJefe.Columns[0].Visible = false;

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            ClsJefeDpto Instancia = new ClsJefeDpto();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Apellidos = txtApellidos.Text.Trim();
            Instancia.FechaN = dtpFecha.Format.ToString();



            int respuesta = ClsJefeDpto.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Datos guardados con exito!!", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatos_dgvJefe();
                // limpia_cajas();
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos del Jefe", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmJefedpto_Load(object sender, EventArgs e)
        {
            OpcionCancelar();
            MostrarDatos_dgvJefe();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OpcionCancelar();
        }

        private void dgvJefe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgvJefe.Rows[e.RowIndex];
                txtIdJefe.Text = dgvJefe.Rows[e.RowIndex].Cells[0].Value.ToString();

                txtNombre.Text = dgvJefe.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtApellidos.Text = dgvJefe.Rows[e.RowIndex].Cells[2].Value.ToString();

                dtpFecha.Text = dgvJefe.Rows[e.RowIndex].Cells[3].Value.ToString();



                //cuando se selecciona la fila el boton guardar se desactiva  
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                HabilitaCajas();
            }catch(Exception){

            }
        }
        public void HabilitaCajas()

        {
            txtApellidos.Enabled = true;
            txtNombre.Enabled = true;

            dtpFecha.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
              if (MessageBox.Show("Esta Seguro que desea eliminar el Jefe Actual", "Esta Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsJefeDpto Instancia = new ClsJefeDpto();
                Instancia.IdJefe = Convert.ToInt32(txtIdJefe.Text);

                if (ClsJefeDpto.Eliminar(Instancia.IdJefe) > 0)
                {
                    MessageBox.Show("Jefe Eliminado Correctamente!", "Jefe Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvJefe();
                    //  OpcionEliminar();
                    limpia_cajas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Jefe", "Jefe No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }
        public void limpia_cajas()
        {
            txtApellidos.Text = "";
            txtNombre.Text = "";
         


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            ClsJefeDpto Instancia = new ClsJefeDpto();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Apellidos = txtApellidos.Text.Trim();
            Instancia.FechaN = dtpFecha.Format.ToString();
            Instancia.IdJefe = Convert.ToInt32(txtIdJefe.Text);


            int respuesta = ClsJefeDpto.Actualizar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Los datos del Jefe se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatos_dgvJefe();
                limpia_cajas();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MostrarDatos_dgvJefe();

         
        }
        
    }

}
