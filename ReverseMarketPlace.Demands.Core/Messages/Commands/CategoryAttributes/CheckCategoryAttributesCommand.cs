using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Demands.Core.Messages.Commands.CategoryAttributes
{
    /// <summary>
    /// Command to verify if a list of attributes belong to a category
    /// </summary>
    public class CheckCategoryAttributesCommand : IRequest<bool>
    {
        /// <summary>
        /// Collection of attribute ids to check
        /// </summary>
        public IEnumerable<int> AttributesId { get; }

        /// <summary>
        /// Id of the category to check against
        /// </summary>
        public int CategoryId { get; }

        public CheckCategoryAttributesCommand(IEnumerable<int> attributesId, int categoryId)
        {
            AttributesId = attributesId;
            CategoryId = categoryId;
        }
    }
}
