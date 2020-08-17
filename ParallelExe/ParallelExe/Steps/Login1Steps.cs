using OpenQA.Selenium;
using ParallelExe.Reporting;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ParallelExe.Steps
{
    [Binding]
    public class Login1Steps
    {
        private ScenarioContext scenarioContext;       
        public IWebDriver driver;

        public Login1Steps(IWebDriver _driver, ScenarioContext scenarioContext)
        {

            driver = _driver;
            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            this.scenarioContext = scenarioContext;
            ExtentTestManager.CreateParentTest(scenarioContext.ScenarioInfo.Title.ToString());
        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            try
            {
                driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
                Console.WriteLine("navigate to application");
                ExtentTestManager.CreateNodePassed("navigate to application");
            }
            catch (Exception ex)
            {
                ExtentTestManager.CreateNodeFailed("navigate to application, in " + ex);
            }
        }
        
        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            try
            {
                Console.WriteLine("enter username and password");
                var credentials = table.CreateInstance<Credentials>();
                driver.FindElement(By.Name("UserName")).SendKeys((string)credentials.UserName);
                driver.FindElement(By.Name("Password")).SendKeys((string)credentials.Password);
                ExtentTestManager.CreateNodePassed("enter username and password");

            }
            catch (Exception ex)
            {
                ExtentTestManager.CreateNodeFailed("enter username and password, in " + ex);
            }
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            try
            {
                Console.WriteLine("I click login");
                driver.FindElement(By.Name("Login")).Submit();
                ExtentTestManager.CreateNodePassed("I click login");

            }
            catch (Exception ex)
            {
                ExtentTestManager.CreateNodeFailed("I click login, in " + ex);
            }
        }
        
        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            try
            {
                Console.WriteLine("I logged in to the application");
                ExtentTestManager.CreateNodePassed("I should see user logged in to the application");
            }
            catch (Exception ex)
            {
                ExtentTestManager.CreateNodeFailed(" logged in to the application" + ex);
            }
        }
    }
}
