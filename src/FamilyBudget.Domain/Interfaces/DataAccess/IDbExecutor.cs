using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities.DataAccess;

namespace FamilyBudget.Domain.Interfaces.DataAccess
{
    public interface IDbExecutor
    {
        Task<List<TR>> QueryAsync<TR>(QueryObject queryObject);
        Task<TR> FirstOrDefaultAsync<TR>(QueryObject queryObject);
        Task<int> ExecuteAsync(QueryObject queryObject);
    }
}