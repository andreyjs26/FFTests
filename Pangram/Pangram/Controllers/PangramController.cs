using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pangram.Controllers
{
    public class PangramController : Controller
    {
       //Method return Default View
        public ActionResult Index()
        {
            //Clean the variable for showing the result at the beggining"   
            ViewBag.Missing = "";
            return View();
        }

        //method that receives a string an returns a string with all missing letter from the English Alphabetic
        public string listMissingLetter(string s)
        {
            //Lowercase the string in order to make sure be case-insitive
            s = s.ToLower();

            //declare final variable with got all missing letters
            string missing = "";

            //declare an array of chars with all the letters
            char[] alphaetic= new char[]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

            //goes for each letter in order to check if it is in the string inputed
            foreach (char letter in alphaetic)
            {
                if (!s.Contains(letter))
                {
                    //contactenate to the final variable
                    missing = missing + letter;
                }
            }
            //return the final variable rsult with all missing letters
            return missing;
        
        }

        //Action when from is submitted, receive the input text value and return the view
        public ActionResult CheckMissing(string input)
        {           
            ViewBag.Missing = listMissingLetter(input.Trim().ToLower());

            return View("Index");
        
        }

         
    }
}
