class Carrito
{
    private List<itemCarrito> productos;

    public Carrito()
    {
        productos = new List<itemCarrito>();
    } 


    public void eliminarProducto(int pos)
    {
        if(pos < 0 || pos >= productos.Count) return;
        productos.RemoveAt(pos);
    }

    public void agregarProducto(itemCarrito producto)
    {
        productos.Add(producto);
    }

    public itemCarrito? obtenerProducto(int pos)
    {
        if(pos < 0 || pos >= productos.Count) return null;
        return productos[pos];
    }

    public int getTam(){return productos.Count;}
    public double getTotal()
    {
        double total = 0.0;
        foreach(itemCarrito item in productos)
        {
            total += item.getTotal();
        }
        return total;
    }
    public void vaciarCarrito()
    {
        productos.Clear();
    }
}