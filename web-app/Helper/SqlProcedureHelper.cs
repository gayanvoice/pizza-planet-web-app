using Microsoft.Data.SqlClient;
using static web_app.Models.View.HomeViewModel;
using System.Data.Common;
using System.Data;
using web_app.Context;
using web_app.Models.Procedure;
using Microsoft.EntityFrameworkCore;

namespace web_app.Helper
{
    public static class SqlProcedureHelper
    {
        public static DataTable GetDataTable(string commandText, SqlParameter? sqlParameter)
        {
            using (RsMssqlContext rsMssqlContext = new RsMssqlContext())
            {
                using (var command = rsMssqlContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = CommandType.StoredProcedure;
                    if (sqlParameter is not null)
                    {
                        command.Parameters.Add(sqlParameter);
                    }
                    rsMssqlContext.Database.OpenConnection();
                    DbDataReader dbDataReader = command.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dbDataReader);
                    return dataTable;
                }
            }
        }
       
    }
}
