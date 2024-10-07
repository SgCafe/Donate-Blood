using DonateBlood.Core.Enums;

namespace DonateBlood.Core.Entities
{
    public class Donors : BaseEntity
    {
        public Donors()
        {
            
        }

        public Donors(
            string fullName, string email, 
            DateTime birthDate, string gender, 
            double weight, EBloodType bloodType,
            EFactorRh factorRh, Adreess adreess)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
            Adreess = adreess;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public EBloodType BloodType { get; private set; }
        public EFactorRh FactorRh { get; private set; }
        
        public List<DonorDonation> DonorDonation { get; private set; }
        public List<Donations> Donations { get; private set; }
        public Adreess Adreess { get; private set; }
    }
}
