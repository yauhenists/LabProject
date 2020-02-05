using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace LabProject
{
    public abstract class ConciseAPI
    {
        public abstract IWebDriver Driver { get; }

        public void Open(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement GetElement(By locator)
        {
            return AssertThat(ExpectedConditions.ElementIsVisible(locator));
        }

        public IReadOnlyList<IWebElement> GetElements(By locator)
        {
            return AssertThat(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public T AssertThat<T>(Func<IWebDriver, T> condition)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));
            return wait.Until(condition);
        }

        public string GetWindowHandle()
        {
            return Driver.CurrentWindowHandle;
        }

        public ReadOnlyCollection<string> GetWindowHandles()
        {
            return Driver.WindowHandles;
        }

        public int GetNumberOfWindows()
        {
            return GetWindowHandles().Count;
        }

        public string GetCurrentWindowTitle()
        {
            return Driver.Title;
        }

        public void GoToWindow(string window)
        {
            Driver.SwitchTo().Window(window);
        }

        public void CloseCurrentWindow()
        {
            Driver.Close();
        }

        public void TypeTextIn(By locator, string text)
        {
            GetElement(locator).SendKeys(text);            
        }

    }
}
