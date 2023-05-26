using ProyectoModificado.Controllers;
using ProyectoModificado.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoModificado.Datos
{
    public class ClientesDatos
    {


        public List<ClientesModels> Listar()
        {
            var oLista = new List<ClientesModels>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string sql = "SELECT * from Clientes";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ClientesModels
                        {
                            Id = dr.GetInt32(0),
                            Nombre = dr.GetString(1),
                            ApellidoP = dr.GetString(2),
                            ApellidoM = dr.GetString(3),
                            Tel = dr.GetString(4)

                        });
                    }
                }

            }
            return oLista;
        }

        
        public List<ClientesBuscarModels> Buscar(string nom, string ap, string am)
        {
            var oLista = new List<ClientesBuscarModels>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                if (nom == null && ap == null && am == null)
                {
                    am = "x";

                    ap = "x";

                    nom = "x";
                }
                else
                {
                    if (nom == null)
                    {
                        nom = "NULL";
                    }
                    else
                    {
                        nom = "'" + nom + "'";
                    }
                    if (ap == null)
                    {
                        ap = "NULL";
                    }
                    else
                    {
                        ap = "'" + ap + "'";
                    }
                    if (am == null)
                    {
                        am = "NULL";
                    }
                    else
                    {
                        am = "'" + am + "'";
                    }
                }

                


                string sql = "EXEC BuscarCliente @Nombre = " + nom + ", @ApellidoPaterno = " + ap + ", @ApellidoMaterno = " + am + ";";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.CommandType = CommandType.Text;


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ClientesBuscarModels
                        {
                            Idb2 = dr.GetInt32(0),
                            Nombreb2 = dr.GetString(1),
                            ApellidoPb2 = dr.GetString(2),
                            ApellidoMb2 = dr.GetString(3),
                            Telb2 = dr.GetString(4)

                        });
                    }
                }

            }
            return oLista;
        }


        public ClientesModels Obtener(int idContacto)
        {
            var oProducto = new ClientesModels();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                string sql = "SELECT * from Clientes WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", idContacto);


                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oProducto.Id = dr.GetInt32(0);
                        oProducto.Nombre = dr.GetString(1);
                        oProducto.ApellidoP = dr.GetString(2);
                        oProducto.ApellidoM = dr.GetString(3);
                        oProducto.Tel = dr.GetString(4);


                    }
                }
            }
            return oProducto;
        }

        public bool Guardar(ClientesModels oProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    String sql = "Insert INTO Clientes " +
                                        "values (@name, @app, @apm, @tel)";
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@name", oProducto.Nombre);
                    cmd.Parameters.AddWithValue("@app", oProducto.ApellidoP);
                    cmd.Parameters.AddWithValue("@apm", oProducto.ApellidoM);
                    cmd.Parameters.AddWithValue("@tel", oProducto.Tel);

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

        public bool Editar(ClientesModels oProducto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    String sql = "UPDATE Clientes " +
                                            "SET nombre=@name, apellidoP=@app, apellidoM=@apm, telefono=@tel " +
                                            "WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@name", oProducto.Nombre);
                    cmd.Parameters.AddWithValue("@app", oProducto.ApellidoP);
                    cmd.Parameters.AddWithValue("@apm", oProducto.ApellidoM);
                    cmd.Parameters.AddWithValue("@tel", oProducto.Tel);
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
                    String sql = "Delete from Clientes where id=@id;";
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
