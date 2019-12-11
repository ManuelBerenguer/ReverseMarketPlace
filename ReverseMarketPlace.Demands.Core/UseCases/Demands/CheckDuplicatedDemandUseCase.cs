using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Demands.Core.Domain;

namespace ReverseMarketPlace.Demands.Core.UseCases.Demands
{
    public class CheckDuplicatedDemandUseCase : ICheckDuplicatedDemandUseCase
    {
        /// <summary>
        /// Checks if a demand already exists in a given collection of demands
        /// </summary>
        /// <param name="demands">Collection of demands to check if contains the demand</param>
        /// <param name="demand">The demand to check if is contained in the collection</param>
        /// <returns>True if demand is duplicated, false otherwise</returns>
        public async Task<bool> ExecuteAsync(IEnumerable<Demand> demands, Demand demand)
        {
            if (demand.IsNull())
                throw new ArgumentNullException(nameof(demand));

            if (demands.IsNull())
                throw new ArgumentNullException(nameof(demands));

            if (demands.IsEmpty())
                return false;
                        
            foreach(var demandInCollection in demands)
            {
                // Different product type, the demand is not duplicated
                if (demandInCollection.ProductTypeId != demand.ProductTypeId)
                    continue;

                // Same product type and both without attributes, the demand is duplicated
                if (demandInCollection.Attributes.EmptyOrNull() && demand.Attributes.EmptyOrNull())
                    return true;

                // Same product type one with attributes and the other one without attributes, the demand is not duplicated
                if ((demandInCollection.Attributes.EmptyOrNull() && !demand.Attributes.EmptyOrNull()) ||
                    (!demandInCollection.Attributes.EmptyOrNull() && demand.Attributes.EmptyOrNull()))
                    continue;

                // Same product type and both with attributes but different number of them
                if (demandInCollection.Attributes.Count() != demand.Attributes.Count())
                    continue;

                // We get attributes of both demands as dictionaries
                var demandInCollectionAttributesDic = demandInCollection.Attributes.ToDictionary(att => att.Id);
                var demandAttributesDic = demand.Attributes.ToDictionary(att => att.Id);

                // Same product type and same number of attributes, but different attributes
                if (demandInCollectionAttributesDic.Keys.Except(demandAttributesDic.Keys).Any())
                    continue;

                // Same product type and same attributes, we check the values
                
            }

            return false;
        }
    }
}
