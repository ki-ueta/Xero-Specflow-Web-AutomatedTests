using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Polly;

namespace Xero.Specflow.Helpers
{
    class RetryHelper
    {
        public static void WaitFor(Func<Boolean> func)
        {
            var retryPolicy = Policy.Handle<Exception>()
                .Retry(10, (exception, i) =>
                {
                    Thread.Sleep(1000);
                });


            retryPolicy.Execute(func);
        }
    }
}
