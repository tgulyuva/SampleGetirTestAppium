using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;

namespace SampleGetirTest.Drivers
{
    public class AppiumDriver
    {
        public AndroidDriver<AndroidElement> Driver { get; private set; }

        public void StartApp()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\Gulyuva\Desktop\GetirApp\sampleGetir.apk");
            var AppiumService = new AppiumServiceBuilder().WithIPAddress("127.0.0.1").UsingPort(4723).Build();
            AppiumService.Start();
            Driver = new AndroidDriver<AndroidElement>(AppiumService, driverOptions);
        }

        public void StopApp() => Driver.Quit();
    }
}
