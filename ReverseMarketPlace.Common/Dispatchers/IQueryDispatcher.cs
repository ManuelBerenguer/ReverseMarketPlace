using ReverseMarketPlace.Common.Types.Queries;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Common.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}