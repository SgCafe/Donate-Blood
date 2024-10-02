namespace DonateBlood.Core.Entities
{
    public class Stocks : BaseEntity
    {
        public Stocks(string bloodType, string factorRh, int quantity)
        {
            BloodType = bloodType;
            FactorRh = factorRh;
            Quantity = quantity;
        }

        public int Id { get; private set; }
        public string BloodType { get; private set; }
        public string FactorRh { get; private set; }
        public int Quantity { get; private set; }
    }
}
