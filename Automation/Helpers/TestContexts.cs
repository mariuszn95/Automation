namespace Automation.Helpers
{
    using System.Configuration;
    using System.Reflection;

    using Automation.Helpers.Logger;

    using NUnit.Framework;

    public class TestContexts
    {
        private static string artifactsPath = TestContext.Parameters.Get("ArtifactsPath")
                                              ?? ConfigurationManager.AppSettings["ArtifactsPath"];

                                              private static string baseAddress = 
            TestContext.Parameters.Get("BaseAddress") ?? ConfigurationManager.AppSettings["testURL"];

        private static string browser =
            TestContext.Parameters.Get("Browser") ?? ConfigurationManager.AppSettings["Browser"];

        public static string ArtifactsPath
        {
            get
            {
                LoggerTestContexts.LogReturn($"{MethodBase.GetCurrentMethod().Name} ----- {artifactsPath}");

                return artifactsPath;
            }

            set
            {
                LoggerTestContexts.LogStart(MethodBase.GetCurrentMethod().Name);

                var param = value;
                if (param != null)
                {
                    LoggerTestContexts.LogStart("ArtifactsPath from CI: " + param);
                    artifactsPath = param;
                    LoggerTestContexts.LogEnd("ArtifactsPath from CI: " + artifactsPath);
                }

                LoggerTestContexts.LogEnd(MethodBase.GetCurrentMethod().Name);
            }
        }

        public static string BaseAddress
        {
            get
            {
                LoggerTestContexts.LogReturn($"{MethodBase.GetCurrentMethod().Name} ----- {baseAddress}");

                return baseAddress;
            }

            set
            {
                LoggerTestContexts.LogStart(MethodBase.GetCurrentMethod().Name);

                var param = value;
                if (param != null)
                {
                    LoggerTestContexts.LogStart("BaseAddress from CI: " + param);
                    baseAddress = param;
                    LoggerTestContexts.LogEnd("BaseAddress from CI: " + baseAddress);
                }

                LoggerTestContexts.LogEnd(MethodBase.GetCurrentMethod().Name);
            }
        }

        public static string Browser
        {
            get
            {
                LoggerTestContexts.LogReturn($"{MethodBase.GetCurrentMethod().Name} ----- {browser}");

                return browser;
            }

            set
            {
                LoggerTestContexts.LogStart(MethodBase.GetCurrentMethod().Name);

                var param = value;
                if (param != null)
                {
                    LoggerTestContexts.LogStart("Browser from CI: " + param);
                    browser = param;
                    LoggerTestContexts.LogEnd("Browser from CI: " + browser);
                }

                LoggerTestContexts.LogEnd(MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}