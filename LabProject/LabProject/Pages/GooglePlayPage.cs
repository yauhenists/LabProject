using OpenQA.Selenium;

namespace LabProject.Pages
{
    public class GooglePlayPage : BasePage
    {
        public By MoreButton { get; } = By.XPath("//a[contains(@class,'id-track-click')]");
        public GooglePlayPage(IWebDriver driver) : base(driver)
        {
            ThisPage = GetWindowHandle(); //before creating the object you should be on this page
        }

        public SimilarAppsPage GoToSimilarAppsPage()
        {
            ClickButton(MoreButton);
            return new SimilarAppsPage(Driver);
        }

        public override void OpenStartPage()
        {
            throw new System.NotImplementedException();
        }
    }
}
