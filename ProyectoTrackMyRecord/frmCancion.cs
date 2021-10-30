using ProyectoTrackMyRecord.CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTrackMyRecord
{
    public partial class frmCancion : Form
    {
        public frmCancion()
        {
            InitializeComponent();
        }
        #region CreaciónDeVariables
        
        ConsultasSQL objInsertarCancion = new ConsultasSQL();
        ConsultasSQL objGeneroMusical = new ConsultasSQL();

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPrincipal frm = new FrmPrincipal();
            this.Hide();
            frm.Show();
        }

        public void limpiar()
        {
            idCancion = "";
            txtTituloCancion.Clear();
            txtNoPiezaDisco.Clear();
            lbFechaLanzaCancion.Text = "";
            cmbGeneroMusical.SelectedIndex = -1;
            txtLetraCancion.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                objInsertarCancion.UpdateCancion(idCancion,txtTituloCancion.Text, Convert.ToInt32(txtNoPiezaDisco.Text), txtLetraCancion.Text,
                    lbFechaLanzaCancion.Text, Convert.ToInt32(cmbGeneroMusical.SelectedValue));

                limpiar();
                MessageBox.Show("SE INSERTO CORRECTAMENTE ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL INSERTAR" + ex);
            }
        }

        private void frmCancion_Load(object sender, EventArgs e)
        {
            #region CargarComboBox
            DataTable dtGeneroMusical = objGeneroMusical.MostrarOpciones("sp_select_genero_musical");
            cmbGeneroMusical.DataSource = dtGeneroMusical;
            cmbGeneroMusical.ValueMember = "id_genero_musical";
            cmbGeneroMusical.DisplayMember = "nombre";


            #endregion



            #region InicializarEnBlancoComboBox
            cmbGeneroMusical.SelectedIndex = -1;


            #endregion


            DGVMostrarCanciones();
        }

        private void DGVMostrarCanciones()
        {
            ConsultasSQL objetoActualizar = new ConsultasSQL();

            dataGridView1.DataSource = objetoActualizar.MostrarOpciones("sp_select_all_cancion");

            dataGridView1.Columns["letra_cancion"].Visible = false;

            dataGridView1.Columns[0].Visible = false;
        }
        string idCancion;
        private bool Editar = false;
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                idCancion = dataGridView1.CurrentRow.Cells["id_cancion"].Value.ToString();
                txtTituloCancion.Text = dataGridView1.CurrentRow.Cells["titulo_cancion"].Value.ToString();
                txtNoPiezaDisco.Text = dataGridView1.CurrentRow.Cells["numero_pieza_disco"].Value.ToString();
                txtLetraCancion.Text = dataGridView1.CurrentRow.Cells["letra_cancion"].Value.ToString();

                if (dataGridView1.CurrentRow.Cells["fecha_lanzamiento_cancion"].Value.ToString()!="")
                {
                    DateTime dateNacimiento = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["fecha_lanzamiento_cancion"].Value.ToString());
                    lbFechaLanzaCancion.Text = dateNacimiento.ToString("yyyy-MM-dd");
                }
                

                int indexGenero = cmbGeneroMusical.FindStringExact(dataGridView1.CurrentRow.Cells["nombre"].Value.ToString());
                cmbGeneroMusical.SelectedIndex = indexGenero;

                if (dataGridView1.CurrentRow.Cells["nombre"].Value.ToString() == "")
                    cmbGeneroMusical.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("SELECCIONE UNA FILA PORFAVOR");
            }
        }

        private void monthCalendar4_DateChanged(object sender, DateRangeEventArgs e)
        {
            lbFechaLanzaCancion.Text = monthCalendar4.SelectionStart.Date.ToString("yyyy-MM-dd");
        }
    }
}
