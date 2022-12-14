// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
/**
 * Test class for testing the car insurance calculator portal using selenium driver.
 */
[TestFixture]
public class CarInsuranceCalculator
{
    private IWebDriver driver;
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;

    // Base url for test cases.
    string baseUrl = "http://localhost/prog8170a04/";
    [SetUp]
    public void SetUp() 
    {
        driver = new FirefoxDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
    }
    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
    }

    /**
     * Test case with all valid inputs and verify if the insurance quote is the given value.
     */
    [Test]
    public void carInsuranceCalculator_AllValidInputs_VerifyInsuranceQuoteValueIs2500()
    {
        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(809, 728);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 Mirage Ave");
        driver.FindElement(By.Id("city")).SendKeys("Waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2G 6G2");
        driver.FindElement(By.Id("phone")).SendKeys("548-111-1213");
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("25");
        driver.FindElement(By.Id("experience")).SendKeys("3");
        driver.FindElement(By.Id("accidents")).SendKeys("0");
        driver.FindElement(By.Id("btnSubmit")).Click();
        {
            // Assert
            string value = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
            Assert.That(value, Is.EqualTo("$2500"));
        }
    }

    /**
    * Test case with age as 14 as input and verify if the validation error message is shown.
    */
    [Test]
    public void carInsuranceCalculator_AgeAs14_VerifyAgeValidationError()
    {
        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1830, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 Mirage Ave");
        driver.FindElement(By.Id("city")).SendKeys("Waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2L 2B5");
        driver.FindElement(By.Id("phone")).SendKeys("512-123-1213");
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("14");
        driver.FindElement(By.Id("experience")).SendKeys("0");
        driver.FindElement(By.Id("experience")).SendKeys("1");
        driver.FindElement(By.Id("accidents")).SendKeys("0");
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("age-error")).Text, Is.EqualTo("Please enter a value greater than or equal to 16."));
    }

    /**
   * Test case with age as 50 and years of driving experience as 35 as inputs and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_AgeAs50AndYearsOfDrivingExperienceAs35_VerifyYearsOfDrivingExperienceValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1830, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 mirage ave");
        driver.FindElement(By.Id("city")).SendKeys("waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N3H 2H5");
        driver.FindElement(By.Id("phone")).SendKeys("512-123-1234");
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("50");
        driver.FindElement(By.Id("experience")).SendKeys("35");
        driver.FindElement(By.Id("accidents")).SendKeys("0");
        driver.FindElement(By.Id("btnSubmit")).Click();
        {
            // Assert
            string value = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
            Assert.That(value, Is.EqualTo("No Insurance for you!! Driver Age / Experience Not Correct"));
        }
    }

    /**
   * Test case with invalid email id as input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_InvalidEmailAddress_VerifyEmailAddressValidationError()
    {
        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1117, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 Mirage Ave");
        driver.FindElement(By.Id("city")).SendKeys("Waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2H 2H2");
        driver.FindElement(By.Id("phone")).SendKeys("548-333-1213");
        driver.FindElement(By.Id("email")).SendKeys("johndoe");
        driver.FindElement(By.Id("age")).SendKeys("28");
        driver.FindElement(By.Id("experience")).SendKeys("3");
        driver.FindElement(By.Id("accidents")).SendKeys("0");
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("email-error")).Text, Is.EqualTo("Must be a valid email address"));
    }

    /**
   * Test case with invalid phone number as input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_InvalidPhoneNumber_VerifyPhoneNumberValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1117, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 Mirage Ave");
        driver.FindElement(By.Id("city")).SendKeys("Waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2H 2H2");
        driver.FindElement(By.Id("phone")).SendKeys("5411231236");
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("27");
        driver.FindElement(By.Id("experience")).SendKeys("3");
        driver.FindElement(By.Id("accidents")).SendKeys("0");
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("phone-error")).Text, Is.EqualTo("Phone Number must follow the patterns 111-111-1111 or (111)111-1111"));
    }

    /**
   * Test case with number of at fault accidents as -1 as input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_NumberOfAtFaultAccidentsNegative1_VerifyNumberOfAtFaultAccidentsValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1830, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 Mirage Ave");
        driver.FindElement(By.Id("city")).SendKeys("Waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2H 5H4");
        driver.FindElement(By.Id("phone")).SendKeys("541-123-1214");
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("32");
        driver.FindElement(By.Id("experience")).SendKeys("5");
        driver.FindElement(By.Id("accidents")).SendKeys("-1");
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("accidents-error")).Text, Is.EqualTo("Please enter a value greater than or equal to 0."));
    }

    /**
   * Test case with invalid postal code as input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_InvalidPostalCode_VerifyPostalCodeValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1117, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 Mirage Ave");
        driver.FindElement(By.Id("city")).SendKeys("Waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2L");
        driver.FindElement(By.Id("phone")).SendKeys("511-233-1213");
        driver.FindElement(By.Id("email")).SendKeys("joihndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("35");
        driver.FindElement(By.Id("experience")).SendKeys("17");
        driver.FindElement(By.Id("accidents")).SendKeys("1");
        driver.FindElement(By.Id("email")).Click();
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("postalCode-error")).Text, Is.EqualTo("Postal Code must follow the pattern A1A 1A1"));
    }

    /**
   * Test case with address omitted with input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_OmitAddress_VerifyAddressValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1830, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("city")).SendKeys("Waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2G 5G3");
        driver.FindElement(By.Id("phone")).SendKeys("512-123-1213");
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("26");
        driver.FindElement(By.Id("experience")).SendKeys("0");
        driver.FindElement(By.Id("accidents")).SendKeys("0");
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("address-error")).Text, Is.EqualTo("Address is required"));
    }

    /**
   * Test case with age omitted with input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_OmitAge_VerifyAgeValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1830, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 Mirage Ave");
        driver.FindElement(By.Id("city")).SendKeys("Waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2L 2H4");
        driver.FindElement(By.Id("phone")).SendKeys("548-333-1212");
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("experience")).SendKeys("5");
        driver.FindElement(By.Id("age")).Click();
        driver.FindElement(By.Id("accidents")).Click();
        driver.FindElement(By.Id("accidents")).SendKeys("0");
        driver.FindElement(By.CssSelector("body")).Click();
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("age-error")).Text, Is.EqualTo("Age (>=16) is required"));
    }

    /**
   * Test case with email address omitted with input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_OmitEmailAddress_VerifyEmailAddressValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1830, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 mirage ave");
        driver.FindElement(By.Id("city")).SendKeys("waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2J 5H2");
        driver.FindElement(By.Id("phone")).SendKeys("512-123-1213");
        driver.FindElement(By.Id("age")).SendKeys("26");
        driver.FindElement(By.Id("experience")).SendKeys("0");
        driver.FindElement(By.Id("accidents")).SendKeys("0");
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("email-error")).Text, Is.EqualTo("email address is required"));
    }

    /**
   * Test case with first name omitted with input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_OmitFirstName_VerifyFirstNameValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1117, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).Click();
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 Mirage Ave");
        driver.FindElement(By.Id("city")).SendKeys("Waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2G 6G3");
        driver.FindElement(By.Id("phone")).SendKeys("548-111-1213");
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("25");
        driver.FindElement(By.Id("experience")).SendKeys("3");
        driver.FindElement(By.Id("accidents")).SendKeys("0");
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("firstName-error")).Text, Is.EqualTo("First Name is required"));
    }

    /**
   * Test case with last name omitted with input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_OmitLastName_VerifyLastNameValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1117, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("address")).SendKeys("100 Mirage Ave");
        driver.FindElement(By.Id("city")).SendKeys("Waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2H 2G1");
        driver.FindElement(By.Id("phone")).SendKeys("5131111213");
        driver.FindElement(By.Id("phone")).Click();
        driver.FindElement(By.Id("phone")).Click();
        driver.FindElement(By.Id("phone")).Click();
        driver.FindElement(By.Id("phone")).SendKeys("513-111-1213");
        driver.FindElement(By.Id("email")).Click();
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("26");
        driver.FindElement(By.Id("experience")).SendKeys("3");
        driver.FindElement(By.Id("accidents")).SendKeys("0");
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("lastName-error")).Text, Is.EqualTo("Last Name is required"));
    }

    /**
   * Test case with number of at fault accidents omitted with input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_OmitNumberOfAtFaultAccidents_VerifyNumberOfAtFaultAccidentsValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1830, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 Mirage Ave");
        driver.FindElement(By.Id("city")).SendKeys("Waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2F 5H4");
        driver.FindElement(By.Id("phone")).SendKeys("413-123-1213");
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("37");
        driver.FindElement(By.Id("experience")).SendKeys("8");
        driver.FindElement(By.CssSelector("body")).Click();
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("accidents-error")).Text, Is.EqualTo("Number of accidents is required"));
    }

    /**
   * Test case with years of driving experience omitted with input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_OmitYearsOfDrivingExperience_VerifyYearsOfDrivingExperienceValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1830, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.CssSelector(".card:nth-child(1) > div > .form-group:nth-child(1)")).Click();
        driver.FindElement(By.Id("firstName")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 mirage ave ");
        driver.FindElement(By.Id("city")).SendKeys("waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2L 2H4");
        driver.FindElement(By.Id("phone")).SendKeys("512-123-1416");
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("45");
        driver.FindElement(By.Id("accidents")).SendKeys("0");
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("experience-error")).Text, Is.EqualTo("Years of experience is required"));
    }

    /**
   * Test case with years of driving experience as -1 as input and verify if the validation error message is shown.
   */
    [Test]
    public void carInsuranceCalculator_YearsOfDrivingExperienceAsNegative1_VerifyYearsOfDrivingExperienceValidationError()
    {

        // Arrange
        driver.Navigate().GoToUrl(baseUrl);
        driver.Manage().Window.Size = new System.Drawing.Size(1830, 914);

        // Act
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("firstName")).Click();
        driver.FindElement(By.Id("firstName")).SendKeys("John");
        driver.FindElement(By.Id("lastName")).SendKeys("Doe");
        driver.FindElement(By.Id("address")).SendKeys("100 mirage ave");
        driver.FindElement(By.Id("city")).SendKeys("waterloo");
        driver.FindElement(By.Id("postalCode")).SendKeys("N2J 2J4");
        driver.FindElement(By.Id("phone")).SendKeys("512-123-1213");
        driver.FindElement(By.Id("email")).SendKeys("johndoe@gmail.com");
        driver.FindElement(By.Id("age")).SendKeys("26");
        driver.FindElement(By.Id("accidents")).SendKeys("1");
        driver.FindElement(By.Id("experience")).SendKeys("-1");
        driver.FindElement(By.Id("btnSubmit")).Click();

        // Assert
        Assert.That(driver.FindElement(By.Id("experience-error")).Text, Is.EqualTo("Please enter a value greater than or equal to 0."));
    }
}
