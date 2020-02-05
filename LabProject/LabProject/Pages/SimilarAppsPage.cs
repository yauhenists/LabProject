using OpenQA.Selenium;

namespace LabProject.Pages
{
    public class SimilarAppsPage : BasePage
    {
        public By AllApps { get; } = By.XPath("//div[contains(@class,'N4FjMb')]//div[contains(@class,'ZmHEEd')]/*");
        public SimilarAppsPage(IWebDriver driver) : base(driver)
        {
        }

        public int GetAmountOfSimilarApps()
        {
            return GetElements(AllApps).Count;
        }

        public override void OpenStartPage()
        {
            throw new System.NotImplementedException();
        }
    }
}
