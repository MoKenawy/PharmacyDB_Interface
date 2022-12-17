/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WinFormsApp35.Utilities
{
    public class SqlBuilder
    {
        protected string[] columnNames;
        protected string[] columnsDataTypes;
        private bool hasIdentityConstraint;
        string tableName;

        public SqlBuilder(string tableName , string[] tableColumnNames, string[] columnsDataTypes, bool hasIdentityConstraint)
        {
            this.tableName = tableName;
            this.tableColumnNames = tableColumnNames;
            this.columnsDataTypes = columnsDataTypes;
            this.hasIdentityConstraint = hasIdentityConstraint;
        }

        private string BuildInsertSql(List<object> record)
        {

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
                if (attributeDataType == "String" || attributeDataType == "DateTime")
                {
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


    }
}
*/