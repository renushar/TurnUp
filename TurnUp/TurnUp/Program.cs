using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Cast;

public class Program

{
    private static void Main(string[] args)
    {
            // ---- Open Chrome Browser ----
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // ---- Launch TurnUp Portal ---
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Thread.Sleep(1000);

            // ---- Identify the username textbox and enter a valid username ---

            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            // ---- Identify password textbox and enter valid password ---
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // ---- Click on login button ---
            IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            LoginButton.Click();
            Thread.Sleep(1500);

            // ---- check if user has logged in successfully ---
            IWebElement helloHari= driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            
            if(helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("user has logged in successfully.");
            }
            else
            { 
                Console.WriteLine("user has not logged in.");
        }

        // ---- create a new Time record --
        // ---- click on administration tab --
        IWebElement administartionTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administartionTab.Click();

        // ---- navigate to Time and Material page ---
        IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        tmOption.Click();

        // ---- click on create new button ---
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();

        // ---- select time from dropdowwn button ---
        IWebElement dropdownList = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        dropdownList.Click();

        IWebElement timeOption= driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();

        // ---- enter code ---
        IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
        codeTextbox.SendKeys("Test1");

        // ---- enter description ---
        IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
        descriptionTextbox.SendKeys("Test1");

        // ---- enter price per unit ---
        IWebElement priceTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTag.Click();

        IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
        priceTextbox.SendKeys("10");

        // ---- click on save button ---
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(3500);

        // ---- check if new time record has been created successfully ---
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButton.Click();

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if(newCode.Text == "Test1")
        {
            Console.WriteLine("New time record has been created successfully.");
        }
        else
        { Console.WriteLine("New time record has not been created.Test failed");
        }

    }
}