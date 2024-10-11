using DonateBlood.Core.Enums;

namespace DonateBlood.Core.Entities
{
    public class Stocks : BaseEntity
    {
        public Stocks(EBloodType bloodType, EFactorRh factorRh, int quantity)
        {
            BloodType = bloodType;
            FactorRh = factorRh;
            Quantity = quantity;
        }

        public int Id { get; private set; }
        public EBloodType BloodType { get; private set; }
        public EFactorRh FactorRh { get; private set; }
        public int Quantity { get; private set; }

        public List<Donations> Donations { get; private set; }
        public List<StockDonation> StockDonation { get; private set; }

        public void Movimentation(int amount)
        {
            Quantity += amount;
        }
    }
}
