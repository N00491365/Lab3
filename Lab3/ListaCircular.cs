using System;

public class ListaCircular
{
    private Nodo head;
    private Nodo last;
    private Nodo actual;

    public ListaCircular()
    {
        head = null;
        last = null;
        actual = null;
    }

    public void Agregar(int dato)
    {
        Nodo nuevo = new Nodo(dato);

        if (head == null)
        {
            head = nuevo;
            last = nuevo;

            // El único nodo apunta a sí mismo
            nuevo.Siguiente = head;

            // El primer nodo también es el actual
            actual = head;
        }
        else
        {
            last.Siguiente = nuevo;
            nuevo.Siguiente = head;
            last = nuevo;
        }

        Console.WriteLine($"Turno {dato} agregado correctamente.");
    }

    public Nodo Buscar(int dato)
    {
        if (head == null)
            return null;

        Nodo recorrido = head;

        do
        {
            if (recorrido.Dato == dato)
                return recorrido;

            recorrido = recorrido.Siguiente;

        } while (recorrido != head);

        return null;
    }

    public void Eliminar(int dato)
    {
        if (head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo recorrido = head;
        Nodo anterior = last;

        do
        {
            if (recorrido.Dato == dato)
            {
                // Caso: solo existe un nodo
                if (head == last)
                {
                    head = null;
                    last = null;
                    actual = null;
                }

                // Caso: eliminar el primer nodo
                else if (recorrido == head)
                {
                    head = head.Siguiente;
                    last.Siguiente = head;

                    if (actual == recorrido)
                        actual = head;
                }

                // Caso: eliminar cualquier otro nodo
                else
                {
                    anterior.Siguiente = recorrido.Siguiente;

                    if (recorrido == last)
                        last = anterior;

                    if (actual == recorrido)
                        actual = recorrido.Siguiente;
                }

                Console.WriteLine($"Turno {dato} eliminado correctamente.");
                return;
            }

            anterior = recorrido;
            recorrido = recorrido.Siguiente;

        } while (recorrido != head);

        Console.WriteLine($"El turno {dato} no existe.");
    }

    public void Imprimir()
    {
        if (head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo recorrido = head;

        Console.WriteLine("\n--- RECORRIDO DE LA LISTA CIRCULAR ---");

        do
        {
            Console.Write(recorrido.Dato);

            recorrido = recorrido.Siguiente;

            if (recorrido != head)
                Console.Write(" -> ");

        } while (recorrido != head);

        Console.WriteLine(" -> vuelve al PRIMER NODO (" + head.Dato + ")");

        Console.WriteLine($"Primer nodo (HEAD): {head.Dato}");
        Console.WriteLine($"Último nodo (LAST): {last.Dato}");
    }

    public void MostrarActual()
    {
        if (actual == null)
        {
            Console.WriteLine("No existen turnos.");
            return;
        }

        Console.WriteLine($"Turno actual: {actual.Dato}");

        if (actual == head)
            Console.WriteLine("Este es el PRIMER NODO (HEAD).");
    }

    public void SiguienteTurno()
    {
        if (actual == null)
        {
            Console.WriteLine("No hay turnos registrados.");
            return;
        }

        Nodo anterior = actual;
        actual = actual.Siguiente;

        Console.WriteLine($"\nAvanzando: {anterior.Dato} -> {actual.Dato}");

        if (actual == head)
        {
            Console.WriteLine("======================================");
            Console.WriteLine(" COMPLETASTE UNA VUELTA A LA LISTA");
            Console.WriteLine(" Regresaste al primer nodo (HEAD).");
            Console.WriteLine("======================================");
        }
        else
        {
            Console.WriteLine($"Turno actual: {actual.Dato}");
        }
    }

  
    public void RetrocederTurno()
    {
        if (actual == null)
        {
            Console.WriteLine("No hay turnos registrados.");
            return;
        }

        
        Nodo anterior = head;

        while (anterior.Siguiente != actual)
        {
            anterior = anterior.Siguiente;
        }

        Nodo turnoAnterior = actual;

        actual = anterior;

        Console.WriteLine($"\nRetrocediendo: {turnoAnterior.Dato} <- {actual.Dato}");

        if (actual == last)
        {
            Console.WriteLine("======================================");
            Console.WriteLine(" LLEGASTE AL ÚLTIMO NODO (LAST)");
            Console.WriteLine(" La lista continúa de forma circular.");
            Console.WriteLine("======================================");
        }
        else if (actual == head)
        {
            Console.WriteLine("Regresaste al primer nodo (HEAD).");
        }
        else
        {
            Console.WriteLine($"Turno actual: {actual.Dato}");
        }
    }

    public bool EstaVacia()
    {
        return head == null;
    }
}