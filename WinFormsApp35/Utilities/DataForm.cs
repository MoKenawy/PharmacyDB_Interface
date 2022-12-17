using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WinFormsApp35.DataForms;
using WinFormsApp35.Utilities;

namespace WinFormsApp35.Tables
{
    public class DataForm : Form, ManageableFormInterface
    {
        protected string tableName;
        protected List<string> tableIDName; 
        protected string[] columnNames;
        protected string[] columnsDataTypes;
        protected SqlConnection connection;
        protected bool hasIdentityConstraint;
        protected bool hasCompositeID;
        string sql;

        public DataForm() { }

        public DataForm(SqlConnection connection) {
            this.connection = connection;
            this.tableIDName = new List<string>();
        }

        public void InitTableInfo() {
            columnNames = getColumnsName();
            columnsDataTypes = getColumnsDataTypes();
        }

        public string[] getColumnsName()
        {
            List<string> listacolumnas = new List<string>();
            using (SqlCommand command = connection.CreateCommand())
            {
                sql = string.Format("select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = '{0}' and t.type = 'U'", tableName);
                command.CommandText = sql;
                connection.Open();


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listacolumnas.Add(reader.GetString(0));
                    }
                }
                connection.Close();
            }
            return listacolumnas.ToArray();
        }

        public string[] getColumnsDataTypes() {
            List<string> dataTypeList = new List<string>();
            SqlCommand command = new SqlCommand("SELECT * FROM " + tableName, connection);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.VisibleFieldCount; i++)
                    {
                        string colDataType = getColumnType(reader, i);
                        dataTypeList.Add(colDataType);
                    }
                    break;
                }
            }
            connection.Close();
            return dataTypeList.ToArray();

        }
        public string getColumnType(SqlDataReader reader, int index) {
            System.Type type = reader.GetFieldType(index);
            string dataType = "";
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.DateTime:
                    dataType = "DateTime";
                    break;

                case TypeCode.String:
                    dataType = "String";
                    break;

                case TypeCode.Int64:
                    dataType = "Int64";
                    break;

                case TypeCode.Int32:
                    dataType = "Int32";
                    break;


                case TypeCode.Int16:
                    dataType = "Int16";
                    break;

                case TypeCode.Decimal:
                    dataType = "Decimal";
                    break;

                case TypeCode.Char:
                    dataType = "Char";
                    break;
                default: break;
            }
            return dataType;
        }

        private string BuildInsertSql(List<object> record) {

            // INSERT INTO tableName Values(val1,val2,val3,...)
            // record sent without ID

            string attributeDataType;
            int numberOfIdentities = 0;
            if (hasIdentityConstraint)
                numberOfIdentities++;

            StringBuilder insertSqlBuilder = new StringBuilder("INSERT INTO ");

            insertSqlBuilder.AppendFormat("{0} Values", tableName);
            insertSqlBuilder.Append("(");

            for (int i = 0; i < (record.Count - 1); i++)
            {
                attributeDataType = columnsDataTypes[i + numberOfIdentities];
                if (attributeDataType == "String" || attributeDataType == "DateTime") {
                    insertSqlBuilder.Append("\'");
                    insertSqlBuilder.Append(record[i]);
                    insertSqlBuilder.Append("\'");
                    insertSqlBuilder.Append(", ");
                }
                else
                insertSqlBuilder.AppendFormat("{0}, ", record[i]);

            }
            attributeDataType = columnsDataTypes[(record.Count - 1) + numberOfIdentities];
            if (attributeDataType == "String" || attributeDataType == "DateTime") // record is sent without ID , so index is shifted by 1 to the right(this gets the last element DataType)
            {
                insertSqlBuilder.Append("\'"); 
                insertSqlBuilder.Append(record[record.Count - 1]);
                insertSqlBuilder.Append("\'");

            }
            else
                insertSqlBuilder.AppendFormat("{0}", record[record.Count - 1]);

            insertSqlBuilder.Append(")");

            return insertSqlBuilder.ToString();

        }

        public bool InsertRecord(List<object> record) {
            try
            {
                connection.Open();
                sql = BuildInsertSql(record);
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                return true;

            }
            catch (Exception exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        private string BuildUpdateSql(List<object> record, string whereCondition) {

            // UPDATE tableName SET attr1 = val, attr = val WHERE attr3 = val
            // record is sent with ID

            string currentColName;
            string attributeDataType;
            object attributeValue;

            int numberOfIdentities = 0;
            if (hasIdentityConstraint)
                numberOfIdentities++;
            StringBuilder updateSqlBuilder = new StringBuilder();
            updateSqlBuilder.AppendFormat("UPDATE {0} ",tableName);
            updateSqlBuilder.Append("SET ");
            for (int i = numberOfIdentities; i < (record.Count - 1); i++)
            {
                currentColName = columnNames[i];
                attributeDataType = columnsDataTypes[i];
                attributeValue = record[i];

                updateSqlBuilder.Append(currentColName);
                updateSqlBuilder.Append(" = ");

                if (attributeDataType == "String" || attributeDataType == "DateTime")
                {
                    updateSqlBuilder.Append("\'");
                    updateSqlBuilder.Append(attributeValue);
                    updateSqlBuilder.Append("\'");
                }
                else
                    updateSqlBuilder.Append(attributeValue); 
                updateSqlBuilder.Append(", ");
            }
            currentColName = columnNames[record.Count - 1];
            attributeDataType = columnsDataTypes[record.Count - 1];
            attributeValue = record[record.Count - 1];
                
            updateSqlBuilder.Append(currentColName);
            updateSqlBuilder.Append("= ");

            if (attributeDataType == "String" || attributeDataType == "DateTime")
            {
                updateSqlBuilder.Append("\'");
                updateSqlBuilder.Append(attributeValue);
                updateSqlBuilder.Append("\'");
            }
            else
                updateSqlBuilder.Append(attributeValue);
            //End of Parameters
            updateSqlBuilder.Append(" ");

            //WHERE
            updateSqlBuilder.Append(whereCondition);

            return updateSqlBuilder.ToString();
        }
        public bool UpdateRecord(List<object> record, string whereCondition) {
            try
            {
                connection.Open();
                sql = BuildUpdateSql(record, whereCondition);
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateRecordByID(List<object> record, int id) {
            string whereCondition = String.Format("WHERE {0} = {1}", tableIDName[0], id);
            return UpdateRecord(record, whereCondition);
        }
        public bool UpdateRecordByCompositeID(List<object> record, string[] compositeID) {
            string whereCondition = BuildWhereConditionForCompositeID(compositeID);

            return UpdateRecord(record, whereCondition);
        }
        private string BuildWhereConditionForCompositeID(string[] compositeID) {
            string whereCondition;
            StringBuilder whereConditionBuilder = new StringBuilder();
            whereConditionBuilder.Append("WHERE ");
            for (int i = 0; i < compositeID.Length - 1; i++)
            {
                whereConditionBuilder.AppendFormat("{0} = {1} ", tableIDName[i], compositeID[i]);
                whereConditionBuilder.Append("AND ");
            }
            whereConditionBuilder.AppendFormat("{0} = {1} ", tableIDName[tableIDName.Count - 1], compositeID[compositeID.Length - 1]);
            whereCondition = whereConditionBuilder.ToString();
            return whereCondition;
        }
        
        private string BuildDeleteSql(string whereCondition) {
            //
            StringBuilder deleteSqlBuilder = new StringBuilder();
            deleteSqlBuilder.AppendFormat("DELETE FROM {0} ", tableName);
            deleteSqlBuilder.Append(whereCondition);
            return deleteSqlBuilder.ToString();
        }
        public bool DeleteRecord(string whereCondition) {
            try
            {
                connection.Open();
                sql = BuildDeleteSql(whereCondition);
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeleteRecordByID(int id)
        {
            string whereCondition = String.Format("WHERE {0} = {1}", tableIDName[0], id);
            return DeleteRecord(whereCondition);
        }
        public bool DeleteRecordByCompositeID(string [] compositeID)
        {
            string whereCondition = BuildWhereConditionForCompositeID(compositeID);
            return DeleteRecord(whereCondition);
        }

        private string BuildSelectSql(string[] attributesNames, string whereCondition) {
            //SELECT attr1, attr2, attr3 FROM tableName
            //whereCondition
            StringBuilder selectSqlBuilder = new StringBuilder();
            selectSqlBuilder.Append("SELECT ");
            for (int i = 0; i < attributesNames.Length - 1; i++)
            {
                selectSqlBuilder.Append(attributesNames[i]);
                selectSqlBuilder.Append(", ");
            }
            selectSqlBuilder.Append(attributesNames[attributesNames.Length - 1]);
            //End of Parameters
            selectSqlBuilder.Append(" ");
            selectSqlBuilder.AppendFormat("FROM {0} ",tableName);
            selectSqlBuilder.Append(whereCondition);
            return selectSqlBuilder.ToString();
        }

        private string BuildSelectSql(string whereCondition)
        {
            //SELECT * FROM tableName
            //whereCondition
            StringBuilder selectSqlBuilder = new StringBuilder();
            selectSqlBuilder.Append("SELECT * ");
            selectSqlBuilder.AppendFormat("FROM {0} ", tableName);
            selectSqlBuilder.Append(whereCondition);
            return selectSqlBuilder.ToString();
        }
        private string BuildSelectSql()
        {
            //SELECT * FROM tableName
            StringBuilder selectSqlBuilder = new StringBuilder();
            selectSqlBuilder.Append("SELECT * ");
            selectSqlBuilder.AppendFormat("FROM {0} ", tableName);
            return selectSqlBuilder.ToString();
        }

        public SqlDataAdapter SearchRecord(string whereCondition) {
            try
            {
                connection.Open();
                sql = BuildSelectSql(whereCondition);
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Close();
                return adapter;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public SqlDataAdapter SearchRecordByID(int id)
        {
            string whereCondition = String.Format("WHERE {0} = {1}", tableIDName[0], id);
            return SearchRecord(whereCondition);
        }
        public SqlDataAdapter SearchRecordByCompositeID(string[] compositeID)
        {
            string whereCondition = BuildWhereConditionForCompositeID(compositeID);
            return SearchRecord(whereCondition);
        }
        public SqlDataAdapter SelectAll() {
            try
            {
                connection.Open();
                sql = BuildSelectSql();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Close();
                return adapter;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
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

        public virtual bool Delete(List<object> record)
        {
            throw new NotImplementedException();
        }
    }
}
