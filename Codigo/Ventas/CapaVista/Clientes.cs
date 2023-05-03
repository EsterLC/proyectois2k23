using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }
        CapaControlador_Alumnos.CpControlador controlador = new CapaControlador_Alumnos.CpControlador();

        void displayDatos()
        {
            DataTable data = controlador.MostrarReportes();
            dataGridView1.DataSource = data;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "DPI";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[1].HeaderText = "Apellidos";
            dataGridView1.Columns[1].HeaderText = "Fecha nacimiento";
            dataGridView1.Columns[5].HeaderText = "NIT";
            dataGridView1.Columns[1].HeaderText = "Estado";
            dataGridView1.Columns[2].HeaderText = "Direccion";
            dataGridView1.Columns[3].HeaderText = "Telefono";           
            dataGridView1.Columns[5].HeaderText = "Vendedor";
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            NavegadorVista.Navegador.idApp = "7003";
            TextBox[] Grupotextbox = { txt_id, txt_dpi, txt_nombre, txt_apellido, txt_fechanac, txt_nit, txt_estado, txt_direccion, txt_telefono, txt_vendedor };
            TextBox[] Idtextbox = { txt_id, txt_dpi };
            navegador1.textbox = Grupotextbox;
            navegador1.tabla = dataGridView1;
            navegador1.textboxi = Idtextbox;
            navegador1.actual = this;
            navegador1.cargar(dataGridView1, Grupotextbox, "tbl_clientes");
        }
    }
}
