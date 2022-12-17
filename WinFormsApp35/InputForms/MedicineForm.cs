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
        public MedicineForm(SqlConnection connection) : base(connection)
        {
            InitializeComponent();
            base.tableName = "Medicine";
            base.hasIdentityConstraint = true;
            base.tableIDName.Add("med_ID");
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
            record.Add(genericNameTextBox.Text);
            record.Add(brandNameTextBox.Text);
            record.Add(priceTextBox.Text);
            return InsertRecord(record);
        }
        public override bool Update(List<object> record)
        {
            int id = (int)record[0];
            return UpdateRecordByID(record, id);
        }

        public override SqlDataAdapter Search()
        {
            int id = int.Parse(searchTextBox.Text);
            return SearchRecordByID(id);
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
