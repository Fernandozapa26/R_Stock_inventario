public class ProductoService
{
    public Boolean stockValidar(int Stock)
    {
        return Stock >= 0 ? true : false;
    }
}