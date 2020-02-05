using System;
using LabProject.Pages;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace LabProject.Tests
{
    [TestFixture]
    public class OnlinerTest : BaseTest
    {
        
        [Test]
        public void CheckTv()
        {
            OnlinerTvPage page = new OnlinerTvPage(Driver);
            page.OpenStartPage();

            page.ClickOnCheckbox(page.FirstCheckbox);
            page.ClickOnCheckbox(page.SecondCheckbox);

            OnlinerComparePage comparePage = page.GoToComparePage();

            comparePage.MoveCursorToElement(comparePage.Diagonal);
            AssertThat(ExpectedConditions.ElementIsVisible(comparePage.QuestionItem));

            comparePage.ClickOnElement(comparePage.QuestionItem);
            AssertThat(ExpectedConditions.ElementIsVisible(comparePage.Tip));
            AssertThat(ExpectedConditions.ElementIsVisible(comparePage.TipVisible));

            comparePage.ClickOnElement(comparePage.QuestionItem);
            AssertThat(ExpectedConditions.InvisibilityOfElementLocated(comparePage.TipInvisible));
            //AssertThat(ExpectedConditions.StalenessOf(GetElement(comparePage.TipVisible))); //StalenessOf doesn't work
            Console.WriteLine(GetCurrentWindowTitle());
            comparePage.ClickOnElement(comparePage.FirstTvClose);
            Console.WriteLine(GetCurrentWindowTitle());       
        }

        [Test]
        public void CheckMultiWindow()
        {
            OnlinerTvPage page = new OnlinerTvPage(Driver);
            page.OpenStartPage();
            AppStorePage appStorePage = page.OpenAppStorePage();
            AssertThat(ExpectedConditions.TitleIs("‎Каталог Onliner on the App Store"));
            Assert.AreEqual("‎Каталог Onliner on the App Store", GetCurrentWindowTitle());

            GoToWindow(page.ThisPage);
            AssertThat(ExpectedConditions.TitleIs("Телевизор купить в Минске"));
            Assert.AreEqual("Телевизор купить в Минске", GetCurrentWindowTitle());

            GooglePlayPage googlePlayPage = page.OpenGooglePlayPage();
            AssertThat(ExpectedConditions.TitleIs("Каталог Onliner - Apps on Google Play"));
            Assert.AreEqual("Каталог Onliner - Apps on Google Play", GetCurrentWindowTitle());
            Assert.AreEqual(3, GetNumberOfWindows());

            SimilarAppsPage similarAppsPage = googlePlayPage.GoToSimilarAppsPage();
            Console.WriteLine($"Amount of similar Apps is {similarAppsPage.GetAmountOfSimilarApps()}");

            GoToWindow(appStorePage.ThisPage);
            //appStorePage.ClickButton(appStorePage.MoreButton);
            appStorePage.ClickOnElementJs(appStorePage.MoreButton);
            CloseCurrentWindow();

            GoToWindow(page.ThisPage);
            page.OpenAdvertisement();
                      
        }
    }
}
