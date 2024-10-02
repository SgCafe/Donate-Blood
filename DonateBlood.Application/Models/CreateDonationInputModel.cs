using DonateBlood.Core.Entities;

namespace DonateBlood.Application.Models
{
    public class CreateDonationInputModel
    {
        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int Quantity { get; private set; }

        public Donations ToEntity()
            => new(DonorId, DonationDate, Quantity);
    }
}
