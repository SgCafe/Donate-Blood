using DonateBlood.Core.Entities;

namespace DonateBlood.Application.Models
{
    public class CreateDonorInputModel
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string FactorRh { get; private set; }
        public Adreess Adreess { get; private set; }

        public Donors ToEntity()
            => new(FullName, Email, BirthDate, Gender, Weight, BloodType, FactorRh, Adreess);
    }
}
