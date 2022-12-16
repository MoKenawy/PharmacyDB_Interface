using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Serialization;

namespace WinFormsApp35.DataForms
{
    internal interface ManageableFormInterface
    {
        public bool Insert();
        public bool Delete(List<object> record);
        public bool Update(List<Object> record);
        public SqlDataAdapter Search();
    }
}
