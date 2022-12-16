using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using WinFormsApp35.Tables;
namespace WinFormsApp35.Utilities
{
    public class DataControllerUtil
    {
        SqlConnection connection;
        DataTable dt;
        public DataForm dataEntryForm { get; set; }
        SqlDataAdapter dataAdapter;
        
        public DataControllerUtil(SqlConnection connection, DataForm dataEntryForm)
        {
            this.connection = connection;
            this.dataEntryForm = dataEntryForm;
        }
        public DataTable loadTable(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                dataAdapter = new SqlDataAdapter(command);
                connection.Close();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        public void InsertData()
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

        public bool UpdateRecord(List<object> record)
        {
            //TO DO
            //Change the Update mechanism By using dataAdapter Update
            bool isUpdated = false;
            if (record != null)
            {
                try
                {
                    int id = (int)record[0];
                    isUpdated = dataEntryForm.Update(record);
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.Message);
                    isUpdated = false;
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row for Change");
                isUpdated = false;
            }
            return isUpdated;
        }

        public bool TryDeleteRecord(List<object> record)
        {
            if (dataEntryForm.Delete(record) == true)
                return true;
            else
            {
                MessageBox.Show("Deletion Failed ,Please try again");
                return false;
            }
        }

        private DataTable FindRecordByID()
        {
            DataTable dt = new DataTable();

            dataAdapter = dataEntryForm.Search();
            dataAdapter.Fill(dt);
            return dt;
        }

    }
}
