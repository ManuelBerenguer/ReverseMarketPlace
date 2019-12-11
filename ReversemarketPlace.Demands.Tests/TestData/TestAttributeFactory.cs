using ReverseMarketPlace.Demands.Core.Domain;
using System;
using Attribute = ReverseMarketPlace.Demands.Core.Domain.Attribute;
using System.Collections.Generic;
using System.Text;
using ReverseMarketPlace.Demands.Core.Enums.Demands;

namespace ReversemarketPlace.Demands.Tests.TestData
{
    internal static class TestAttributeFactory
    {
        internal static Guid INCHES_ATTRIBUTE_GUID() => new Guid(Constants.INCHES_ATTRIBUTE_GUID);

        internal static Attribute INCHES_ATTRIBUTE() =>
            new Attribute(INCHES_ATTRIBUTE_GUID(), Constants.INCHES_ATTRIBUTE, AttributeDataTypeEnum.NumericValue);

        internal static Guid COLOR_ATTRIBUTE_GUID() => new Guid(Constants.COLOR_ATTRIBUTE_GUID);

        internal static Attribute COLOR_ATTRIBUTE() =>
            new Attribute(COLOR_ATTRIBUTE_GUID(), Constants.COLOR_ATTRIBUTE, AttributeDataTypeEnum.StringValue);
    }

    internal static class TestValueAttributeFactory
    {
        internal static ValueAttribute INCHES_55_ATTRIBUTE() =>
            new ValueAttribute(TestAttributeFactory.INCHES_ATTRIBUTE(), 55);

        internal static ValueAttribute INCHES_50_ATTRIBUTE() =>
            new ValueAttribute(TestAttributeFactory.INCHES_ATTRIBUTE(), 50);

        internal static ValueAttribute COLOR_BLACK_ATTRIBUTE() =>
            new ValueAttribute(TestAttributeFactory.COLOR_ATTRIBUTE(), "Black");
    }
}
