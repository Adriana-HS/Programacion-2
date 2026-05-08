class PromocionMonto : Promocion
{
    private double montoMinimo;
    public PromocionMonto(string nombre, double porcentaje, double montoMinimo) : base(nombre, porcentaje)
    {
        this.montoMinimo = montoMinimo;
    }

    public double getMontoMinimo() { return montoMinimo; }
    public void setMontoMinimo(double montoMinimo) { this.montoMinimo = montoMinimo; }

    public override bool aplicarPromocion(double montoMinimo, Rol rol)
    {
        return montoMinimo >= this.montoMinimo;
    }
}