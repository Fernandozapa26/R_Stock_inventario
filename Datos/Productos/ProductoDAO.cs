using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;



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
<<<<<<< HEAD
            var lista = new List<Producto>();
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand("SELECT Id, Nombre, Categoria, Precio, Stock FROM Productos ORDER BY Nombre", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
=======
            conn.Open();

                string query = @"INSERT INTO Productos 
                        (nombre, precio_costo, precio_venta, stock, id_categoria, id_proveedor) 
                        VALUES 
                        (@nombre, @precio_costo, @precio_venta, @stock, @id_categoria, @id_proveedor)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@precio_costo", producto.Precio_Costo);
                    cmd.Parameters.AddWithValue("@precio_venta", producto.Precio_Venta);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@id_categoria", producto.IdCategoria);
                    cmd.Parameters.AddWithValue("@id_proveedor", producto.IdProveedor);

                    cmd.ExecuteNonQuery();
                }
        }
    }

        public void EliminarProducto(int idProduct)
        {
            using (SqlConnection conm = new SqlConnection(conexion))
            {
                conm.Open();

                string query = "DELETE FROM Productos WHERE (id_producto = @id_producto)";
                using (SqlCommand cmd = new SqlCommand(query, conm))
                {
                    cmd.Parameters.AddWithValue("@id_producto", idProduct);
                    cmd.ExecuteNonQuery();
                    
                }
            }
             
        }

        public void EditarProducto(Producto producto)
{
    using (SqlConnection conn = new SqlConnection(conexion))
    {
        conn.Open();

        string query = @"UPDATE Productos 
                         SET nombre = @nombre,
                             precio_costo = @precio_costo,
                             precio_venta = @precio_venta,
                             stock = @stock,
                             id_categoria = @id_categoria
                         WHERE id_producto = @id_producto";

        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@precio_costo", producto.Precio_Costo);
            cmd.Parameters.AddWithValue("@precio_venta", producto.Precio_Venta);
            cmd.Parameters.AddWithValue("@stock", producto.Stock);
            cmd.Parameters.AddWithValue("@id_categoria", producto.IdCategoria);
            cmd.Parameters.AddWithValue("@id_producto", producto.Id_producto);

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

                string query = @"SELECT 
                p.id_producto,
                p.nombre,
                p.precio_costo,
                p.precio_venta,
                p.stock,
                p.id_categoria,
                p.id_proveedor,
                c.nombre AS categoria_nombre,
                pr.nombre_empresa 
         FROM Productos p
         INNER JOIN Categorias c 
                ON p.id_categoria = c.id_categoria
         INNER JOIN Proveedores pr
                ON p.id_proveedor = pr.id_proveedor;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
>>>>>>> origin/main
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

<<<<<<< HEAD
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
=======
                        p.Id_producto = Convert.ToInt32(reader["id_producto"]);
                        p.Nombre = reader["nombre"].ToString();
                        p.Precio_Costo = Convert.ToDecimal(reader["precio_costo"]);
                        p.Precio_Venta = Convert.ToDecimal(reader["precio_venta"]);
                        p.Stock = Convert.ToInt32(reader["stock"]);
                        p.IdCategoria = Convert.ToInt32(reader["id_categoria"]);
                        p.IdProveedor = Convert.ToInt32(reader["id_proveedor"]);
                        p.CategoriaNombre = reader["categoria_nombre"].ToString();
                        p.ProveedorNombre = reader["nombre_empresa"].ToString();
>>>>>>> origin/main

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
