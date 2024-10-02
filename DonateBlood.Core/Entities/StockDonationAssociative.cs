namespace DonateBlood.Core.Entities
{
    public class StockDonationAssociative : BaseEntity
    {
        public StockDonationAssociative(int donationId, int stockId)
            : base()
        {
            DonationId = donationId;
            StockId = stockId;
        }

        public int Id { get; private set; }
        public int DonationId { get; private set; }
        public Donations Donation { get; private set; }
        public int StockId { get; private set; }
        public DonationStock Stock { get; private set; }
    }
}
