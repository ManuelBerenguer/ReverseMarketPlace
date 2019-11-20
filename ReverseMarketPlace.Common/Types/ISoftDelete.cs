using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; }

        void SetIsDeleted(bool isDeleted);
    }
}
