using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xero.Specflow.Drivers
{
    public interface ILoginDriver
    {
        void Navigate();
        void Login(string username, string password);
    }
}
