namespace DonateBlood.Core.Entities
{
    public class DonationStock
    {
        public int Id { get; private set; }
        public string BloodType { get; private set; }
        public string FactorRh { get; private set; }
        public int Quantity { get; private set; }
    }
}
