using Inventario_Final.Entidades;
using Inventario_Final.Servicios;

private void btnGuardar_Click(object sender, EventArgs e)
{
    var movimientoVenta = new Movimiento()
    {
        IdProducto = int.Parse(txtIdProducto.Text),
        Cantidad = int.Parse(txtCantidad.Text),
        Costo = decimal.Parse(txtCosto.Text),
        TipoMovimiento = "Salida", 
        Fecha = DateTime.Now
    };

    InventarioService service = new InventarioService();
    string resultado = service.ProcesarMovimiento(movimientoVenta);
    MessageBox.Show(resultado == "Éxito" ? "Venta registrada y stock restado" : resultado);
}