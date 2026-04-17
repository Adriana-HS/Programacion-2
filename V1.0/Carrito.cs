class Carrito
{
    private const int MAX = 100;
    private Producto[] productos;
    private int tam;
    public Carrito()
    {
        productos = new Producto[MAX];
        tam = 0;
    }


    public void eliminarProducto(int pos)
    {
        if(pos < 0 || pos >= tam) return;
        for(int i = pos; i < tam - 1; i++)
        {
            productos[i] = productos[i + 1];
        }
        tam--;
    }

    public void agregarProducto(Producto producto)
    {
        if(tam > MAX) return;
        productos[tam++] = producto;
    }

    public Producto? obtenerProducto(int pos)
    {
        if(pos < 0 || pos >= tam) return null;
        return productos[pos];
    }

    public int getTam(){return tam;}
}