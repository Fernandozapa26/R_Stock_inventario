using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Inventario_Final.Entidades;

namespace Inventario_Final.Datos.Productos
{
    /// <summary>
    /// DAO de Productos - Integrante 1.
    /// CRUD para la tabla Productos.
    /// </summary>
    internal class ProductoDAO
    {
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
