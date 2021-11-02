using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        public tp2_netEntities _EfConn;
        const string consKeyDefaultCnnString = "ConnStringExpress";

        private SqlConnection _sqlConn;


        public SqlConnection SqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value; }
        }

        public Adapter()
        {
            _EfConn = new tp2_netEntities();
        }

        protected void OpenConnection()
        {
            var miConnectionString = ConfigurationManager.ConnectionStrings["ConnStringExpress"].ConnectionString;
            SqlConn = new SqlConnection(miConnectionString);
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
