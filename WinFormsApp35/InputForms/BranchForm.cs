using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp35.Tables;
using WinFormsApp35.Utilities;

namespace WinFormsApp35.DataForms
{
    public partial class BranchForm : DataForm
    {
        SqlConnection connection;
        string query;
        string idName = "branch_ID";
        TextBoxValidator textBoxValidator;
        public BranchForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private bool IsValid() {
            if (addressTextBox.Text != "")
                return true;
            else
                return false;

        }

        public override bool Insert()
        {
            if (!IsValid())
            {
                MessageBox.Show("Address Field required. Please Enter the address");
                return false;
            }
            try { 
            connection.Open();
            string query = "INSERT INTO Branch Values(@address)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@address", addressTextBox.Text);
            command.ExecuteNonQuery();
            return true;

        }
            catch (Exception exception) {
                return false;
            }
            finally {
                connection.Close();
            }
        }
        public override bool Update(List<object> record)
        {
            try
            {
                int index = 0;
                connection.Open();
                query = "UPDATE Branch " +
                    "SET branch_address = @branch_address " +
                    "WHERE branch_ID = " + record[index++];
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@branch_address", (string)record[index++]);
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public override bool Delete(List<object> record)
        {
            try
            {
                int id = (int)record[0];
                connection.Open();
                query = "DELETE FROM Branch WHERE branch_ID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public override SqlDataAdapter Search()
        {
            connection.Open();
            query = "SELECT * FROM Branch WHERE branch_ID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", searchTextBox.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Close();
            return adapter;
        }
    }
}
