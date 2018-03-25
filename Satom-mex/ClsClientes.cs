using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Satom_mex
{
    class ClsClientes
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string FechaN { get; set; }
        public double IMC { get; set; }
         public int Estado { get; set; }
         public string fechaRegistro { get; set; }

        public ClsClientes() { }

        //--------------------------------------------------------------------------
        //estos son los variables que se mandan a llamar
        public ClsClientes(int pIdCliente,string fecha, string pNombre, string pApellidos, string pDireccion, string pCorreo, string pTelefono, string pfecha,double pImc,int pEstado)
        {
            this.IdCliente = pIdCliente;
            this.Nombre = pNombre;
            this.Apellidos = pApellidos;
            this.Direccion = pDireccion;
            this.Correo = pCorreo;
            this.Telefono = pTelefono;
            this.FechaN = pfecha;
            this.IMC = pImc;
            this.Estado=pEstado;
            this.fechaRegistro = fecha;
        }
        
         //Funcion guardar
        public static int Guardar(ClsClientes variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tblcliente (intIdCliente, vchNombre, vchApellidos, vchDomicilio,vchCorreo, vchTelefono,dteFechaNac,dbleIMC,intEstado) VALUES ('{0}','{1}','{2}', '{3}', '{4}', '{5}','{6}','{7}','{8}')",
            variable.IdCliente, variable.Nombre, variable.Apellidos, variable.Direccion,variable.Correo, variable.Telefono,variable.FechaN,variable.IMC,variable.Estado ), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        //Funcion actualizar
        public static int Actualizar(ClsClientes variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Update tblcliente set vchNombre='{0}', vchApellidos='{1}', vchDomicilio='{2}',vchCorreo='{3}', vchTelefono='{4}',dteFechaNac='{5}',dbleIMC='{6}',intEstado='{7}' where intIdCliente={8}",
           variable.Nombre, variable.Apellidos, variable.Direccion, variable.Correo, variable.Telefono, variable.FechaN, variable.IMC, variable.Estado,variable.IdCliente), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        //--------------------------------------------------------------------------

        //llena tabla
        public static List<ClsClientes> MostrarDatos()
        {
            List<ClsClientes> lista = new List<ClsClientes>();
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * from tblcliente"), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ClsClientes Cliente = new ClsClientes();
                Cliente.IdCliente = _reader.GetInt32(0);
                Cliente.fechaRegistro   =_reader.GetString(1);
                Cliente.Nombre = _reader.GetString(2);
                Cliente.Apellidos = _reader.GetString(3);
                Cliente.Direccion = _reader.GetString(4);
                Cliente.Correo = _reader.GetString(5);
                Cliente.Telefono = _reader.GetString(6);
                Cliente.FechaN = _reader.GetDataTypeName(7);
                Cliente.IMC = _reader.GetDouble(8);
                Cliente.Estado = _reader.GetInt32(9);
               

                lista.Add(Cliente);
            }
            return lista;
        }
        //Funcion eliminar
        public static int Eliminar(int IdCliente)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tblCliente where intIdCliente={0}", IdCliente), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        //--------------------------------------------------------------------------

      
        }
}
  
