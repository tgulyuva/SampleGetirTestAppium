using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using SampleGetirTest.Drivers;
using TechTalk.SpecFlow;


namespace SampleGetirTest.Hooks
{
    [Binding]
   public class AppiumHook
    {
        private readonly AppiumDriver _appiumDriver;
        
       public AppiumHook(AppiumDriver appiumDriver)
       {
           _appiumDriver = appiumDriver;
       }
        [BeforeScenario]
        public void StartAndroidApp()
        {
            _appiumDriver.StartApp();
        }
        [AfterScenario]
        public void ShutdownAndroidApp()
        {
            _appiumDriver.StopApp();
        }
    }
}
