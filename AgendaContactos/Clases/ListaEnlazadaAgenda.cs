namespace AgendaContactos.Clases
{
    using System;
    using System.Text.RegularExpressions;

    public class ListaEnlazadaAgenda
    {
        // Nodo que representa el inicio de la lista enlazada por eso el nombre de -cabeza-
        private Nodo? cabeza;

        // metodo para agregar un conacto al final de la lista
        public void AgregarContacto(Contacto nuevo)
        {
            // Validando que solo sean numeros ingresados en telefono 
            if (!ValidarTelefono(nuevo.Telefono))
            {
                Console.WriteLine("\n Error! Telefono no valido. Solo se permiten numeros.\n");;
                return;
            }

            // creamos un nuevo nodo con el contacto
            Nodo nuevoNodo = new Nodo(nuevo);

            // Si la lista esta vacia, el nuevo nodo sera la cabeza
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                // Si ya hay nodos, se recorre la lista hasta el final para agregarlo
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }

            Console.WriteLine("\nContacto agregado correctamente\n");
            Console.ResetColor();
        }

        // Método para mostrar todos los contactos en consola
        public void MostrarContactos()
        {
            Console.WriteLine("\n─────────── AGENDA DE CONTACTOS ───────────\n");

            // Si no hay nodos
            if (cabeza == null)
            {
                Console.WriteLine("\nLa agenda se encuentra vacia\n");
                return;
            }

            Nodo actual = cabeza;
            int index = 1;

            //Se recorre la lista y se muestra cada contacto
            while (actual != null)
            {
                Console.WriteLine($"[{index}] {actual.Datos}\n");
                actual = actual.Siguiente;
                index++;
            }

            Console.WriteLine("──────────────────────────────────────────────\n");
        }

        // metodo para eliminar contacto
        public void EliminarContacto(string nombre)
        {
            // se verifica que existan datos
            if (cabeza == null)
            {
                Console.WriteLine("\nLa agenda esta vacia\n");
                return;
            }

            // Si el contacto a eliminar es el primero
            if (cabeza.Datos.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                cabeza = cabeza.Siguiente;
                Console.WriteLine($"\n Contacto '{nombre}' eliminado.\n");
                return;
            }

            Nodo actual = cabeza;
            Nodo? anterior = null;

            // buscamos el nodo que contiene el contacto
            while (actual != null && !actual.Datos.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                anterior = actual;
                actual = actual.Siguiente;
            }

            // Si se encontro el nodo, se elimina
            if (actual != null)
            {
                anterior!.Siguiente = actual.Siguiente;
                Console.WriteLine($"\nContacto '{nombre}' ha sido eliminado");
            }
            else
            {
                Console.WriteLine($"\nContacto '{nombre}`' no encontrado.\n");
            }
        }

        // metodo para editar un contacto 
        public void EditarContacto(string nombre)
        {
            Nodo? actual = cabeza;

            // se busca el contacto por nombre
            while (actual != null && !actual.Datos.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                actual = actual.Siguiente;
            }

            // si se encuentra, pedimos los nuevos datos
            if (actual != null)
            {
                Console.Write("\nNuevo nombre: ");
                string nuevoNombre = Console.ReadLine()!;

                Console.Write("Nuevo telefono: ");
                string nuevoTelefono = Console.ReadLine()!;
                if (!ValidarTelefono(nuevoTelefono))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nError! Telefono no valido. Solo se permiten numeros.\n");
                    Console.ResetColor();
                    return;
                }

                Console.Write("Nuevo correo: ");
                string nuevoCorreo = Console.ReadLine()!;

                // Se actualizan los datos del contacto
                actual.Datos.Nombre = nuevoNombre;
                actual.Datos.Telefono = nuevoTelefono;
                actual.Datos.Correo = nuevoCorreo;

                Console.WriteLine("\nContacto editado correctamente.\n");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"\nContacto '{nombre}' no encontrado.\n");
            }
        }

        // metodo privado para validar que un telefono contenga solo dígitos
        private bool ValidarTelefono(string telefono)
        {
            return Regex.IsMatch(telefono, @"^\d{7,15}$"); // devuelve true si el string tiene de 7 a 15 numeros (lo que tiene permitido)
        }
    }
}
