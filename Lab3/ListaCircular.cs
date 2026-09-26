using System;

public class ListaCircular
{
    private Nodo head; 
    private Nodo last; 

    public ListaCircular()
    {
        head = null;
        last = null;
    }

    public void Insertar(int dato)
    {
        Nodo nuevo = new Nodo(dato);

        if (head == null) 
        {
            head = nuevo;
            last = nuevo;
            nuevo.Siguiente = head; 
        }
        else
        {
            last.Siguiente = nuevo; // El último apunta al nuevo
            nuevo.Siguiente = head; // El nuevo apunta al primero (circular)
            last = nuevo;           // Actualizamos el puntero last
        }
    }

    // Alias en estilo de nombre solicitado: Agregar
    public void Agregar(int dato)
    {
        Insertar(dato);
    }

    // Busca un nodo por su valor y devuelve el nodo encontrado o null si no existe
    public Nodo Buscar(int dato)
    {
        if (head == null)
            return null;

        Nodo actual = head;
        do
        {
            if (actual.Dato == dato)
                return actual;
            actual = actual.Siguiente;
        } while (actual != head);

        return null;
    }
        // ---------------------------------------------------------------
    // Eliminar(dato): elimina la PRIMERA aparición de 'dato'.
    // Devuelve true si lo eliminó y false si no existe.
    // Condición de parada: recorre como máximo UNA vuelta completa
    // (se detiene al regresar a head), así nunca entra en bucle infinito
    // aunque el dato no esté en la lista.
    // Mantiene la circularidad: al terminar, last.Siguiente == head.
    // ---------------------------------------------------------------
    public bool Eliminar(int dato)
    {
        // Caso 1: lista vacía -> no hay nada que eliminar
        if (head == null)
            return false;

        // Caso 2: el dato está en head
        if (head.Dato == dato)
        {
            if (head == last)
            {
                // Caso 2a: era el único nodo -> la lista queda vacía
                head = null;
                last = null;
            }
            else
            {
                // Caso 2b: avanzar head y reconectar el último con el nuevo head
                head = head.Siguiente;
                last.Siguiente = head;
            }
            return true;
        }

        // Caso 3: buscar desde el segundo nodo, recordando el anterior
        Nodo anterior = head;
        Nodo actual = head.Siguiente;

        while (actual != head) // parada: una vuelta completa
        {
            if (actual.Dato == dato)
            {
                anterior.Siguiente = actual.Siguiente; // saltar el nodo eliminado

                // Caso 3b: si era el último, 'anterior' pasa a ser el nuevo last
                if (actual == last)
                    last = anterior;

                return true;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }

        // Caso 4: se dio una vuelta completa y no se encontró el dato
        return false;
    }

    // ---------------------------------------------------------------
    // Imprimir(): muestra los datos desde head hasta regresar a head.
    // Usa do...while porque el recorrido empieza en head: con un
    // while (actual != head) normal, el ciclo no se ejecutaría nunca.
    // ---------------------------------------------------------------
    public void Imprimir()
    {
        // Lista vacía: se valida ANTES de recorrer
        if (head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = head;
        do
        {
            Console.Write($"{actual.Dato} -> ");
            actual = actual.Siguiente;
        } while (actual != head); // parada: se regresó al inicio

        Console.WriteLine($"(vuelve a {head.Dato})");
    }
}