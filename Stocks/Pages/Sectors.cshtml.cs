using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Stocks.Models;
using Stocks.Models.Stocks.Models;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Stocks.Pages
{
    public class SectorsModel : PageModel
    {
        public List<Stock> LstMArketStocks = new List<Stock>();
        public List<Stock> LstStockToBuy = new List<Stock>();
        public  List<Stock> LstQuantumStocks = new List<Stock>();
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



           await StocksToCheck();
        }

        private async Task StocksToCheck()
        {
            Stock stock = await AddStockToLIst("PL", "", LstStockToBuy);
            if (stock.IsLoaded && stock.CurrentPrice > 12)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("META", "", LstStockToBuy); //cyclestrading  
            if (stock.IsLoaded && stock.CurrentPrice > 622.13m)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("ORCL", "", LstStockToBuy); //cyclestrading  
            if (stock.IsLoaded && stock.CurrentPrice > 240.40m)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("AMZN", "", LstStockToBuy); //cyclestrading  
            if (stock.IsLoaded && stock.CurrentPrice > 244.90m)
            {
                LstStockToBuy.Add(stock);
            }



            stock = await AddStockToLIst("CGNT", "", LstStockToBuy); //cyclestrading  
            if (stock.IsLoaded && stock.CurrentPrice > 9)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("DRS", "", LstStockToBuy); //cyclestrading  
            if (stock.IsLoaded && stock.CurrentPrice > 35)
            {
                LstStockToBuy.Add(stock);
            }



            stock = await AddStockToLIst("FAST", "", LstStockToBuy); //cyclestrading  
            if (stock.IsLoaded && stock.CurrentPrice > 40)
            {
                LstStockToBuy.Add(stock);
            }


            stock = await AddStockToLIst("TEM", "", LstStockToBuy); //cyclestrading  
            if (stock.IsLoaded && stock.CurrentPrice > 72)
            {
                LstStockToBuy.Add(stock);
            }




        }

        private async Task<Stock> AddStockToLIst(string symbol,string description, List<Stock> lstStocks)
        {
            var stock = new Stock(symbol,description);
            await stock.LoadAsync(Stock.eProviderType.Finnhub);            

            lstStocks.Add(stock);
            return stock;
        }
    }
}
