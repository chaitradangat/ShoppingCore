using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //return View(new string[] { "C#", "Language", "Features" });
            List<string> results = new List<string>();
            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";
                //results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}",name, price, relatedName));
                results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");
            }
            return View(results);
        }
    }
}