using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWhatsAppPOOII
{
    public partial class Form1 : Form
    {
        private Acciones acciones = new Acciones();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Usar los campos correctos para contactos
            if (acciones.AgregarContacto(txbNombre.Text, txbNumero.Text))
            {
                MessageBox.Show("Contacto agregado");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = acciones.MostrarContactos();
            }
            else
            {
                MessageBox.Show("Error al agregar contacto");
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            var contactos = acciones.MostrarContactos();
            dataGridView1.DataSource = contactos;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (acciones.EliminarContacto(txbNombre.Text))
            {
                MessageBox.Show("Contacto eliminado");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = acciones.MostrarContactos();
            }
            else
            {
                MessageBox.Show("Error al eliminar contacto");
            }   
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            btnExportar.Enabled = false;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
