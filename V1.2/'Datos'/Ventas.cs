class Ventas
{
    private List<Carrito> ventas;
 
    public Ventas()
    {
        ventas = new List<Carrito>();
    }
 
    public void agregarVenta(Carrito carrito)
    {
        ventas.Add(carrito);
    }
 
    public int getCantidadVentas() { return ventas.Count; }
 
    public Carrito? obtenerVenta(int pos)
    {
        if (pos < 0 || pos >= ventas.Count) return null;
        return ventas[pos];
    }
 
    public double getTotalGeneral()
    {
        double total = 0;
        foreach (var v in ventas)
            total += v.getTotal();
        return total;
    }
    
}