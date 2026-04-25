class PresentacionTienda
{
    private Login login;
    private logicaVenta logica;
 
    public PresentacionTienda()
    {
        Inventario inventario = new Inventario();
        Ventas ventas = new Ventas();
        inventario.cargarInventario();
 
        login  = new Login();
        logica = new logicaVenta(inventario, ventas);
 
        ejecutar();
    }
 
    private void ejecutar()
    {
        while (true)
        {
            Usuario? usuario = mostrarLogin();
            if (usuario is null) continue;
 
            bool cerrarTienda = usuario.getRol() == Rol.Admin
                ? new vistaAdmin(logica, login).mostrar()
                : new vistaCliente(logica, usuario).mostrar();
 
            if (cerrarTienda)
            {
                Console.Clear();
                Console.WriteLine("Tienda cerrada. Nos vemos!");
                break;
            }
        }
    }
 
    private Usuario? mostrarLogin()
    {
        Console.Clear();
        Console.WriteLine("TIENDA CONSOLA - LOGIN");
        Console.Write("Usuario:    ");  string nombre = Console.ReadLine() ?? "";
        Console.Write("Contraseña: "); string contraseña = Console.ReadLine() ?? "";
 
        Usuario? usuario = login.iniciarSesion(nombre, contraseña);
        if (usuario is null)
        {
            Console.WriteLine("\nCredenciales incorrectas. Intente de nuevo.");
            Console.WriteLine("Presione Enter...");
            Console.ReadLine();
        }
        return usuario;
    }
}