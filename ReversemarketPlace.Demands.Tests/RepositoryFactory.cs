using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using ReverseMarketPlace.Demands.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ReversemarketPlace.Demands.Tests
{
    public class RepositoryFactory : IDisposable
    {
        /// <summary>
        /// The database context
        /// </summary>
        private AppDbContext _dbContext;

        public RepositoryFactory()
        {
            var options = CreateNewContextOptions();
            _dbContext = new AppDbContext(options);

            // We populate context with some test data
            SeedData.PopulateTestData(_dbContext);
        }        

        public void Dispose()
        {
            //_dbContext.Dispose();
        }
                                
        public EfUnitOfWork GetUnitOfWork()
        {
            return new EfUnitOfWork(_dbContext);
        }

        public AppDbContext GetDbContext()
        {
            return _dbContext;
        }
                
        private DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString()) // We generate a GUID to use as a name for the database. This is to ensure that every TestContext run has new database that is not affected by other test runs.
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }

    /// <summary>
    /// https://xunit.net/docs/shared-context.html#collection-fixture
    /// Collection Fixtures (shared object instances across multiple test classes)
    /// </summary>
    [CollectionDefinition("Repository Collection")]
    public class RepositoryCollection : ICollectionFixture<RepositoryFactory>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
