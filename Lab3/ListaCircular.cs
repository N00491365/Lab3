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
}