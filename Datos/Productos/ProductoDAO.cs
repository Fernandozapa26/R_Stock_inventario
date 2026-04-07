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
            {
                        Producto p = new Producto();

                        p.Id_producto = Convert.ToInt32(reader["id_producto"]);
                        p.Nombre = reader["nombre"].ToString();
                        p.Precio_Costo = Convert.ToDecimal(reader["precio_costo"]);
                        p.Precio_Venta = Convert.ToDecimal(reader["precio_venta"]);
                        p.Stock = Convert.ToInt32(reader["stock"]);
                        p.IdCategoria = Convert.ToInt32(reader["id_categoria"]);
                        p.IdProveedor = Convert.ToInt32(reader["id_proveedor"]);
                        p.CategoriaNombre = reader["categoria_nombre"].ToString();
                        p.ProveedorNombre = reader["nombre_empresa"].ToString();

                        lista.Add(p);
                    }
        }
    }

    return lista;
}
    }
}
