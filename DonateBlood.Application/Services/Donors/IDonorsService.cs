using DonateBlood.Application.Models;
using DonateBlood.Application.Models.DonorsDto;

namespace DonateBlood.Application.Services.Donors
{
    public interface IDonorsService
    {
        ResultViewModel<List<DonorsViewModel>> GetAll();
        ResultViewModel<DonorsViewModel> GetById(int id);
        ResultViewModel<int> Post(CreateDonorInputModel model);

    }
}
