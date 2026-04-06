using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Inventario_Final.Datos.Entidades;
using Microsoft.Data.SqlClient;



namespace Inventario_Final.Datos.Productos
{
        /// <summary>
    /// DAO de Productos - Integrante 1.
    /// Estructura base para que el Integrante 1 implemente los métodos.
    /// </summary>
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
            var lista = new List<Producto>();
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("SELECT Id, Nombre, Categoria, Precio, Stock FROM Productos ORDER BY Nombre", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Producto
                {
                    Id        = dr.GetInt32(0),
                    Nombre    = dr.GetString(1),
                    Categoria = dr.IsDBNull(2) ? "" : dr.GetString(2),
                    Precio    = dr.GetDecimal(3),
                    Stock     = dr.GetInt32(4)
                });
            }
            return lista;
        }
        public void Insertar(Producto p)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO Productos (Nombre, Categoria, Precio, Stock) VALUES (@n, @c, @p, @s)", con);
            cmd.Parameters.AddWithValue("@n", p.Nombre);
            cmd.Parameters.AddWithValue("@c", p.Categoria);
            cmd.Parameters.AddWithValue("@p", p.Precio);
            cmd.Parameters.AddWithValue("@s", p.Stock);
            cmd.ExecuteNonQuery();
        }

        public void Editar(Producto p)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(
                "UPDATE Productos SET Nombre=@n, Categoria=@c, Precio=@p, Stock=@s WHERE Id=@id", con);
            cmd.Parameters.AddWithValue("@n",  p.Nombre);
            cmd.Parameters.AddWithValue("@c",  p.Categoria);
            cmd.Parameters.AddWithValue("@p",  p.Precio);
            cmd.Parameters.AddWithValue("@s",  p.Stock);
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("DELETE FROM Productos WHERE Id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
