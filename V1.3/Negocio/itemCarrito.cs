class itemCarrito
{
    private Producto producto;
    private List<string> codigos;

    public itemCarrito(Producto producto)
    {
        this.producto = producto;
        this.codigos = new List<string>();
    }

    public Producto getProducto(){return producto;}
    public int getCantidad(){return codigos.Count;}
    public List<string> getCodigos(){return codigos;}

    public void agregarCarrito(string codigo)
    {
        codigos.Add(codigo);
    }

    public double getTotal()
    {
        return producto.getPrecio() * codigos.Count;
    } 
    
    public void eliminarItem()
    {
        codigos.Clear();
    }
}