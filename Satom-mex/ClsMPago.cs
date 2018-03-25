using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Satom_mex
{
    class ClsMPago
    {
        public int IdModo { get; set; }
        public string Nombre { get; set; }
        public string Desc { get; set; }
      public ClsMPago() { }

        //--------------------------------------------------------------------------
        //estos son los variables que se mandan a llamar
        public ClsMPago(int pIdpago, string pNombre, string pDesc)
        {
            this.IdModo = pIdpago;
            this.Nombre = pNombre;
            this.Desc = pDesc;
          
        }
        //Funcion guardar
        public static int Guardar(ClsMPago variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tblmodopago (intIdModoPago, vchNombre, vchOtroDetalle) VALUES ('{0}','{1}','{2}')",
            variable.IdModo, variable.Nombre, variable.Desc), conexion);
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
                MySqlCommand comando = new MySqlCommand("SELECT * FROM tblmodopago", conexion);
                MySqlDataAdapter datos = new MySqlDataAdapter(comando);
                datos.Fill(tabla);
                conexion.Close();
            }
            return tabla;
        }
        public static int Actualizar(ClsMPago variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update tblmodopago set vchNombre='{0}', vchOtroDetalle='{1}' where intIdModoPago={2}",
           variable.Nombre, variable.Desc, variable.IdModo), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        //Funcion eliminar
        public static int Eliminar(int IdModo)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tblmodopago where intIdModoPago={0}", IdModo), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        //--------------------------------------------------------------------------
    }
}
