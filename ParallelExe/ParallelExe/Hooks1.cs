using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ParallelExe.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ParallelExe
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly BoDi.IObjectContainer _objectContainer;
       
        private IWebDriver driver;
        public ScenarioContext scenarioContext;
       
        public Hooks1(BoDi.IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            this.scenarioContext = scenarioContext;
            _objectContainer = objectContainer;

        }

        [BeforeScenario]

        public void BeforeScenario()
        {
            SelectBrowser(BrowserType.Chrome);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            
            ExtentManager.Instance.Flush();
            driver.Quit();
            //TODO: implement logic that has to run after executing each scenario
        }
        public void SelectBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions option = new ChromeOptions();
                    //option.AddArgument("--headless");
                    driver = new ChromeDriver(option);
                    _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
                    break;
                /* case BrowserType.Firefox:
                     var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                     FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                     service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                     service.HideCommandPromptWindow = true;
                     service.SuppressInitialDiagnosticInformation = true;
                     driver = new FirefoxDriver(service);
                     _objectContainer.RegisterInstanceAs<RemoteWebDriver>(_driver);
                     break;
                 case BrowserType.IE:
                     break;*/
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    break;
            }
        }
        public enum BrowserType
        {
            Chrome,
            Firefox,
            IE
        }

    }
}
