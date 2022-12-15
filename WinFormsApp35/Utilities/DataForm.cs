using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WinFormsApp35.DataForms;
namespace WinFormsApp35.Tables
{
    public class DataForm : Form, dataEntryInterface
    {
        public virtual void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(int index)
        {
            throw new NotImplementedException();
        }
    }
}
