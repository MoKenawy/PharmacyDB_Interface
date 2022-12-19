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
    public partial class OrdersForm : DataForm
    {

        public OrdersForm(SqlConnection connection) : base(connection)
        {
            InitializeComponent();
            base.tableName = "Orders";
            base.hasIdentityConstraint = true;
            base.InitTableInfo();
        }


        public override bool Delete(List<object> record)
        {
            return false;

        }

        public override bool Insert()
        {
            return false;

        }


        public override bool Update(List<object> record)
        {

            return false;
        }

        public override SqlDataAdapter Search()
        {
            return null;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
