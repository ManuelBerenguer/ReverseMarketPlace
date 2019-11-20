﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types
{
    // source: https://github.com/jhewlett/ValueObject
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}
