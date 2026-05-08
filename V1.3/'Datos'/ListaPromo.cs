class ListaPromo
{
    private List<Promocion> promociones;

    public ListaPromo()
    {
        promociones = new List<Promocion>();
    }

    public void agregarPromocion(Promocion promocion)
    {
        promociones.Add(promocion);
    }

    public void editarPromocion(int ind, Promocion promocion)
    {
        if (ind >= 0 && ind < promociones.Count)
        {
            promociones[ind] = promocion;
        }
    }

    public void eliminarPromocion(int pos)
    {
        if (pos < 0 || pos >= promociones.Count) return;
        promociones.RemoveAt(pos);
    }

    public List<Promocion> getPromociones() { return promociones; }
    public Promocion? getPromocion(int pos)
    {
        if (pos < 0 || pos >= promociones.Count) return null;
        return promociones[pos];
    }

    public int getCantidad() { return promociones.Count; }
}