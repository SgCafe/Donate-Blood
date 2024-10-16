using DonateBlood.Application.Models;
using DonateBlood.Application.Models.StockDto;

namespace DonateBlood.Application.Services.Stock
{
    public interface IStockService
    {
        ResultViewModel<List<StockViewModel>> GetAll(string search = "");

        ResultViewModel<StockViewModel> GetById(int id);

        ResultViewModel<StockViewModel> GetByType(string bloodType, string factorRh);
    }
}
