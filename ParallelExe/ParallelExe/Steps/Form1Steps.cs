using System;
using TechTalk.SpecFlow;

namespace ParallelExe.Steps
{
    [Binding]
    public class Form1Steps
    {
        [Given(@"I start entering user form details like")]
        public void GivenIStartEnteringUserFormDetailsLike(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I click submit button")]
        public void GivenIClickSubmitButton()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
