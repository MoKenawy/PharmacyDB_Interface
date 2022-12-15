using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WinFormsApp35.DataForms
{
    internal interface dataEntryInterface
    {
        public void Insert();
        public void Delete(int index);
        public void Update(int index);
    }
}
