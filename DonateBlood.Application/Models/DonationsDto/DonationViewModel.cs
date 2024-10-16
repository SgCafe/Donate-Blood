using DonateBlood.Core.Entities;
using DonateBlood.Core.Enums;

namespace DonateBlood.Application.Models.DonationsDto
{
    public class DonationViewModel
    {
        public DonationViewModel(
            int id,
            DateTime donationDate,
            int quantity,
            DonorDonationViewModel donor,
            List<StockDonationViewModel> stocksMoviments)
        {
            DonationId = id;
            DonationDate = donationDate;
            Quantity = quantity;
            Donor = donor;
            StocksMoviments = stocksMoviments;
        }

        public int DonationId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int Quantity { get; private set; }

        public DonorDonationViewModel Donor { get; private set; }
        public List<StockDonationViewModel> StocksMoviments { get; private set; }

        public static DonationViewModel FromEntity(Donations donations)
        {
            var moviments = new List<StockDonationViewModel>();

            foreach (var stockDonation in donations.StockDonation)
            {
                moviments.Add(new(stockDonation.DonationId, stockDonation.StockId));
            }

            return new(
                donations.Id,
                donations.DonationDate,
                donations.Quantity,
                new(
                    donations.Donor.FullName,
                    donations.Donor.Email,
                    donations.Donor.BloodType,
                    donations.Donor.FactorRh),
                moviments);
        }
    }

    public record DonorDonationViewModel(
        string FullName,
        string Email,
        EBloodType BloodType,
        EFactorRh FactorRh);

    public record StockDonationViewModel(
        int IdDonation,
        int IdStock);
}
