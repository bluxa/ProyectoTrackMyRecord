using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTrackMyRecord.CapaDatos
{
    public class ConexionBD
    {
        private SqlConnection urlConexion = new SqlConnection("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=TrackMyRecord;Integrated Security=True");

        public SqlConnection AbrirConexion()
        {
            if (urlConexion.State == ConnectionState.Closed)
            {
                urlConexion.Open();
            }
            return urlConexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (urlConexion.State == ConnectionState.Open)
            {
                urlConexion.Close();
            }
            return urlConexion;
        }
    }
}
