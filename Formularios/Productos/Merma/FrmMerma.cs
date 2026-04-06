using Inventario_Final.Entidades;
using Inventario_Final.Servicios;

private void btnGuardar_Click(object sender, EventArgs e)
{
    var movimientoMerma = new Movimiento()
    {
        IdProducto = int.Parse(txtIdProducto.Text),
        Cantidad = int.Parse(txtCantidad.Text),
        Costo = decimal.Parse(txtCosto.Text),
        TipoMovimiento = "Merma", 
        Fecha = DateTime.Now
    };

    InventarioService service = new InventarioService();
    string resultado = service.ProcesarMovimiento(movimientoMerma);
    MessageBox.Show(resultado == "Éxito" ? "Merma registrada correctamente" : resultado);
}