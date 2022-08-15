using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDatos
    {
        public bool ValidarLogin(string codigo, string clave)
        {
            bool valido = false;

            string sql = "SELECT 1 FROM usuarios WHERE Codigo = @COdigo AND Clave= @Clave";

            using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
            {
                _conexion.Open();

                using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 30).Value = codigo;
                    comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 50).Value = clave;

                    valido = Convert.ToBoolean(comando.ExecuteScalar());
                }

            }
            return valido;


        }

        public bool Nuevo(Usuario usuario)

        {
            bool inserto = false;
            string sql = "INSERT INTO usuarios VALUES (@Codigo, @Nombre, @Email, @Clave)";

            using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
            {
                _conexion.Open();

                using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 30).Value = usuario.Codigo;
                    comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 60).Value = usuario.Nombre;
                    comando.Parameters.Add("@Email", MySqlDbType.VarChar, 40).Value = usuario.Correo;
                    comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 50).Value = usuario.Clave;

                    comando.ExecuteNonQuery();
                    inserto = true;
                }
            }
            return inserto;
        }

        public DataTable DevolverTodos()
        {
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM usuarios";

            using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
            {
                _conexion.Open();

                using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    MySqlDataReader dr = comando.ExecuteReader();
                    dt.Load(dr);

                }
            }
            return dt;
        }
    
        public bool Actualizar(Usuario usuario)
        {
            bool actualizo = false;
            string sql = "UPDATE usuarios SET Nombre=@Nombre, Email=@Email, Clave=@Clave WHERE Codigo= @Codigo";

            using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
            {
                _conexion.Open();

                using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 30).Value = usuario.Codigo;
                    comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 60).Value = usuario.Nombre;
                    comando.Parameters.Add("@Email", MySqlDbType.VarChar, 40).Value = usuario.Correo;
                    comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 50).Value = usuario.Clave;

                    comando.ExecuteNonQuery();
                    actualizo = true;
                }
            }
            return actualizo;
        }
        public bool Eliminar(string codigo)
        {
            bool elimino = false;
            string sql = "DELETE FROM usuarios WHERE Codigo = @Codigo ";

            using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
            {
                _conexion.Open();

                using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 30).Value = codigo;
                    comando.ExecuteNonQuery();
                    elimino = true;
                }
            }
            return elimino;
        }
    }
}
    