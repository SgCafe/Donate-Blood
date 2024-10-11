using DonateBlood.Core.Entities;

namespace DonateBlood.Application.Models.DonationsDto
{
    public class CreateDonationInputModel
    {
        public int DonorId { get; set; }
        public DateTime DonationDate { get; set; }
        public int Quantity { get; set; }

        public Donations ToEntity()
            => new(DonorId, DonationDate, Quantity);
    }
}
