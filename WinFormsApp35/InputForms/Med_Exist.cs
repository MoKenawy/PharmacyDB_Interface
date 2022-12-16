using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WinFormsApp35.Tables;

namespace WinFormsApp35.DataForms
{
    public partial class Med_Exist : DataForm
    {
        SqlConnection connection;
        string query;
        

        public Med_Exist(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            base.hasCompositeID = true;
        }
        public override bool Insert()
        {
            try
            {
                connection.Open();
                query = "INSERT INTO Med_Exist Values(@medID, @branchID, @quantity, @expiryDate)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@medID", medIDTextBox.Text);
                command.Parameters.AddWithValue("@branchID", branchIDTextBox.Text);
                command.Parameters.AddWithValue("@quantity", int.Parse(quantityTextBox.Text));
                command.Parameters.AddWithValue("@expiryDate", expiryDateTextBox.Text);
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exception)
            {
                return false;
                MessageBox.Show(exception.Message);
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
                query = "UPDATE Med_Exist " +
                    "SET quantity = @quantity , expiryDate = @expiryDate" +
                    " WHERE med_ID = "+ record[index++] + " AND branch_ID = " + record[index++];
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@quantity", (int)record[index++]);
                command.Parameters.AddWithValue("@expiryDate", record[index++]);
                command.ExecuteNonQueryAsync();
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
                int medID = (int)record[0];
                int branchID = (int)record[1];
                connection.Open();
                query = "DELETE FROM Med_Exist WHERE med_ID = @med_ID AND branch_ID = @branch_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@med_ID", medID);
                command.Parameters.AddWithValue("@branch_ID", branchID);
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
            query = "SELECT * FROM Med_Exist WHERE med_ID = @med_ID AND branch_ID = @branch_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@med_ID", medIDTextBox.Text);
            command.Parameters.AddWithValue("@branch_ID", branchIDTextBox.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Close();
            return adapter;
        }

    }
}
