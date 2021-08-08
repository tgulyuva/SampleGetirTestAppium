using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SampleGetirTest.Drivers;
using TechTalk.SpecFlow;

namespace SampleGetirTest.Steps
{
    [Binding]
    public sealed class GetirStepDefinitions
    {
        private AppiumDriver _appiumDriver;

        public GetirStepDefinitions(ScenarioContext scenarioContext, AppiumDriver appiumDriver)
        {
            _appiumDriver = appiumDriver;
        }
        [Given(@"I pass onboarding screens click skip button")]
        public void GivenIPassOnboardingScreensClickSkipButton()
        {
            Thread.Sleep(3000);
            _appiumDriver.Driver.FindElementById("com.allandroidprojects.getirsample:id/btn_skip").Click();
            Thread.Sleep(1000);
        }

        [Given(@"I check that I am at home page")]
        public void GivenICheckThatIAmAtHomePage()
        {
            Assert.That(_appiumDriver.Driver.FindElementById("com.allandroidprojects.getirsample:id/drawer_layout").Displayed, Is.True);
        }

        [Then(@"I change category to water")]
        public void ThenIChangeCategoryToWater()
        {
            _appiumDriver.Driver.FindElementByXPath("//android.support.v7.app.ActionBar.Tab[@content-desc=\"Water\"]/android.widget.TextView").Click();
        }

        [Then(@"I open ""(.*)"" indexed product detail")]
        public void ThenIOpenIndexedProductDetail(int index)
        {
            var products = _appiumDriver.Driver.FindElementsById("com.allandroidprojects.getirsample:id/layout_item");
            products[index - 1].Click();
        }
        [Then(@"I add this product to basket")]
        public void ThenIAddThisProductToBasket()
        {
            _appiumDriver.Driver.FindElementById("com.allandroidprojects.getirsample:id/text_action_bottom1").Click();

        }
        
        [Then(@"I go to basket and checks added product and price")]
        public void ThenIGoToCartAndChecksAddedProductAndPrice()
        {

            _appiumDriver.Driver.Navigate().Back();
            _appiumDriver.Driver.FindElementByAccessibilityId("Cart").Click();
            var priceElement = _appiumDriver.Driver.FindElementById("com.allandroidprojects.getirsample:id/text_action_bottom1");
            var productItem = _appiumDriver.Driver.FindElementById("com.allandroidprojects.getirsample:id/recyclerview");
            Assert.That(priceElement.Displayed && productItem.Displayed, Is.True);
            Console.WriteLine(priceElement.Text);

        }

        [When(@"I delete products from basket")]
        public void WhenIDeleteProductsFromBasket()
        {
            _appiumDriver.Driver.FindElementById("com.allandroidprojects.getirsample:id/layout_action1").Click();
        }

        [Then(@"I check is basket empty")]
        public void ThenICheckIsBasketEmpty()
        {
            var priceElement = _appiumDriver.Driver.FindElementById("com.allandroidprojects.getirsample:id/text_action_bottom1");
            Assert.That(priceElement.Text == "$0.00", Is.True);
            Console.WriteLine("----------------" + priceElement.Text + "++++++++++++");
        }
        [Then(@"I open the left menu")]
        public void ThenIOpenTheLeftMenu()
        {
            _appiumDriver.Driver.FindElementByAccessibilityId("Open navigation drawer").Click();
        }

        [Then(@"I go to ""(.*)"" category")]
        public void ThenIGoToCategory(string category)
        {
            _appiumDriver.Driver.FindElementByXPath("/ hierarchy / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.widget.LinearLayout / android.widget.FrameLayout / android.support.v4.widget.DrawerLayout / android.widget.FrameLayout / android.support.v7.widget.RecyclerView / android.support.v7.widget.LinearLayoutCompat[5]").Click();
        }

        [Then(@"I check that the product price is equal to ""(.*)""")]
        public void ThenICheckProductPrice(string price )
        {
            var productPriceSelector = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.LinearLayout/android.widget.ScrollView/android.widget.LinearLayout/android.widget.LinearLayout[1]/android.widget.TextView[2]";
            var productPrice = _appiumDriver.Driver.FindElementByXPath(productPriceSelector);
            Assert.That(productPrice.Text == price, Is.True);
            Console.WriteLine("----------------" + productPrice.Text + "++++++++++++");
        }

        [Then(@"I back to category detail page")]
        public void ThenIBackToCategoryDetailPage()
        {
            _appiumDriver.Driver.Navigate().Back();
        }

        [Then(@"I see product list in ""(.*)"" page")]
        public void ThenISeeProductListInPage(string category)
        {
            bool selectedItem = _appiumDriver.Driver.FindElementByXPath("//android.support.v7.app.ActionBar.Tab[@content-desc='" + category + "']").Selected;
            bool isListedProduct = _appiumDriver.Driver.FindElementById("com.allandroidprojects.getirsample:id/recyclerview").Displayed;
            Assert.IsTrue(selectedItem && isListedProduct);
        }

    }
}
