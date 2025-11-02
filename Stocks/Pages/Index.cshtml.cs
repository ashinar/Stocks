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
        public decimal SpyPrice { get; set; }
        public decimal SpyPriceDayBefore { get; set; }

        public List<string> MyStocks { get; set; } = new List<string>();
        public List<string> ReportedStocks { get; set; } = new List<string>();

        public async Task OnGetAsync()
        {
            string apiKey = "d431ai1r01qvk0j9nnigd431ai1r01qvk0j9nnj0";
            string url = $"https://finnhub.io/api/v1/quote?&token={apiKey}&symbol=";

            bool isLongDay = await CheckStock("SPY"); 

            if (!isLongDay)
            {
                return;
            }


            using var client = new HttpClient();

            //1 - PL
            string stock = "PL";           
            var response = await client.GetStringAsync(url + stock);
            var data = JObject.Parse(response);

            var price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 13.45m)
            {
                MyStocks.Add(stock);
            }


            //2 -CRDO
            stock = "CRDO";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 187.62m)
            {
                MyStocks.Add(stock);
            }


            //3 -REAL
            stock = "REAL";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 12.81m)
            {
                MyStocks.Add(stock);
            }

            //3 -XAUUSD
            stock = "XAUUSD";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 4391m)
            {
                MyStocks.Add(stock);
            }


            //4 -PSIX
            stock = "PSIX";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 86.62m)
            {
                MyStocks.Add(stock);
            }



            //5 -ALAB
            stock = "ALAB";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 220m)
            {
                MyStocks.Add(stock);
            }



            //6 -ASTS
            stock = "ASTS";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 102.93m)
            {
                MyStocks.Add(stock);
            }


            //5 -ALAB
            stock = "ALAB";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 220m)
            {
                MyStocks.Add(stock);
            }



            //6 -LMND
            stock = "LMND";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 60.4m)
            {
                MyStocks.Add(stock);
            }


            //7 -OPEN
            stock = "OPEN";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 8.59m)
            {
                MyStocks.Add(stock);
            }


            //8 -SEDG
            stock = "SEDG";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 42.63m)
            {
                MyStocks.Add(stock);
            }


            //9 -ONDS
            stock = "ONDS";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 7.91m)
            {
                MyStocks.Add(stock);
            }


            //10 -NNE
            stock = "NNE";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 49.50m)
            {
                MyStocks.Add(stock);
            }


            //11 -META
            stock = "META";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 660.68m)
            {
                MyStocks.Add(stock);
            } 


            //13 -HLI
            stock = "HLI";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 188m)
            {
                MyStocks.Add(stock);
            }


            //14 -DR
             stock = "DR";
             //response = await client.GetStringAsync(url + stock);
             //data = JObject.Parse(response);

             //price = data["c"]?.Value<decimal>() ?? 0;
             //if (price < 14m)
             //{
             //    MyStocks.Add(stock);
             //}
             MyStocks.Add(stock);


            //15 -MRVL
            stock = "MRVL";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 95m)
            {
                MyStocks.Add(stock);
            }


            //16 - ADP
            stock = "ADP";
            //response = await client.GetStringAsync(url + stock);
            //data = JObject.Parse(response);

            //price = data["c"]?.Value<decimal>() ?? 0;
            //if (price > 220m)
            //{
            //    MyStocks.Add(stock);
            //}

            MyStocks.Add(stock);

            //17 -RTX
            stock = "RTX";
            //response = await client.GetStringAsync(url + stock);
            //data = JObject.Parse(response);

            //price = data["c"]?.Value<decimal>() ?? 0;
            //if (price > 95m)
            //{
            //    MyStocks.Add(stock);
            //}

            MyStocks.Add(stock);



            //18 - CRWD
            stock = "CRWD";
            //response = await client.GetStringAsync(url + stock);
            //data = JObject.Parse(response);

            //price = data["c"]?.Value<decimal>() ?? 0;
            //if (price > 95m)
            //{
            //    MyStocks.Add(stock);
            //}

            MyStocks.Add(stock);



            //19 -REKR
            stock = "REKR";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 2.71m)
            {
                MyStocks.Add(stock);
            }



            //19 -SES
            stock = "SES";
            response = await client.GetStringAsync(url + stock);
            data = JObject.Parse(response);

            price = data["c"]?.Value<decimal>() ?? 0;
            if (price > 2.53m)
            {
                MyStocks.Add(stock);
            }


    


            CheckStock("MP", 69);
            CheckStock("CIFR", 15);
            CheckStock("NVTS", 17);
            CheckStock("EOSE", 16);
            CheckStock("ARM", 183);
            CheckStock("IREN", 74.6m);
            CheckStock("IREN", 194);
            CheckStock("IONQ", 76);

            MyStocks.Add("HOOD");
            MyStocks.Add("QS");
            MyStocks.Add("SYM");
            MyStocks.Add("RGTI");
            MyStocks.Add("QBTS");
            MyStocks.Add("NBIS");

            CheackReoprtDate();
        }


        private async Task<bool> CheckStock(string symbol,decimal minPrice = 0)
        {
            bool status = false;
            string apiKey = "d431ai1r01qvk0j9nnigd431ai1r01qvk0j9nnj0";

            using var client = new HttpClient();
            var response = await client.GetStringAsync($"https://finnhub.io/api/v1/quote?&token={apiKey}&symbol={symbol}");
            var data = JObject.Parse(response);

            if (data != null)
            {
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
