using DonateBlood.Core.Entities;
using DonateBlood.Core.Enums;

namespace DonateBlood.Application.Models.DonorsDto
{
    public class CreateDonorInputModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public EBloodType BloodType { get; set; }
        public EFactorRh FactorRh { get; set; }
        public Address Address { get; set; }

        public Donors ToEntity()
            => new(FullName, Email, BirthDate, Gender, Weight, BloodType, FactorRh, Address);

    }
}
