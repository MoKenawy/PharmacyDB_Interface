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

namespace WinFormsApp35.DataForms
{
    public partial class ManufacturerForm : DataForm
    {
        SqlConnection connection;
        string query;
        string idName = "manufacturer_ID";
        public ManufacturerForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;

        }
        public override bool Insert()
        {
            try {
            connection.Open();
            query = "INSERT INTO Manufacturer Values(@name,@address)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", nameTextBox.Text);
            command.Parameters.AddWithValue("@address", addressTextBox.Text);
            command.ExecuteNonQuery();
            return true;

        }
            catch (SqlException exception) {
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
                query = "UPDATE Manufacturer " +
                    "SET manufacturer_name = @manufacturer_name, manufacturer_address = @manufacturer_address " +
                    "WHERE manufacturer_ID = " + record[index++];
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@manufacturer_name", record[index++]);
                command.Parameters.AddWithValue("@manufacturer_address", record[index++]);
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
                query = "DELETE FROM Manufacturer WHERE manufacturer_ID = @id";
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
            query = "SELECT * FROM Manufacturer WHERE manufacturer_ID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", searchTextBox.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Close();
            return adapter;
        }
    }
}
