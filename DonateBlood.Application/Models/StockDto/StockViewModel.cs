using DonateBlood.Core.Entities;
using DonateBlood.Core.Enums;

namespace DonateBlood.Application.Models.StockDto
{
    public class StockViewModel
    {
        public StockViewModel(
            int id, 
            EBloodType bloodType, 
            EFactorRh factorRh, 
            int quantity)
        {
            Id = id;
            BloodType = bloodType;
            FactorRh = factorRh;
            Quantity = quantity;
        }

        public int Id { get; private set; }
        public EBloodType BloodType { get; private set; }
        public EFactorRh FactorRh { get; private set; }
        public int Quantity { get; private set; }

        public static StockViewModel FromEntity(Stocks stock)
        {
            return new(stock.Id, stock.BloodType, stock.FactorRh, stock.Quantity);
        }
    }
}
