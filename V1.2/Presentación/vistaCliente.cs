class vistaCliente
{
    private logicaVenta logica;
    private Usuario usuario;
 
    public vistaCliente(logicaVenta logica, Usuario usuario)
    {
        this.logica  = logica;
        this.usuario = usuario;
    }
 
    public bool mostrar()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Bienvenido, {usuario.getNombre()}");
            Console.WriteLine("1. Ver productos");
            Console.WriteLine("2. Agregar producto al carrito");
            Console.WriteLine("3. Ver carrito");
            Console.WriteLine("4. Eliminar del carrito");
            Console.WriteLine("5. Realizar compra");
            Console.WriteLine("6. Cerrar sesión");
            Console.WriteLine("7. Cerrar tienda");
            Console.Write("Opción: ");
 
            string? op = Console.ReadLine();
            switch (op)
            {
                case "1": verProductos(); break;
                case "2": agregarAlCarrito(); break;
                case "3": verCarrito(); break;
                case "4": eliminarDelCarrito(); break;
                case "5": realizarCompra(); break;
                case "6": return false; 
                case "7": return true;  
                default:
                    Console.WriteLine("Opción inválida.");
                    pausar();
                    break;
            }
        }
    }
 
    //products
    private void verProductos()
    {
        Console.Clear();
        Console.WriteLine("PRODUCTOS DISPONIBLES");
        Inventario inv = logica.getInventario();
 
        if (inv.getCantidad() == 0)
        {
            Console.WriteLine("No hay productos disponibles.");
            pausar();
            return;
        }
 
        Console.WriteLine($"{"#",-4} {"Nombre",-22} {"Precio",10} {"Disponibles",12}");
        Console.WriteLine(new string('-', 52));
 
        for (int i = 0; i < inv.getCantidad(); i++)
        {
            Producto? p   = inv.obtenerProducto(i);
            int stock     = inv.obtenerProductos(i)?.getCantidad() ?? 0;
            string disp   = stock > 0 ? stock.ToString() : "Agotado";
            Console.WriteLine($"{i+1,-4} {p?.getNombre(),-22} ${p?.getPrecio(),9:F2} {disp,12}");
        }
        pausar();
    }
 
    private void agregarAlCarrito()
    {
        Console.Clear();
        Console.WriteLine("AGREGAR AL CARRITO");
        Inventario inv = logica.getInventario();
        bool hayStock = false;
        for (int i = 0; i < inv.getCantidad(); i++)
        {
            int stock = inv.obtenerProductos(i)?.getCantidad() ?? 0;
            if (stock > 0)
            {
                Producto? p = inv.obtenerProducto(i);
                Console.WriteLine($"  {i+1}. {p?.getNombre()} — ${p?.getPrecio():F2} (stock: {stock})");
                hayStock = true;
            }
        }
 
        if (!hayStock) { Console.WriteLine("No hay productos con stock."); pausar(); return; }
 
        Console.Write("Número de producto: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        { Console.WriteLine("Entrada inválida."); pausar(); return; }
 
        int pos = num - 1;
        int posCarrito = logica.agregarProductoCarrito(pos);
        if (posCarrito == -1)
        { Console.WriteLine("Producto no válido."); pausar(); return; }
 
        int maxStock = logica.getInventario().obtenerProductos(pos)?.getCantidad() ?? 0;
        Console.Write($"Cantidad (máx {maxStock}): ");
        if (!int.TryParse(Console.ReadLine(), out int cant) || cant <= 0)
        { Console.WriteLine("Cantidad inválida."); pausar(); return; }
 
        if (!logica.cantidadProductoCarrito(posCarrito, cant))
            Console.WriteLine("Cantidad no disponible en stock.");
        else
            Console.WriteLine("Producto agregado al carrito.");
 
        pausar();
    }
 
    //carrito
    private void verCarrito()
    {
        Console.Clear();
        Console.WriteLine("CARRITO DE COMPRAS");
        Carrito carrito = logica.getCarrito();
 
        if (carrito.getTam() == 0)
        {
            Console.WriteLine("El carrito está vacío.");
            pausar();
            return;
        }
 
        Console.WriteLine($"{"#",-4} {"Producto",-22} {"Cant",6} {"Subtotal",10}");
        Console.WriteLine(new string('-', 46));
        for (int i = 0; i < carrito.getTam(); i++)
        {
            itemCarrito? item = carrito.obtenerProducto(i);
            if (item is null) continue;
            Console.WriteLine($"{i+1,-4} {item.getProducto().getNombre(),-22} {item.getCantidad(),6} ${item.getTotal(),9:F2}");
        }
        Console.WriteLine(new string('-', 46));
        Console.WriteLine($"{"TOTAL",-32} ${carrito.getTotal(),9:F2}");
        pausar();
    }
 
    private void eliminarDelCarrito()
    {
        Console.Clear();
        Console.WriteLine("ELIMINAR DEL CARRITO");
        Carrito carrito = logica.getCarrito();
 
        if (carrito.getTam() == 0)
        {
            Console.WriteLine("El carrito está vacío.");
            pausar();
            return;
        }
 
        for (int i = 0; i < carrito.getTam(); i++)
        {
            itemCarrito? item = carrito.obtenerProducto(i);
            Console.WriteLine($"  {i+1}. {item?.getProducto().getNombre()} x{item?.getCantidad()}");
        }
 
        Console.Write("Número de producto a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        { Console.WriteLine("Entrada inválida."); pausar(); return; }
 
        if (logica.eliminarProductoCarrito(num - 1))
            Console.WriteLine("✓ Producto eliminado del carrito.");
        else
            Console.WriteLine("✗ Posición inválida.");
        pausar();
    }
 
    //compra
    private void realizarCompra()
    {
        Console.Clear();
        Console.WriteLine("CONFIRMAR COMPRA");
        Carrito carrito = logica.getCarrito();
 
        if (carrito.getTam() == 0)
        {
            Console.WriteLine("El carrito está vacío. Agrega productos antes de comprar.");
            pausar();
            return;
        }
 
        Console.WriteLine("Resumen de su compra:");
        Console.WriteLine(new string('-', 46));
        for (int i = 0; i < carrito.getTam(); i++)
        {
            itemCarrito? item = carrito.obtenerProducto(i);
            if (item is null) continue;
            if (item.getCantidad() == 0)
            {
                Console.WriteLine($"{item.getProducto().getNombre()} — sin cantidad asignada");
                continue;
            }
            Console.WriteLine($"  • {item.getProducto().getNombre(),-22} x{item.getCantidad(),3}  ${item.getTotal():F2}");
        }
        Console.WriteLine(new string('-', 46));
        Console.WriteLine($"  TOTAL: ${carrito.getTotal():F2}");
 
        if (!logica.carritoValido())
        {
            Console.WriteLine("\nHay items sin cantidad. Asigna cantidad a todos los productos.");
            pausar();
            return;
        }
 
        Console.Write("\n¿Confirmar compra? (s/n): ");
        if (Console.ReadLine()?.ToLower() != "s")
        {
            Console.WriteLine("Compra cancelada.");
            pausar();
            return;
        }
 
        Carrito? resultado = logica.realizarVenta();
        if (resultado != null)
        {
            Console.WriteLine("\nCompra realizada con éxito!");
            Console.WriteLine($"Total pagado: ${resultado.getTotal():F2}");
        }
        else
        {
            Console.WriteLine("No se pudo completar la compra.");
        }
        pausar();
    }
 
    private void pausar()
    {
        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
    }
}