class logicaVenta
{
    private Inventario inventario;
    private Ventas ventas;
    private Carrito carrito;
 
    public logicaVenta(Inventario inventario, Ventas ventas)
    {
        this.inventario = inventario;
        this.ventas = ventas;
        this.carrito = new Carrito();
    }
 
    public Inventario getInventario() { return inventario; }
    public Carrito getCarrito() { return carrito; }
    public Ventas getVentas() { return ventas; }
 
    //Carrito
    public int agregarProductoCarrito(int pos)
    {
        Producto? producto = inventario.obtenerProducto(pos);
        if (producto is null) return -1;
 
        for (int i = 0; i < carrito.getTam(); i++)
            if (carrito.obtenerProducto(i)?.getProducto().getCodigo() == producto.getCodigo())
                return i; 
 
        carrito.agregarProducto(new itemCarrito(producto));
        return carrito.getTam() - 1;
    }


    public bool cantidadProductoCarrito(int posCarrito, int cantidad)
    {
        if (cantidad <= 0) return false;
        itemCarrito? item = carrito.obtenerProducto(posCarrito);
        if (item is null) return false;
 
        //Buscamos ProductoInventario por código
        int posInv = inventario.buscarPorCodigo(item.getProducto().getCodigo());
        ProductoInventario? pi = inventario.obtenerProductos(posInv);
        if (pi is null) return false;
 
        if (cantidad > pi.getCantidad()) return false; 
 
        //No se añade o aumenta cantidad, se reemplaza
        item.eliminarItem();
        for (int i = 0; i < cantidad; i++)
        {
            string? codigo = pi.getCodigo(i);
            if (codigo is null) break;
            item.agregarCarrito(codigo);
        }
        return true;
    }
 
    public bool eliminarProductoCarrito(int posCarrito)
    {
        itemCarrito? item = carrito.obtenerProducto(posCarrito);
        if (item is null) return false;
        item.eliminarItem();
        carrito.eliminarProducto(posCarrito);
        return true;
    }
 
    //Ventas
    public bool carritoValido()
    {
        if (carrito.getTam() == 0) return false;
        for (int i = 0; i < carrito.getTam(); i++)
            if (carrito.obtenerProducto(i)?.getCantidad() <= 0) return false;
        return true;
    }
 
    public Carrito? realizarVenta()
    {
        if (!carritoValido()) return null;
 
        for (int i = 0; i < carrito.getTam(); i++)
        {
            itemCarrito? item = carrito.obtenerProducto(i);
            if (item is null) continue;
 
            int posInv = inventario.buscarPorCodigo(item.getProducto().getCodigo());
            ProductoInventario? pi = inventario.obtenerProductos(posInv);
            if (pi is null) continue;
 
            int cantidad = item.getCantidad();
            for (int j = 0; j < cantidad; j++)
                pi.venderProducto();
        }
 
        Carrito ventaRealizada = carrito;
        ventas.agregarVenta(ventaRealizada);
        carrito = new Carrito(); 
        return ventaRealizada;
    }
 
    //Inventario
 
    public void agregarProductoInventario(string nombre, string codigo, double precio, int cantidad)
    {
        var pi = new ProductoInventario(new Producto(nombre, codigo, precio));
        pi.agregarInventario(cantidad);
        inventario.agregarProducto(pi);
    }
 
    public bool actualizarProducto(int pos, string nombre, double precio)
    {
        Producto? p = inventario.obtenerProducto(pos);
        if (p is null) return false;
        p.setNombre(nombre);
        p.setPrecio(precio);
        return true;
    }
 
    public bool agregarStockProducto(int pos, int cantidad)
    {
        ProductoInventario? pi = inventario.obtenerProductos(pos);
        if (pi is null) return false;
        pi.agregarInventario(cantidad);
        return true;
    }
 
    public bool eliminarProductoInventario(int pos)
    {
        if (inventario.obtenerProducto(pos) is null) return false;
        inventario.eliminarProducto(pos);
        return true;
    }

}