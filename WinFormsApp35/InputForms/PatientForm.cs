using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp35.DataForms;
using WinFormsApp35.Tables;

namespace WinFormsApp35
{
    public partial class PatientForm : DataForm
    {
        SqlConnection connection;
        string query;
        public PatientForm(SqlConnection connection) : base(connection)
        {
            InitializeComponent();
            base.tableName = "Patient";
            base.hasIdentityConstraint = true;
            base.tableIDName.Add("patient_ID");
            base.InitTableInfo();
        }


        public override bool Delete(List<object> record)
        {
            int id = (int)record[0];
            return DeleteRecordByID(id);
        }

        public override bool Insert()
        {
            List<object> record = new List<object>();
            record.Add(nameTextBox.Text);
            record.Add(addressTextBox.Text);
            return InsertRecord(record);
        }


        public override bool Update(List<object> record)
        {   // Patient Table has patient_address before patient_name in DB
                int id = (int)record[0];
                return UpdateRecordByID(record, id);

        }

        public override SqlDataAdapter Search()
        {
            int id = int.Parse(searchTextBox.Text);
            return SearchRecordByID(id);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
