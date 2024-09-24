namespace DonateBlood.Core.Entities
{
    public class Donations
    {
        public int Id { get; private set; }
        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int Quantity { get; private set; }
        public Donors Donor { get; private set; }
    }
}
