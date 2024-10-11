namespace DonateBlood.Core.Entities
{
    public class StockDonation : BaseEntity
    {
        public StockDonation(int donationId, int stockId)
            : base()
        {
            DonationId = donationId;
            StockId = stockId;
        }

        public int Id { get; private set; }
        public int DonationId { get; private set; }
        public Donations Donation { get; set; }
        public int StockId { get; private set; }
        public Stocks Stock { get; private set; }
    }
}
