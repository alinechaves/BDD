using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Webinator;
 
namespace TestNamespace.Steps
{
    [Binding]
    class AuthenticationSteps
    {
        private MultipleBrowsers _multipleBrowsers;
 
        public AuthenticationSteps()
        {
            _multipleBrowsers = new MultipleBrowsers(new List<Config.AvailableBrowsers>
                {
                    // TODO: Figure out why InternetExplorer doesn't work well alongside Chrome.
                    // Config.AvailableBrowsers.Chrome,
                    Config.AvailableBrowsers.Firefox,
                    Config.AvailableBrowsers.InternetExplorer
                });
        }
 
        [Given(@"I am on the registration page")]
        public void GivenIAmOnTheMainPage()
        {
            _multipleBrowsers.RunTest(web => web.GoToUrl("http://localhost/PROJECT/Authentication/Registration"));
        }
 
        [When(@"I fill the ""(.*)"" field with ""(.*)""")]
        public void WhenFillField(string label, string value)
        {
            _multipleBrowsers.RunTest(web => StepsHelper.FillField(web, label, value));
        }
 
        [When(@"I click ""(.*)""")]
        public void ThenIClick(string buttonValue)
        {
            _multipleBrowsers.RunTest(web => StepsHelper.ClickButton(web, buttonValue));
        }
 
        [Then(@"I should be on the confirmation page")]
        public void ThenIShouldBeOnTheConfirmationPage()
        {
            _multipleBrowsers.RunTest(delegate(IWebManager web)
            {
                var confirmationUrl =  "http://localhost/PROJECT/Authentication/Confirmation";
 
                Assert.AreEqual(confirmationUrl, web.Url());
 
                web.CloseBrowser();
            });
        }
 
        [Then(@"I should see the error ""(.*)""")]
        public void ThenIShouldSeeTheError(string text)
        {
            _multipleBrowsers.RunTest(delegate(IWebManager web)
            {
                var pageText = web.GetText(LocateBy.Id("error"));
 
                Assert.IsNotNull(pageText);
                Assert.AreEqual(text, pageText);
            });
        }
 
        [Then(@"I should be on the registration page")]
        public void ThenIShouldBeOnTheRegistrationPage()
        {
            _multipleBrowsers.RunTest(delegate(IWebManager web)
            {
                var registrationUrl = "http://localhost/PROJECT/Authentication/Registration";
 
                Assert.AreEqual(registrationUrl, web.Url());
 
                web.CloseBrowser();
            });  
        }
    }
}
