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
        SqlDataAdapter dataAdapter;

        DataControllerUtil controllerUtil;
        public DataControllerForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            controllerUtil = new DataControllerUtil(connection, dataEntryForm);
        }

        private void tableSelectorCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTableName = tableSelectorCombobox.Text;
            ShowDataEntryForm();
            dataGridView1.DataSource = null;

            controllerUtil.dataEntryForm = dataEntryForm;
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

            dataGridView1.DataSource = controllerUtil.loadTable(query);
        }
        private void insertButton_Click(object sender, EventArgs e)
        {
            if (ValidateTableSelector())
            {
                controllerUtil.InsertData();
                ShowData();
            }
        }
        
        private void updateButton_Click(object sender, EventArgs e)
        {
            List<object> record = getSelectedRecord();
            if (controllerUtil.UpdateRecord(record))
            {
                ShowData();
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
            catch (ArgumentOutOfRangeException exception) {
                // TO DO Must show before Deletion Dialog
                MessageBox.Show("Please Select a Row");
            }
            return record;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FindRecordByID();
            
        }
        private DataTable FindRecordByID() {
            DataTable dt = new DataTable();

            dataAdapter = dataEntryForm.Search();
            dataAdapter.Fill(dt);
            return dt;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (DeleteRecordDialog())
            {
                List<object> record = getSelectedRecord();
                if (controllerUtil.TryDeleteRecord(record))
                {
                    ShowData();
                }
            }
        }

        private bool DeleteRecordDialog() {
            string message = "Are you sure?";
            string title = "Delete Record";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
