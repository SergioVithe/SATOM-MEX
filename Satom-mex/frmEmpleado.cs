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
    public partial class frmEmpleado : UserControl
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            MostrarDatos_dgvEmpleados();
            OpcionCancelar();
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
           
            cmbestado.Enabled = true;

            txtApellidos.Text = "";
            txtNombre.Text = "";

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsEmpleado Instancia = new ClsEmpleado();
            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Apellidos = txtApellidos.Text.Trim();
            Instancia.FechaN = dtpFecha.Format.ToString();
            Instancia.Salario =Convert.ToDouble( txtsalario.Text);
            Instancia.Estado = 1;



            int respuesta = ClsEmpleado.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Empleado Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("No se pudo guardar el Empleado", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            limpia_cajas();
            MostrarDatos_dgvEmpleados();
        }
        public void limpia_cajas()
        {
            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtsalario.Text = "";


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgvEmpleados.Rows[e.RowIndex];
                txtIdEmpleado.Text = dgvEmpleados.Rows[e.RowIndex].Cells[0].Value.ToString();
                dteRegistro.Text = dgvEmpleados.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNombre.Text = dgvEmpleados.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtApellidos.Text = dgvEmpleados.Rows[e.RowIndex].Cells[3].Value.ToString();

                dtpFecha.Text = dgvEmpleados.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtsalario.Text = dgvEmpleados.Rows[e.RowIndex].Cells[5].Value.ToString();
                cmbestado.Text = dgvEmpleados.Rows[e.RowIndex].Cells[6].Value.ToString();


                //cuando se selecciona la fila el boton guardar se desactiva  
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                HabilitaCajas();
            }
            catch (Exception)
            {
            }
        }
        public void HabilitaCajas()
        {
            txtApellidos.Enabled = true;
            txtNombre.Enabled = true;
            dtpFecha.Enabled = true;

            cmbestado.Enabled = true;
        }
        public void MostrarDatos_dgvEmpleados()
        {


            dgvEmpleados.DataSource = ClsEmpleado.MostrarDatos();
            dgvEmpleados.Columns[0].HeaderText = "IdEmpleado";
            dgvEmpleados.Columns[1].HeaderText = "Fecha Registro";
            dgvEmpleados.Columns[2].HeaderText = "Nombre";
            dgvEmpleados.Columns[3].HeaderText = "Apellidos";
            dgvEmpleados.Columns[4].HeaderText = "Fecha Nacimiento";
            dgvEmpleados.Columns[5].HeaderText = "Salario";
            dgvEmpleados.Columns[6].HeaderText = "Estado";
  
            dgvEmpleados.Columns[0].Visible = false;
        

            //Estilo titulo
            this.dgvEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 39, 40);  //(44, 62, 80); //argb
            this.dgvEmpleados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10);
            this.dgvEmpleados.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10);
            //Estilo seleccion 
            this.dgvEmpleados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            this.dgvEmpleados.DefaultCellStyle.SelectionForeColor = Color.White;
            //Estilo borde celda 
            this.dgvEmpleados.GridColor = Color.FromArgb(41, 39, 40); //(44, 62, 80);
            //Ajustable
            this.dgvEmpleados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEmpleados.ScrollBars = ScrollBars.Both;
            this.dgvEmpleados.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsEmpleado Instancia = new ClsEmpleado();

            Instancia.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);
           
            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Apellidos = txtApellidos.Text.Trim();
            Instancia.FechaN = dtpFecha.Format.ToString();
            Instancia.Salario =Convert.ToDouble( txtsalario.Text);
            Instancia.Estado = 1;
                if (ClsEmpleado.Actualizar(Instancia) > 0)
                {
                    MessageBox.Show("Los datos del Empleado se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                    MostrarDatos_dgvEmpleados();
                    limpia_cajas();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MostrarDatos_dgvEmpleados();
            }
            
        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OpcionCancelar();
        }
        public void OpcionCancelar()
        {
            txtApellidos.Enabled = false;
            txtNombre.Enabled = false;
            txtsalario.Enabled = false;
            dtpFecha.Enabled = false;
            cmbestado.Enabled = false;
            dteRegistro.Enabled = false;
       

            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtsalario.Text = "";
           


            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Empleado Actual", "Esta Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsEmpleado Instancia = new ClsEmpleado();
                Instancia.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);

                if (ClsEmpleado.Eliminar(Instancia.IdEmpleado) > 0)
                {
                    MessageBox.Show("Empleado Eliminado Correctamente!", "Empleado Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvEmpleados();
                    //  OpcionEliminar();
                    limpia_cajas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Empleado", "Empleado No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }
    }
}
