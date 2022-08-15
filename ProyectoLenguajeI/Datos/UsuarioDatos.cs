using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    }
}
