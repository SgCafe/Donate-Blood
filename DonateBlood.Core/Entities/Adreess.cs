namespace DonateBlood.Core.Entities
{

    public class Adreess
    {
        public Adreess(string street, string city, string state, string postalCode)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public int Id { get; private set; }    
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }

        public int DonorId { get; private set; }
        public Donors Donor { get; private set; }
    }
}