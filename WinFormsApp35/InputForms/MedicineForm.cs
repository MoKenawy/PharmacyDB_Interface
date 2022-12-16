using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WinFormsApp35.Tables;

namespace WinFormsApp35
{
    public partial class MedicineForm : DataForm
    {
        SqlConnection connection;
        string query;
        public MedicineForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        public override bool Delete(List<object> record)
        {
            try
            {
                int id = (int)record[0];
                connection.Open();
                query = "DELETE FROM Medicine WHERE med_ID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public override bool Insert()
        {
            try { 
            connection.Open();
            query = "INSERT INTO Medicine Values(@genericName,@brandName,@price)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@genericName", genericNameTextBox.Text);
            command.Parameters.AddWithValue("@brandName", brandNameTextBox.Text);
                command.Parameters.Add("@price", SqlDbType.Decimal, 18);

                command.Parameters["@price"].Precision = 5;
                command.Parameters["@price"].Scale = 2;
                command.Parameters["@price"].Value = decimal.Parse(priceTextBox.Text);
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
                query = "UPDATE Medicine " +
                    "SET generic_name = @genericName, brand_name = @brandName , price = @price" +
                    " WHERE med_ID = " + record[index++];
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@genericName", (string)record[index++]);
                command.Parameters.AddWithValue("@brandName", (string)record[index++]);
                command.Parameters.Add("@price", SqlDbType.Decimal, 18);

                command.Parameters["@price"].Precision = 5;
                command.Parameters["@price"].Scale = 2;
                command.Parameters["@price"].Value = (decimal)record[index++];
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
            query = "SELECT * FROM Medicine WHERE med_ID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", searchTextBox.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Close();
            return adapter;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
