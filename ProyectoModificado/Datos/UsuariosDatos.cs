using ProyectoModificado.Controllers;
using ProyectoModificado.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoModificado.Datos
{
    public class UsuariosDatos
    {

        public List<Usuario> Listar()
        {
            var oLista = new List<Usuario>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string sql = "SELECT * from usuarios";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Usuario
                        {
                            uid = dr.GetInt32(0),
                            umail = dr.GetString(1),
                            upass= dr.GetString(2),

                        });
                    }
                }

            }
            return oLista;
        }

        public Usuario Obtener(int idContacto)
        {
            var oProducto = new Usuario();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string sql = "SELECT * from usuarios WHERE usid=@id";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", idContacto);


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oProducto.uid = dr.GetInt32(0);
                        oProducto.umail = dr.GetString(1);
                        oProducto.upass = dr.GetString(2);
      
                        
                    }
                }
            }
            return oProducto;
        }

        public bool Guardar(Usuario oProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    String sql = "Insert INTO usuarios " +
                                        "values (@name, @pass)";
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@name", oProducto.umail);
                    cmd.Parameters.AddWithValue("pass", oProducto.upass);

                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception)
            {
                rpta= false;
            }


            return rpta;
        }

        public bool Editar(Usuario oProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    String sql = "UPDATE usuarios " +
                                            "SET usuario=@name, contraseña=@pass " +
                                            "WHERE usid = @id";
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@name", oProducto.umail);
                    cmd.Parameters.AddWithValue("@pass", oProducto.upass);
                    cmd.Parameters.AddWithValue("@id", oProducto.uid);

                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception)
            {
                rpta = false;
            }


            return rpta;
        }

        public bool Eliminar(int IdProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                     String sql = "Delete from usuarios where usid=@id;";
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@id", IdProducto);

                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception)
            {
                rpta = false;
            }


            return rpta;
        }


    }




}
