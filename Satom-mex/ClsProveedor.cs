using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace Satom_mex
{
    class ClsProveedor
    {
        
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string CP { get; set; }
        public string RFC { get; set; }

         public ClsProveedor() { }

        //--------------------------------------------------------------------------
        //estos son los variables que se mandan a llamar
        public ClsProveedor(int pIdProveedor, string pNombre, string pDireccion,string pRFC, string pCP)
        {
            this.IdProveedor = pIdProveedor;
            this.Nombre = pNombre;
            this.Direccion = pDireccion;
            this.RFC = pRFC;
            this.CP = pCP;
           
         
        }
        //Funcion guardar
        public static int Guardar(ClsProveedor variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tblproveedor (intIdProveedor, vchNombre, vchUbicacion,vchRFC,vchCP) VALUES ('{0}','{1}','{2}', '{3}','{4}')",
            variable.IdProveedor, variable.Nombre, variable.Direccion,variable.RFC,variable.CP), conexion);
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
                MySqlCommand comando = new MySqlCommand("SELECT * FROM tblproveedor", conexion);
                MySqlDataAdapter datos = new MySqlDataAdapter(comando);
                datos.Fill(tabla);
                conexion.Close();
            }
            return tabla;
        }
        //Funcion eliminar
        public static int Eliminar(int IdProveedor)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tblproveedor where intIdProveedor={0}", IdProveedor), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        //--------------------------------------------------------------------------
        public static int Actualizar(ClsProveedor variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update tblproveedor set vchNombre='{0}', vchUbicacion='{1}',vchRFC='{2}',vchCP='{3}' where intIdProveedor={4}",
            variable.Nombre, variable.Direccion, variable.RFC, variable.CP,variable.IdProveedor), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
    }
}
