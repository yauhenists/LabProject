using OpenQA.Selenium;

namespace LabProject.Pages
{
    public class FramePage : BasePage
    {
        //public By CodeString { get; } =By.XPath("//div[@class='CodeMirror-activeline']//pre[contains(@class,'CodeMirror-line')]");

        public By InputField { get; } = By.XPath("//input[@id='text']");
        public FramePage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenStartPage()
        {
            Open("https://jsbin.com/nifokilome/edit?html,output");
        }

        //public void AddInputField()
        //{
        //    ClickOnElement(CodeString);
        //    TypeTextIn(CodeString, "<input id =\"test\"/>");
        //}

        public void SwitchToFrameWithInputField()
        {
            SwitchToFrame("<proxy>");
            SwitchToFrame("JS Bin Output ");
        }

        public void TypeTextInInput(string text)
        {
            TypeTextIn(InputField, text);
        }
    }
}
