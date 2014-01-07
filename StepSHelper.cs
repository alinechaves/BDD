--Projeto de Teste

using TestHelpers;
using Webinator;

namespace PROJECT TESTE.Helpers
{
    public class StepsHelper
    {
        private static IWebManager WebManager;
        public static IWebManager SharedWebManager
        {
            get
            {
                if (WebManager == null)
                {
                    var config = new Config
                    {
                        LogScreenshots = true,
                        LogLevel = Config.AvailableLogLevels.Verbose,
                        BaseUrl = "about:blank",
                        //Browser = Config.AvailableBrowsers.InternetExplorer,
                        //Browser = Config.AvailableBrowsers.Chrome,
                        Browser = Config.AvailableBrowsers.Firefox,
                        Framework = Config.AvailableFrameworks.WebDriver
                    };

                    WebManager = WebManagerFactory.CreateInstance(config);
                }

                return WebManager;
            } 
        }


        public static void FillField(IWebManager web, string label, string value)
        {
            var inputName = web.GetAttribute(LocateBy.Xpath("//label[text()='"+label+"']"), "for");
            web.SendKeys(LocateBy.Name(inputName), value);
        }

        public static void ClickButton(IWebManager web, string buttonValue)
        {
            // Test whether this will work alongside Chrome & IE
            web.Click(LocateBy.Attributes(ByAttribute.Type("submit").AndValue(buttonValue)), WaitUntil.AjaxOrPostCompleted(5000, false));
            //web.Click(LocateBy.Value(buttonValue), WaitUntil.AjaxOrPostCompleted());
        }

        public static void ClickLink(IWebManager web, string linkText)
        {
            web.Click(LocateBy.Text(linkText), WaitUntil.AjaxOrPostCompleted(5000, false));
        }
        
        public static void EraseAllEmails(string email, string password)
        {
            var mail = new MailHelper(email, password, "registration", "imap.gmail.com");
            mail.ConnectAndDeleteEmails();
        }

        public static void CloseBrowser()
        {
            SharedWebManager.CloseBrowser();
            WebManager = null;
        }

        public static bool isObjectDisable(IWebManager web, string objectId)
        {
            var obj = web.GetHtmlNodes(LocateBy.Id(objectId));

            var attributes = obj[0].GetAttributeValue("disabled", "");

            return attributes != "";

        }

        public static string returnObjectStatusString(IWebManager web, string objectId)
        {
            var obj = web.GetHtmlNodes(LocateBy.Id(objectId));

            var attributes = obj[0].GetAttributeValue("disabled", "");

            return attributes;

        }
    }
}
