using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWhatsAppPOOII
{
    internal class WhatsApp
    {
        public WhatsApp()
        { }

        public WhatsApp(string estado, string mensaje, int hora, int numerogrupos)
           
        {
            Estado = estado;
            Mensaje = mensaje;
            Hora = hora;
            Numerogrupos = numerogrupos;
        }

        public string Estado { get; set; }
        public string Mensaje { get; set; }
        public int Hora { get; set; }
        public int Numerogrupos { get; set; }



    }
}
