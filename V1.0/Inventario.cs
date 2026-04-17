class Inventario
{
    private const int MAX = 100;
    private Producto[] productos;
    private int cantidad;
    public Inventario()
    {
        productos = new Producto[MAX];
        cantidad = 0;
    }

    public void agregarProducto(Producto producto)
    {
        if(cantidad > MAX) return;
        productos[cantidad++] = producto;
    }

    private int buscarProducto(string codigo)
    {
        for(int i = 0; i < cantidad; i++)
        {
            if(productos[i].getCodigo() == codigo) return i;
        }
        return -1;
    }
    public void eliminarProducto(string codigo)
    {
        int pos = buscarProducto(codigo);
        if(pos == -1) return;
        for(int i = pos; i < cantidad - 1; i++)
        {
            productos[i] = productos[i + 1];
        }
        cantidad--;
    }

    public Producto? obtenerProducto(int pos)
    {
        if(pos < 0 || pos >= cantidad) return null;
        return productos[pos];
    }

    public int getCantidad(){return cantidad;}

    public void cargarInventario()
    {
        agregarProducto(new Producto("Manzana", "1", 2.0));
        agregarProducto(new Producto("Bananas", "2", 5.5));
        agregarProducto(new Producto("Duraznos", "3", 18.0));
        agregarProducto(new Producto("Pan", "4", 1.0));
        agregarProducto(new Producto("Naranjas", "5", 4.0));
        agregarProducto(new Producto("Leche", "6", 9.0));
        agregarProducto(new Producto("Sandia", "7", 7.5));
        agregarProducto(new Producto("Manzana Verde", "8", 3.5));
        agregarProducto(new Producto("Mandarinas", "9", 5.5));
        agregarProducto(new Producto("Pera", "10", 4.0));
    }
}