using DonateBlood.Application.Models;
using DonateBlood.Application.Models.DonationsDto;
using DonateBlood.Core.Entities;
using DonateBlood.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DonateBlood.Application.Services.Donations
{
    public class DonationService : IDonationsService
    {
        private readonly DonateBloodDbContext _context;

        public DonationService(DonateBloodDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<DonationViewModel>> GetAll()
        {
            var donations = _context.Donations
                .Include(x => x.StockDonation)
                .Include(x => x.Donor)
                .Include(x => x.Stock)
                .Where(x => !x.IsDeleted)
                .ToList();

            if (donations.Count is 0)
            {
                return ResultViewModel<List<DonationViewModel>>.Error("Não existem doações cadastradas.");
            }

            var model = donations.Select(DonationViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonationViewModel>>.Success(model);
        }

        public ResultViewModel<DonationViewModel> GetById(int id)
        {
            var donation = _context.Donations
                .AsNoTracking()
                .Include(x => x.Donor)
                .Include(x => x.StockDonation)
                .SingleOrDefault(x => x.Id == id);

            if (donation is null)
            {
                ResultViewModel<DonationViewModel>.Error("Doador não encontrado.");
            }

            var model = DonationViewModel.FromEntity(donation!);
            return ResultViewModel<DonationViewModel>.Success(model);
        }

        public ResultViewModel<int> Post(CreateDonationInputModel model)
        {
            var donation = model.ToEntity();

            if (donation is null)
            {
                return ResultViewModel<int>.Error("Erro ao cadastrar Doação.");
            }

            int? stock = GetStock(donation);

            if (stock is null)
            {
                return ResultViewModel<int>.Error("Doador não encontrado.");
            }

            donation.StockId = stock ?? 0;
            _context.Donations.Add(donation);
            _context.SaveChanges();

            var stockReturn = _context.Stocks.First(x => x.Id == stock);
            stockReturn.Movimentation(donation.Quantity);

            var stockDonation = new StockDonation(donation.Id, stock ?? 0);

            _context.Stocks.Update(stockReturn);
            _context.StockDonation.Add(stockDonation);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(donation.DonorId);
        }

        private int? GetStock(Core.Entities.Donations model)
        {
            var donor = _context.Donors
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == model.DonorId);

            if (donor is null)
            {
                return null;
            }

            var stock = _context.Stocks
                .AsNoTracking()
                .FirstOrDefault(x => x.BloodType == donor.BloodType && x.FactorRh == donor.FactorRh);

            if (stock is null)
            {
                var stockCreated = new Core.Entities.Stocks(donor.BloodType, donor.FactorRh, 0);

                _context.Stocks.Add(stockCreated);
                _context.SaveChanges();
                return stockCreated.Id;
            }

            return stock.Id;
        }
    }
}
