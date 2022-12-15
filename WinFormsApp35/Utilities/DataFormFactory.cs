using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WinFormsApp35.DataForms;
using WinFormsApp35.Tables;

namespace WinFormsApp35.Utilities
{

    public static class DataFormFactory
    {
        public static DataForm createDataForm(string formName, SqlConnection connection)
        {
            switch (formName)
            {
                case "Patient":
                    return new PatientForm(connection);

                case "Medicine":
                    return new MedicineForm(connection);

                case "Branch":
                    return new BranchForm(connection);

                case "Med_Exist":
                    return new Med_Exist(connection);

                case "Manufacturer":
                    return new ManufacturerForm(connection);

                default:
                    return new defaultForm();


            }
        }
    }
}
