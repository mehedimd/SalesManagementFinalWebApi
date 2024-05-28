using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesManagement.Core.Models;
using SalesManagement.Services.Interfaces;


namespace SalesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService stockService;
        public StocksController(IStockService stockService)
        {
            this.stockService = stockService;
        }
        // api/Stocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            var allStocks = await stockService.GetAllStocks();
            if(allStocks == null)
            {
                return NotFound();
            }
            return Ok(allStocks);
        }
        // api/Stock/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            var stock = await stockService.GetStockById(id);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
        // api/Stocks
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
            var isCreated = await stockService.CreateStock(stock);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest();
        }
        // api/Stocks/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id,Stock stock)
        {
            if(id != stock.StockId)
            {
                return BadRequest();
            }
            if(stock != null)
            {
                var isUpdated = await stockService.UpdateStock(stock);
                if (isUpdated)
                {
                    return Ok(isUpdated);
                }
            }
            
            return BadRequest();
        }
        // api/Stock/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var isDeleted = await stockService.DeleteStock(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return BadRequest();
        }
    }
}
