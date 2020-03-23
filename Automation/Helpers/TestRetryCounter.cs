namespace Automation.Helpers
{
    using NUnit.Framework;

    public static class TestRetryCounter
    {
        public static string CurrentTestName { get; set; }

        public static string PreviousTestName { get; set; }

        public static int Counter { get; set; }

        public static void PrintRetryCounter()
        {
            Logger.Logger.Log($"Retry: {Counter}");
        }

        public static void SetCurrentTestNameAndCounter()
        {
            CurrentTestName = GetTestName();
            Counter = (CurrentTestName == PreviousTestName) ? ++Counter : Counter = 1;
        }

        public static void SetPreviousTestName()
        {
            PreviousTestName = GetTestName();
        }

        private static string GetTestName()
        {
            return TestContext.CurrentContext.Test.MethodName;
        }
    }
}