namespace DonateBlood.Core.Entities
{
    public class Donations : BaseEntity
    {
        public Donations(int donorId, DateTime donationDate, int quantity) 
            : base()
        {
            DonorId = donorId;
            DonationDate = donationDate;
            Quantity = quantity;
        }

        public int Id { get; private set; }
        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int Quantity { get; private set; }

        public List<DonorDonation> DonorDonation { get; private set; }
        public List<Donors> Donor { get; private set; }
    }
}
