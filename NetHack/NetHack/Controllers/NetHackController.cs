using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetHack.Controllers
{
    public class NetHackController : Controller
    {
        //Method return Default View
        public ActionResult Index()
        {
            //Clean the variable for showing the result at the beggining"   
            ViewBag.Result = "";
            return View();
        }

        //Action when from is submitted, receive the input text value and return the view
        public ActionResult CheckHack(string bomb, string force)
        {
            ViewBag.Result = explode(bomb, Convert.ToInt32(force));

            return View("Index");

        }
        //method that recieves the boms and the force and returns the result in an array of strings
        public String[] explode(String bombs, int force)
        {
            //convert the string to uppercase in case of lowercase inputed
            bombs=bombs.ToUpper();

            //final result that will be handled with a list a string and formatted to array of string at the end
            //I used list string because with an array I need to define how many lines, as is dynamic I prefer list strings
            List<string> result = new List<string>();
            result.Add(bombs);

            //this var will keep a temporary string with movements in the positions
            string aux = bombs;

            //while it is not empty chamber will continue 
            while (aux.Contains('B')||aux.Contains('<')||aux.Contains('>')||aux.Contains('X'))
            {               
                //convert string to array of chars
                Char[] separateBomb = aux.ToArray();
                //create a second arry of char that will be used to handle the temporary movements
                //should be cleaned at the beggining of each round
                 Char[] auxSeparateBomb = aux.ToArray();
                for (int y = 0; y < auxSeparateBomb.Length; y++)
			    {
                    auxSeparateBomb[y] = '.';
			    }
               
                
                for (int i = 0; i < separateBomb.Length; i++)
                {

                    if (separateBomb[i]=='<')
                    {
                        if (auxSeparateBomb[i] == 'X' || auxSeparateBomb[i] == 'B')
                        {
                            auxSeparateBomb[i] = '.';
                        }
                        //validate positions before in order to assing
                        if ((i - force) >= 0)
                        {
                            //valiate if the shrapnel should be X or not
                            if (auxSeparateBomb[i - force] == '>' || auxSeparateBomb[i - force] == '<')
                            {
                                auxSeparateBomb[i - force] = 'X';
                            }
                            else
                            {
                                auxSeparateBomb[i - force] = '<';
                            }

                        }
                    }
                   
                    if (separateBomb[i] == '>')
                    {
                        if (auxSeparateBomb[i] == 'X' || auxSeparateBomb[i] == 'B')
                        {
                            auxSeparateBomb[i] = '.';
                        }
                        //validate positions after in order to assing
                        if ((i + force) < auxSeparateBomb.Length)
                        {
                            //valiate if the shrapnel should be X or not
                            if (auxSeparateBomb[i + force] == '>' || auxSeparateBomb[i + force] == '<')
                            {
                                auxSeparateBomb[i + force] = 'X';
                            }
                            else
                            {
                                auxSeparateBomb[i + force] = '>';
                            }
                        }

                    }

                    if (separateBomb[i] == 'B' || separateBomb[i] == 'X')
                    {
                        if (auxSeparateBomb[i] == 'X' || auxSeparateBomb[i] == 'B')
                        {
                            auxSeparateBomb[i] = '.';
                        }
                        //validate positions before in order to assing
                        if ((i - force) >= 0)
                        {
                            //valiate if the shrapnel should be X or not
                            if (auxSeparateBomb[i - force] == '>' || auxSeparateBomb[i - force] == '<')
                            {
                                auxSeparateBomb[i - force] = 'X';
                            }
                            else
                            {
                                auxSeparateBomb[i - force] = '<';
                            }
                        }
                        //validate positions after in order to assing
                        if ((i + force) < auxSeparateBomb.Length)
                        {
                            //valiate if the shrapnel should be X or not
                            if (auxSeparateBomb[i + force] == '>' || auxSeparateBomb[i + force] == '<' )
                            {
                                auxSeparateBomb[i + force] = 'X';
                            }
                            else
                            {
                                auxSeparateBomb[i + force] = '>';
                            }
                        }
                    }
                   
                }
                //concatenate the array to a string, added to the list and continue with the next
                result.Add(string.Join("", auxSeparateBomb));
                aux = string.Join("", auxSeparateBomb);
            }
                
            //convert final result of list string into array of string
            String[] finalResult = result.ToArray();
            return finalResult;
        
        }



    }
}
