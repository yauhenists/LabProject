using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace LabProject.Pages
{
    public abstract class BasePage : ConciseAPI
    {
        public abstract void OpenStartPage();
        public override IWebDriver Driver { get; }
        public string ThisPage { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ClickOnElement(By locator)
        {
            GetElement(locator).Click();
        }
        public void ClickOnCheckbox(By checkbox)
        {
            ClickOnElement(checkbox);
        }

        public void ClickButton(By button)
        {
            ClickOnElement(button);
        }

        public void ClickOnLink(By link)
        {
            ClickOnElement(link);
        }

        public void ClickOnElementJs(By locator)
        {
            var element = GetElement(locator);
            IJavaScriptExecutor jse = (IJavaScriptExecutor) Driver;
            jse.ExecuteScript("arguments[0].click();", element);

        }

        protected void SwitchToFrame(int id)
        {
            Driver.SwitchTo().Frame(id);
        }

        protected void SwitchToFrame(string name)
        {
            Driver.SwitchTo().Frame(name);
        }

        protected void OpenPage(By pageLink, IReadOnlyList<string> pages)
        {
            ClickOnLink(pageLink);
            //var countOfPages = GetWindowHandles().Count;
            pages = GetWindowHandles();
            GoToWindow(pages.Last());
        }

    }
}
