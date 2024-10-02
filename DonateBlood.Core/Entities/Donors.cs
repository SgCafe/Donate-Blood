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
            double weight, string bloodType, 
            string factorRh, Adreess adreess)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
            Adreess = new Adreess();
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string FactorRh { get; private set; }

        public List<DonorDonation> DonorDonation { get; private set; }
        public List<Donations> Donations { get; private set; }
        public Adreess Adreess{ get; private set; } = new Adreess();
    }
}
