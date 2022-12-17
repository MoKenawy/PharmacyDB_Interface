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

namespace WinFormsApp35.DataForms
{
    public partial class ManufacturerForm : DataForm
    {
        SqlConnection connection;
        string query;
        string idName = "manufacturer_ID";
        public ManufacturerForm(SqlConnection connection) : base(connection)
        {
            InitializeComponent();
            base.tableName = "Manufacturer";
            base.hasIdentityConstraint = true;
            base.tableIDName.Add("manufacturer_ID");
            base.InitTableInfo();

        }
        public override bool Insert()
        {
            List<object> record = new List<object>();
            record.Add(nameTextBox.Text);
            record.Add(addressTextBox.Text);
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
        public override bool Delete(List<object> record)
        {
            int id = (int)record[0];
            return DeleteRecordByID(id);
        }
    }
}
