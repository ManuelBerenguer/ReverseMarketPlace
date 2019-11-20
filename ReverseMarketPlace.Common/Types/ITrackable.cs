using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types
{
    public interface ITrackable
    {
        DateTime CreatedAt { get; }
        string CreatedBy { get; }
        DateTime LastUpdatedAt { get; }
        string LastUpdatedBy { get; }

        void SetCreatedAt(DateTime time);
        void SetCreatedBy(string userName);
        void SetLastUpdatedAt(DateTime time);
        void SetLastUpdatedBy(string userName);
    }
}
