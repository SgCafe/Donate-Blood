using DonateBlood.Application.Models;
using DonateBlood.Application.Models.DonorsDto;

namespace DonateBlood.Application.Services.Donors
{
    public interface IDonorsService
    {
        ResultViewModel<DonorsViewModel> GetAll();

    }
}
