using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace LabProject.Pages
{
    public class OnlinerComparePage : BasePage
    {
        public By Diagonal { get; } = By.XPath("//span[contains(text(),'Диагональ экрана')]/..");
        public By QuestionItem { get; } = By.XPath("//span[@data-tip-term='Диагональ экрана']");
        public By Tip { get; } = By.XPath("//div[@id='productTableTip']");
        public By TipVisible { get; } = By.XPath("//div[@class='product-table-tip__tip product-table-tip__tip_visible']");
        public By TipInvisible { get; } = By.XPath("//div[@class='product-table-tip__tip']");
        public By FirstTvClose { get; } = By.XPath("//*[@id='product-table']/tbody[2]/tr/th[3]/div/a");

        private readonly Actions _actions;
        public OnlinerComparePage(IWebDriver driver) : base(driver)
        {
            _actions = new Actions(driver);
        }

        public void MoveCursorToElement(By locator)
        {
            _actions.MoveToElement(GetElement(locator)).Build().Perform();
        }

        public override void OpenStartPage()
        {
            throw new System.NotImplementedException();
        }
    }
}
