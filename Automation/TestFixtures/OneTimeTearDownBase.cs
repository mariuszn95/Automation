namespace Automation.TestFixtures
{
    using Automation.Driver;
    using Automation.Helpers.DriverHelpers;

    public class OneTimeTearDownBase
    {
        public void ClearCookies()
        {
            Actions.ClearCookies();
        }

        public void DriverDispose()
        {
            DriverSingleton.Dispose();
        }
    }
}