// See https://aka.ms/new-console-template for more information
using LinkedinScraper.Scraper;
Console.WriteLine("Hello!");



var username = "";
var password = "";

var Scraper = new Scraper("https://www.linkedin.com/login?fromSignIn=true&trk=guest_homepage-basic_nav-header-signin",username,password);
var linkedInJobs = await Scraper.FetchPageContentAsync();
Console.WriteLine(linkedInJobs);