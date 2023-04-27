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
    public partial class Vendedores : Form
    {
        public Vendedores()
        {
            InitializeComponent();
        }
        CapaControlador_Alumnos.CpControlador controlador = new CapaControlador_Alumnos.CpControlador();

        void displayDatos()
        {
            DataTable data = controlador.MostrarReportes();
            dataGridView1.DataSource = data;
            dataGridView1.Columns[0].HeaderText = "Carnet";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Direccion";
            dataGridView1.Columns[3].HeaderText = "Telefono";
            dataGridView1.Columns[4].HeaderText = "Correo";
            dataGridView1.Columns[5].HeaderText = "Estatus";
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            NavegadorVista.Navegador.idApp = "8002";
            TextBox[] Grupotextbox = { txt_nombre, txt_Edad, txt_DPI, txt_Empresa, txt_Fecha, txt_Puesto, txt_Venta, txt_Telefono };
            TextBox[] Idtextbox = { txt_nombre, txt_DPI };
            navegador1.textbox = Grupotextbox;
            navegador1.tabla = dataGridView1;
            navegador1.textboxi = Idtextbox;
            navegador1.actual = this;
            navegador1.cargar(dataGridView1, Grupotextbox, "Vendedores");
        }
    }
}
