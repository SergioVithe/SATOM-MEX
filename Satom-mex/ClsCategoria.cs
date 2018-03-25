using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Satom_mex
{
    class ClsCategoria
    {


        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdCat { get; set; }
        //public string Busqueda { get; set; }

        public ClsCategoria() { }

        public ClsCategoria(int pIdCat,string pNombre, string pDescripcion)
        {
            this.IdCat = pIdCat;
            this.Nombre = pNombre;
            this.Descripcion = pDescripcion;
           
            //this.Busqueda = pBusqueda;
        }
        //Funsion guardar
        public static int Guardar(ClsCategoria variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tblcategoria (intIdCategoria,vchNombre,vchDescripcion) VALUES ('{0}','{1}','{2}')",
            variable.IdCat, variable.Nombre,variable.Descripcion), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        //llena tabla
        public static List<ClsCategoria> MostrarDatos()
        {
            List<ClsCategoria> lista = new List<ClsCategoria>();
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * from tblcategoria "), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ClsCategoria Catego = new ClsCategoria();
                Catego.IdCat = _reader.GetInt32(0);
                Catego.Nombre = _reader.GetString(1);
                Catego.Descripcion = _reader.GetString(2);
                

                lista.Add(Catego);
            }
            conexion.Close();
            return lista;
        }
        //--------------------------------------------------------------------------
        public static int Actualizar(ClsCategoria variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Update tblcategoria set vchNombre='{0}', vchDescripcion='{1}' where intIdCategoria={2}",
          variable.Nombre, variable.Descripcion, variable.IdCat), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        //Funcion eliminar
        public static int Eliminar(int IdCliente)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tblcategoria where intIdCategoria={0}", IdCliente), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------
    }


        //------------------------------------------------------------------------
}
