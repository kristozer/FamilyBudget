using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using FamilyBudget.DependencyInjection;
using FamilyBudget.Domain.Entities.DataAccess;
using FamilyBudget.Domain.Interfaces.DataAccess;
using Microsoft.Extensions.Configuration;

namespace FamilyBudget.Infrastructure.DataAccess.Implementations
{
    [InjectAsSingleton]
    public class DbExecutor : IDbExecutor
    {
        private readonly string connectionString; 

        public DbExecutor(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<TR>> QueryAsync<TR>(QueryObject queryObject)
        {
            var queryParams = GetQueryParams(queryObject.QueryParams);
            try
            {
                await using var cnn = new SqlConnection(connectionString);
                await cnn.OpenAsync().ConfigureAwait(false);

                var result = await cnn.QueryAsync<TR>(
                    queryObject.Sql,
                    queryParams,
                    commandType: queryObject.CommandType).ConfigureAwait(false);

                return result.ToList();
            }
            catch (Exception ex)
            {
                //TODO сделать обработку ошибок
                throw;
            }
        }

        public async Task<TR> FirstOrDefaultAsync<TR>(QueryObject queryObject)
        {
            var queryParams = GetQueryParams(queryObject.QueryParams);
            try
            {
                await using var cnn = new SqlConnection(connectionString);
                await cnn.OpenAsync().ConfigureAwait(false);

                var result = await cnn.QueryAsync<TR>(
                    queryObject.Sql,
                    queryParams,
                    commandType: queryObject.CommandType).ConfigureAwait(false);

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                //TODO сделать обработку ошибок
                throw;
            }
        }

        public async Task<int> ExecuteAsync(QueryObject queryObject)
        {
            var queryParams = GetQueryParams(queryObject.QueryParams);
            try
            {
                await using var cnn = new SqlConnection(connectionString);
                await cnn.OpenAsync().ConfigureAwait(false);

                var count = await cnn.ExecuteAsync(
                    queryObject.Sql,
                    queryParams,
                    commandType: queryObject.CommandType).ConfigureAwait(false);

                return count;
            }
            catch (Exception ex)
            {
                //TODO сделать обработку ошибок
                throw;
            }
        }

        private static object GetQueryParams(object queryParams)
        {
            if (queryParams == null)
            {
                return null;
            }

            var list = queryParams as IEnumerable<object>;

            if (list != null)
            {
                return list.Select(PrepareQueryParams).ToList();
            }

            return PrepareQueryParams(queryParams);
        }

        private static object PrepareQueryParams(object queryParams)
        {
            if (queryParams is IDictionary<string, object>)
            {
                return PrepareQueryParams((IDictionary<string, object>) queryParams);
            }

            var result = new ExpandoObject();
            var valueType = queryParams.GetType();
            var props = new List<PropertyInfo>(valueType.GetProperties());

            foreach (var prop in props)
            {
                var propValue = prop.GetValue(queryParams, null);
                propValue = ChangeIfTvp(propValue);
                ((IDictionary<string, object>) result).Add(prop.Name, propValue);
            }

            return result;
        }

        private static object PrepareQueryParams(IDictionary<string, object> queryParams)
        {
            var result = (IDictionary<string, object>) new ExpandoObject();

            foreach (var keyValuePair in queryParams)
            {
                var value = ChangeIfTvp(keyValuePair.Value);
                result.Add(keyValuePair.Key, value);
            }

            return result;
        }

        private static object ChangeIfTvp(object propValue)
        {
            var dataTable = propValue as DataTable;

            return dataTable == null ? propValue : dataTable.AsTableValuedParameter(dataTable.TableName);
        }
    }
}