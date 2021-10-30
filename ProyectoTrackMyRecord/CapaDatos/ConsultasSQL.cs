using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTrackMyRecord.CapaDatos
{
    class ConsultasSQL
    {
        private ConexionBD miConexion = new ConexionBD();

        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataReader da;

        public DataTable MostrarOpciones(string procedure_name)
        {
            cmd.Connection = miConexion.AbrirConexion();
            cmd.CommandText = procedure_name;
            cmd.CommandType = CommandType.StoredProcedure;

            da = cmd.ExecuteReader();

            dt.Load(da);

            da.Close();
            miConexion.CerrarConexion();
            return dt;
        }

        //public void InsertarInterprete(string nombreReal, string nombreArtistico, string fechaNacimiento,
        //    int idPais, int idOcupacion, int idEstado, string fechaInicioCarrera, int idTipoInstrumentalista,
        //    int tipoVozInterprete, byte[] fotografiaInterprete)
        //{

        //    //SqlTransaction transaction = miConexion.AbrirConexion().BeginTransaction();

        //    //cmd.Transaction = transaction;

        //    try
        //    {
        //        cmd.Connection = miConexion.AbrirConexion();

        //        cmd.CommandText = "sp_insert_interprete";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@nombre_real", nombreReal);
        //        cmd.Parameters.AddWithValue("@nombre_artistico", nombreArtistico);
        //        cmd.Parameters.AddWithValue("@fecha_nacimiento", fechaNacimiento);
        //        cmd.Parameters.AddWithValue("@id_pais", idPais);
        //        cmd.Parameters.AddWithValue("@id_ocupacion", idOcupacion);
        //        cmd.Parameters.AddWithValue("@id_estado", idEstado);
        //        cmd.Parameters.AddWithValue("@fecha_inicio_carrera", fechaInicioCarrera);
        //        cmd.Parameters.AddWithValue("@id_tipo_instrumentalista", idTipoInstrumentalista);
        //        cmd.Parameters.AddWithValue("@id_tipo_registro_voz", tipoVozInterprete);
        //        cmd.Parameters.AddWithValue("@fotografia_interprete", fotografiaInterprete);

        //        cmd.ExecuteNonQuery();

        //        //transaction.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        const string message ="Error en la base de datos";
        //        const string caption = "Form Closing";
        //        var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        //transaction.Rollback();
        //    }
        //    finally
        //    {
        //        miConexion.CerrarConexion();
        //    }           
        //}
        public void InsertarInterprete(string nombreReal, string nombreArtistico, string fechaNacimiento,
            string idPais, string idOcupacion, string idEstado, string fechaInicioCarrera, string idTipoInstrumentalista,
            string tipoVozInterprete, byte[] fotografiaInterprete, string procedure_name)
        {
            //SqlTransaction transaction = miConexion.AbrirConexion().BeginTransaction();
            //cmd.Transaction = transaction;

            try
            {
                cmd.Connection = miConexion.AbrirConexion();

                if (nombreReal == "")
                    nombreReal = null;
                if (fechaNacimiento == "")
                    fechaNacimiento = null;
                if (idOcupacion == "")
                    idOcupacion = null;
                if (fechaInicioCarrera == "")
                    fechaInicioCarrera = null;
                if (idTipoInstrumentalista == "")
                    idTipoInstrumentalista = null;
                if (tipoVozInterprete == "")
                    tipoVozInterprete = null;

                cmd.CommandText = procedure_name;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre_real", nombreReal);
                cmd.Parameters.AddWithValue("@nombre_artistico", nombreArtistico);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@id_pais", idPais);
                cmd.Parameters.AddWithValue("@id_ocupacion", idOcupacion);
                cmd.Parameters.AddWithValue("@id_estado", idEstado);
                cmd.Parameters.AddWithValue("@fecha_inicio_carrera", fechaInicioCarrera);
                cmd.Parameters.AddWithValue("@id_tipo_instrumentalista", idTipoInstrumentalista);
                cmd.Parameters.AddWithValue("@id_tipo_registro_voz", tipoVozInterprete);
                cmd.Parameters.AddWithValue("@fotografia_interprete", fotografiaInterprete);

                cmd.ExecuteNonQuery();

                //transaction.Commit();
            }
            catch (Exception ex)
            { 
                const string message = "Error en la base de datos ";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message+ex, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //transaction.Rollback();
            }
            finally
            {
                miConexion.CerrarConexion();
            }
        }

        public void InsertarDisco(string nombreDisco, string fechaLanzamiento, int idCompaniaDiscografica,
            int numeroCancion, string tiempoDuracion, byte[] fotografiaDisco, int idFormatoDisco, int idInterprete)
        {
            cmd.Connection = miConexion.AbrirConexion();

            cmd.CommandText = "sp_insert_disco";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre_disco", nombreDisco);
            cmd.Parameters.AddWithValue("@fecha_lanzamiento", fechaLanzamiento);
            cmd.Parameters.AddWithValue("@id_compañia_discografica", idCompaniaDiscografica);
            cmd.Parameters.AddWithValue("@numero_cancion", numeroCancion);
            cmd.Parameters.AddWithValue("@tiempo_duracion", tiempoDuracion);
            cmd.Parameters.AddWithValue("@fotografia_disco", fotografiaDisco);
            cmd.Parameters.AddWithValue("@id_formato_disco", idFormatoDisco);
            cmd.Parameters.AddWithValue("@id_interprete", idInterprete);

            cmd.ExecuteNonQuery();
            miConexion.CerrarConexion();
        }

        public void InsertarCancion(string tituloCancion, int noPiezaDisco, string letraCancion, 
            string fechaLanzCancion, int idGeneroMusical)
        {
            cmd.Connection = miConexion.AbrirConexion();

            cmd.CommandText = "sp_insert_cancion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@titulo_cancion", tituloCancion);
            cmd.Parameters.AddWithValue("@numero_pieza_disco", noPiezaDisco);
            cmd.Parameters.AddWithValue("@letra_cancion", letraCancion);
            cmd.Parameters.AddWithValue("@fecha_lanzamiento_cancion", fechaLanzCancion);
            cmd.Parameters.AddWithValue("@id_genero_musical", idGeneroMusical);

            cmd.ExecuteNonQuery();
            miConexion.CerrarConexion();
        }

        public void InsertarGrupoMusical(string nombreGrp, string anoFundacionGrp, string anoSeparacionGrp, 
            string casaProductoraGrp, string noIntegranteGrp, int idEstadoGrp)
        {
           
            cmd.Connection = miConexion.AbrirConexion();

            if (anoFundacionGrp == "")
                anoFundacionGrp = null;
            if (anoSeparacionGrp == "")
                anoSeparacionGrp = null;
            if (casaProductoraGrp == "")
                casaProductoraGrp = null;
            if (noIntegranteGrp == "")
                noIntegranteGrp = null;

            cmd.CommandText = "sp_insert_grupo_musical";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre_grupo_musical", nombreGrp);
            cmd.Parameters.AddWithValue("@ano_fundacion", anoFundacionGrp);
            cmd.Parameters.AddWithValue("@ano_separacion", anoSeparacionGrp);
            cmd.Parameters.AddWithValue("@casa_productora", casaProductoraGrp);
            cmd.Parameters.AddWithValue("@no_integrante", noIntegranteGrp);
            cmd.Parameters.AddWithValue("@id_estado", idEstadoGrp);

            cmd.ExecuteNonQuery();
            miConexion.CerrarConexion();
        }


        public void InsertarCancionInterprete(int idInterprete)
        {
            try
            {
                cmd.Connection = miConexion.AbrirConexion();

                cmd.CommandText = "sp_insertar_cancion_interprete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_interprete", idInterprete);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                const string message = "Error en la base de datos ";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message + ex, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                miConexion.CerrarConexion();
            }
        }



        /*INSERTAR AUTOR */
        public void InsertarAutor(int idTipoAutor)
        {
            try
            {
                cmd.Connection = miConexion.AbrirConexion();

                cmd.CommandText = "sp_insert_autor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_tipo_autor", idTipoAutor);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                const string message = "Error en la base de datos ";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message + ex, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                miConexion.CerrarConexion();
            }
        }

        public void InsertarCancionAutor(int idAutor)
        {
            try
            {
                cmd.Connection = miConexion.AbrirConexion();

                cmd.CommandText = "sp_insert_cancion_autor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_autor", idAutor);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                const string message = "Error en la base de datos ";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message + ex, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                miConexion.CerrarConexion();
            }
        }


        public void InsertarInterpretePremio(int idInterprete, int idPremio, string categoriaPremio)
        {
            try
            {
                cmd.Connection = miConexion.AbrirConexion();

                cmd.CommandText = "sp_insert_interprete_premio";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_interprete", idInterprete);
                cmd.Parameters.AddWithValue("@id_premio", idPremio);
                cmd.Parameters.AddWithValue("@categoria_premio", categoriaPremio);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                const string message = "Error en la base de datos ";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message + ex, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                miConexion.CerrarConexion();
            }
        }


        public void InsertarGrupoInterprete(int idInterprete)
        {
            try
            {
                cmd.Connection = miConexion.AbrirConexion();

                cmd.CommandText = "sp_insert_grupo_interprete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_interprete", idInterprete);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                const string message = "Error en la base de datos ";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message + ex, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                miConexion.CerrarConexion();
            }
        }


        public void UpdateInterprete(int id, string nombreReal, string nombreArtistico, string fechaNacimiento,
            string idPais, string idOcupacion, string idEstado, string fechaInicioCarrera, string idTipoInstrumentalista,
            string tipoVozInterprete, byte[] fotografiaInterprete)
        {
            //SqlTransaction transaction = miConexion.AbrirConexion().BeginTransaction();
            //cmd.Transaction = transaction;

            try
            {
                cmd.Connection = miConexion.AbrirConexion();

                if (nombreReal == "")
                    nombreReal = null;
                if (fechaNacimiento == "")
                    fechaNacimiento = null;
                if (idOcupacion == "")
                    idOcupacion = null;
                if (fechaInicioCarrera == "")
                    fechaInicioCarrera = null;
                if (idTipoInstrumentalista == "")
                    idTipoInstrumentalista = null;
                if (tipoVozInterprete == "")
                    tipoVozInterprete = null;

                cmd.CommandText = "sp_update_interprete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_interprete", id);
                cmd.Parameters.AddWithValue("@nombre_real", nombreReal);
                cmd.Parameters.AddWithValue("@nombre_artistico", nombreArtistico);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@id_pais", idPais);
                cmd.Parameters.AddWithValue("@id_ocupacion", idOcupacion);
                cmd.Parameters.AddWithValue("@id_estado", idEstado);
                cmd.Parameters.AddWithValue("@fecha_inicio_carrera", fechaInicioCarrera);
                cmd.Parameters.AddWithValue("@id_tipo_instrumentalista", idTipoInstrumentalista);
                cmd.Parameters.AddWithValue("@id_tipo_registro_voz", tipoVozInterprete);
                cmd.Parameters.AddWithValue("@fotografia_interprete", fotografiaInterprete);

                cmd.ExecuteNonQuery();

                //transaction.Commit();
            }
            catch (Exception ex)
            {
                const string message = "Error en la base de datos ";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message + ex, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //transaction.Rollback();
            }
            finally
            {
                miConexion.CerrarConexion();
            }
        }



        public void UpdateCancion(string id, string tituloCancion, int noPiezaDisco, string letraCancion,
            string fechaLanzCancion, int idGeneroMusical)
        {
            try
            {
                cmd.Connection = miConexion.AbrirConexion();

                cmd.CommandText = "sp_update_cancion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_cancion", id);
                cmd.Parameters.AddWithValue("@titulo_cancion", tituloCancion);
                cmd.Parameters.AddWithValue("@numero_pieza_disco", noPiezaDisco);
                cmd.Parameters.AddWithValue("@letra_cancion", letraCancion);
                cmd.Parameters.AddWithValue("@fecha_lanzamiento_cancion", fechaLanzCancion);
                cmd.Parameters.AddWithValue("@id_genero_musical", idGeneroMusical);

                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                const string message = "Error en la base de datos ";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message + ex, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                miConexion.CerrarConexion();
            }
            
        }
    }
}
