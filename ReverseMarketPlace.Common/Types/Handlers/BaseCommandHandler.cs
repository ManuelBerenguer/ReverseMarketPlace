using AutoMapper;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types.Handlers
{
    /// <summary>
    /// Base class for any command handler built following the Command Query Responsability Segregation (CQRS).
    /// </summary>
    public abstract class BaseCommandHandler<T>
    {        
        /// <summary>
        /// Used for localization
        /// </summary>
        protected readonly IStringLocalizer<T> _localizer;

        /// <summary>
        /// Used to log messages somewhere
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// Auto mapper
        /// </summary>
        protected readonly IMapper _mapper;

        public BaseCommandHandler(IStringLocalizer<T> localizer, ILogger<T> logger, IMapper mapper) {
            _localizer = localizer;
            _logger = logger;
            _mapper = mapper;
        }

    }
}
