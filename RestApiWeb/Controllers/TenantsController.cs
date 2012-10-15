namespace RestApiWeb.Controllers
{
    using RestApiWeb.Context;
    using RestApiWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Http;

    public class TenantsController : ApiController
    {
        private readonly RestApiAzureContext _context;

        public TenantsController()
        {
            this._context = new RestApiAzureContext();
        }

        public IEnumerable<Tenant> Get()
        {
            ICollection<Tenant> result = this._context.Tenants.ToList();
            return result;
        }

        public Tenant Get(Guid id)
        {
            Tenant result = this._context.Tenants.SingleOrDefault(x => x.Id == id);
            return result;
        }

        public Tenant Post(Tenant tenant)
        {
            try
            {
                tenant.Id = Guid.NewGuid();
                this._context.Tenants.Add(tenant);
                this._context.SaveChanges();
                return tenant;
            }
            catch(Exception exception)
            {
                Debug.WriteLine(exception.Message + "\n\n" + exception.StackTrace);
                return tenant;
            }
        }

        public Tenant Put(Guid id, [FromBody]Tenant tenant)
        {
            try
            {
                Tenant result = this._context.Tenants.SingleOrDefault(x => x.Id == id);
                result.Code = tenant.Code;
                result.Name = tenant.Name;
                result.Description = tenant.Description;
                result.AccountId = tenant.AccountId;
                result.IsActive = tenant.IsActive;

                this._context.SaveChanges();

                return result;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message + "\n\n" + exception.StackTrace);
                return tenant;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                Tenant tenant = this._context.Tenants.SingleOrDefault(x => x.Id == id);
                this._context.Tenants.Remove(tenant);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message + "\n\n" + exception.StackTrace);
                return false;
            }
        }
    }
}