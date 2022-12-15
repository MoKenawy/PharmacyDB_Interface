using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WinFormsApp35.DataForms
{
    internal interface ManageableFormInterface
    {
        public void Insert();
        public void Delete(int index);
        public void Update(int index, List<Object> record);

        public void Search(int index);
    }
}
