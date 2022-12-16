using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using WinFormsApp35.DataForms;
namespace WinFormsApp35.Tables
{
    public class DataForm : Form, ManageableFormInterface
    {
        public bool hasCompositeID = false;

        public virtual bool Delete(List<object> record)
        {
            throw new NotImplementedException();
        }

        public virtual bool Insert()
        {
            throw new NotImplementedException();
        }


        public virtual SqlDataAdapter Search()
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(List<object> record)
        {
            return false;
        }
    }
}
