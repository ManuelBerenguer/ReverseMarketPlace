﻿using Microsoft.EntityFrameworkCore;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReversemarketPlace.Demands.Tests
{
    public static class SeedData
    {
        public async static void PopulateTestData(AppDbContext dbContext)
        {
            AddCategories(dbContext);
            AddDemands(dbContext);

            await dbContext.SaveChangesAsync();
        }

        private async static void AddCategories(AppDbContext dbContext)
        {
            var category1 = await dbContext.Categories.AddAsync(new Category("Category 1", null));
            var category2 = await dbContext.Categories.AddAsync(new Category("Category 2", category1.Entity));
            var category3 = await dbContext.Categories.AddAsync(new Category("Category 3", category1.Entity));
            var category4 = await dbContext.Categories.AddAsync(new Category("Category 4", category2.Entity));
        }

        private async static void AddDemands(AppDbContext dbContext)
        {
            var category1 = await dbContext.Categories.FindAsync(1);
            var category2 = await dbContext.Categories.FindAsync(2);
            var category3 = await dbContext.Categories.FindAsync(3);
            //var category4 = await dbContext.Categories.FindAsync(4);

            await dbContext.Demands.AddAsync(new Demand("111", category1 , 1));
            await dbContext.Demands.AddAsync(new Demand("111", category2, 3));
            await dbContext.Demands.AddAsync(new Demand("111", category3, 5));
            //await dbContext.Demands.AddAsync(new Demand("111", category4, 2));
        }
    }
}
