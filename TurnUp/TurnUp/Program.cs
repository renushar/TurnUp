using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Cast;

public class Program

{
    private static void Main(string[] args)
    {
        {
            // ---- Open Chrome Browser ----
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // ---- Launch TurnUp Portal ---
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            // ---- Identify the username textbox and enter a valid username ---
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            // ---- Identify password textbox and enter valid password ---
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // ---- Click on login button ---
            IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            LoginButton.Click();

            // ---- check if user has logged in successfully ---
            IWebElement helloHari= driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            
            if(helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("user has logged in successfully.");
            }
            else
                Console.WriteLine("user has not logged in.");
        }
    }
}