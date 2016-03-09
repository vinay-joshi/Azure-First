using Azure_First.Web.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azure_First.Web.Data
{
    public class AccountRepository : IAccountReopsitory
    {
        private AzureFirstContext _context;
        public AccountRepository(AzureFirstContext context)
        {
            this._context = context;
        }

        public bool IsAutenticated(string userName, string password)
        {
            if (_context.Members.Where(m => m.UserName == userName && m.Password == password).Any())
                return true;

            return false;
        }
    }
}