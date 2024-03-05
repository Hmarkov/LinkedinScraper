using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedinScraper.Models;

namespace LinkedinScraper.Scraper
{
    public class Scraper {
        private readonly string _linkedinUrl;

        public Scraper(string url)
        {
            _linkedinUrl = url;
        }

        async Task<string> FetchPageContentAsync()
        {
            var options = new ChromeOptions()
            {
                BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
            };

            options.AddArguments(new List<string>() { "headless", "disable-gpu" });

            using (IWebDriver driver = new ChromeDriver())
            {
                // Navigate to the desired URL
                driver.Navigate().GoToUrl("https://example.com");

                // Fetch page content
                return await Task.Run(() => driver.PageSource);
            }
        }


    }
}
