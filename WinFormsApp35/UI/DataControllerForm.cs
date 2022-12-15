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
        
        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void UpdateRecord()
        {
            //TO DO
            //Change the Update mechanism By using dataAdapter Update
            List<object> record = getSelectedRecord();
            if (record != null)
            {
                try
                {
                    int id = (int)record[0];

                    dataEntryForm.Update(id, record);
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row for Change");
            }

        }
        private List<object> getSelectedRecord() {
            List<object> record = null;
            try {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                record = new List<object>();
                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    record.Add(selectedRow.Cells[i].Value);
                }
            }
            catch (IndexOutOfRangeException exception) {
                throw new IndexOutOfRangeException(exception.Message);
            }

            return record;
        }

    }
}
