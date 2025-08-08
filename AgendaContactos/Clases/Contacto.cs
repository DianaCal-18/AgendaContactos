
namespace AgendaContactos.Clases
{
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public Contacto(string nombre, string telefono, string correo)
        {
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Telefono: {Telefono}, Correo: {Correo}";
        }
    }

}
