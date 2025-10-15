using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

namespace CRUDWhatsAppPOOII
{
    internal class Acciones : IAcciones
    {
        private List<Contactos> listaContactos = new List<Contactos>();

        // Nuevo método para agregar todos los atributos
        public bool AgregarContacto(string nombre, string numero, string estado, string mensaje, int hora, int numerogrupos)
        {
            try
            {
                var contacto = new Contactos(nombre, numero, estado, mensaje, hora, numerogrupos)
                {
                    Estado = estado,
                    Mensaje = mensaje,
                    Hora = hora,
                    Numerogrupos = numerogrupos
                };
                listaContactos.Add(contacto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Método original para compatibilidad, puedes eliminarlo si no lo necesitas
        public bool AgregarContacto(string nombre, string numero)
        {
            try
            {
                // Proporciona valores predeterminados para los parámetros faltantes
                listaContactos.Add(new Contactos(nombre, numero, "", "", 0, 0));
                return true;
            }   
            catch (Exception)
            {
                return false;
            }
        }

        public List<Contactos> MostrarContactos()
        {
            return listaContactos;
        }

        public bool EliminarContacto(string nombre)
        {
            try
            {
                var contacto = listaContactos.FirstOrDefault(c => c.Nombre == nombre);
                if (contacto != null)
                {
                    listaContactos.Remove(contacto);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Modificar todos los atributos
        public bool ModificarContacto(string nombre, string numero, string estado, string mensaje, int hora, int numerogrupos)
        {
            try
            {
                var contacto = listaContactos.FirstOrDefault(c => c.Nombre == nombre);
                if (contacto != null)
                {
                    contacto.Numero = numero;
                    contacto.Estado = estado;
                    contacto.Mensaje = mensaje;
                    contacto.Hora = hora;
                    contacto.Numerogrupos = numerogrupos;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Método original para compatibilidad, puedes eliminarlo si no lo necesitas
        public bool ModificarContacto(string nombre, string numero)
        {
            try
            {
                var contacto = listaContactos.FirstOrDefault(c => c.Nombre == nombre);
                if (contacto != null)
                {
                    contacto.Numero = numero;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExportarExel()
        {
            try
            {
                if (listaContactos.Count == 0)
                {
                    Console.WriteLine("No hay contactos para exportar.");
                    return false;
                }

                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Contactos");

                // Encabezados
                worksheet.Cell(1, 1).Value = "Nombre";
                worksheet.Cell(1, 2).Value = "Número";
                worksheet.Cell(1, 3).Value = "Estado";
                worksheet.Cell(1, 4).Value = "Mensaje";
                worksheet.Cell(1, 5).Value = "Hora";
                worksheet.Cell(1, 6).Value = "Número de Grupos";

                // Datos
                for (int i = 0; i < listaContactos.Count; i++)
                {
                    var contacto = listaContactos[i];
                    worksheet.Cell(i + 2, 1).Value = contacto.Nombre;
                    worksheet.Cell(i + 2, 2).Value = contacto.Numero;
                    worksheet.Cell(i + 2, 3).Value = contacto.Estado;
                    worksheet.Cell(i + 2, 4).Value = contacto.Mensaje;
                    worksheet.Cell(i + 2, 5).Value = contacto.Hora;
                    worksheet.Cell(i + 2, 6).Value = contacto.Numerogrupos;
                }

                worksheet.Columns().AdjustToContents();

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string nombreArchivo = Path.Combine(desktopPath, "Contactos_exportados.xlsx");

                workbook.SaveAs(nombreArchivo);

                Console.WriteLine($"✅ Archivo Excel exportado correctamente en el escritorio: {nombreArchivo}");
                System.Diagnostics.Process.Start("explorer.exe", nombreArchivo);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al exportar el archivo Excel: " + ex.Message);
                return false;
            }
        }
    }
}
