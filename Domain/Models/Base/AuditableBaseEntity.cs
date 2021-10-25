using System;


namespace Infrastructure.Data.Models.Base
{
    public abstract class AuditableBaseEntity : BaseEntity
    {
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual string LastModifedBy { get; set; }
        public virtual DateTime? LastModifedOn { get; set; }
    }
}
