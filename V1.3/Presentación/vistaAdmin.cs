class vistaAdmin
{
    private logicaVenta logica;
    private Login login;
 
    public vistaAdmin(logicaVenta logica, Login login)
    {
        this.logica = logica;
        this.login = login;
    }
 
    //true -> cerrar la tienda, false -> cerró sesión
    public bool mostrar()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("PANEL ADMINISTRADOR");
            Console.WriteLine("PRODUCTOS");
            Console.WriteLine("1. Listar productos");
            Console.WriteLine("2. Agregar producto");
            Console.WriteLine("3. Actualizar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("USUARIOS");
            Console.WriteLine("5. Listar usuarios");
            Console.WriteLine("6. Agregar usuario");
            Console.WriteLine("7. Actualizar usuario");
            Console.WriteLine("8. Eliminar usuario");
            Console.WriteLine("9. Ver reporte de ventas");
            Console.WriteLine("PROMOCIONES");
            Console.WriteLine("10. Listar promociones");
            Console.WriteLine("11. Agregar promoción");
            Console.WriteLine("12. Actualizar promoción");
            Console.WriteLine("13. Eliminar promoción");
            Console.WriteLine("14. Cerrar sesión");
            Console.WriteLine("15. Cerrar tienda");
            Console.Write("Opción: ");
 
            string? op = Console.ReadLine();
            switch (op)
            {
                case "1":  listarProductos(); break;
                case "2":  agregarProducto(); break;
                case "3":  actualizarProducto(); break;
                case "4":  eliminarProducto(); break;
                case "5":  listarUsuarios(); break;
                case "6":  agregarUsuario(); break;
                case "7":  actualizarUsuario(); break;
                case "8":  eliminarUsuario(); break;
                case "9":  reporteVentas(); break;
                case "10": listarPromociones(); break;
                case "11": agregarPromocion(); break;
                case "12": actualizarPromocion(); break;
                case "13": eliminarPromocion(); break;
                case "14": return false;
                case "15": return true;
                default:
                    Console.WriteLine("Opción inválida.");
                    pausar();
                    break;
            }
        }
    }
 
    //Productos
    private void listarProductos()
    {
        Console.Clear();
        Console.WriteLine("INVENTARIO");
        Inventario inv = logica.getInventario();
        if (inv.getCantidad() == 0)
        {
            Console.WriteLine("No hay productos registrados.");
        }
        else
        {
            Console.WriteLine($"{"#",-4} {"Código",-8} {"Nombre",-20} {"Precio",10} {"Stock",6}");
            Console.WriteLine(new string('-', 52));
            for (int i = 0; i < inv.getCantidad(); i++)
            {
                Producto? p = inv.obtenerProducto(i);
                int stock = inv.obtenerProductos(i)?.getCantidad() ?? 0;
                Console.WriteLine($"{i+1,-4} {p?.getCodigo(),-8} {p?.getNombre(),-20} ${p?.getPrecio(),9:F2} {stock,6}");
            }
        }
        pausar();
    }
 
    private void agregarProducto()
    {
        Console.Clear();
        Console.WriteLine("AGREGAR PRODUCTO");
        Console.Write("Nombre: "); string nombre  = Console.ReadLine() ?? "";
        Console.Write("Código: "); string codigo  = Console.ReadLine() ?? "";
        Console.Write("Precio: $"); string precioS = Console.ReadLine() ?? "0";
        Console.Write("Cantidad inicial: "); string cantS = Console.ReadLine() ?? "0";
 
        if (!double.TryParse(precioS, out double precio) || precio < 0)
        { Console.WriteLine("Precio inválido."); pausar(); return; }
        if (!int.TryParse(cantS, out int cant) || cant < 0)
        { Console.WriteLine("Cantidad inválida."); pausar(); return; }
 
        logica.agregarProductoInventario(nombre, codigo, precio, cant);
        Console.WriteLine("Producto agregado.");
        pausar();
    }
 
    private void actualizarProducto()
    {
        Console.Clear();
        listarProductosBreve();
        Console.Write("Número de producto a actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        { Console.WriteLine("Entrada inválida."); pausar(); return; }
 
        int pos = num - 1;
        Producto? p = logica.getInventario().obtenerProducto(pos);
        if (p is null) { Console.WriteLine("Producto no encontrado."); pausar(); return; }
 
        Console.WriteLine($"Editando: {p.getNombre()} | Precio: ${p.getPrecio():F2}");
        Console.Write($"Nuevo nombre [{p.getNombre()}]: ");
        string nombre = Console.ReadLine() ?? "";
        if (nombre == "") nombre = p.getNombre();
 
        Console.Write($"Nuevo precio [{p.getPrecio():F2}]: ");
        string precioS = Console.ReadLine() ?? "";
        double precio = precioS == "" ? p.getPrecio() : double.Parse(precioS);
 
        Console.Write("¿Agregar stock adicional? (0 para no agregar): ");
        if (int.TryParse(Console.ReadLine(), out int stock) && stock > 0)
            logica.agregarStockProducto(pos, stock);
 
        logica.actualizarProducto(pos, nombre, precio);
        Console.WriteLine("Producto actualizado.");
        pausar();
    }
 
    private void eliminarProducto()
    {
        Console.Clear();
        listarProductosBreve();
        Console.Write("Número de producto a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        { Console.WriteLine("Entrada inválida."); pausar(); return; }
 
        if (logica.eliminarProductoInventario(num - 1))
            Console.WriteLine("Producto eliminado.");
        else
            Console.WriteLine("Producto no encontrado.");
        pausar();
    }
 
    private void listarProductosBreve()
    {
        Inventario inv = logica.getInventario();
        for (int i = 0; i < inv.getCantidad(); i++)
        {
            Producto? p = inv.obtenerProducto(i);
            Console.WriteLine($"  {i+1}. {p?.getNombre()} (${p?.getPrecio():F2})");
        }
    }
 
    //Usuario
 
    private void listarUsuarios()
    {
        Console.Clear();
        Console.WriteLine("USUARIOS REGISTRADOS");
        ListaUsuario lista = login.getListaUsuarios();
        Console.WriteLine($"{"#",-4} {"Nombre",-20} {"Rol",-10}");
        Console.WriteLine(new string('-', 36));
        for (int i = 0; i < lista.getCantidad(); i++)
        {
            Usuario? u = lista.obtenerUsuario(i);
            Console.WriteLine($"{i+1,-4} {u?.getNombre(),-20} {u?.getRol(),-10}");
        }
        pausar();
    }
 
    private void agregarUsuario()
    {
        Console.Clear();
        Console.WriteLine("AGREGAR USUARIO");
        Console.Write("Nombre: ");      string nombre    = Console.ReadLine() ?? "";
        Console.Write("Contraseña: ");  string contrasena = Console.ReadLine() ?? "";
        Console.Write("Rol (1=Admin, 2=Cliente, 3=ClienteVIP): ");
        Rol rol = Console.ReadLine() == "1" ? Rol.Admin : Console.ReadLine() == "2" ? Rol.Cliente : Rol.ClienteVIP;
        login.registrarUsuario(nombre, contrasena, rol);
        Console.WriteLine("Usuario registrado.");
        pausar();
    }
 
    private void actualizarUsuario()
    {
        Console.Clear();
        listarUsuariosBreve();
        Console.Write("Número de usuario a actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        { Console.WriteLine("Entrada inválida."); pausar(); return; }
 
        int pos = num - 1;
        Usuario? u = login.getListaUsuarios().obtenerUsuario(pos);
        if (u is null) { Console.WriteLine("Usuario no encontrado."); pausar(); return; }
 
        Console.Write($"Nuevo nombre [{u.getNombre()}]: ");
        string nombre = Console.ReadLine() ?? "";
        if (nombre == "") nombre = u.getNombre();
 
        Console.Write($"Nueva contraseña: ");
        string contra = Console.ReadLine() ?? "";
        if (contra == "") contra = u.getContraseña();
 
        Console.Write($"Nuevo rol (1=Admin, 2=Cliente, 3=ClienteVIP) [{u.getRol()}]: ");
        string rolS = Console.ReadLine() ?? "";
        Rol rol = rolS == "1" ? Rol.Admin : rolS == "2" ? Rol.Cliente : rolS == "3" ? Rol.ClienteVIP : u.getRol();
 
        login.modificarUsuario(pos, nombre, contra, rol);
        Console.WriteLine("Usuario actualizado.");
        pausar();
    }
 
    private void eliminarUsuario()
    {
        Console.Clear();
        listarUsuariosBreve();
        Console.Write("Número de usuario a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        { Console.WriteLine("Entrada inválida."); pausar(); return; }
 
        if (login.eliminarUsuario(num - 1))
            Console.WriteLine("Usuario eliminado.");
        else
            Console.WriteLine("Usuario no encontrado.");
        pausar();
    }
 
    private void listarUsuariosBreve()
    {
        ListaUsuario lista = login.getListaUsuarios();
        for (int i = 0; i < lista.getCantidad(); i++)
        {
            Usuario? u = lista.obtenerUsuario(i);
            Console.WriteLine($"  {i+1}. {u?.getNombre()} ({u?.getRol()})");
        }
    }
 
    //ventas
    private void reporteVentas()
    {
        Console.Clear();
        Console.WriteLine("REPORTE DE VENTAS");
        Ventas ventas = logica.getVentas();
 
        if (ventas.getCantidadVentas() == 0)
        {
            Console.WriteLine("No hay ventas registradas.");
            pausar();
            return;
        }
 
        for (int i = 0; i < ventas.getCantidadVentas(); i++)
        {
            Carrito? venta   = ventas.obtenerVenta(i);
            Usuario? usuario = ventas.obtenerUsuario(i);
            if (venta is null || usuario is null) continue;
 
            Rol rol = usuario.getRol();
 
            Console.WriteLine($"\n  Venta #{i+1}  —  Cliente: {usuario.getNombre()} ({rol})");
            Console.WriteLine("  " + new string('-', 60));
            Console.WriteLine($"  {"Producto",-22} {"Cant",5} {"Subtotal",10} {"Descuento",10} {"Total",10}");
            Console.WriteLine("  " + new string('-', 60));
 
            for (int j = 0; j < venta.getTam(); j++)
            {
                itemCarrito? item = venta.obtenerProducto(j);
                if (item is null) continue;
 
                double subtotal  = item.getTotal();
                double descuento = logica.getLogicaPromo().obtenerDescuento(subtotal, rol);
                double totalItem = subtotal - descuento;
 
                string descStr = descuento > 0 ? $"-${descuento:F2}" : "  —";
                Console.WriteLine($"  {item.getProducto().getNombre(),-22} {item.getCantidad(),5} ${subtotal,9:F2} {descStr,10} ${totalItem,9:F2}");
            }
 
            Console.WriteLine("  " + new string('-', 60));
            // El descuento total se lee desde el carrito guardado (calculado al momento de la venta)
            Console.WriteLine($"  {"Subtotal",-50} ${venta.getTotal(),9:F2}");
            if (venta.getDescuento() > 0)
            {
                Console.WriteLine($"  {"Descuento aplicado",-50}-${venta.getDescuento(),9:F2}");
                Console.WriteLine($"  {"TOTAL COBRADO",-50} ${venta.getTotalConDescuento(),9:F2}");
            }
            else
            {
                Console.WriteLine($"  {"TOTAL COBRADO",-50} ${venta.getTotal(),9:F2}");
            }
        }
 
        Console.WriteLine($"\n  {'═',1}  TOTAL GENERAL (sin descuentos): ${ventas.getTotalGeneral():F2}");
        pausar();
    }
 
    private void pausar()
    {
        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
    }

    //Promociones
    private void listarPromociones()
    {
        Console.Clear();
        Console.WriteLine("PROMOCIONES ACTIVAS");
        List<Promocion> promos = logica.getLogicaPromo().getPromociones();
        if (promos.Count == 0)
        {
            Console.WriteLine("No hay promociones registradas.");
            pausar();
            return;
        }else
        {
            foreach (Promocion promo in promos)
            {
                if (promo is PromocionMonto pm)
                {
                    Console.WriteLine($"• {pm.getNombre()} - {pm.getPorcentaje()*100}% de descuento para compras mayores a ${pm.getMontoMinimo():F2}");
                }
                else
                {
                    Console.WriteLine($"• {promo.getNombre()} - {promo.getPorcentaje()*100}% de descuento para clientes VIP");
                }
            }
        }
        pausar();
    }

    private void agregarPromocion()
    {
        Console.Clear();
        listarPromocionesBreve();
        Console.WriteLine("AGREGAR PROMOCIÓN");
        Console.Write("Nombre: "); string nombre = Console.ReadLine() ?? "";
        Console.Write("Porcentaje de descuento (ej. 0.15 para 15%): ");
        if (!double.TryParse(Console.ReadLine(), out double porcentaje) || porcentaje <= 0 || porcentaje >= 1)
        {
            Console.WriteLine("Porcentaje inválido.");
            pausar();
            return;
        }
        Console.Write("¿Es una promoción por monto mínimo? (s/n): ");
        if (Console.ReadLine()?.ToLower() == "s")
        {
            Console.Write("Monto mínimo para aplicar la promoción: $");
            if (!double.TryParse(Console.ReadLine(), out double montoMin) || montoMin <= 0)
            {
                Console.WriteLine("Monto mínimo inválido.");
                pausar();
                return;
            }
            logica.getLogicaPromo().agregarPromocion(new PromocionMonto(nombre, porcentaje, montoMin));
            Console.WriteLine("Promoción por monto mínimo agregada.");
            pausar();
        }
        else
        {
            logica.getLogicaPromo().agregarPromocion(new Promocion(nombre, porcentaje));
            Console.WriteLine("Promoción para clientes VIP agregada.");
            pausar();
        }
    }

    private void eliminarPromocion()
    {
        Console.Clear();
        listarPromocionesBreve();
        Console.Write("Número de promoción a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
            {  Console.WriteLine("Entrada inválida."); pausar(); return; }
        if (logica.getLogicaPromo().eliminarPromocion(num - 1))
        {
            Console.WriteLine("Promoción eliminada.");
        }
        else{
            Console.WriteLine("Número de promoción inválido.");
        }
        pausar();
    }

    private void actualizarPromocion()
    {
        Console.Clear();
        listarPromocionesBreve();
        Console.Write("Numero de promoción a actualizar: "); 
        if (!int.TryParse(Console.ReadLine(), out int num))
            {  Console.WriteLine("Entrada inválida."); pausar(); return; }
        Promocion? promo = logica.getLogicaPromo().getPromocion(num-1);
        if (promo is null)  {Console.WriteLine("Número de promoción inválido."); pausar(); return; }
        Console.Write("Nuevo nombre: "); string nuevoNombre = Console.ReadLine() ?? "";
        Console.Write("Nuevo porcentaje de descuento (ej. 0.15 para 15%): ");
        if (!double.TryParse(Console.ReadLine(), out double nuevoPorcentaje) || nuevoPorcentaje <= 0 || nuevoPorcentaje >= 1)
            {Console.WriteLine("Porcentaje inválido."); pausar(); return; }

        if(promo is PromocionMonto pm)
        {
            Console.Write("Nuevo monto minimo:   $");
            if (!double.TryParse(Console.ReadLine(), out double nuevoMontoMin) || nuevoMontoMin <= 0)
            {   Console.WriteLine("Monto mínimo inválido."); pausar(); return; }
            logica.getLogicaPromo().editarPromocion(num - 1, new PromocionMonto(nuevoNombre, nuevoPorcentaje, nuevoMontoMin));
        }
        else
        {
            logica.getLogicaPromo().editarPromocion(num - 1, new Promocion(nuevoNombre, nuevoPorcentaje));
        }
        Console.WriteLine("Promoción actualizada.");
        pausar();
    }

    private void listarPromocionesBreve()
    {
        List<Promocion> promos = logica.getLogicaPromo().getPromociones();
        for (int i = 0; i < promos.Count; i++)
        {
            Promocion promo = promos[i];
            Console.WriteLine($"  {i+1}. {promo.getNombre()} ({promo.getPorcentaje()*100}% de descuento)");
        }
    }
}