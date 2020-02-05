using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LabProject.Pages
{
    public class ToolsqaPage : BasePage
    {
        public By SimpleAlertButton { get; } = By.XPath("//button[contains(text(),'Simple Alert')]");
        public By ConfirmPopUpButton { get; } = By.XPath("//button[contains(text(),'Confirm Pop up')]");
        public By PromtPopUpButton { get; } = By.XPath("//button[contains(text(),'Prompt Pop up')]");
        public IAlert Alert { get; set; }

        public ToolsqaPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenStartPage()
        {
            Open("https://www.toolsqa.com/handling-alerts-using-selenium-webdriver/");
        }

        public void SwitchToAlert()
        {
            AssertThat(ExpectedConditions.AlertIsPresent());
            Alert = Driver.SwitchTo().Alert();
        }

        public void AcceptAlert()
        {
            Alert.Accept();
        }

        public void DismissAlert()
        {
            Alert.Dismiss();
        }

        public void InputTextInAlert(string text)
        {
            Alert.SendKeys(text);
        }

        public string GetAlertText()
        {
            if (Alert != null)
            {
                return Alert.Text;
            }

            return string.Empty;
        }

        public void ScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor) Driver;
            js.ExecuteScript("window.scrollBy(0,200)");
        }
    }
}
