namespace DonateBlood.Core.Entities
{
    public class Adreess
    {
        public int Id { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
    }
}