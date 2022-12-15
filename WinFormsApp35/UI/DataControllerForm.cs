using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using WinFormsApp35.Utilities;

namespace WinFormsApp35.DataForms
{
    public partial class DataControllerForm : Form
    {
        SqlConnection connection;
        string selectedTableName = "";
        Tables.DataForm dataEntryForm;
        public DataControllerForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void tableSelectorCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTableName = tableSelectorCombobox.Text;
            ShowDataEntryForm();
            dataGridView1.DataSource = null;
        }

        private void ShowDataEntryForm()
        {
            dataEntryForm = DataFormFactory.createDataForm(selectedTableName, connection);

            dataEntryPanel.Controls.Clear();
            dataEntryForm.FormBorderStyle = FormBorderStyle.None;
            dataEntryForm.TopLevel = false;
            dataEntryPanel.Controls.Add(dataEntryForm);
            dataEntryForm.Dock = DockStyle.Fill;
            dataEntryForm.Show();
        }
        private bool ValidateTableSelector()
        {
            if (selectedTableName != "")
                return true;
            else
            {
                MessageBox.Show("Please choose a table");
                return false;
            }
        }
        private void showDataButton_Click(object sender, EventArgs e)
        {
            if (ValidateTableSelector())
                ShowData();
        }
        private void ShowData() {
            string query = "Select * from " + selectedTableName;
            dataGridView1.DataSource = loadTable(query);

        }
        private DataTable loadTable(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Close();
                adapter.Fill(dt);
                return dt;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        private void InsertData()
        {
            try
            {
                dataEntryForm.Insert();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (ValidateTableSelector())
            {
                InsertData();
                ShowData();
            }
        }

    }
}
