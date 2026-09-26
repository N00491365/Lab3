using System;

class Program
{
    static void Main()
    {
        ListaCircular turnos = new ListaCircular();

        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("      SISTEMA DE GESTIÓN DE TURNOS");
            Console.WriteLine("          LISTA CIRCULAR");
            Console.WriteLine("======================================");

            Console.WriteLine("\n1. Agregar turno");
            Console.WriteLine("2. Mostrar lista circular");
            Console.WriteLine("3. Buscar turno");
            Console.WriteLine("4. Eliminar turno");
            Console.WriteLine("5. Mostrar turno actual");
            Console.WriteLine("6. Avanzar al siguiente turno");
            Console.WriteLine("7. Retroceder al turno anterior");
            Console.WriteLine("0. Salir");

            Console.Write("\nSeleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("\nOpción no válida.");
                Pausar();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("\nIngrese el número del turno: ");

                    if (int.TryParse(Console.ReadLine(), out int nuevoTurno))
                    {
                        if (turnos.Buscar(nuevoTurno) != null)
                        {
                            Console.WriteLine("Ese turno ya existe.");
                        }
                        else
                        {
                            turnos.Agregar(nuevoTurno);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número válido.");
                    }

                    Pausar();
                    break;

                case 2:
                    turnos.Imprimir();
                    Pausar();
                    break;

                case 3:
                    Console.Write("\nIngrese el turno que desea buscar: ");

                    if (int.TryParse(Console.ReadLine(), out int turnoBuscar))
                    {
                        Nodo encontrado = turnos.Buscar(turnoBuscar);

                        if (encontrado != null)
                        {
                            Console.WriteLine($"El turno {turnoBuscar} SÍ existe.");
                        }
                        else
                        {
                            Console.WriteLine($"El turno {turnoBuscar} NO existe.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número válido.");
                    }

                    Pausar();
                    break;

                case 4:
                    Console.Write("\nIngrese el turno que desea eliminar: ");

                    if (int.TryParse(Console.ReadLine(), out int turnoEliminar))
                    {
                        turnos.Eliminar(turnoEliminar);
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número válido.");
                    }

                    Pausar();
                    break;

                case 5:
                    turnos.MostrarActual();
                    Pausar();
                    break;

                case 6:
                    turnos.SiguienteTurno();
                    Pausar();
                    break;

                case 7:
                    turnos.RetrocederTurno();
                    Pausar();
                    break;

                case 0:
                    Console.WriteLine("\nPrograma finalizado.");
                    break;

                default:
                    Console.WriteLine("\nOpción no válida.");
                    Pausar();
                    break;
            }

        } while (opcion != 0);
    }

    static void Pausar()
    {
        Console.WriteLine("\nPresione ENTER para continuar...");
        Console.ReadLine();
    }
}