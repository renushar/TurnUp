using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Cast;

public class Program

{
    private static void Main(string[] args)
    {
            // Open Chrome Browser 
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Launch TurnUp Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Thread.Sleep(1000);

            //Identify the username textbox and enter a valid username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            // Identify password textbox and enter valid password 
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // Click on login button 
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
            Thread.Sleep(1500);

            // Check if user has logged in successfully
            IWebElement helloHari= driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            
            if(helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("user has logged in successfully.");
            }
            else
            { 
                Console.WriteLine("user has not logged in.");
        }


       //------------------------------ Create a new Time record ------------------------------
        // Click on administration tab 
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationTab.Click();

        // Navigate to Time and Material page 
        IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        tmOption.Click();

        // Click on create new button 
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();

        // Select time from dropdowwn button 
        IWebElement dropdownList = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        dropdownList.Click();

        IWebElement timeOption= driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();

        // Enter code 
        IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
        codeTextbox.SendKeys("Test1");

        // Enter description 
        IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
        descriptionTextbox.SendKeys("Test1");

        // Enter price per unit
        IWebElement priceTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTag.Click();

        IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
        priceTextbox.SendKeys("10");

        // Click on save button 
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(3500);

        // Check if new time record has been created successfully
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
        Thread.Sleep(3500);


        // ------------------------------ Edit time record ----------------------------
        // Click on edit button
        IWebElement lastPageButtonForEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        lastPageButtonForEdit.Click();
        IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        editButton.Click();
        Thread.Sleep(3500);

        // Edit code 
        IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
        editCodeTextbox.SendKeys("RenuS");
              
        // Click on save button
        IWebElement saveEditButton = driver.FindElement(By.Id("SaveButton"));
        saveEditButton.Click();
        Thread.Sleep(3500);

        // Check if time records has been edited successfully 
         IWebElement goToTheLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToTheLastPageButton.Click();

        IWebElement newEditCode = driver.FindElement(By.XPath("//*[@id=tmsGrid]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (newEditCode.Text == "RenuS2") 
         {
          Console.WriteLine("Edit Functionality has been working.");
        }
        else
        {
       Console.WriteLine("Edit Functionality has not been working.Test failed");
        }
        Thread.Sleep(1500);


        // ---------------------------------------- Delete Time Record --------------------------
        // Click on delete button
        IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[7]/td[last()]/a[2]"));
        deleteButton.Click();
        Thread.Sleep(1000);

        // Click OK to delete
        driver.SwitchTo().Alert().Accept();

        // Check if the record is deleted
        IWebElement lastPgButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        lastPgButton.Click();
        IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[7]/td[last()]/a[2]"));
        if (deletedCode.Text == "RenuS")
        {
            Console.WriteLine("The delete functionality has been working successfully");
        }

        else
        {
            Console.WriteLine("The delete functionality has not been working . test failed");

        }
    }
}


    
