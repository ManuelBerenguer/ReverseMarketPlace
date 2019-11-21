using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReversemarketPlace.Demands.Tests.TestData
{
    internal static class TestCategoryFactory
    {
        internal static Category Category1()
        {
            return new Category("Category 1", null);
        }

        internal static Category Category2()
        {
            return new Category("Category 2", TestCategoryFactory.Category1());
        }

        internal static Category Category3()
        {
            return new Category("Category 3", TestCategoryFactory.Category1());
        }

        internal static Category Category4()
        {
            return new Category("Category 4", TestCategoryFactory.Category2());
        }
    }
}
