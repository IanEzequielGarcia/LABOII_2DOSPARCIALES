using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace EjercicioIntegrador
{
    public partial class FormAlta : Form
    {
        public Planetas planeta;

        public FormAlta()
        {
            InitializeComponent();
            this.planeta = new Planetas();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public FormAlta(Planetas p):this()
        {
            this.txtNombre.Text = p.nombre;
            this.txtSatelites.Text = p.satelites.ToString();
            this.txtGravedad.Text = p.gravedad.ToString();
        }



        //Recupera los datos de los txtBox y carga el atributo.
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.planeta.nombre     = this.txtNombre.Text;
            this.planeta.satelites  = int.Parse(this.txtSatelites.Text);
            this.planeta.gravedad   = double.Parse(this.txtGravedad.Text);

            this.DialogResult       = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
