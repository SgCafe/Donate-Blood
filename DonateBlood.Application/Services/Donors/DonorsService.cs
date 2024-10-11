using DonateBlood.Application.Models;
using DonateBlood.Application.Models.DonorsDto;
using DonateBlood.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DonateBlood.Application.Services.Donors
{
    public class DonorsService : IDonorsService
    {
        private readonly DonateBloodDbContext _context;
        public DonorsService(DonateBloodDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<DonorsViewModel>> GetAll()
        {
            var donors = _context.Donors
                .Include(a => a.Address)
                .Include(d => d.Donations)
                .Where(isD => !isD.IsDeleted)
                .ToList();

            if (donors is null)
            {
                return ResultViewModel<List<DonorsViewModel>>.Error("Não existem doadores cadastrados.");
            }

            var model = donors.Select(DonorsViewModel.FromEntity).ToList();


            return ResultViewModel<List<DonorsViewModel>>.Success(model);
        }

        public ResultViewModel<DonorsViewModel> GetById(int id)
        {
            var donor = _context.Donors
                .Include(a => a.Address)
                .Include(d => d.Donations)
                .SingleOrDefault(x => x.Id == id);

            if (donor is null)
            {
                return ResultViewModel<DonorsViewModel>.Error("Doador não encontrado.");
            }

            var model = DonorsViewModel.FromEntity(donor);

            return ResultViewModel<DonorsViewModel>.Success(model);
        }

        public ResultViewModel<int> Post(CreateDonorInputModel model)
        {
            var donor = model.ToEntity();

            _context.Donors.Add(donor);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
