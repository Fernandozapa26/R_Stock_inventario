using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;


namespace Inventario_Final.Datos.Proveedores
{
    internal class ProveedorDAO
    {
        string conexion = "Server=Fernandozapa26\\SQLDEVELOPER;Database=Stock_Manager;Trusted_Connection=True;TrustServerCertificate=True;";


        public void Guardar(Proveedor proveedor)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();

                string query = @"INSERT INTO Proveedores 
                        (nombre_empresa, contacto_nombre, telefono, correo, direccion)
                        VALUES 
                        (@nombre_empresa, @contacto_nombre, @telefono, @correo, @direccion)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre_empresa", proveedor.NombreEmpresa);
                    cmd.Parameters.AddWithValue("@contacto_nombre", proveedor.ContactoNombre);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@correo", proveedor.Correo);
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();

                string query = "SELECT * FROM Proveedores";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Proveedor p = new Proveedor();
                        p.Id_proveedor = (int)reader["id_proveedor"];
                        p.NombreEmpresa = reader["nombre_empresa"].ToString();
                        p.ContactoNombre = reader["contacto_nombre"].ToString();
                        p.Telefono = reader["telefono"].ToString();
                        p.Correo = reader["correo"].ToString();
                        p.Direccion = reader["direccion"].ToString();

                        lista.Add(p);
                    }
                }
            }

            return lista;
        }

        public void Editar(Proveedor proveedor)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();

                string query = @"UPDATE Proveedores 
                        SET nombre_empresa = @nombre_empresa,
                            contacto_nombre = @contacto_nombre,
                            telefono = @telefono,
                            correo = @correo, 
                            direccion = @direccion
                        WHERE 
                        id_proveedor = @IdProveedor";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdProveedor", proveedor.Id_proveedor);
                    cmd.Parameters.AddWithValue("@nombre_empresa", proveedor.NombreEmpresa);
                    cmd.Parameters.AddWithValue("@contacto_nombre", proveedor.ContactoNombre);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@correo", proveedor.Correo);
                    cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int id_proveedor)
        {
            using (SqlConnection conm = new SqlConnection(conexion))
            {
                conm.Open();

                string query = "DELETE FROM Proveedores WHERE (id_proveedor = @id_proveedor)";
                using (SqlCommand cmd = new SqlCommand(query, conm))
                {
                    cmd.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}