﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ReverseMarketPlace.Common.Extensions;
using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Demands.Core.Constants;
using ReverseMarketPlace.Demands.Core.Dtos;
using ReverseMarketPlace.Demands.Core.Entities;
using ReverseMarketPlace.Demands.Core.Exceptions;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using ReverseMarketPlace.Demands.Core.Repositories;
using ReverseMarketPlace.Demands.Core.UseCases.ProductTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Handlers.Demands
{
    /// <summary>
    /// Handler for create demand commands
    /// </summary>
    public sealed class CreateDemandHandlerOld// : BaseCommandHandler<CreateDemandHandlerOld>, IRequestHandler<CreateDemandCommand, CreateDemandResult>
    {
        //private readonly IUnitOfWorkOld _unitOfWork;        
        //private readonly IAttributesBelongToCategoryUseCase _attributesBelongToCategoryUseCase;
        //private readonly CheckDuplicateDemandHandler _checkDuplicateDemandHandler;

        //public CreateDemandHandlerOld(            
        //    IUnitOfWorkOld unitOfWork, IAttributesBelongToCategoryUseCase attributesBelongToCategoryUseCase, CheckDuplicateDemandHandler checkDuplicateDemandHandler, IStringLocalizer<CreateDemandHandlerOld> localizer, 
        //    ILogger<CreateDemandHandlerOld> logger, IMapper mapper) : base(localizer, logger, mapper)
        //{
        //    _unitOfWork = unitOfWork;            
        //    _attributesBelongToCategoryUseCase = attributesBelongToCategoryUseCase;
        //    _checkDuplicateDemandHandler = checkDuplicateDemandHandler;
        //}

        //public async Task<CreateDemandResult> Handle(CreateDemandCommand request, CancellationToken cancellationToken)
        //{
        //    if (request.Quantity <= 0)
        //        throw new QuantityMustBeGreaterThanZeroException(_localizer[ExceptionConstants.QuantityMustBeGreaterThanZero]);

        //    // We get the category by id and if the category doesn't exist we throw exception
        //    //var category = request.Attributes.IsNotNull() ? await _unitOfWork.CategoriesRepository.GetByIdWithAttributes(request.CategoryId)
        //    //    : await _unitOfWork.CategoriesRepository.GetByIdAsync(request.CategoryId);
        //    var category = await _unitOfWork.CategoriesRepository.GetByIdAsync(new System.Guid());
        //    if (category.IsNull())
        //        throw new CategoryNotFoundException(_localizer[ExceptionConstants.CategoryNotFound]);

        //    // We check if the attributes added to the demand belongs to the category
        //    //if (request.Attributes.IsNotNull())
        //    //{
        //    //    bool allAttributesBelongCategory = await _attributesBelongToCategoryUseCase.ExecuteAsync(category, request.Attributes.Keys);
        //    //    if(!allAttributesBelongCategory)
        //    //        throw new CategoryAttributeNotFoundException(_localizer[ExceptionConstants.CategoryAttributeNotFound]);                                               
        //    //}

        //    var checkDuplicateDemandCommand = new CheckDuplicateDemandCommand(request.BuyerReference,
        //        request.CategoryId, request.Quantity, request.Attributes);

        //    var checkDuplicateDemandResult = await _checkDuplicateDemandHandler.Handle(checkDuplicateDemandCommand, CancellationToken.None);

        //    if (!checkDuplicateDemandResult.Duplicated.IsNull())
        //        return new CreateDemandResult(null, _mapper.Map<DemandDto>(checkDuplicateDemandResult.Duplicated));
        //    else
        //    {
        //        return null;
        //        // The demand to be created
        //        //var newDemand = new Demand(request.BuyerReference, category, request.Quantity);

        //        //var attributes = category.CategoryAttributes.Where( catAttr => request.Attributes.Keys.Contains( catAttr.Attribute.Id ) ).Select(catAttr => catAttr.Attribute);
        //        //foreach(var attributeRequested in request.Attributes)
        //        //{
        //        //    newDemand.AddAttribute(attributes.Where(att => att.Id == attributeRequested.Key).FirstOrDefault(), attributeRequested.Value);
        //        //}

        //        //await _unitOfWork.DemandsRepository.AddAsync(newDemand);
        //        //await _unitOfWork.SaveChangesAsync();
        //        //return new CreateDemandResult(_mapper.Map<DemandDto>(newDemand), null);
        //    }
        //}       
    }
}
