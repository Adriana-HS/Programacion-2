class ListaUsuario
{
    private List<Usuario> usuarios;
    
    public ListaUsuario()
    {
        usuarios = new List<Usuario>();
    }

    public void agregarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
    }

    public Usuario? obtenerUsuario(int pos)
    {
        if(pos < 0 || pos >= usuarios.Count) return null;
        return usuarios[pos];
    }

    public void modificarUsuario(int pos, Usuario usuario)
    {
        if(pos < 0 || pos >= usuarios.Count) return;
        usuarios[pos] = usuario;
    }

    public void eliminarUsuario(int pos)
    {
        if(pos < 0 || pos >= usuarios.Count) return;
        usuarios.RemoveAt(pos);
    }

    public int getCantidad(){return usuarios.Count;}    
}