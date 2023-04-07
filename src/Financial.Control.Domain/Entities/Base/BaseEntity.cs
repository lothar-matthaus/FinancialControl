﻿namespace Financial.Control.Domain.Entities.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
        }
        public long Id { get; }
        public DateTime CreationDate { get; }
        public DateTime UpdateDate { get; }
    }
}
