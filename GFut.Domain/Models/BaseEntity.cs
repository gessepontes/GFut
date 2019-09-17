using System;

namespace GFut.Domain.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Active = true;
            RegisterDate = DateTime.Now;
        }

        public virtual int Id { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
