using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWhatsAppPOOII
{
    internal interface IAcciones
    {
        List<Contactos> MostrarContactos();
        bool AgregarContacto(string nombre, string numero);
        bool EliminarContacto(string nombre);
        bool ModificarContacto(string nombre, string numero);
        bool ExportarExel();
    }
}
