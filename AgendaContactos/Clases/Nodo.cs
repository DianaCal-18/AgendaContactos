namespace AgendaContactos.Clases
{
    public class Nodo
    {
        public Contacto Datos { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Contacto datos)
        {
            Datos = datos;
            Siguiente = null;
        }
    }

}
