using ReverseMarketPlace.Demands.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReversemarketPlace.Demands.Tests.TestData
{
    internal static class TestProductTypeFactory
    {
        internal static Guid PRODUCT_TYPE_TELEVISIONS_GUID()
        {
            return new Guid(Constants.PRODUCT_TYPE_TELEVISIONS_GUID);
        }

        internal static ProductType PRODUCT_TYPE_TELEVISIONS_WITHOUT_ATTRIBUTES()
        {
            return new ProductType(PRODUCT_TYPE_TELEVISIONS_GUID(), Constants.PRODUCT_TYPE_TELEVISIONS, TestCategoryFactory.CATEGORY_TV(), null);
        }

        internal static ProductType PRODUCT_TYPE_TELEVISIONS_WITH_ATTRIBUTES()
        {
            return new ProductType(PRODUCT_TYPE_TELEVISIONS_GUID(), Constants.PRODUCT_TYPE_TELEVISIONS, TestCategoryFactory.CATEGORY_TV(), null);
        }
    }
}
