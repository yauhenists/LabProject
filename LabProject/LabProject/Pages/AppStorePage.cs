using OpenQA.Selenium;

namespace LabProject.Pages
{
    public class AppStorePage : BasePage
    {
        public By MoreButton { get; } = By.XPath("//div[@id='ember209']//button[text()='more']");
        public AppStorePage(IWebDriver driver) : base(driver)
        {
            ThisPage = GetWindowHandle();//before creating the object you should be on this page
        }

        public override void OpenStartPage()
        {
            throw new System.NotImplementedException();
        }
    }
}
