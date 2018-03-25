using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Satom_mex
{
    class ClsJefeDpto
    {
        public int IdJefe { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string FechaN { get; set; }

         public ClsJefeDpto() { }

        //--------------------------------------------------------------------------
        //estos son los variables que se mandan a llamar
        public ClsJefeDpto(int pIdJefe, string pNombre, string pApellidos, string pfecha)
        {
            this.IdJefe = pIdJefe;
            this.Nombre = pNombre;
            this.Apellidos = pApellidos;
          
            this.FechaN = pfecha;
           
         
        }
        //Funcion guardar
        public static int Guardar(ClsJefeDpto variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbljefedepartamento (intIdJefe, vchNombre, vchApellidos,dteFechaNac) VALUES ('{0}','{1}','{2}', '{3}')",
            variable.IdJefe, variable.Nombre, variable.Apellidos, variable.FechaN), conexion);
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
                MySqlCommand comando = new MySqlCommand("SELECT * FROM tbljefedepartamento", conexion);
                MySqlDataAdapter datos = new MySqlDataAdapter(comando);
                datos.Fill(tabla);
                conexion.Close();
            }
            return tabla;
        }
        //Funcion eliminar
        public static int Eliminar(int IdJefe)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tbljefedepartamento where intIdJefe={0}", IdJefe), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        //--------------------------------------------------------------------------
        public static int Actualizar(ClsJefeDpto variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update tbljefedepartamento set vchNombre='{0}', vchApellidos='{1}',dteFechaNac='{2}' where intIdJefe={3}",
           variable.Nombre, variable.Apellidos, variable.FechaN, variable.IdJefe), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
    }
}
