using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServiceEjemplo.Clases
{
    public class cnxSQL
    {
        private SqlConnection Cnx = new SqlConnection("data source=DEVELOP\\SQLEXPRESS ;Database=Prueba;Integrated Security=False;Persist Security Info=false;User Id=sa;Password=pass");
    
        public SqlConnection AbrirConexion()
        {
            if (Cnx.State == ConnectionState.Closed)
                Cnx.Open();
            return Cnx;
        }
        public SqlConnection CerrarConexion()
        {
            if (Cnx.State == ConnectionState.Open)
                Cnx.Close();
            return Cnx;
        }



        public void EjecutarConsulta(string Qry)
        {
            AbrirConexion();
            SqlCommand cmd = new SqlCommand(Qry, Cnx);
            cmd.ExecuteNonQuery();
            CerrarConexion();
        }

        public DataTable getDatatable(string Qry)
        {
            DataTable Datos = new DataTable();
            try
            {
                SqlDataAdapter Da = new SqlDataAdapter(Qry, Cnx);
                Da.Fill(Datos);
                return Datos;
            }
            catch
            {
                return Datos;
            }
        }
    }
}