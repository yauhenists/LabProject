using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LabProject.Tests
{
    [TestFixture]
    public class BaseTest : ConciseAPI
    {
        public override IWebDriver Driver { get; } = new ChromeDriver();
        [SetUp]
        public void SetUp()
        {
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        
    }
}
