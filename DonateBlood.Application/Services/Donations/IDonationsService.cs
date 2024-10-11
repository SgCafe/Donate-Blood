using DonateBlood.Application.Models;
using DonateBlood.Application.Models.DonationsDto;

namespace DonateBlood.Application.Services.Donations
{
    public interface IDonationsService
    {
        ResultViewModel<List<DonationViewModel>> GetAll();
        ResultViewModel<DonationViewModel> GetById(int id);
        ResultViewModel<int> Post(CreateDonationInputModel model);
    }
}
