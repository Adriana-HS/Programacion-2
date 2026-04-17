class PresentacionTienda
{
    private Inventario inventario;
    private Carrito carrito;    
    public PresentacionTienda()
    {
        inventario = new Inventario();
        carrito = new Carrito();
        inventario.cargarInventario();
        mostrarInventario();
    }


    private void mostrarInventario()
    {
        Console.WriteLine("Inventario:");
        for(int i = 0; i < inventario.getCantidad(); i++)
        {
            Console.WriteLine($"{i + 1}. {inventario.obtenerProducto(i)?.getNombre()} - Codigo: {inventario.obtenerProducto(i)?.getCodigo()} - Precio: ${inventario.obtenerProducto(i)?.getPrecio()}");
        }
    }

    private void mostrarCarrito()
    {
        Console.WriteLine("Carrito:");
        for(int i = 0; i < carrito.getTam(); i++)
        {
            Console.WriteLine($"{i + 1}. {carrito.obtenerProducto(i)?.getNombre()} - Codigo: {carrito.obtenerProducto(i)?.getCodigo()} - Precio: ${carrito.obtenerProducto(i)?.getPrecio()}");
        }
    }
}