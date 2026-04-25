class ProductoInventario
{
    private Producto producto;
    private List<string> codigos;
    private List<string> vendidos;
    
    public ProductoInventario(Producto producto)
    {
        this.producto = producto;
        this.codigos = new List<string>();
        this.vendidos = new List<string>();
    }

    public Producto getProducto(){return producto;}
    public int getCantidad(){return codigos.Count;}
    public List<string> getCodigos(){return codigos;}
    public List<string> getVendidos(){return vendidos;}

    public void agregarInventario(int cantidad)
    {
        for(int i = 0; i < cantidad; i++)
        {
            codigos.Add((producto.getCodigo() + "-" + (codigos.Count + 1 + vendidos.Count)).ToString() );
        }
    }

    public string? venderProducto()
    {
        if(codigos.Count == 0) return null;
        string codigoVendido = codigos[0];
        codigos.RemoveAt(0);
        vendidos.Add(codigoVendido);
        return codigoVendido;
    }

    public int devolverProducto(string codigo)
    {
        if(!vendidos.Contains(codigo)) return -1;
        vendidos.Remove(codigo);
        codigos.Add(codigo);
        return 0;
    }

    public string? getCodigo(int pos)
    {
        if(pos < 0 || pos >= codigos.Count) return null;
        return codigos[pos];
    }
    
}