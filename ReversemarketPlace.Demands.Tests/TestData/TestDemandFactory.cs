using ReverseMarketPlace.Demands.Core.Domain;
using System;
using System.Collections.Generic;

namespace ReversemarketPlace.Demands.Tests.TestData
{
    internal static class TestDemandFactory
    {
        internal static Guid DEMAND_1_GUID()
        {
            return new Guid(Constants.DEMAND_1_GUID);
        }

        internal static Guid DEMAND_2_GUID()
        {
            return new Guid(Constants.DEMAND_2_GUID);
        }

        internal static Demand DEMAND_TELEVISIONS_WITHOUT_ATTRIBUTES()
        {
            return new Demand(DEMAND_1_GUID(), TestBuyerFactory.BUYER_1_GUID(), TestProductTypeFactory.PRODUCT_TYPE_TELEVISIONS_GUID(),
                1, null);
        }

        internal static Demand DEMAND_PRODUCTTYPE2_WITHOUT_ATTRIBUTES()
        {
            return new Demand(DEMAND_2_GUID(), TestBuyerFactory.BUYER_1_GUID(), TestProductTypeFactory.PRODUCT_TYPE_2_GUID(),
                1, null);
        }

        internal static Demand DEMAND_PRODUCTTYPE2_WITH_ONE_ATTRIBUTE_INCHES_55()
        {
            return new Demand(DEMAND_2_GUID(), TestBuyerFactory.BUYER_1_GUID(), TestProductTypeFactory.PRODUCT_TYPE_2_GUID(),
                1, new List<AttributeValue>() { TestAttributeValueFactory.INCHES_55_ATTRIBUTE() });
        }

        internal static Demand DEMAND_PRODUCTTYPE2_WITH_ONE_ATTRIBUTE_INCHES_50()
        {
            return new Demand(DEMAND_2_GUID(), TestBuyerFactory.BUYER_1_GUID(), TestProductTypeFactory.PRODUCT_TYPE_2_GUID(),
                1, new List<AttributeValue>() { TestAttributeValueFactory.INCHES_50_ATTRIBUTE() });
        }

        internal static Demand DEMAND_PRODUCTTYPE2_WITH_ONE_ATTRIBUTE_COLOR()
        {
            return new Demand(DEMAND_2_GUID(), TestBuyerFactory.BUYER_1_GUID(), TestProductTypeFactory.PRODUCT_TYPE_2_GUID(),
                1, new List<AttributeValue>() { TestAttributeValueFactory.COLOR_BLACK_ATTRIBUTE() });
        }

        internal static Demand DEMAND_PRODUCTTYPE2_WITH_TWO_ATTRIBUTES()
        {
            return new Demand(DEMAND_2_GUID(), TestBuyerFactory.BUYER_1_GUID(), TestProductTypeFactory.PRODUCT_TYPE_2_GUID(),
                1, new List<AttributeValue>() {
                    TestAttributeValueFactory.INCHES_55_ATTRIBUTE(), TestAttributeValueFactory.COLOR_BLACK_ATTRIBUTE()
                });
        }

        internal static Demand ThreeUnitsOfCategory2Buyer111()
        {
            return null;
            //return new Demand("111", TestCategoryFactory.Category2(), 3);
        }

        internal static Demand FiveUnitsOfCategory3Buyer111()
        {
            return null;
            //return new Demand("111", TestCategoryFactory.Category3(), 5);
        }

        internal static Demand FiveUnitsOfCategory4Buyer111()
        {
            return null;
            //return new Demand("111", TestCategoryFactory.Category4(), 5);
        }
    }
}
