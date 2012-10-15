namespace RestApiWeb.Migrations
{
    using RestApiWeb.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestApiWeb.Context.RestApiAzureContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestApiWeb.Context.RestApiAzureContext context)
        {
            Account account = new Account { Id = Guid.NewGuid(), Name = "Account One", Email = "xajler@gmail.com", IsActive = true };

            context.Accounts.AddOrUpdate(account);

            context.Tenants.AddOrUpdate(
                new Tenant { Id = Guid.NewGuid(), Code = 1000, Name = "Tenant 1000", Description = "The Tenant Thousand", Account = account }
            );
        }
    }
}
