using Microsoft.Data.SqlClient;
using System;
using Inventario_Final.Entidades;

namespace Inventario_Final.Datos.Movimiento
{
    public class MovimientoDAO
    {
        // cadena de conexión local
        string cadena = "Server=(localdb)\\MSSQLLocalDB;Database=Stock_Manager;Trusted_Connection=True;";

        public bool RegistrarMovimiento(Entidades.Movimiento mov)
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Insertar el registro en la tabla Movimientos
                        string sqlMov = "INSERT INTO Movimientos (id_producto, tipo_movimiento, cantidad, costo, fecha) " +
                                        "VALUES (@id, @tipo, @cant, @costo, GETDATE())";

                        using (SqlCommand cmd1 = new SqlCommand(sqlMov, conn, trans))
                        {
                            cmd1.Parameters.AddWithValue("@id", mov.IdProducto);
                            cmd1.Parameters.AddWithValue("@tipo", mov.TipoMovimiento);
                            cmd1.Parameters.AddWithValue("@cant", mov.Cantidad);
                            cmd1.Parameters.AddWithValue("@costo", mov.Costo);
                            cmd1.ExecuteNonQuery();
                        }

                        // Actualizar el stock en la tabla Productos
                        // Si es Entrada suma (+), si es Salida o Merma resta (-)
                        string operador = (mov.TipoMovimiento == "Entrada") ? "+" : "-";
                        string sqlStock = $"UPDATE Productos SET stock_actual = stock_actual {operador} @cant WHERE id_producto = @id";

                        using (SqlCommand cmd2 = new SqlCommand(sqlStock, conn, trans))
                        {
                            cmd2.Parameters.AddWithValue("@cant", mov.Cantidad);
                            cmd2.Parameters.AddWithValue("@id", mov.IdProducto);
                            cmd2.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}