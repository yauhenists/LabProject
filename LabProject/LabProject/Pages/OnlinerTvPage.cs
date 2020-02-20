using System.Collections.Generic;
using OpenQA.Selenium;

namespace LabProject.Pages
{
    public class OnlinerTvPage : BasePage
    {
        public By FirstCheckbox { get; } = By.XPath(
            "//div[@id='schema-products']/div[@class='schema-product__group'][1]/div/div/div[@class='schema-product__compare'][1]//label");

        public By SecondCheckbox { get; } = By.XPath(
            "//div[@id='schema-products']/div[@class='schema-product__group'][2]/div/div/div[@class='schema-product__compare'][1]//label");

        public By CompareButton { get; } =
            By.XPath("//a[contains(@href,'https://catalog.onliner.by/compare')]/span[contains(text(),'2')]");

        public By AppStoreLink { get; } =
            By.XPath("//a[@class='schema-filter__store-item schema-filter__store-item_apple']");

        public By GooglePlayLink { get; } =
            By.XPath("//a[@class='schema-filter__store-item schema-filter__store-item_google']");

        public By AdvertisementLink { get; } = By.XPath("//div[@class=\"schema-block\"]/div/a"); //div[@id='Stage']/..
        //"//div[@class='gwd-page-content gwd-page-size']"


        public IReadOnlyList<string> Pages;
    

        public OnlinerTvPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenStartPage()
        {
            Open("https://catalog.onliner.by/tv");
            ThisPage = GetWindowHandle();
            Pages = GetWindowHandles();
        }

        public AppStorePage OpenAppStorePage()
        {
            OpenPage(AppStoreLink, Pages);
            AppStorePage appStorePage = new AppStorePage(Driver);
            //appStorePage.ThisPage = GetWindowHandle();
            return appStorePage;
        }

        public GooglePlayPage OpenGooglePlayPage()
        {
            OpenPage(GooglePlayLink, Pages);
            GooglePlayPage googlePlayPage = new GooglePlayPage(Driver);
            //googlePlayPage.ThisPage = GetWindowHandle();
            return googlePlayPage;
        }

        

        public OnlinerComparePage GoToComparePage()
        {
            ClickButton(CompareButton);
            return new OnlinerComparePage(Driver);
        }

        public void OpenAdvertisement()
        {
            SwitchToFrame(0);
            ClickOnLink(AdvertisementLink);
        }
    }
}
