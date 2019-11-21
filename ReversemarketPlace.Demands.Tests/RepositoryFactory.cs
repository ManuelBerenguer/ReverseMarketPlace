using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using ReverseMarketPlace.Demands.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ReversemarketPlace.Demands.Tests
{
    public class RepositoryFactory
    {
        /// <summary>
        /// The database context
        /// </summary>
        private static AppDbContext _dbContext;

        public RepositoryFactory()
        {
            var options = CreateNewContextOptions();
            _dbContext = new AppDbContext(options);

            // We populate context with some test data
            SeedData.PopulateTestData(_dbContext);
        }

        public static void CreateNewContext()
        {
            var options = CreateNewContextOptions();
            _dbContext = new AppDbContext(options);

            // We populate context with some test data
            SeedData.PopulateTestData(_dbContext);
        }
                

        public static EfRepository<Category> GetCategoryRepository()
        {
            return new EfRepository<Category>(_dbContext);
        }

        public static EfDemandsRepository GetDemandsRepository()
        {
            return new EfDemandsRepository(_dbContext);
        }

        private static DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("TestDataBase")
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
