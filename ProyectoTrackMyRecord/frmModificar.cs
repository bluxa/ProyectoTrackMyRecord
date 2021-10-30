using ProyectoTrackMyRecord.CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTrackMyRecord
{
    public partial class frmModificar : Form
    {
        public frmModificar()
        {
            InitializeComponent();
        }
        #region CreaciónDeVariables
        
        string idInterprete;
        ConsultasSQL objPais = new ConsultasSQL();
      
        ConsultasSQL objOcupacion = new ConsultasSQL();

        ConsultasSQL objEstado = new ConsultasSQL();

        ConsultasSQL objTipoInstrumentalista = new ConsultasSQL();

        ConsultasSQL objInsertarInterprete = new ConsultasSQL();
        
        ConsultasSQL objTipoVoz = new ConsultasSQL();

        ConsultasSQL objInterprete = new ConsultasSQL();

        ConsultasSQL objUpdate = new ConsultasSQL();

        #endregion
        private void frmModificar_Load(object sender, EventArgs e)
        {
            #region CargarComboBox
            DataTable dtPais = objPais.MostrarOpciones("sp_select_pais");
            cmbPais.DataSource = dtPais;
            cmbPais.ValueMember = "id_pais";
            cmbPais.DisplayMember = "nombre_pais";

            DataTable dtOcupacion = objOcupacion.MostrarOpciones("sp_select_ocupacion");
            cmbOcupacion.DataSource = dtOcupacion;
            cmbOcupacion.ValueMember = "id_ocupacion";
            cmbOcupacion.DisplayMember = "ocupacion";

            DataTable dtEstado = objEstado.MostrarOpciones("sp_select_estado");
            cmbEstado.DataSource = dtEstado;
            cmbEstado.ValueMember = "id_estado";
            cmbEstado.DisplayMember = "status";
            
            DataTable dtTipoInstrumentalista = objTipoInstrumentalista.MostrarOpciones("sp_select_tipo_instrumentalista");
            cmbInstrumentalista.DataSource = dtTipoInstrumentalista;
            cmbInstrumentalista.ValueMember = "id_tipo_instrumentalista";
            cmbInstrumentalista.DisplayMember = "nombre_tipo";

            DataTable dtTipoVoz = objTipoVoz.MostrarOpciones("sp_select_tipo_registro_voz");
            cmbTipoVoz.DataSource = dtTipoVoz;
            cmbTipoVoz.ValueMember = "id_tipo_registro_voz";
            cmbTipoVoz.DisplayMember = "nombre_registro";
            #endregion



            #region InicializarEnBlancoComboBox
            cmbPais.SelectedIndex = -1;
            cmbOcupacion.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbInstrumentalista.SelectedIndex = -1;
            cmbTipoVoz.SelectedIndex = -1;
            #endregion

            DGVMostrarInterpretes();
        }

        private void DGVMostrarInterpretes()
        {
            ConsultasSQL objetoActualizar = new ConsultasSQL();
            
            dataGridView1.DataSource = objetoActualizar.MostrarOpciones("sp_select_all_interprete");



            dataGridView1.Columns["fotografia_interprete"].Visible = false;

            dataGridView1.Columns[0].Visible = false;
        }


        private bool Editar = false;

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                idInterprete = dataGridView1.CurrentRow.Cells["id_interprete"].Value.ToString();
                txtNombreReal.Text = dataGridView1.CurrentRow.Cells["nombre_real"].Value.ToString();
                txtNombreArtistico.Text = dataGridView1.CurrentRow.Cells["nombre_artistico"].Value.ToString();
                //lbFechaNacimiento.Text = dataGridView1.CurrentRow.Cells["fecha_nacimiento"].Value.ToString();

                if (dataGridView1.CurrentRow.Cells["fecha_nacimiento"].Value.ToString()!="")
                {
                    DateTime dateNacimiento = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["fecha_nacimiento"].Value.ToString());
                    lbFechaNacimiento.Text = dateNacimiento.ToString("yyyy-MM-dd");
                }
                
                

                cmbPais.Text = dataGridView1.CurrentRow.Cells["nombre_pais"].Value.ToString();

                int indexOcupacion = cmbOcupacion.FindStringExact(dataGridView1.CurrentRow.Cells["ocupacion"].Value.ToString());
                cmbOcupacion.SelectedIndex = indexOcupacion;

                if (dataGridView1.CurrentRow.Cells["ocupacion"].Value.ToString() == "")
                    cmbOcupacion.SelectedIndex = -1;
                

                cmbEstado.Text = dataGridView1.CurrentRow.Cells["status"].Value.ToString();
                //lbFechaInicioCarrera.Text = dataGridView1.CurrentRow.Cells["fecha_inicio_carrera"].Value.ToString();
                if (dataGridView1.CurrentRow.Cells["fecha_inicio_carrera"].Value.ToString() != "")
                {
                    DateTime dateInicioCarrera = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["fecha_inicio_carrera"].Value.ToString());
                    lbFechaInicioCarrera.Text = dateInicioCarrera.ToString("yyyy-MM-dd");
                }
                

                int indexInstrumentalista = cmbInstrumentalista.FindStringExact(dataGridView1.CurrentRow.Cells["nombre_tipo"].Value.ToString());
                cmbInstrumentalista.SelectedIndex = indexInstrumentalista;

                if (dataGridView1.CurrentRow.Cells["nombre_tipo"].Value.ToString() == "")
                    cmbInstrumentalista.SelectedIndex = -1;

                
                int indexTipoVoz = cmbTipoVoz.FindStringExact(dataGridView1.CurrentRow.Cells["nombre_registro"].Value.ToString());
                cmbTipoVoz.SelectedIndex = indexTipoVoz;

                if (dataGridView1.CurrentRow.Cells["nombre_registro"].Value.ToString() == "")
                    cmbTipoVoz.SelectedIndex = -1;

                Byte[] data = new Byte[0];
                data = (Byte[])(dataGridView1.CurrentRow.Cells["fotografia_interprete"].Value);
                MemoryStream mem = new MemoryStream(data);
                picInterprete.Image = Image.FromStream(mem);

                
            }
            else
            {
                MessageBox.Show("SELECCIONE UNA FILA PORFAVOR");
            }
        }

        private void btnExaminarInter_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Archivos jpg (*.jpg)|*.jpg|Archivos png(*.png)|*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFotografia.Text = openFileDialog1.FileName;
            }
        }

        public void limpiar()
        {
            idInterprete = "";
            txtNombreReal.Clear();
            txtNombreArtistico.Clear();
            lbFechaNacimiento.Text="";
            cmbPais.SelectedIndex = -1;
            cmbOcupacion.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            lbFechaInicioCarrera.Text = "";
            cmbInstrumentalista.SelectedIndex = -1;
            cmbTipoVoz.SelectedIndex = -1;
            txtFotografia.Clear();
            picInterprete.Image.Dispose();
            picInterprete.Image = null;

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Editar == true)
            {
                try
                {
                    Byte[] data = new Byte[0];
                    if (txtFotografia.Text == "")
                    {
                        //img = dataGridView1.CurrentRow.Cells["fotografia_interprete"].Value.ToString();

                        data = (Byte[])(dataGridView1.CurrentRow.Cells["fotografia_interprete"].Value);
                    }
                    else
                    {
                        byte[] file = null;
                        Stream myStream = openFileDialog1.OpenFile();
                        using (MemoryStream ms = new MemoryStream())
                        {
                            myStream.CopyTo(ms);
                            file = ms.ToArray();
                        }
                        data = file;
                    }

                    objUpdate.UpdateInterprete(Convert.ToInt32(idInterprete),txtNombreReal.Text, txtNombreArtistico.Text,
                        lbFechaNacimiento.Text, cmbPais.SelectedValue + "", cmbOcupacion.SelectedValue + "",
                        cmbEstado.SelectedValue + "", lbFechaInicioCarrera.Text, cmbInstrumentalista.SelectedValue + "",
                        cmbTipoVoz.SelectedValue + "", data);

                    MessageBox.Show("SE EDITO CORRECTAMENTE ");
                    DGVMostrarInterpretes();
                    limpiar();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!!" + ex);
                }
            }
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            lbFechaNacimiento.Text = monthCalendar2.SelectionStart.Date.ToString("yyyy-MM-dd");
        }

        private void monthCalendar3_EnabledChanged(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar3_DateChanged(object sender, DateRangeEventArgs e)
        {
            lbFechaInicioCarrera.Text = monthCalendar3.SelectionStart.Date.ToString("yyyy-MM-dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPrincipal frm = new FrmPrincipal();
            this.Hide();
            frm.Show();
        }
    }
}
