using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VendorLibrary.Controllers
{
    public class VendorController : ApiController
    {

        //This function returns the report formatted in rows, the reason of the function is beacuse as the tool is going to be consulted thousands of times, we need a way that don't affect users running at the same specific time.
        //And returning  and instancing the result each time should  work for multiple users at the same time .
        private List<string> returnReport() 
        {            
            string report = "1/31/2017,cola soda,100;1/31/2017,cream cookie,60;1/31/2017,cream cookie,50;1/31/2017,chips,110;1/29/2017,cream cookie,130;1/28/2017,cola soda,100";

            List<string> rows = report.Split(';').Select(sValue => sValue.Trim()).ToList();

            return rows;

        }

        // GET api/vendor/getSoldQuantity?date={date}
        public int getSoldQuantity(string date)
        {
            
            List<string> formatReport = returnReport();

            var result = (
                            (from x in formatReport
                            where x.Contains(date)
                            select new
                            {
                                number =Int32.Parse(x.Split(',')[2])
                            }).ToList()
                         ).Sum(x => x.number);

            return result;           
        }

        // GET api/vendor/getSoldQuantityPerItem?date={date}&itemName={itemName}
        public int getSoldQuantityPerItem(string date, string itemName)
        {
            List<string> formatReport = returnReport();

            var result = (
                            (from x in formatReport
                             where x.Contains(date) && x.Contains(itemName)
                             select new
                             {
                                 number = Int32.Parse(x.Split(',')[2])
                             }).ToList()
                         ).Sum(x => x.number);

            return result;           
        }

        // GET api/vendor/getMostSoldItems?date={date}
        public List<string> getMostSoldItems(string date)
        {
            List<string> formatReport = returnReport();

            var result =    (from x in formatReport
                             where x.Contains(date)                           
                            select new
                             {
                                 itemName = x.Split(',')[1],
                                 number = x.Split(',')[2]
                             }).ToList();

            var grouped = (from x in result
                           group x by new { x.itemName } into g                          
                           select new { g.Key.itemName, sum = g.Sum(x => Int32.Parse(x.number)) }
                          ).ToList();

            return grouped.Where(x => x.sum == grouped.Max(y => y.sum)).Select(x => x.itemName).ToList();
                                    
        }

        // GET api/vendor/getMostSoldDates?itemName={itemName}
        public List<string> getMostSoldDates(string itemName)
        {
            List<string> formatReport = returnReport();
            var result =     (from x in formatReport
                              where x.Contains(itemName)
                             select new
                             {
                                 date = x.Split(',')[0],
                                 number = x.Split(',')[2]
                             }).ToList();

            var grouped = (from x in result
                           group x by new { x.date } into g
                           select new { g.Key.date, sum = g.Sum(x => Int32.Parse(x.number)) }
                          ).ToList();

            return grouped.Where(x => x.sum == grouped.Max(y => y.sum)).Select(x => x.date).ToList();          
        }
    }
}
