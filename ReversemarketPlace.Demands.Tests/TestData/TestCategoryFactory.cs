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
            return new Category(Constants.CATEGORY_TV_AND_AUDIO, null);
        }

        internal static Category Category2()
        {
            return new Category(Constants.CATEGORY_TV, TestCategoryFactory.Category1());
        }

        internal static Category Category3()
        {
            return new Category(Constants.CATEGORY_AUDIO, TestCategoryFactory.Category1());
        }

        internal static Category Category4()
        {
            return new Category(Constants.CATEGORY_TELEVISIONS, TestCategoryFactory.Category2());
        }
    }
}
