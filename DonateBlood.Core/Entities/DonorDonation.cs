namespace DonateBlood.Core.Entities
{
    public class DonorDonation : BaseEntity
    {
        public DonorDonation(int donorId, int donationId)
            : base()
        {
            DonorId = donorId;
            DonationId = donationId;
        }

        public int Id { get; private set; }
        public int DonorId { get; private set; }
        public Donors Donor { get; private set; }
        public int DonationId { get; private set; }
        public Donations Donation { get; private set; }
    }
}
