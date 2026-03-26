using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Final.Datos.Productos
{
    internal class ProductoDAO
    {
          string conexion = "Server=Fernandozapa26\\SQLDEVELOPER;Database=InventarioDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Guardar(string nombre, string categoria, decimal precio, int stock)
    {
        using (SqlConnection conn = new SqlConnection(conexion))
        {
            conn.Open();

            string query = "INSERT INTO Productos (Nombre, Categoria, Precio, Stock) VALUES (@Nombre, @Categoria, @Precio, @Stock)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Categoria", categoria);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);

                cmd.ExecuteNonQuery();
            }
        }
    }
    }
}
