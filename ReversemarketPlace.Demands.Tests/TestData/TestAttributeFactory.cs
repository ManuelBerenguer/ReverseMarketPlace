using System;
using System.Collections.Generic;
using System.Text;

namespace ReversemarketPlace.Demands.Tests.TestData
{
    internal static class TestAttributeFactory
    {
        internal static Guid INCHES_ATTRIBUTE_GUID() => new Guid(Constants.INCHES_ATTRIBUTE_GUID);

        internal static ReverseMarketPlace.Demands.Core.Domain.Attribute INCHES_ATTRIBUTE() =>
            new ReverseMarketPlace.Demands.Core.Domain.Attribute(INCHES_ATTRIBUTE_GUID(), Constants.INCHES_ATTRIBUTE, ReverseMarketPlace.Demands.Core.Enums.Demands.AttributeDataTypeEnum.NumericValue);

    }
}
