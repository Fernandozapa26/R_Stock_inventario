using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Final.Datos.categoria
{
    internal class CategoriaDAO
    {
        string conexion = "Server=Fernandozapa26\\SQLDEVELOPER;Database=Stock_Manager;Trusted_Connection=True;TrustServerCertificate=True;";

        // 🔹 LISTAR
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();

                string query = "SELECT * FROM Categorias";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categoria c = new Categoria();

                        c.Id = Convert.ToInt32(reader["id_categoria"]);
                        c.Nombre = reader["nombre"].ToString();

                        lista.Add(c);
                    }
                }
            }

            return lista;
        }

        // 🔹 GUARDAR
        public void Guardar(string nombre)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();

                string query = "INSERT INTO Categorias (nombre) VALUES (@nombre)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 🔹 ELIMINAR
        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();

                string query = "DELETE FROM Categorias WHERE id_categoria = @id_categoria";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_categoria", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
