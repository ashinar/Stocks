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
        public  List<Stock> LstQuantumStocks = new List<Stock>();
        public async Task OnGet()
        {

            //Market
            await AddStockToLIst("SPY", "ETF", LstMArketStocks);
            await AddStockToLIst("QQQ", "", LstMArketStocks);
          
            //Quantum
            await AddStockToLIst("QTUM","ETF",LstQuantumStocks);
            await AddStockToLIst("IONQ", "", LstQuantumStocks);
            await AddStockToLIst("RGTI", "", LstQuantumStocks);
            await AddStockToLIst("QBTS", "", LstQuantumStocks);
            await AddStockToLIst("QUBT", "", LstQuantumStocks);
        }


        private async Task AddStockToLIst(string symbol,string description, List<Stock> lstStocks)
        {
            var stock = new Stock(symbol,description);
            await stock.LoadAsync(Stock.eProviderType.Finnhub);            

            lstStocks.Add(stock);
        }
    }
}
