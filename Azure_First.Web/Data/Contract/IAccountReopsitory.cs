using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_First.Web.Data.Contract
{
    public interface IAccountReopsitory
    {
        bool IsAutenticated(string userName, string password);
    }
}
