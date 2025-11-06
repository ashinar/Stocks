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
            Stock stock = await AddStockToLIst("PL", "", LstMArketStocks);
            if (stock.IsLoaded && stock.CurrentPrice > 13.25m)
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
