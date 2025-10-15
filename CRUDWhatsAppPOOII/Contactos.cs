using System;

namespace CRUDWhatsAppPOOII
{
    internal class Contactos : WhatsApp
    {
        public Contactos()
        { }

        public Contactos(string nombre, string numero, string estado, string mensaje, int hora, int numerogrupos)
            : base(estado, mensaje, hora, numerogrupos)
        {
            Nombre = nombre;
            Numero = numero;
        }

        public string Nombre { get; set; }
        public string Numero { get; set; }
    }
}

