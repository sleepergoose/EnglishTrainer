using System;

namespace Trainer.Domain.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
