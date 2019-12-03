using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Enums.Demands;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Attribute = ReverseMarketPlace.Demands.Core.Entities.Attribute;

namespace ReversemarketPlace.Demands.Tests
{
    public static class SeedData
    {
        public async static void PopulateTestData(AppDbContext dbContext)
        {
            AddCategories(dbContext);
            AddDemands(dbContext);
            AddAttributes(dbContext);
            AddCategoryAttributes(dbContext);

            await dbContext.SaveChangesAsync();
        }

        private async static void AddCategories(AppDbContext dbContext)
        {
            var category1 = await dbContext.Categories.AddAsync(new Category(Constants.CATEGORY_TV_AND_AUDIO, null));
            var category2 = await dbContext.Categories.AddAsync(new Category(Constants.CATEGORY_TV, category1.Entity));
            var category3 = await dbContext.Categories.AddAsync(new Category(Constants.CATEGORY_AUDIO, category1.Entity));
            var category4 = await dbContext.Categories.AddAsync(new Category(Constants.CATEGORY_TELEVISIONS, category2.Entity));
        }

        private async static void AddDemands(AppDbContext dbContext)
        {
            var category1 = await dbContext.Categories.FindAsync(1);
            var category2 = await dbContext.Categories.FindAsync(2);
            var category3 = await dbContext.Categories.FindAsync(3);
            
            await dbContext.Demands.AddAsync(new Demand("111", category1, 1, null));
            await dbContext.Demands.AddAsync(new Demand("111", category2, 3, null));
            await dbContext.Demands.AddAsync(new Demand("111", category3, 5, null));
        }

        private async static void AddAttributes(AppDbContext dbContext)
        {
            var inchesAttribute = await dbContext.Attributes.AddAsync( new Attribute("Inches", AttributeDataTypeEnum.NumericValue) );
        }

        private async static void AddCategoryAttributes(AppDbContext dbContext)
        {
            var categoryTelevisions = await dbContext.Categories.FindAsync(4);
            var inchesAttribute = await dbContext.Attributes.FindAsync(1);

            var categoryAttribute = new CategoryAttributes(
                categoryTelevisions,
                inchesAttribute    
            );

            await dbContext.CategoryAttributes.AddAsync(categoryAttribute);
        }
    }
}
