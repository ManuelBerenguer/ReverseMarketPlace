using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReverseMarketPlace.Common.Types
{
    public abstract class BaseEntity : ITrackable, ISoftDelete
    {
        [Key]
        [IgnoreMember]
        public int Id { get; private set; }

        [IgnoreMember]
        public DateTime CreatedAt { get; private set; }
        [IgnoreMember]
        public string CreatedBy { get; private set; }
        [IgnoreMember]
        public DateTime LastUpdatedAt { get; private set; }
        [IgnoreMember]
        public string LastUpdatedBy { get; private set; }
        [IgnoreMember]
        public bool IsDeleted { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetCreatedAt(DateTime time)
        {
            CreatedAt = time;
        }

        public void SetCreatedBy(string userName)
        {
            CreatedBy = userName;
        }

        public void SetLastUpdatedAt(DateTime time)
        {
            LastUpdatedAt = time;
        }

        public void SetLastUpdatedBy(string userName)
        {
            LastUpdatedBy = userName;
        }

        public void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
    }
}
