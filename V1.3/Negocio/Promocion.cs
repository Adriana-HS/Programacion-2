class Promocion
{
    protected string nombre;
    protected double porcentaje;

    public Promocion(string nombre, double porcentaje)
    {
        this.nombre = nombre;
        this.porcentaje = porcentaje;
    }
    
    public string getNombre() { return nombre; }
    public double getPorcentaje() { return porcentaje; }
    public void setNombre(string nombre) { this.nombre = nombre; }
    public void setPorcentaje(double porcentaje) { this.porcentaje = porcentaje; }

    public virtual bool aplicarPromocion(double montoMinimo, Rol rol)
    {
        return rol == Rol.ClienteVIP;
    }
}