using System;
using System.Data;

namespace FamilyBudget.Domain.Entities.DataAccess
{
    public class QueryObject
    {
        public QueryObject(string sql, object queryParams = null, CommandType? commandType = null)
        {
            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentNullException(nameof(sql));
            }

            Sql = sql;
            QueryParams = queryParams;
            CommandType = commandType;
        }

        public string Sql { get; private set; }

        public object QueryParams { get; private set; }

        public CommandType? CommandType { get; private set; }
    }
}