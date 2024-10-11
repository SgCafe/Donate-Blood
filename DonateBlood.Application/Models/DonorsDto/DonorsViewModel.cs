using DonateBlood.Core.Entities;

namespace DonateBlood.Application.Models.DonorsDto
{
    public class DonorsViewModel
    {
        public DonorsViewModel(
            string fullName, string email, DateTime birthDate, string gender,
            double weight, string bloodType, string factorRh, List<Donations> donations)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
            Donations = new List<Donations>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string FactorRh { get; private set; }

        public List<Donations> Donations { get; private set; }

        public static DonorsViewModel FromEntity(Donors donor)
        {
            var donations = donor.Donations
                .Select(x => x.Donor)
                .Where(x => x.Id == donor.Id).ToList();

            return new DonorsViewModel(
                donor.FullName, donor.Email, donor.BirthDate,
                donor.Gender, donor.Weight, donor.BloodType.ToString(), 
                donor.FactorRh.ToString(), donor.Donations);
        }
    }
}
