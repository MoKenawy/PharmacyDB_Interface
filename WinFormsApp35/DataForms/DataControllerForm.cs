using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp35.DataForms
{
    public partial class DataControllerForm : Form
    {
        SqlConnection connection;
        string selectedTableName;
        Tables.DataForm dataEntryForm;
        public DataControllerForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void DataControllerForm_Load(object sender, EventArgs e)
        {

        }

        private void showDataButton_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        private void ShowData() {
            string query = "Select * from " + selectedTableName;
            if (selectedTableName != null || selectedTableName != "")
            {
                dataGridView1.DataSource = loadTable(query);
            }
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

        private void tableSelectorCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTableName = tableSelectorCombobox.Text;
            ShowDataEntryForm();
        }

        private void ShowDataEntryForm() {
            switch (selectedTableName) {
                case "Patient":
                    dataEntryForm = new PatientForm(connection);
                    break;
                case "Medicine":
                    dataEntryForm = new MedicineForm(connection);
                    break;
                case "Orders":
                    dataEntryForm = new defaultForm();
                    ShowData();
                    break;
                case "Branch":
                    dataEntryForm = new BranchForm(connection);
                    break;
                case "Med_Exist":
                    dataEntryForm = new Med_Exist(connection);
                    break;
                case "Manufacturer":
                    dataEntryForm = new ManufacturerForm(connection);
                    break;

                default:
                    dataEntryForm = new defaultForm();
                    break;
            }
            dataEntryPanel.Controls.Clear();
            dataEntryForm.FormBorderStyle = FormBorderStyle.None;
            dataEntryForm.TopLevel = false;
            dataEntryPanel.Controls.Add(dataEntryForm);
            dataEntryForm.Dock = DockStyle.Fill;
            dataEntryForm.Show();
        }

        private void InsertData() {
            try{
                dataEntryForm.Insert();
            }
            catch (SqlException exception){
                MessageBox.Show(exception.Message);
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            InsertData();
            ShowData();
            
        }
    }
}
