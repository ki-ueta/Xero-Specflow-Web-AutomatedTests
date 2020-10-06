using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using Xero.Specflow.Contexts;
using Xero.Specflow.Drivers;
using Xero.Specflow.Drivers.Interfaces;

namespace Xero.Specflow.Hooks
{
    [Binding]
    public class BeforeScenario
    {
        private readonly TestContext _testContext;

        public BeforeScenario(TestContext testContext)
        {
            _testContext = testContext;
        }

        [BeforeScenario(Order = 1)]
        public void RegisterDependencies(IObjectContainer objectContainer)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(BaseTestContext.TestDirectory, "appsettings.json"), optional: true, reloadOnChange: true)
                .Build();

            objectContainer.RegisterInstanceAs(config);
            _testContext.Configuration = config;

            objectContainer.RegisterTypeAs<LoginDriver, ILoginDriver>();
            objectContainer.RegisterTypeAs<DashboardDriver, IDashboardDriver>();
            objectContainer.RegisterTypeAs<BankAccountsDriver, IBankAccountsDriver>();
        }
    }
}
