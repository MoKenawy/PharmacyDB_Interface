using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WinFormsApp35.Utilities
{
    internal class ConnectionUtil
    {
        const string SERVER_NAME = "LAPTOP-IH3NAIAC";
        string connectionURL;
        private SqlConnection connection;
        public SqlConnection getConnection() {
            return connection; 
        }
        public ConnectionUtil(String databaseName) {
            connectionURL = "Data Source = " + SERVER_NAME + ";"
                         + "Initial Catalog =" + databaseName + ";"
                         + "Integrated Security = True;";
        }
        public SqlConnection Connect() {
            connection = new SqlConnection(connectionURL);
            return connection;
        }

    }
}
