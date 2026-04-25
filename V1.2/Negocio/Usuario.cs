enum Rol
{
    Admin,
    Cliente
}   

class Usuario
{
    private string nombre;
    private string contraseña;
    private Rol rol;

    public Usuario()
    {
        nombre = "";
        contraseña = "";
        rol = Rol.Cliente;
    }

    public Usuario(string nombre, string contraseña, Rol rol)
    {
        this.nombre = nombre;
        this.contraseña = contraseña;
        this.rol = rol;
    }
    
    public string getNombre(){return nombre;}
    public string getContraseña(){return contraseña;}
    public Rol getRol(){return rol;}
    public void setNombre(string nombre) { this.nombre = nombre; }
    public void setContraseña(string contraseña) { this.contraseña = contraseña; }
    public void setRol(Rol rol) { this.rol = rol; }
}