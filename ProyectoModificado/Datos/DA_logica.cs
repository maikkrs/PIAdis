using NuGet.Packaging.Signing;
using ProyectoModificado.Models;
using System.Data.SqlClient;

namespace ProyectoModificado.Datos
{
    public class DA_logica
    {
        public Usuario ValidarUsuario(string correo, string pass)
        {

            // GUARDADO
            try
            {
                string connectionString = "Data Source=SQL5104.site4now.net;Initial Catalog=db_a99b7f_tienda;User Id=db_a99b7f_tienda_admin;Password=GY593Ro2";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT usuario,contraseña from usuarios where usuario='" + correo + "'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            new List<Usuario>();
                            while (reader.Read())
                            {
                                UsInfo comp = new UsInfo();
                                comp.umail = reader.GetString(0);
                                comp.upass = reader.GetString(1);
                               

                                if (pass == comp.upass)
                                {
                                    correo = ""; pass = "";
                                    return new Usuario { umail = comp.umail, upass = comp.upass };
                                }
                                else
                                {
                                    return new Usuario();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }

            return new Usuario();


        }

        public class UsInfo
        {
            public string umail;
            public string upass;
        }

    }
}
