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
    public partial class sucursal_1 : UserControl
    {
        public sucursal_1()
        {
            InitializeComponent();
        }

        private void sucursal_1_Load(object sender, EventArgs e)
        {
            MostrarDatos_dgvCategoria();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           
                
        }
        public void MostrarDatos_dgvCategoria()
        {
            dgvCatego.DataSource = ClsCategoria.MostrarDatos();
            this.dgvCatego.Columns["IdCat"].Visible = false;
         
            //Estilo titulo
            this.dgvCatego.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 39, 40);  //(44, 62, 80); //argb
            this.dgvCatego.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvCatego.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10);
            this.dgvCatego.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 10);
            //Estilo seleccion 
            this.dgvCatego.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            this.dgvCatego.DefaultCellStyle.SelectionForeColor = Color.White;
            //Estilo borde celda 
            this.dgvCatego.GridColor = Color.FromArgb(41, 39, 40); //(44, 62, 80);
            //Ajustable
            this.dgvCatego.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCatego.ScrollBars = ScrollBars.Both;
            this.dgvCatego.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsCategoria Instancia = new ClsCategoria();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Descripcion = txtDesc.Text.Trim();

            int respuesta = ClsCategoria.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Datos guardados con exito!!", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatos_dgvCategoria();
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos del cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvCatego_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgvCatego.Rows[e.RowIndex];
                txtId.Text = row.Cells["IdCat"].Value.ToString();

                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtDesc.Text = row.Cells["Descripcion"].Value.ToString();

            }
            catch (Exception)
            {

            }
        }
    }
}
