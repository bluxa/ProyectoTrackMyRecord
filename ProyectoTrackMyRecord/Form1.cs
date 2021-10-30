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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        #region CreaciónDeVariables
        ConsultasSQL objPais = new ConsultasSQL();

        ConsultasSQL objFormatoDisco = new ConsultasSQL();

        ConsultasSQL objCompaniaDiscografica = new ConsultasSQL();

        ConsultasSQL objOcupacion = new ConsultasSQL();

        ConsultasSQL objEstado = new ConsultasSQL();

        ConsultasSQL objTipoInstrumentalista = new ConsultasSQL();

        ConsultasSQL objInsertarInterprete = new ConsultasSQL();

        ConsultasSQL objGeneroMusical = new ConsultasSQL();

        ConsultasSQL objInsertarDisco = new ConsultasSQL();

        ConsultasSQL objInsertarCancion = new ConsultasSQL();

        ConsultasSQL objInsertarGrupo = new ConsultasSQL();

        ConsultasSQL objTipoVoz = new ConsultasSQL();

        ConsultasSQL objInterprete = new ConsultasSQL();

        ConsultasSQL objCancionInterprete = new ConsultasSQL();

        ConsultasSQL objInsertarCancionInterprete = new ConsultasSQL();

        ConsultasSQL objTipoAutor = new ConsultasSQL();

        ConsultasSQL objInsertarAutor = new ConsultasSQL();

        ConsultasSQL objCancionAutor = new ConsultasSQL();

        ConsultasSQL objInsertarCancionAutor = new ConsultasSQL();

        ConsultasSQL objPremio = new ConsultasSQL();

        ConsultasSQL objInterpretePremio = new ConsultasSQL();

        ConsultasSQL objInsertarInterpretePremio = new ConsultasSQL();

        ConsultasSQL objIntegranteGrupo = new ConsultasSQL();

        ConsultasSQL objInsertarIntegranteGrupo = new ConsultasSQL();

        #endregion

        public void limpiar()
        {
            cmbPais.SelectedIndex = -1;
            cmbFormatoDisco.SelectedIndex = -1;
            cmbCompaniaDiscografica.SelectedIndex = -1;
            cmbOcupacion.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbEstadoGrpMusical.SelectedIndex = -1;
            cmbInstrumentalista.SelectedIndex = -1;
            cmbGeneroMusical.SelectedIndex = -1;
            cmbTipoVoz.SelectedIndex = -1;
            cmbInterpreteDisco.SelectedIndex = -1;
            cmbInterpreteCancion.SelectedIndex = -1;
            cmbTipoAutorInterprete.SelectedIndex = -1;
            cmbCancionAutor.SelectedIndex = -1;
            cmbInterpretePremio.SelectedIndex = -1;
            cmbPremio.SelectedIndex = -1;
            cmbIntegranteGrupo.SelectedIndex = -1;

            
            txtNombreReal.Clear();
            txtNombreArtistico.Clear();
            lbFechaNacimiento.Text = "";
            cmbPais.SelectedIndex = -1;
            cmbOcupacion.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            lbFechaInicioCarrera.Text = "";
            cmbInstrumentalista.SelectedIndex = -1;
            cmbTipoVoz.SelectedIndex = -1;
            txtFotografia.Clear();

            txtLetraCancion.Clear();
            txtTituloCancion.Clear();

            txtFotografiaDisco.Clear();
            txtNombreDisco.Clear();
            txtNoPiezaDisco.Clear();
            txtTiempoDuracion.Clear();
            lbFechaLanzamiento.Text = "";
            txtNumeroCancion.Clear();

            txtCategoriaPremio.Clear();

            txtNombreGrupoMusical.Clear();
            txtNoIntegranteGrp.Clear();
            txtCasaProductoraGrp.Clear();
            lbAnoFundacionGrp.Text = "";
            lbAnoSeparacionGrp.Text = "";

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            try
            {
                byte[] file = null;
                Stream myStream = openFileDialog1.OpenFile();
                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);
                    file = ms.ToArray();
                }

                //objInsertarInterprete.InsertarInterprete(txtNombreReal.Text, txtNombreArtistico.Text,
                //    lbFechaNacimiento.Text, Convert.ToInt32(cmbPais.SelectedValue), Convert.ToInt32(cmbOcupacion.SelectedValue),
                //    Convert.ToInt32(cmbEstado.SelectedValue), lbFechaInicioCarrera.Text, Convert.ToInt32(cmbInstrumentalista.SelectedValue),
                //    Convert.ToInt32(cmbTipoVoz.SelectedValue), file);

                objInsertarInterprete.InsertarInterprete(txtNombreReal.Text, txtNombreArtistico.Text,
                    lbFechaNacimiento.Text, cmbPais.SelectedValue + "", cmbOcupacion.SelectedValue + "",
                    cmbEstado.SelectedValue + "", lbFechaInicioCarrera.Text, cmbInstrumentalista.SelectedValue + "",
                    cmbTipoVoz.SelectedValue + "", file, "sp_insert_interprete");

                if (chkAutor.Checked == true)
                {
                    objInsertarAutor.InsertarAutor(Convert.ToInt32(cmbTipoAutorInterprete.SelectedValue));
                    //MessageBox.Show("CORRECTAMENTE");
                }

                MessageBox.Show("SE INSERTO CORRECTAMENTE");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL INSERTAR" + ex);
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            #region CargarComboBox
            DataTable dtPais = objPais.MostrarOpciones("sp_select_pais");
            cmbPais.DataSource = dtPais;
            cmbPais.ValueMember = "id_pais";
            cmbPais.DisplayMember = "nombre_pais";

            DataTable dtFormatoDisco = objFormatoDisco.MostrarOpciones("sp_selec_formato_disco");
            cmbFormatoDisco.DataSource = dtFormatoDisco;
            cmbFormatoDisco.ValueMember = "id_formato_disco";
            cmbFormatoDisco.DisplayMember = "nombre_formato";

            DataTable dtCompaniaDiscografica = objCompaniaDiscografica.MostrarOpciones("sp_selec_compañia_discografica");
            cmbCompaniaDiscografica.DataSource = dtCompaniaDiscografica;
            cmbCompaniaDiscografica.ValueMember = "id_compañia_discografica";
            cmbCompaniaDiscografica.DisplayMember = "nombre_compañia";

            DataTable dtOcupacion = objOcupacion.MostrarOpciones("sp_select_ocupacion");
            cmbOcupacion.DataSource = dtOcupacion;
            cmbOcupacion.ValueMember = "id_ocupacion";
            cmbOcupacion.DisplayMember = "ocupacion";

            DataTable dtEstado = objEstado.MostrarOpciones("sp_select_estado");
            cmbEstado.DataSource = dtEstado;
            cmbEstado.ValueMember = "id_estado";
            cmbEstado.DisplayMember = "status";

            cmbEstadoGrpMusical.DataSource = dtEstado;
            cmbEstadoGrpMusical.ValueMember = "id_estado";
            cmbEstadoGrpMusical.DisplayMember = "status";

            DataTable dtTipoInstrumentalista = objTipoInstrumentalista.MostrarOpciones("sp_select_tipo_instrumentalista");
            cmbInstrumentalista.DataSource = dtTipoInstrumentalista;
            cmbInstrumentalista.ValueMember = "id_tipo_instrumentalista";
            cmbInstrumentalista.DisplayMember = "nombre_tipo";

            DataTable dtGeneroMusical = objGeneroMusical.MostrarOpciones("sp_select_genero_musical");
            cmbGeneroMusical.DataSource = dtGeneroMusical;
            cmbGeneroMusical.ValueMember = "id_genero_musical";
            cmbGeneroMusical.DisplayMember = "nombre";

            DataTable dtTipoVoz = objTipoVoz.MostrarOpciones("sp_select_tipo_registro_voz");
            cmbTipoVoz.DataSource = dtTipoVoz;
            cmbTipoVoz.ValueMember = "id_tipo_registro_voz";
            cmbTipoVoz.DisplayMember = "nombre_registro";

            DataTable dtInterprete = objInterprete.MostrarOpciones("sp_select_interprete");
            cmbInterpreteDisco.DataSource = dtInterprete;
            cmbInterpreteDisco.ValueMember = "id_interprete";
            cmbInterpreteDisco.DisplayMember = "nombre_artistico";

            DataTable dtCancionInterprete = objCancionInterprete.MostrarOpciones("sp_select_interprete");
            cmbInterpreteCancion.DataSource = dtCancionInterprete;
            cmbInterpreteCancion.ValueMember = "id_interprete";
            cmbInterpreteCancion.DisplayMember = "nombre_artistico";

            DataTable dtTipoAutor = objTipoAutor.MostrarOpciones("sp_select_tipo_autor");
            cmbTipoAutorInterprete.DataSource = dtTipoAutor;
            cmbTipoAutorInterprete.ValueMember = "id_tipo_autor";
            cmbTipoAutorInterprete.DisplayMember = "nombre_tipo";

            DataTable dtCancionAutor = objCancionAutor.MostrarOpciones("sp_select_autor");
            cmbCancionAutor.DataSource = dtCancionAutor;
            cmbCancionAutor.ValueMember = "id_autor";
            cmbCancionAutor.DisplayMember = "nombre_artistico";

            DataTable dtInterpretePremio = objInterpretePremio.MostrarOpciones("sp_select_interprete");
            cmbInterpretePremio.DataSource = dtInterpretePremio;
            cmbInterpretePremio.ValueMember = "id_interprete";
            cmbInterpretePremio.DisplayMember = "nombre_artistico";

            DataTable dtPremio = objPremio.MostrarOpciones("sp_select_premio");
            cmbPremio.DataSource = dtPremio;
            cmbPremio.ValueMember = "id_premio";
            cmbPremio.DisplayMember = "nombre_premio";

            DataTable dtIntegranteGrupo = objIntegranteGrupo.MostrarOpciones("sp_select_interprete");
            cmbIntegranteGrupo.DataSource = dtIntegranteGrupo;
            cmbIntegranteGrupo.ValueMember = "id_interprete";
            cmbIntegranteGrupo.DisplayMember = "nombre_artistico";
            #endregion



            #region InicializarEnBlancoComboBox
            cmbPais.SelectedIndex = -1;
            cmbFormatoDisco.SelectedIndex = -1;
            cmbCompaniaDiscografica.SelectedIndex = -1;
            cmbOcupacion.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbEstadoGrpMusical.SelectedIndex = -1;
            cmbInstrumentalista.SelectedIndex = -1;
            cmbGeneroMusical.SelectedIndex = -1;
            cmbTipoVoz.SelectedIndex = -1;
            cmbInterpreteDisco.SelectedIndex = -1;
            cmbInterpreteCancion.SelectedIndex = -1;
            cmbTipoAutorInterprete.SelectedIndex = -1;
            cmbCancionAutor.SelectedIndex = -1;
            cmbInterpretePremio.SelectedIndex = -1;
            cmbPremio.SelectedIndex = -1;
            cmbIntegranteGrupo.SelectedIndex = -1;

            #endregion

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            lbFechaNacimiento.Text = monthCalendar2.SelectionStart.Date.ToString("yyyy-MM-dd");
        }

        private void monthCalendar3_DateChanged(object sender, DateRangeEventArgs e)
        {
            lbFechaInicioCarrera.Text = monthCalendar3.SelectionStart.Date.ToString("yyyy-MM-dd");
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            lbFechaLanzamiento.Text = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
        }

        private void monthCalendar4_DateChanged(object sender, DateRangeEventArgs e)
        {
            lbFechaLanzaCancion.Text = monthCalendar4.SelectionStart.Date.ToString("yyyy-MM-dd");
        }

        private void btnAgregarDisco_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] file = null;
                Stream myStream = openFileDialog1.OpenFile();
                using (MemoryStream ms = new MemoryStream())
                {
                    myStream.CopyTo(ms);
                    file = ms.ToArray();
                }

                objInsertarDisco.InsertarDisco(txtNombreDisco.Text, lbFechaLanzamiento.Text, Convert.ToInt32(cmbCompaniaDiscografica.SelectedValue),
                    Convert.ToInt32(txtNumeroCancion.Text), txtTiempoDuracion.Text, file, Convert.ToInt32(cmbFormatoDisco.SelectedValue),
                    Convert.ToInt32(cmbInterpreteDisco.SelectedValue));
                MessageBox.Show("SE INSERTO CORRECTAMENTE");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL INSERTAR" + ex);
            }
        }

        private void btnAgregarCancion_Click(object sender, EventArgs e)
        {
            try
            {
                objInsertarCancion.InsertarCancion(txtTituloCancion.Text, Convert.ToInt32(txtNoPiezaDisco.Text), txtLetraCancion.Text,
                    lbFechaLanzaCancion.Text, Convert.ToInt32(cmbGeneroMusical.SelectedValue));

                objInsertarCancionInterprete.InsertarCancionInterprete(Convert.ToInt32(cmbInterpreteCancion.SelectedValue));

                if (chkAgregarCancionAutor.Checked == true)
                {
                    objInsertarCancionAutor.InsertarCancionAutor(Convert.ToInt32(cmbCancionAutor.SelectedValue));

                }
                MessageBox.Show("SE INSERTO CORRECTAMENTE ");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL INSERTAR" + ex);
            }
        }

        private void btnAgregarGrpMusical_Click(object sender, EventArgs e)
        {
            try
            {
                objInsertarGrupo.InsertarGrupoMusical(txtNombreGrupoMusical.Text,lbAnoFundacionGrp.Text, lbAnoSeparacionGrp.Text,
                    txtCasaProductoraGrp.Text,txtNoIntegranteGrp.Text,Convert.ToInt32(cmbEstadoGrpMusical.SelectedValue));

                if (chkIntegranteGrupo.Checked == true)
                {
                    objInsertarIntegranteGrupo.InsertarGrupoInterprete(Convert.ToInt32(cmbIntegranteGrupo.SelectedValue));
                }
                limpiar();
                MessageBox.Show("SE INSERTO CORRECTAMENTE");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL INSERTAR" + ex);
            }
        }

        private void monthCalendar5_DateChanged(object sender, DateRangeEventArgs e)
        {
            lbAnoFundacionGrp.Text = monthCalendar5.SelectionStart.Date.ToString("yyyy-MM-dd");
        }

        private void monthCalendar6_DateChanged(object sender, DateRangeEventArgs e)
        {
            lbAnoSeparacionGrp.Text = monthCalendar6.SelectionStart.Date.ToString("yyyy-MM-dd");
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

        private void btnExaminarImgDisco_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Archivos jpg (*.jpg)|*.jpg|Archivos png(*.png)|*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFotografiaDisco.Text = openFileDialog1.FileName;
            }
        }

        private void chkAutor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutor.Checked == true)
                cmbTipoAutorInterprete.Enabled = true;
            if (chkAutor.Checked == false)
                cmbTipoAutorInterprete.Enabled = false;
            
        }

        private void chkAgregarCancionAutor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgregarCancionAutor.Checked == true)
                cmbCancionAutor.Enabled = true;
            if (chkAgregarCancionAutor.Checked == false)
                cmbCancionAutor.Enabled = false;
        }

        private void btnInterpretePremio_Click(object sender, EventArgs e)
        {
            try
            {
                objInsertarInterpretePremio.InsertarInterpretePremio(Convert.ToInt32(cmbInterpretePremio.SelectedValue),
                Convert.ToInt32(cmbPremio.SelectedValue),txtCategoriaPremio.Text);
                MessageBox.Show("SE INSERTO CORRECTAMENTE ");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL INSERTAR" + ex);
            }

        }

        private void chkIntegranteGrupo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIntegranteGrupo.Checked == true)
                cmbIntegranteGrupo.Enabled = true;
            if (chkIntegranteGrupo.Checked == false)
                cmbIntegranteGrupo.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            frmModificar frm = new frmModificar();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCancion frm = new frmCancion();
            this.Hide();
            frm.Show();
        }
    }
}
