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
        public Med_Exist(SqlConnection connection) : base(connection)
        {
            InitializeComponent();
            base.tableName = "Med_Exist";
            base.tableIDName.Add("med_ID");
            base.tableIDName.Add("branch_ID");
            base.hasIdentityConstraint = false;
            base.InitTableInfo();
        }
        public override bool Insert()
        {
            List<object> record = new List<object>();
            record.Add(medIDTextBox.Text);
            record.Add(branchIDTextBox.Text);
            record.Add(quantityTextBox.Text);
            record.Add(expiryDateTextBox.Text);
            return InsertRecord(record);
        }
        public override bool Update(List<object> record)
        {
            string[] compositeID = new string[2];
            compositeID[0] = ((int)record[0]).ToString();
            compositeID[1] = ((int)record[1]).ToString();
            return UpdateRecordByCompositeID(record,compositeID);

        }
        public bool DeleteRecord(List<object> record)
        {
            string[] compositeID = new string[2];
            compositeID[0] = ((int)record[0]).ToString();
            compositeID[1] = ((int)record[1]).ToString();
            return DeleteRecordByCompositeID(compositeID);
        }
        public override SqlDataAdapter Search()
        {
            string[] compositeID = new string[2];
            compositeID[0] = medIDTextBox.Text;
            compositeID[1] = branchIDTextBox.Text;

            return SearchRecordByCompositeID(compositeID);
        }

    }
}
