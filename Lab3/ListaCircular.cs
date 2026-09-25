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
}