using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;



namespace Inventario_Final.Datos.Productos
{
    internal class ProductoDAO
    {
          string conexion = "Server=Fernandozapa26\\SQLDEVELOPER;Database=Stock_Manager;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Guardar(Producto producto)
    {
        using (SqlConnection conn = new SqlConnection(conexion))
        {
            conn.Open();

                string query = @"INSERT INTO Productos 
                        (nombre, precio_costo, precio_venta, stock, id_categoria) 
                        VALUES 
                        (@nombre, @precio_costo, @precio_venta, @stock, @id_categoria)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@precio_costo", producto.Precio_Costo);
                    cmd.Parameters.AddWithValue("@precio_venta", producto.Precio_Venta);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@id_categoria", producto.IdCategoria);

                    cmd.ExecuteNonQuery();
                }
        }
    }
       public List<Producto> Listar()
{
    List<Producto> lista = new List<Producto>();

    using (SqlConnection conn = new SqlConnection(conexion))
    {
        conn.Open();

                string query = @"SELECT p.id_producto,
                        p.nombre,
                        p.precio_costo,
                        p.precio_venta,
                        p.stock,
                        p.id_categoria,
                        c.nombre AS categoria_nombre
                 FROM Productos p
                 INNER JOIN Categorias c 
                 ON p.id_categoria = c.id_categoria";

                using (SqlCommand cmd = new SqlCommand(query, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                        Producto p = new Producto();

                        p.Id = Convert.ToInt32(reader["id_producto"]);
                        p.Nombre = reader["nombre"].ToString();
                        p.Precio_Costo = Convert.ToDecimal(reader["precio_costo"]);
                        p.Precio_Venta = Convert.ToDecimal(reader["precio_venta"]);
                        p.Stock = Convert.ToInt32(reader["stock"]);
                        p.IdCategoria = Convert.ToInt32(reader["id_categoria"]);
                        p.CategoriaNombre = reader["categoria_nombre"].ToString();

                        lista.Add(p);
                    }
        }
    }

    return lista;
}
    }
}
