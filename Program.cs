using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebScraper
{
    public class Program
    {
        public static void Main(string[] args)
        {

            /*
            Parašyti WebScraper konsolinę programą, kuri išspausdina darbo skelbimų pavadinimus kuriuose yra toks stringas(pavyzdžiui: '.NET')
            iš https://www.cvbankas.lt/darbo-pasiulymai-programuotojams-it-specialistams pirmojo puslapio.
            Patarimas: Instaliuokite, panaudokite 'HTMLAgilityPack Nuget package' savo programoje.
         */

            Console.WriteLine(" We found! ");

            ScrapingBrowser broswer = new ScrapingBrowser();

            WebPage homePage = broswer.NavigateToPage(new Uri("https://www.cvbankas.lt/darbo-pasiulymai-programuotojams-it-specialistams"));

            var html = homePage.Html;

            var nodes = html.CssSelect(".list_cell h3");

            var professionNames = nodes.Where(n => n.InnerText.Contains(".NET")).Select(n => n.InnerText);
            foreach (var name in professionNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}