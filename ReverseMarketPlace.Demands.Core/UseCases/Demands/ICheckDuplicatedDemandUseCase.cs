using ReverseMarketPlace.Demands.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.UseCases.Demands
{
    /// <summary>
    /// Use Case to check if a demand already exists in a given collection of demands
    /// </summary>
    public interface ICheckDuplicatedDemandUseCase
    {
        /// <summary>
        /// Checks if a demand already exists in a given collection of demands
        /// </summary>
        /// <param name="demands">Collection of demands to check if contains the demand</param>
        /// <param name="demand">The demand to check if is contained in the collection</param>
        /// <returns>True if demand is duplicated, false otherwise</returns>
        Task<bool> ExecuteAsync(IEnumerable<Demand> demands, Demand demand);
    }
}
