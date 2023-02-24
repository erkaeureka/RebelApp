using Core.Interfaces;
using System;

namespace Core.Entities {
    public abstract class BaseEntity : IEntity {
        public DateTimeOffset? DeletedDate { get; private set; }

        public virtual void Delete() {
            DeletedDate ??= DateTimeOffset.Now;
        }
    }
}
