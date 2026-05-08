class Login
{
    private ListaUsuario usuarios;
 
    public Login()
    {
        usuarios = new ListaUsuario();
        cargarUsuarios();
    }
 
    private void cargarUsuarios()
    {
        usuarios.agregarUsuario(new Usuario("admin",   "admin123", Rol.Admin));
        usuarios.agregarUsuario(new Usuario("cliente1","cli123",   Rol.Cliente));
        usuarios.agregarUsuario(new Usuario("cliente2","cli456",   Rol.Cliente));
        usuarios.agregarUsuario(new Usuario("cliente3","cli789",   Rol.ClienteVIP));
    }
 
    public void registrarUsuario(string nombre, string contraseña, Rol rol)
    {
        usuarios.agregarUsuario(new Usuario(nombre, contraseña, rol));
    }
 
    public Usuario? iniciarSesion(string nombre, string contraseña)
    {
        for (int i = 0; i < usuarios.getCantidad(); i++)
        {
            Usuario? u = usuarios.obtenerUsuario(i);
            if (u != null && u.getNombre() == nombre && u.getContraseña() == contraseña)
                return u;
        }
        return null;
    }
 
    //Admin
    public ListaUsuario getListaUsuarios() { return usuarios; }
 
    public bool modificarUsuario(int pos, string nuevoNombre, string nuevaContraseña, Rol nuevoRol)
    {
        Usuario? u = usuarios.obtenerUsuario(pos);
        if (u == null) return false;
        u.setNombre(nuevoNombre);
        u.setContraseña(nuevaContraseña);
        u.setRol(nuevoRol);
        return true;
    }
 
    public bool eliminarUsuario(int pos)
    {
        if (usuarios.obtenerUsuario(pos) == null) return false;
        usuarios.eliminarUsuario(pos);
        return true;
    }
}