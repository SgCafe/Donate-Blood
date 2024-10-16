using DonateBlood.Core.Entities;
using System.Diagnostics.Contracts;

namespace DonateBlood.Application.Models.DonorsDto
{
    public class DonorsViewModel
    {
        public DonorsViewModel(
            string fullName,
            string email,
            DateTime birthDate,
            string gender,
            double weight,
            string bloodType,
            string factorRh,
            List<DonationDonorViewModel> donations)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
            Donations = donations;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string FactorRh { get; private set; }

        public List<DonationDonorViewModel> Donations { get; private set; }

        public static DonorsViewModel FromEntity(Donors donor)
        {
            var dn = new List<DonationDonorViewModel>();

            foreach (var donation in donor.Donations)
            {
                dn.Add(new(donation.Id, donation.DonationDate, donation.Quantity));
            }

            return new DonorsViewModel(
                donor.FullName, donor.Email, donor.BirthDate,
                donor.Gender, donor.Weight, donor.BloodType.ToString(),
                donor.FactorRh.ToString(),
                dn);
        }

        public record DonationDonorViewModel(
            int id,
            DateTime donationDate,
            int quantity);
    }
}
