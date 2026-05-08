class Inventario
{
    private List<ProductoInventario> productos;
    public Inventario()
    {
        productos = new List<ProductoInventario>();
    }

    public void agregarProducto(ProductoInventario producto)
    {
        productos.Add(producto);
    }

    public void eliminarProducto(int pos)
    {
        if(pos < 0 || pos >= productos.Count) return;
        productos.RemoveAt(pos);
    }   

    public ProductoInventario? obtenerProductos(int pos)
    {
        if(pos < 0 || pos >= productos.Count) return null;
        return productos[pos];
    }
    
    public Producto? obtenerProducto(int pos)
    {
        if(pos < 0 || pos >= productos.Count) return null;
        return productos[pos].getProducto();
    }

    public int getCantidad(){return productos.Count;}
    public int buscarPorCodigo(string codigo)
    {
        for (int i = 0; i < productos.Count; i++)
            if (productos[i].getProducto().getCodigo() == codigo) return i;
        return -1;
    }
 
    public void cargarInventario()
    {
        var p1 = new ProductoInventario(new Producto("Laptop", "P001", 1200.00));
        var p2 = new ProductoInventario(new Producto("Mouse", "P002", 25.00));
        var p3 = new ProductoInventario(new Producto("Teclado", "P003", 45.00));
        var p4 = new ProductoInventario(new Producto("Monitor", "P004", 350.00));
        var p5 = new ProductoInventario(new Producto("Auriculares","P005", 80.00));
 
        p1.agregarInventario(5);
        p2.agregarInventario(20);
        p3.agregarInventario(15);
        p4.agregarInventario(8);
        p5.agregarInventario(12);
 
        productos.Add(p1);
        productos.Add(p2);
        productos.Add(p3);
        productos.Add(p4);
        productos.Add(p5);
    }

}