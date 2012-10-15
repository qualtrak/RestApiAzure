namespace RestApiWeb.Context
{
    using RestApiWeb.Models;
    using System.Data.Entity;

    public class RestApiAzureContext : DbContext
    {
        public RestApiAzureContext()
            : base("RestApiAzure")
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Tenant> Tenants { get; set; }
    }
}