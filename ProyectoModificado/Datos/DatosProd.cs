using ProyectoModificado.Controllers;
using ProyectoModificado.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoModificado.Datos
{
    public class DatosProd
    {

        public List<Productos> Listar()
        {
            var oLista = new List<Productos>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string sql = "SELECT * from Producto";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Productos
                        {
                            Id = dr.GetInt32(0),
                            Nombre = dr.GetString(1),
                            Descripcion= dr.GetString(2),
                            Precio = dr.GetInt32(3),
                            Stock = dr.GetInt32(4)

                        });
                    }
                }

            }
            return oLista;
        }
        public Productos Obtener(int idContacto)
        {
            var oProducto = new Productos();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string sql = "SELECT * from Producto WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", idContacto);


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oProducto.Id = dr.GetInt32(0);
                        oProducto.Nombre = dr.GetString(1);
                        oProducto.Descripcion = dr.GetString(2);
                        oProducto.Precio = dr.GetInt32(3);
                        oProducto.Stock = dr.GetInt32(4);

                        
                    }
                }
            }
            return oProducto;
        }

        public bool Guardar(Productos oProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    String sql = "Insert INTO Producto " +
                                        "values (@name, @desc, @precio, @stock)";
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@name", oProducto.Nombre);
                    cmd.Parameters.AddWithValue("desc", oProducto.Descripcion);
                    cmd.Parameters.AddWithValue("@precio",oProducto.Precio);
                    cmd.Parameters.AddWithValue("@stock", oProducto.Stock);

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

        public bool Editar(Productos oProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    String sql = "UPDATE Producto " +
                                            "SET Nombre=@name, Descripcion=@desc, Precio=@precio, Stock=@stock " +
                                            "WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@name", oProducto.Nombre);
                    cmd.Parameters.AddWithValue("desc", oProducto.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", oProducto.Precio);
                    cmd.Parameters.AddWithValue("@stock", oProducto.Stock);
                    cmd.Parameters.AddWithValue("@id", oProducto.Id);

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
                     String sql = "Delete from Producto where id=@id;";
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
