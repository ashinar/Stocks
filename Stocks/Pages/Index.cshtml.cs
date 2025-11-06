using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stocks.Pages
{
    public class IndexModel : PageModel
    {
        public int StockChecked { get; set; }
        public decimal SpyPrice { get; set; }
        public decimal SpyPriceDayBefore { get; set; }

        public List<string> MyStocks { get; set; } = new List<string>();
        public List<string> ReportedStocks { get; set; } = new List<string>();

        public async Task OnGetAsync()
        {
            string apiKey = "d431ai1r01qvk0j9nnigd431ai1r01qvk0j9nnj0";
            string url = $"https://finnhub.io/api/v1/quote?&token={apiKey}&symbol=";

            bool isLongDay = await CheckStock("SPY"); 

            //if (!isLongDay)
            //{
            //    return;
            //}

 
          
            CheckStock("CRDO", 187.62m);
            CheckStock("REAL", 12.81m);
            CheckStock("XAUUSD", 4391m);
            CheckStock("PSIX", 86.62m);
            CheckStock("ALAB", 220m);
            CheckStock("SEDG", 42);
            CheckStock("META", 660.68m);
            CheckStock("HLI", 188m);
            CheckStock("REKR", 2.71m);


            Thread.Sleep(500);


            CheckStock("REKR", 2.53m);
            CheckStock("MP", 69);
            CheckStock("CIFR", 22);
            CheckStock("NVTS", 17);
            CheckStock("EOSE", 16);
            CheckStock("ARM", 183);
            CheckStock("IREN", 74.6m);
            CheckStock("IREN", 194);
        
            CheckStock("TSLA", 466);
            CheckStock("BITF", 4.55m);


            Thread.Sleep(500);

           
            CheckStock("DGXX", 5.69m);
            CheckStock("LMND",7);
            //CheckStock("BULL",11); //without Trend
            CheckStock("NNE", 47);
            CheckStock("OUST", 36);
            CheckStock("OPEN", 7);
            CheckStock("RR", 4.10m);
            CheckStock("ASTS", 80);
            CheckStock("OKLO", 144);//ראש וכפתיים לירידות
            CheckStock("JOBY", 17);//לא נראה טוב כגע
            CheckStock("CRCL", 159);

            Thread.Sleep(500);

   
            CheckStock("MRVL", 94);
            CheckStock("LAES", 7.69m);
            CheckStock("ONDS", 7.91m);
            CheckStock("ZIM", 16);
            CheckStock("MNDY", 207);
            CheckStock("ACN", 255);


            //Quantum
            CheckStock("RGTI", 44.52m); //trendspider
            CheckStock("RGTI", 37.62m); //trendspider
            CheckStock("QUBT", 16.68m); //trendspider
            CheckStock("IONQ", 62.69m); //trendspider
            CheckStock("SEZL", 61); //trendspider


            Thread.Sleep(500);
            CheckStock("ORCL", 264);//cyclestrading  
            CheckStock("AMZN", 242);//cyclestrading  
            CheckStock("CGNT", 8.3m);//cyclestrading  
            CheckStock("DRS",33);//cyclestrading  
            CheckStock("FAST", 39);//cyclestrading  
            CheckStock("SE", 156);//cyclestrading  
            CheckStock("PLTR", 190);//cyclestrading  
            CheckStock("DGX", 182);//cyclestrading  
            CheckStock("INDP", 71);//cyclestrading 
            CheckStock("FORM", 48);//David Ariel

            MyStocks.Add("HOOD");
            MyStocks.Add("QS");
            MyStocks.Add("SYM");
         
     
            MyStocks.Add("NBIS");
            MyStocks.Add("BBAI");
            MyStocks.Add("NVDA");
            MyStocks.Add("DR");
            MyStocks.Add("ADP");
            MyStocks.Add("RTX");
            MyStocks.Add("CRWD");

            CheackReoprtDate();
        }



        private async Task<bool> CheckStock(string symbol,decimal minPrice = 0)
        {
            bool status = false;
            string apiKey = "d431ai1r01qvk0j9nnigd431ai1r01qvk0j9nnj0";
            StockChecked++;

            using var client = new HttpClient();
            var response = await client.GetStringAsync($"https://finnhub.io/api/v1/quote?&token={apiKey}&symbol={symbol}");
            var data = JObject.Parse(response);

            if (data != null)
            {

                //c - close priice
                //h - high price
                //l - low price
                //o - open price
                //v - volume
                decimal price = data["c"]?.Value<decimal>() ?? 0;
               
                decimal dayBefore = data["pc"]?.Value<decimal>() ?? 0;

                if (symbol == "SPY")
                {
                    SpyPrice = price;
                    SpyPriceDayBefore = dayBefore;
                }

                status =  price > dayBefore;

                if (status && minPrice > 0)
                {
                    status = price > minPrice;
                }
                              
            }



            return status;
        }

        private void CheackReoprtDate()
        {
            DateTime date = DateTime.Now.AddDays(1);
            switch (date.Year)
            {
                case 2025:
                    switch (date.Month)
                    {
                        case 11:
                            switch (date.Day)
                            {
                                case 3:
                                    ReportedStocks.Add("PLTR"); //3.11.25
                                    ReportedStocks.Add("HIMS");
                                    ReportedStocks.Add("NVTS");
                                    break;                                    
                                case 4:
                                    ReportedStocks.Add("UBER"); //4.11.25
                                    ReportedStocks.Add("SHOP");
                                    ReportedStocks.Add("SPOT");
                                    ReportedStocks.Add("AMD");
                                    ReportedStocks.Add("SMCI");
                                    break;
                                case 5:
                                    ReportedStocks.Add("HOOD"); //5.11.25
                                    ReportedStocks.Add("APP");
                                    ReportedStocks.Add("ARM");
                                    ReportedStocks.Add("LYFT");
                                    break;
                                case 19:
                                    ReportedStocks.Add("פועלים"); //19.11.25
                                    break;
                                case 25:
                                    ReportedStocks.Add("לאומי"); //25.11.25
                                    break;
                            }
                            break;
                        case 12:
                            case 2:
                                ReportedStocks.Add("דיסקונט"); //2.12.25
                                break;                  
                        }
                    break;
                case 2026:
                    switch (date.Month)
                    {
                        case 2:
                            ReportedStocks.Add("גד"); //12.2.26
                            break;
                    }
                    break;
            }
        }
    }
}
