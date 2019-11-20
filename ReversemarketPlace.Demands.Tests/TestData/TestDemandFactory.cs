using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReversemarketPlace.Demands.Tests.TestData
{
    internal static class TestDemandFactory
    {
        internal static Demand OneUnitOfCategory1Buyer111()
        {
            return new Demand("111", TestCategoryFactory.Category1(), 1);
        }

        internal static Demand ThreeUnitsOfCategory2Buyer111()
        {
            return new Demand("111", TestCategoryFactory.Category2(), 3);
        }

        internal static Demand FiveUnitsOfCategory3Buyer111()
        {
            return new Demand("111", TestCategoryFactory.Category3(), 5);
        }
    }
}
