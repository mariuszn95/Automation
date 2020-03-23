namespace Automation.TestFixtures
{
    public class TestFixtureBase
    {
        public TestFixtureBase()
        {
            this.OneTimeTearDown = new OneTimeTearDownBase();
            this.SetUp = new SetUpBase();
            this.TearDown = new TearDownBase();
        }

        public OneTimeTearDownBase OneTimeTearDown { get; set; }

        public SetUpBase SetUp { get; set; }

        public TearDownBase TearDown { get; set; }
    }
}