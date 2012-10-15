namespace RestApiWeb.Controllers
{
    using RestApiWeb.Context;
    using RestApiWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Http;

    public class AccountsController : ApiController
    {
        private readonly RestApiAzureContext _context;

        public AccountsController()
        {
            this._context = new RestApiAzureContext();
        }

        public IEnumerable<Account> Get()
        {
            ICollection<Account> result = this._context.Accounts.ToList();
            return result;
        }

        public Account Get(Guid id)
        {
            Account result = this._context.Accounts.SingleOrDefault(x => x.Id == id);
            return result;
        }

        public Account Post(Account account)
        {
            try
            {
                account.Id = Guid.NewGuid();
                this._context.Accounts.Add(account);
                this._context.SaveChanges();
                return account;
            }
            catch(Exception exception)
            {
                Debug.WriteLine(exception.Message + "\n\n" + exception.StackTrace);
                return account;
            }
        }

        public Account Put(Guid id, [FromBody]Account account)
        {
            try
            {
                Account result = this._context.Accounts.SingleOrDefault(x => x.Id == id);
                result.Name = account.Name;
                result.Email = account.Email;
                result.IsActive = account.IsActive;

                this._context.SaveChanges();

                return result;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message + "\n\n" + exception.StackTrace);
                return account;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                Account account = this._context.Accounts.SingleOrDefault(x => x.Id == id);
                this._context.Accounts.Remove(account);
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