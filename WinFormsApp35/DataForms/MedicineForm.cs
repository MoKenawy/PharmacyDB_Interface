using System;
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
        public MedicineForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        public override void Delete(int index)
        {
            base.Delete(index);
        }

        public override void Insert()
        {
            connection.Open();
            string query = "INSERT INTO Medicine Values(@genericName,@brandName,@price)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@genericName", genericNameTextBox.Text);
            command.Parameters.AddWithValue("@brandName", brandNameTextBox.Text);
            command.Parameters.AddWithValue("@price", int.Parse(priceTextBox.Text));
            command.ExecuteNonQuery();
            connection.Close();
        }

        public override void Update(int index)
        {
            base.Update(index);
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
