using System;

namespace FamilyBudget.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}