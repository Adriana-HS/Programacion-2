class Producto
{
    private string nombre;
    private string codigo;
    private double precio;

    public Producto()
    {
        nombre = "";
        codigo = "";
        precio = 0;
    }
    public Producto(string nombre, string codigo, double precio)
    {
        this.nombre = nombre;
        this.codigo = codigo;
        this.precio = precio;
    }
    public string getNombre(){return nombre;}
    public string getCodigo(){return codigo;}
    public double getPrecio(){return precio;}
    public void setNombre(string nombre){this.nombre = nombre;}
    public void setPrecio(double precio){this.precio = precio;}  
}