using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Mappers
{
    public class AttributeMapper
    {
        public static Core.Domain.Attribute MapFrom(EF.Persistance_Models.Attribute attribute)
        {
            return new Core.Domain.Attribute(attribute.Id, attribute.Name, attribute.DataType);
        }

        public static Core.Domain.AttributeValue MapFrom(EF.Persistance_Models.DemandAttributeValue demandAttributeValue)
        {
            return new Core.Domain.AttributeValue(demandAttributeValue.Id, MapFrom(demandAttributeValue.Attribute), demandAttributeValue.Value);
        }
    }
}
