using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Satom_mex
{
    class ClsEmpleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string FechaN { get; set; }
        public double Salario { get; set; }
        public int Estado { get; set; }
        public ClsEmpleado() { }

        //estos son los variables que se mandan a llamar
        public ClsEmpleado(int pIdEmpleado, string pNombre, string pApellidos, string pfecha,double pSalario,int pEstado)
        {
            this.IdEmpleado = pIdEmpleado;
            this.Nombre = pNombre;
            this.Apellidos = pApellidos;
            this.FechaN = pfecha;
            this.Salario = pSalario;
            this.Estado = pEstado;
            
        }
        public static int Guardar(ClsEmpleado variables)
        {

            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tblempleado (intIdEmpleado,dteFechaRegistro, vchNombre, vchApellidos,dteFechaNac,dbeSalario,intEstado) VALUES ('{0}','{1}','{2}', '{3}', '{4}', '{5}', '{6}')",
            variables.IdEmpleado,variables.FechaN, variables.Nombre, variables.Apellidos, variables.FechaN,variables.Salario, variables.Estado), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        //Fincion para llenar datos en el datagriwview
        public static DataTable MostrarDatos()
        {
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            DataTable tabla = new DataTable();
            using (conexion)
            {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM tblempleado", conexion);
                MySqlDataAdapter datos = new MySqlDataAdapter(comando);
                datos.Fill(tabla);
                conexion.Close();
            }
            return tabla;
        }
        public static int Eliminar(int IdEmpleado)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tblEmpleado where intIdEmpleado={0}", IdEmpleado), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        public static int Actualizar(ClsEmpleado variables)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update tblEmpleado set dteFechaRegistro='{0}', vchNombre='{1}', vchApellidos='{2}',dteFechaNac='{3}',dbeSalario='{4}',intEstado='{5}' where intIdEmpleado={6}",
            variables.FechaN, variables.Nombre, variables.Apellidos, variables.FechaN, variables.Salario, variables.Estado, variables.IdEmpleado), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
    }
}
