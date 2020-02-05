using System;
using LabProject.Pages;
using NUnit.Framework;

namespace LabProject.Tests
{
    [TestFixture]
    public class ToolsqaTest : BaseTest
    {
        [Test]
        public void TestAlerts()
        {
            ToolsqaPage page = new ToolsqaPage(Driver);
            page.OpenStartPage();
            page.ClickButton(page.SimpleAlertButton);
            page.SwitchToAlert();
            Console.WriteLine(page.GetAlertText());
            page.AcceptAlert();
            page.ClickButton(page.ConfirmPopUpButton);
            page.SwitchToAlert();
            Console.WriteLine(page.GetAlertText());
            page.AcceptAlert();
            page.ClickButton(page.ConfirmPopUpButton);
            page.SwitchToAlert();
            page.DismissAlert();
            page.ScrollDown();
            page.ClickButton(page.PromtPopUpButton);
            page.SwitchToAlert();
            Console.WriteLine(page.GetAlertText());
            page.InputTextInAlert("Great site");//step is passed but the text is not typed
            page.AcceptAlert();
        }
    }
}
