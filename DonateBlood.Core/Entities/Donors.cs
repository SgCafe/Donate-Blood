namespace DonateBlood.Core.Entities
{
    public class Donors
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string FactorRh { get; private set; }

        public List<Donations> Donations { get; private set; }
        public Adreess Adreess{ get; private set; }

    }

    public record Adreess
    {
        public int Id { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
    }
}
