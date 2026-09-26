// Pruebas de los métodos Eliminar() e Imprimir() de ListaCircular.
// Cada prueba cubre un caso límite. Si algún método tuviera un bucle
// infinito, el programa se quedaría "colgado" en esa prueba.
// Para ejecutarlas: llamar PruebasListaCircular.Ejecutar() desde Main.
public static class PruebasListaCircular
{
    private static int aprobadas = 0;
    private static int fallidas = 0;

    public static void Ejecutar()
    {
        Console.WriteLine("=== Pruebas de ListaCircular: Eliminar() e Imprimir() ===\n");

        // 1. Imprimir una lista vacía
        var lista = new ListaCircular();
        Verificar("Imprimir lista vacía", "La lista está vacía.", Capturar(lista));

        // 2. Eliminar en una lista vacía
        Verificar("Eliminar en lista vacía devuelve false", false, lista.Eliminar(10));

        // 3. Eliminar el único nodo y volver a usar la lista
        lista.Agregar(10);
        Verificar("Eliminar único nodo devuelve true", true, lista.Eliminar(10));
        Verificar("La lista queda vacía", "La lista está vacía.", Capturar(lista));
        lista.Agregar(5);
        Verificar("Reutilizar la lista tras vaciarla", "5 -> (vuelve a 5)", Capturar(lista));

        // 4. Eliminar el primer nodo (head)
        lista = Crear(10, 20, 30);
        lista.Eliminar(10);
        Verificar("Eliminar head", "20 -> 30 -> (vuelve a 20)", Capturar(lista));

        // 5. Eliminar el último nodo (last) y agregar después
        lista = Crear(10, 20, 30);
        lista.Eliminar(30);
        Verificar("Eliminar last", "10 -> 20 -> (vuelve a 10)", Capturar(lista));
        lista.Agregar(40);
        Verificar("Agregar tras eliminar last", "10 -> 20 -> 40 -> (vuelve a 10)", Capturar(lista));

        // 6. Eliminar un nodo intermedio
        lista = Crear(10, 20, 30);
        lista.Eliminar(20);
        Verificar("Eliminar nodo intermedio", "10 -> 30 -> (vuelve a 10)", Capturar(lista));

        // 7. Eliminar un dato que no existe (caso clave de bucle infinito)
        lista = Crear(10, 20, 30);
        Verificar("Eliminar dato inexistente devuelve false", false, lista.Eliminar(99));
        Verificar("La lista no cambia", "10 -> 20 -> 30 -> (vuelve a 10)", Capturar(lista));

        // 8. Con duplicados, solo se elimina la primera aparición
        lista = Crear(10, 20, 10);
        lista.Eliminar(10);
        Verificar("Eliminar primera aparición", "20 -> 10 -> (vuelve a 20)", Capturar(lista));

        // 9. Vaciar la lista eliminando todos los nodos
        lista = Crear(1, 2, 3);
        lista.Eliminar(2);
        lista.Eliminar(1);
        lista.Eliminar(3);
        Verificar("Vaciar la lista completa", "La lista está vacía.", Capturar(lista));

        Console.WriteLine($"\nResultado: {aprobadas} aprobadas, {fallidas} fallidas.");
    }

    // Crea una lista con los datos indicados
    private static ListaCircular Crear(params int[] datos)
    {
        var lista = new ListaCircular();
        foreach (int d in datos)
            lista.Agregar(d);
        return lista;
    }

    // Captura lo que Imprimir() escribe en consola para compararlo
    private static string Capturar(ListaCircular lista)
    {
        var original = Console.Out;
        var salida = new StringWriter();
        Console.SetOut(salida);
        lista.Imprimir();
        Console.SetOut(original);
        return salida.ToString().Trim();
    }

    private static void Verificar<T>(string nombre, T esperado, T obtenido)
    {
        bool ok = Equals(esperado, obtenido);
        if (ok) aprobadas++; else fallidas++;
        Console.WriteLine($"[{(ok ? "OK" : "FALLO")}] {nombre}");
        if (!ok)
            Console.WriteLine($"       esperado: {esperado} | obtenido: {obtenido}");
    }
}