﻿using ReverseMarketPlace.Demands.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Demands.Core.Repositories
{
    public interface IDemandGroupsRepository : IRepositoryOld<GroupDemands>
    {
        //Task<IEnumerable<DemandsGroup>> GetGroupsByCategoryIdWithDemands(int categoryId);
    }
}
