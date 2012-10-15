namespace RestApiWeb.Models
{
    using System;

    public class Tenant
    {
        public Guid Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public Guid AccountId { get; set; }

        public Account Account { get; set; }
    }
}