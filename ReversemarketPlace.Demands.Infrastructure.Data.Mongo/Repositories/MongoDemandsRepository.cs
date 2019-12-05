using MongoDB.Driver;
using ReverseMarketPlace.Demands.Core.Domain;
using ReverseMarketPlace.Demands.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReversemarketPlace.Demands.Infrastructure.Data.Mongo.Repositories
{
    public class MongoDemandsRepository : MongoRepository<Demand>, IDemandsRepository
    {
        public MongoDemandsRepository(IMongoDatabase database) : base(database, "Demands") { } // TODO: Move "Demands" to constants class"

        public async Task<Demand> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
