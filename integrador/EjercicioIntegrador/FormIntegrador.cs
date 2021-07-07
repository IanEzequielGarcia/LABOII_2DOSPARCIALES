using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entidades;
namespace EjercicioIntegrador
{
    public partial class FormIntegrador : Form
    {
        SqlConnection connection;
        DataTable tablita;
        SqlDataAdapter dataAdapter;
        public FormIntegrador()
        {
            InitializeComponent();
            this.connection = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=Astros;Integrated Security = True");
            this.ConfigurarGrilla();
            this.ConfigurarDataTable();
            this.ConfigurarDataAdapter();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void ConfigurarGrilla()
        {
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            this.dataGridView1.BackgroundColor = Color.LightCyan;
            this.dataGridView1.ForeColor = Color.Black;

        }

            
        public void ConfigurarDataTable()
        {
            this.tablita = new DataTable("planetas");

            this.tablita.Columns.Add("id", typeof(int));
            this.tablita.Columns.Add("nombre", typeof(string));
            this.tablita.Columns.Add("satelites", typeof(int));
            this.tablita.Columns.Add("gravedad", typeof(double));

            //columna nº0 sera la primary key
            this.tablita.PrimaryKey = new DataColumn[] { this.tablita.Columns[0] };

            this.tablita.Columns["id"].AutoIncrement = true;
            this.tablita.Columns["id"].AutoIncrementSeed = 1;
            this.tablita.Columns["id"].AutoIncrementStep = 1;
        }

        public void ConfigurarDataAdapter()
        {
            try
            {
                this.dataAdapter = new SqlDataAdapter();

                this.dataAdapter.SelectCommand = new SqlCommand("SELECT id, nombre, satelites, gravedad FROM planetas", this.connection);
                this.dataAdapter.InsertCommand = new SqlCommand("INSERT INTO planetas (nombre, satelites, gravedad) VALUES (@nombre, @satelites, @gravedad)", this.connection);
                this.dataAdapter.UpdateCommand = new SqlCommand("UPDATE planetas SET nombre=@nombre, satelites=@satelites, gravedad=@gravedad WHERE id=@id", this.connection);
                this.dataAdapter.DeleteCommand = new SqlCommand("DELETE FROM planetas WHERE id=@id", this.connection);

                this.dataAdapter.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.dataAdapter.InsertCommand.Parameters.Add("@satelites", SqlDbType.Int, 50, "satelites");
                this.dataAdapter.InsertCommand.Parameters.Add("@gravedad", SqlDbType.Float, 50, "gravedad");

                this.dataAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
                this.dataAdapter.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.dataAdapter.UpdateCommand.Parameters.Add("@satelites", SqlDbType.Int, 50, "satelites");
                this.dataAdapter.UpdateCommand.Parameters.Add("@gravedad", SqlDbType.Float, 50, "gravedad");
                

                this.dataAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


         /* 
           1- Crear un objeto de tipo Planeta.
           2- Serializarlo y mostrar en un MessageBox lo sucedido.
		   3- Si serializo, deserializarlo y mostrarlo en el RichTextBox.
         */
        private void btn1_Click(object sender, EventArgs e)
        {
            Planetas planetas = new Planetas("Urano", 27, 8.69);
            if( ((ISerializable)planetas).SerializarXML() )
            {
                MessageBox.Show("Serializado");
                this.richTextBox1.Text = ((ISerializable)planetas).DeserializarXML();
            }
        }



        /*
        1- Crear tres objetos de tipo Planeta.
		2- Crear objeto de tipo SistemaSolar.
		3- Agregarlos con el método Agregar().
        4- Mostrarlos en el RichTextBox.
        */
        private void btn2_Click(object sender, EventArgs e)
        {
            Planetas planeta1 = new Planetas("Urano", 27, 8.69);
            Planetas planeta2 = new Planetas("Marte", 2, 3.720);
            Planetas planeta3 = new Planetas("Saturno", 82, 10.44);
            SistemaSolar<Planetas> sistemaSolar = new SistemaSolar<Planetas>(new List<Planetas>(), 5);
            sistemaSolar.AgregarPlaneta(planeta1);
            sistemaSolar.AgregarPlaneta(planeta2);
            sistemaSolar.AgregarPlaneta(planeta3);
            foreach(Planetas planetas in sistemaSolar.lista)
            {
                if(!ReferenceEquals(planetas,null))
                {
                    this.richTextBox1.Text += planetas.ToString();
                }
            }
        }




        /*
         1- Crear tres objetos de tipo Planeta.
		 2- Crear objeto de tipo SistemaSolar con capacidad=2.
		 3- Atrapar la Excepción "NoHayLugarException" en un bloque try-catch 
         4- Mostrar el mensaje de error en un MessageBox.
         */
        private void btn3_Click(object sender, EventArgs e)
        {
            try
            {
                Planetas planeta1 = new Planetas("Urano", 27, 8.69);
                Planetas planeta2 = new Planetas("Marte", 2, 3.720);
                Planetas planeta3 = new Planetas("Saturno", 82, 10.44);
                SistemaSolar<Planetas> sistemaSolar = new SistemaSolar<Planetas>(new List<Planetas>(), 2);
                sistemaSolar.AgregarPlaneta(planeta1);
                sistemaSolar.AgregarPlaneta(planeta2);
                sistemaSolar.AgregarPlaneta(planeta3);
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }




        /*
         1- Invoca al método TraerPlanetas()
         2- Actualiza la grilla
         */
        private void btnTraer_Click(object sender, EventArgs e)
        {
            this.tablita = this.TraerPlanetas();
            this.dataGridView1.DataSource = this.tablita;
        }
        DataTable TraerPlanetas()
        {
            try
            {
                this.dataAdapter.Fill(this.tablita);
            }
            catch (Exception e)
            {

                throw e;
            }

            return this.tablita;
        }

        /*
         1- Invoca al formulario de alta.
		 2- Si se acepta, agrega la nueva fila(DataRow) y la ingresa en el DataTable.
		 3- Se actualiza la grilla.
         * */
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAlta formAlta = new FormAlta();
            if (formAlta.ShowDialog() == DialogResult.OK)
            {
                DataRow fila = this.tablita.NewRow();

                fila[1] = formAlta.planeta.nombre;
                fila[2] = formAlta.planeta.satelites;
                fila[3] = formAlta.planeta.gravedad;

                this.tablita.Rows.Add(fila);

                this.dataGridView1.DataSource = this.tablita;
            }
            //this.Planetas.Add(formAlta.planeta);
        }




        /*
         1- Recupera la fila seleccionada.
      	 2- Invoca el formulario de alta a modificar pasandole los datos para mostrar.
		 3- Si se acepta el modificado, se modifica en la tabla y a su vez la grilla.
         * */
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int i = this.dataGridView1.SelectedRows[0].Index;

            DataRow fila = this.tablita.Rows[i];

            Planetas p = new Planetas(fila[1].ToString(), int.Parse(fila[2].ToString()), double.Parse(fila[3].ToString()));

            FormAlta planetaModificado = new FormAlta(p);

            if (planetaModificado.ShowDialog() == DialogResult.OK)
            {
                this.tablita.Rows[i][1] = planetaModificado.planeta.nombre;
                this.tablita.Rows[i][2] = planetaModificado.planeta.satelites;
                this.tablita.Rows[i][3] = planetaModificado.planeta.gravedad;

                this.dataGridView1.DataSource = this.tablita;
            }
        }




        /*
         1- Recupera la fila seleccionada.
      	 2- Invoca el formulario de alta a eliminar pasandole los datos para mostrar.
		 3- Si se  acepta eliminado, usar el método Delete() de DataRow para eliminar 
         de la tabla.
		 4- Actualizar la grilla.
         */
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int i = this.dataGridView1.SelectedRows[0].Index;

            DataRow fila = this.tablita.Rows[i];

            Planetas p = new Planetas(fila[1].ToString(), int.Parse(fila[2].ToString()), double.Parse(fila[3].ToString()));

            FormAlta planetaEliminado = new FormAlta(p);

            if (planetaEliminado.ShowDialog() == DialogResult.OK)
            {
                this.tablita.Rows[i].Delete();

                this.dataGridView1.DataSource = this.tablita;
            }

        }




        /*
         1- Invoca al método GuardarDatos() que guarda actialización en base de datos. 
         2- Mostrar en un MessageBox lo sucedido.
         */
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.GuardarDatos())
            {
                MessageBox.Show("Se guardo exitosamente", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            else
            {
                MessageBox.Show("Error en guardar");
            }
        }
        private bool GuardarDatos()
        {
            try
            {
                this.dataAdapter.Update(this.tablita);
            }
            catch (Exception e)
            {

                return false;
            }
            return true;

        }
    }
}
