using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedinScraper.Models;
using System.Collections;

namespace LinkedinScraper.Scraper
{
    public class Scraper {
        private readonly string _linkedinUrl;
        private readonly string _username;
        private readonly string _password;
        private ArrayList Jobs = new ArrayList();

        public Scraper(string url,string username,string password)
        {
            _linkedinUrl = url;
            _username = username;
            _password = password;
        }

        public async Task<string> FetchPageContentAsync()
        {
            List<string> programmerLinks = new List<string>();
            var options = new ChromeOptions()
            {
                BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
            };

            //options.AddArguments(new List<string>() { "headless", "disable-gpu" });


            ArrayList pages = new ArrayList();

            int increment = 25;

            int numberOfPages = 5;

            for (int i = 0; i < numberOfPages; i++)
            {
                int value = i * increment;
                pages.Add(value);
            }


            var browser = new ChromeDriver(options);
            browser.Manage().Cookies.DeleteAllCookies();
            browser.Navigate().GoToUrl(_linkedinUrl);
            browser.FindElement(By.Id("username")).SendKeys(_username);
            browser.FindElement(By.Id("password")).SendKeys(_password);
            browser.FindElement(By.XPath("//*[@id=\"organic-div\"]/form/div[3]/button")).SendKeys(OpenQA.Selenium.Keys.Enter);

            
            for (int i = 0; i < pages.Count; i++) {
                int page = (int)pages[i];
                ProcessPage(browser,page);
            }

            //Parallel.ForEach(pages.Cast<int>(), page =>
            //{
                
            //});


            return "hello";
        }


        private void ProcessPage(ChromeDriver browser, int page)
        {
            browser.Navigate().GoToUrl($"https://www.linkedin.com/jobs/search/?distance=25.0&geoId=102257491&keywords=software%20engineer&start={page}");
            IJavaScriptExecutor js = (IJavaScriptExecutor)browser;

            js.ExecuteScript("arguments[0].scrollTo(0, arguments[0].scrollHeight);", browser.FindElement(By.ClassName("jobs-search-results-list")));
            Jobs.Add(browser.FindElements(By.ClassName("scaffold-layout__list-container")));


            // Your logic to search for elements on the page
            var links = browser.FindElements(By.XPath("//li[not(contains(@class, 'tocsection'))]/a[1]"));

            // Additional processing or storing of links as needed
        }


    }
}
