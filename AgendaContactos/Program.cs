using AgendaContactos.Clases;

class Program
{
    static void Main()
    {
        ListaEnlazadaAgenda agenda = new ListaEnlazadaAgenda();
        int opcion;

        do
        {
            Console.WriteLine("\n===== AGENDA DE CONTACTOS =====");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Mostrar contactos");
            Console.WriteLine("3. Editar contacto");
            Console.WriteLine("4. Eliminar contacto");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción invalida. Intente nuevamente.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\n ─────────── AGREGAR CONTACTO ───────────\n");
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine()!;
                    Console.Write("Telefono: ");
                    string telefono = Console.ReadLine()!;
                    Console.Write("Correo: ");
                    string correo = Console.ReadLine()!;
                    agenda.AgregarContacto(new Contacto(nombre, telefono, correo));
                    break;

                case 2:
                    Console.Clear();
                    agenda.MostrarContactos();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("\n ─────────── EDITAR CONTACTO ───────────\n");
                    Console.Write("Ingrese el nombre del contacto a editar: ");
                    string nombreEditar = Console.ReadLine()!;
                    agenda.EditarContacto(nombreEditar);
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("\n ─────────── ELIMINAR CONTACTO ───────────\n");
                    Console.Write("Ingrese el nombre del contacto a eliminar: ");
                    string nombreEliminar = Console.ReadLine()!;
                    agenda.EliminarContacto(nombreEliminar);
                    break;

                case 5:
                    Console.WriteLine("Saliendo de la agenda...");
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }

        } while (opcion != 5);
    }
}
