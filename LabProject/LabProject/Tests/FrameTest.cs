using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabProject.Pages;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;

namespace LabProject.Tests
{
    public class FrameTest : BaseTest
    {
        [Test]
        public void CheckInputInFrameField()
        {
            FramePage page = new FramePage(Driver);
            page.OpenStartPage();
            //page.AddInputField();
            page.SwitchToFrameWithInputField();
            page.TypeTextInInput("test text");
        }
    }
}
