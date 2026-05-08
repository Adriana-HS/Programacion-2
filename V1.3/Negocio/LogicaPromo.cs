class LogicaPromo
{
    private ListaPromo listaPromociones;

    public LogicaPromo()
    {
        listaPromociones = new ListaPromo();
        cargarPromos();
    }

    public void agregarPromocion(Promocion promocion)
    {
        listaPromociones.agregarPromocion(promocion);
    }

    public bool editarPromocion(int pos, Promocion promocion)
    {
        if (pos < 0 || pos >= listaPromociones.getCantidad()) return false;
        listaPromociones.editarPromocion(pos, promocion);
        return true;
    }

    public bool eliminarPromocion(int pos)
    {
        if (pos < 0 || pos >= listaPromociones.getCantidad()) return false;
        listaPromociones.eliminarPromocion(pos);
        return true;
    }

    public List<Promocion> getPromociones()
    {
        return listaPromociones.getPromociones();
    }

    public Promocion? getPromocion(int pos)
    {
        return listaPromociones.getPromocion(pos);
    }

    public int getCantidadPromociones()
    {
        return listaPromociones.getCantidad();
    }

    public double obtenerDescuento(double montoTotal, Rol rol)
    {
        double descuento = 0.0;
        foreach (Promocion promo in listaPromociones.getPromociones())
        {
            if (promo.aplicarPromocion(montoTotal, rol))
            {
                descuento += promo.getPorcentaje() * montoTotal;
            }
        }
        return descuento;
    }

    private void cargarPromos()
    {
        agregarPromocion(new Promocion("Descuento VIP", 0.10));
        agregarPromocion(new PromocionMonto("Supera 500", 0.05, 500));
    }
}
