using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReverseMarketPlace.Common.Types.Queries;

namespace ReverseMarketPlace.Common.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            throw new NotImplementedException();
        }
    }
}
