--Projeto de Teste


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Webinator;
 
namespace TestNamespace
{
    class MultipleBrowsers
    {
        private List<Config.AvailableBrowsers> _browsers;
        private List<IWebManager> _webManagers = new List<IWebManager>();
        private Config _baseConfig = new Config
                                         {
                                             LogScreenshots = true,
                                             LogLevel = Config.AvailableLogLevels.Verbose,
                                             BaseUrl = "about:blank",
                                             Framework = Config.AvailableFrameworks.WebDriver
                                         };
        
        public MultipleBrowsers(List<Config.AvailableBrowsers> browsers)
        {
            _browsers = browsers;
 
            CreateWebManagers();
        }
 
        private void CreateWebManagers()
        {
            foreach (var browser in _browsers)
            {
                var localConfig = new Config
                                      {
                                          LogScreenshots = _baseConfig.LogScreenshots,
                                          LogLevel = _baseConfig.LogLevel,
                                          BaseUrl = _baseConfig.BaseUrl,
                                          Framework = _baseConfig.Framework,
                                          Browser = browser
                                      };
 
                var web = WebManagerFactory.CreateInstance(localConfig);
 
                _webManagers.Add(web);
            }
        }
 
        public void RunTest(Action<IWebManager> action)
        {
            foreach (var web in _webManagers)
            {
                Debug.WriteLine("Running test with " + web.Config.Browser);
 
                action(web);
            }
        }
    }
}
