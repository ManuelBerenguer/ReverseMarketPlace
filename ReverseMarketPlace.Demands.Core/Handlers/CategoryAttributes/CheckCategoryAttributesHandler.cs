using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ReverseMarketPlace.Common.Handlers;
using ReverseMarketPlace.Demands.Core.Messages.Commands.CategoryAttributes;
using ReverseMarketPlace.Demands.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Handlers.CategoryAttributes
{
    public class CheckCategoryAttributesHandler : BaseCommandHandler<CheckCategoryAttributesHandler>, IRequestHandler<CheckCategoryAttributesCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckCategoryAttributesHandler(
            IUnitOfWork unitOfWork, IStringLocalizer<CheckCategoryAttributesHandler> localizer, ILogger<CheckCategoryAttributesHandler> logger, IMapper mapper) : base(localizer, logger, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckCategoryAttributesCommand request, CancellationToken cancellationToken)
        {
            // We get all the category attributes
            var categoryAttributes = await _unitOfWork.CategoryAttributesRepository.GetCategoryAttributes(request.CategoryId);
            var categoryAttributesId = categoryAttributes.Select(catAttr => catAttr.Attribute.Id);

            foreach(var attributeId in request.AttributesId)
            {
                if (!categoryAttributesId.Contains(attributeId)) // If the attribute is not allowed on that category
                    return false;
            }

            return true;
        }
    }
}
