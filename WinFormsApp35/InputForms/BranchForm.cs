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
        public BranchForm(SqlConnection connection): base(connection)
        {  
            InitializeComponent();
            base.tableName = "Branch";
            base.tableIDName.Add("branch_ID");
            base.hasIdentityConstraint = true;
            base.InitTableInfo();
            
        }

        private bool IsValid() {
            if (addressTextBox.Text != "")
                return true;
            else
                return false;

        }

        public override bool Insert()
        {
            List<object> record = new List<object>();
//            record.Add(nameTextBox.Text);
            record.Add(addressTextBox.Text);
            return InsertRecord(record);
        }
        public override bool Update(List<object> record)
        {
            int id = (int)record[0];
            return UpdateRecordByID(record, id);
        }

        public override bool Delete(List<object> record)
        {
            int id = (int)record[0];
            return DeleteRecordByID(id);
        }
        public override SqlDataAdapter Search()
        {
            int id = int.Parse(searchTextBox.Text);
            return SearchRecordByID(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<object> record = new List<object>();
            record.Add(addressTextBox.Text);
            base.InsertRecord(record);
        }

        private void updateRecordButton_Click(object sender, EventArgs e)
        {
            List<object> record = new List<object>();
            record.Add(12);
            record.Add(addressTextBox.Text);
            base.UpdateRecord(record, "WHERE branch_ID = 12");

        }

        private void deleteRecordbutton_Click(object sender, EventArgs e)
        {      
            DeleteRecord("WHERE branch_ID = 12");
        }
    }
}
