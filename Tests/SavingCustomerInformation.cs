using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using White.Core;
using White.Core.UIItems.WindowItems;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.Finders;

namespace Tests
{
    [Binding]
    public class SavingCustomerInformation
    {
        private static Application applicationUnderTest;
        private Window newCustomerWindow;
        private const string COMPANY = "Some Company";

        [BeforeFeature]
        public static void LaunchApplication()
        {
            SavingCustomerInformation.applicationUnderTest = Application.Launch(@"..\..\..\Application\bin\Debug\Application.exe");
        }

        [Given("I am in the New Customer window")]
        public void GivenNewCustomerWindow()
        {
            this.newCustomerWindow = SavingCustomerInformation.applicationUnderTest.GetWindow("New Customer");
        }

        [When("I enter a company name in the company name field")]
        public void WhenEnterCompanyName()
        {
            TextBox companyTextBox = this.newCustomerWindow.Get<TextBox>("companyTextBox");
            companyTextBox.Enter(COMPANY);
        }

        [When("I enter a contact e-mail address in the e-mail field")]
        public void WhenEnterEmail()
        {
            TextBox emailTextBox = this.newCustomerWindow.Get<TextBox>("emailTextBox");
            emailTextBox.Enter("some@email.com");
        }

        [When("I click on the Save button")]
        public void WhenClickSaveButton()
        {
            Button saveButton = this.newCustomerWindow.Get<Button>("saveButton");
            saveButton.Click();
        }

        [Then("I should see a newly added customer in the list of customers filed by their company name")]
        public void ThenNewCustomerInList()
        {
            ListBox customersList = this.newCustomerWindow.Get<ListBox>("customersListView");

            Assert.NotNull(customersList.Items.Find(x => x.Text == COMPANY));
        }

        [When("I leave the company name field blank")]
        public void WhenLeaveBlankCompanyName()
        {
            TextBox companyTextBox = this.newCustomerWindow.Get<TextBox>("companyTextBox");
            companyTextBox.Enter(string.Empty);
        }

        [Then("I should be presented with an error saying so")]
        public void ThenError()
        {
            Assert.NotNull(this.newCustomerWindow.Get(SearchCriteria.ByText("Company name is empty")));
        }

        [AfterFeature]
        public static void KillApplication()
        {
            SavingCustomerInformation.applicationUnderTest.Kill();
        }
    }
}
