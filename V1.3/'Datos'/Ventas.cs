class Ventas
{
    private List<Carrito> ventas;
    private List<Usuario> usuarios;
 
    public Ventas()
    {
        ventas = new List<Carrito>();
        usuarios = new List<Usuario>();
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

    public void agregarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
    }

    public Usuario? obtenerUsuario(int pos)
    {
        if (pos < 0 || pos >= usuarios.Count) return null;
        return usuarios[pos];
    }
    
}