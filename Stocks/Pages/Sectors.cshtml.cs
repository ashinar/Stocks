using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Stocks.Models;
using Stocks.Models.Stocks.Models;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace Stocks.Pages
{
    public class SectorsModel : PageModel
    {
        public List<Stock> LstMArketStocks = new List<Stock>();
        public List<Stock> LstStockToBuy = new List<Stock>();
        public  List<Stock> LstQuantumStocks = new List<Stock>();
        public List<Stock> LstNuclearEnergyStocks = new List<Stock>();

        public async Task OnGet()
        {

            //Market
            Stock stock = await AddStockToLIst("SPY", "ETF", LstMArketStocks);
            if(stock.IsLoaded && stock.CurrentPrice > 680)
            {
                LstStockToBuy.Add(stock);
            }
           


            await AddStockToLIst("QQQ", "", LstMArketStocks);
            await AddStockToLIst("UVIX", "", LstMArketStocks);



            //Quantum
            await AddStockToLIst("QTUM","ETF",LstQuantumStocks);
            await AddStockToLIst("IONQ", "", LstQuantumStocks);
            await AddStockToLIst("RGTI", "", LstQuantumStocks);
            await AddStockToLIst("QBTS", "", LstQuantumStocks);
            await AddStockToLIst("QUBT", "", LstQuantumStocks);


            //Nuclear Energy.
            await AddStockToLIst("URA", "ETF", LstNuclearEnergyStocks);
            await AddStockToLIst("NNE", "", LstNuclearEnergyStocks);
            await AddStockToLIst("OKLO", "", LstNuclearEnergyStocks);
            await AddStockToLIst("SMR", "", LstNuclearEnergyStocks);
            await AddStockToLIst("CCJ", "", LstNuclearEnergyStocks);
            await AddStockToLIst("LTBR", "", LstNuclearEnergyStocks);


            await StocksToCheck();
        }

        private async Task StocksToCheck()
        {
            Stock stock = await AddStockToLIst("PL", "");
            //if (stock.IsLoaded && stock.CurrentPrice > 12)
            //{
            //    LstStockToBuy.Add(stock);
            //}


            //stock = await AddStockToLIst("META", "", LstStockToBuy); //cyclestrading  
            //if (stock.IsLoaded && stock.CurrentPrice > 622.13m)
            //{
            //    LstStockToBuy.Add(stock);
            //}





            //stock = await AddStockToLIst("AMZN", "", LstStockToBuy); //cyclestrading  
            //if (stock.IsLoaded && stock.CurrentPrice > 244.90m)
            //{
            //    LstStockToBuy.Add(stock);
            //}



            //stock = await AddStockToLIst("CGNT", "", LstStockToBuy); //cyclestrading  
            //if (stock.IsLoaded && stock.CurrentPrice > 9)
            //{
            //    LstStockToBuy.Add(stock);
            //}


            //stock = await AddStockToLIst("DRS", "", LstStockToBuy); //cyclestrading  
            //if (stock.IsLoaded && stock.CurrentPrice > 35)
            //{
            //    LstStockToBuy.Add(stock);
            //}



            //stock = await AddStockToLIst("FAST", "", LstStockToBuy); //cyclestrading  
            //if (stock.IsLoaded && stock.CurrentPrice > 40)
            //{
            //    LstStockToBuy.Add(stock);
            //}


            //stock = await AddStockToLIst("TEM", "", LstStockToBuy); //cyclestrading  
            //if (stock.IsLoaded && stock.CurrentPrice > 72)
            //{
            //    LstStockToBuy.Add(stock);
            //}


            //stock = await AddStockToLIst("TSLA", "", LstStockToBuy); //dark pool  
            //if (stock.IsLoaded && (stock.CurrentPrice < 402 || stock.CurrentPrice > 443))
            //{
            //    LstStockToBuy.Add(stock);
            //}



            //stock = await AddStockToLIst("ACHR", "", LstStockToBuy); //dark pool  
            //if (stock.IsLoaded && stock.CurrentPrice > 8.5m)
            //{
            //    LstStockToBuy.Add(stock);
            //}



            //stock = await AddStockToLIst("HIMS", "", LstStockToBuy); //dark pool  
            //if (stock.IsLoaded && stock.CurrentPrice < 41)
            //{
            //    LstStockToBuy.Add(stock);
            //}

            //stock = await AddStockToLIst("RBLX", "", LstStockToBuy); //dark pool  
            //if (stock.IsLoaded && stock.CurrentPrice > 101.77m) 
            //{
            //    LstStockToBuy.Add(stock);
            //}




            stock = await AddStockToLIst("IREN", "Take profix 53", LstStockToBuy); //dark pool  
            if (stock.IsLoaded && stock.CurrentPrice > 47)
            {
                LstStockToBuy.Add(stock);
            }



            //stock = await AddStockToLIst("OKLO","", LstStockToBuy); //dark pool  
            //LstStockToBuy.Add(stock);
            ////if (stock.IsLoaded && (stock.CurrentPrice < 97.06m || stock.CurrentPrice > 112.65m))
            ////{
            ////    LstStockToBuy.Add(stock);
            ////}


            //stock = await AddStockToLIst("NNE", "", LstStockToBuy); //dark pool  
            //if (stock.IsLoaded && (stock.CurrentPrice < 34.8m || stock.CurrentPrice > 39.25m))
            //{
            //    LstStockToBuy.Add(stock);
            //}

            stock = await AddStockToLIst("SMR", "", LstStockToBuy); //dark pool  
            if (stock.IsLoaded && (stock.CurrentPrice > 19 ))
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("NVTS", "", LstStockToBuy); //dark pool  
            if (stock.IsLoaded && (stock.CurrentPrice > 7))
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("RKLB", "", LstStockToBuy); //dark pool  
            if (stock.IsLoaded && (stock.CurrentPrice > 42))
            {
                LstStockToBuy.Add(stock);
            }


            //AXON
            stock = await AddStockToLIst("XPEV", ""); //dark pool  
            if (stock.IsLoaded && (stock.CurrentPrice > 24))
            {
                LstStockToBuy.Add(stock);
            }



            stock = await AddStockToLIst("SEDG", ""); //cyclestrading
            if (stock.IsLoaded && (stock.CurrentPrice > 35))
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("PLTR", ""); //cyclestrading
            if (stock.IsLoaded && (stock.CurrentPrice > 168))
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("APLD", ""); //cyclestrading
            if (stock.IsLoaded && (stock.CurrentPrice < 21 && stock.CurrentPrice > 14))
            {
                LstStockToBuy.Add(stock);
            }

            stock = await AddStockToLIst("NVMI", ""); //cyclestrading
            if (stock.IsLoaded && (stock.CurrentPrice < 291 ))
            {
                LstStockToBuy.Add(stock);
            }

            stock = await AddStockToLIst("IONQ", ""); //cyclestrading
            if (stock.IsLoaded && (stock.CurrentPrice > 50))
            {
                LstStockToBuy.Add(stock);
            }



            stock = await AddStockToLIst("CIFR", ""); // cyclestrading
            if (stock.IsLoaded && stock.CurrentPrice > 14)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("LMND", ""); // cyclestrading
            if (stock.IsLoaded && stock.CurrentPrice < 69 && stock.CurrentPrice > 63.52m)
            {
                LstStockToBuy.Add(stock);
            }

            stock = await AddStockToLIst("SHOP", ""); //cyclestrading
            if (stock.IsLoaded && stock.CurrentPrice > 150)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("SOFI", ""); // cyclestrading
           // if (stock.IsLoaded &&( stock.CurrentPrice < 24 ))
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("KTOS", ""); // cyclestrading + dark pool
            if (stock.IsLoaded && (stock.CurrentPrice > 70 ))
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("VRT", ""); // cyclestrading
            if (stock.IsLoaded && (stock.CurrentPrice > 155))
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("WIX", ""); // cyclestrading
            if (stock.IsLoaded && (stock.CurrentPrice > 248))
            {
                LstStockToBuy.Add(stock);
            }

            stock = await AddStockToLIst("JOBY", "", LstStockToBuy); //dark pool  
            if (stock.IsLoaded && stock.CurrentPrice > 13.07m)
            {
                LstStockToBuy.Add(stock);
            }

            stock = await AddStockToLIst("ORCL", "", LstStockToBuy); // Dark Pool
            if (stock.IsLoaded && stock.CurrentPrice > 217)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("APP", "", LstStockToBuy); // Dark Pool
            if (stock.IsLoaded && stock.CurrentPrice > 529)
            {
                LstStockToBuy.Add(stock);
            }

            stock = await AddStockToLIst("OPEN", "", LstStockToBuy); //dark pool  short ???
            if (stock.IsLoaded && stock.CurrentPrice > 6.5m)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("IREN", "", LstStockToBuy); //dark pool  short ???
            if (stock.IsLoaded && stock.CurrentPrice > 44)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("OKLO", "", LstStockToBuy); //dark pool  short ???
            if (stock.IsLoaded && stock.CurrentPrice > 88)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("PGY", "", LstStockToBuy); //dark pool  short ???
            if (stock.IsLoaded && stock.CurrentPrice > 24)
            {
                LstStockToBuy.Add(stock);
            }

            stock = await AddStockToLIst("IONQ", "", LstStockToBuy); //dark pool  short ???
            if (stock.IsLoaded && stock.CurrentPrice > 47)
            {
                LstStockToBuy.Add(stock);
            }

            stock = await AddStockToLIst("SOXL", "ETF", LstStockToBuy); //dark pool  short ???
            if (stock.IsLoaded && stock.CurrentPrice > 29.50m)
            {
                LstStockToBuy.Add(stock);
            }



            stock = await AddStockToLIst("RGTI", "ETF", LstStockToBuy); //dark pool  short ???
            if (stock.IsLoaded && stock.CurrentPrice > 23.59m)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("ZETA", "", LstStockToBuy); //dark pool  
            if (stock.IsLoaded && stock.CurrentPrice > 16)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("NBIS", "", LstStockToBuy); //dark pool  
            if (stock.IsLoaded && stock.CurrentPrice > 83)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("BBAI", "", LstStockToBuy); //dark pool  
            if (stock.IsLoaded && stock.CurrentPrice > 5.47m)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("ALAB", "Need over the Gap", LstStockToBuy); //dark pool  
            if (stock.IsLoaded && stock.CurrentPrice > 162m)
            {
                LstStockToBuy.Add(stock);
            }



            stock = await AddStockToLIst("ASTS", "", LstStockToBuy); //dark pool  
            if (stock.IsLoaded && stock.CurrentPrice > 55)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("RDDT", "Take profit 230", LstStockToBuy); //dark pool  
            if (stock.IsLoaded && stock.CurrentPrice > 217)
            {
                LstStockToBuy.Add(stock);
            }
        }

        private async Task<Stock> AddStockToLIst(string symbol,string description, List<Stock> lstStocks = null)
        {
            var stock = new Stock(symbol,description);
            await stock.LoadAsync(Stock.eProviderType.Finnhub);

            if (lstStocks != null)
            {
                lstStocks.Add(stock);
            }
            return stock;
        }
    }
}
