using DonateBlood.Application.Models;
using DonateBlood.Application.Models.StockDto;
using DonateBlood.Infrastructure.Persistence;

namespace DonateBlood.Application.Services.Stock
{
    public class StockService : IStockService
    {
        private DonateBloodDbContext _context;

        public StockService(DonateBloodDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<StockViewModel>> GetAll(string search = "")
        {
            var stocks = _context.Stocks
                .Where(x => !x.IsDeleted)
                .ToList();

            if (stocks is null)
            {
                return ResultViewModel<List<StockViewModel>>.Error("Não existem estoques cadastrados");
            }

            var model = stocks.Select(StockViewModel.FromEntity).ToList();

            return ResultViewModel<List<StockViewModel>>.Success(model);
        }

        public ResultViewModel<StockViewModel> GetById(int id)
        {
            var stock = _context.Stocks
                .SingleOrDefault(x => x.Id == id);

            if (stock is null)
            {
                return ResultViewModel<StockViewModel>.Error("Estoque não encontrado");
            }

            var model = StockViewModel.FromEntity(stock);

            return ResultViewModel<StockViewModel>.Success(model);
        }

        public ResultViewModel<StockViewModel> GetByType(string bloodType, string factorRh)
        {
            var stock = _context.Stocks
                .SingleOrDefault(x => 
                    !x.IsDeleted && 
                    x.BloodType.ToString() == bloodType || 
                    x.FactorRh.ToString() == factorRh);

            if (stock is null)
            {
                return ResultViewModel<StockViewModel>.Error("Estoque não encontrado.");
            }

            var model = StockViewModel.FromEntity(stock);

            return ResultViewModel<StockViewModel>.Success(model);
        }
    }
}
