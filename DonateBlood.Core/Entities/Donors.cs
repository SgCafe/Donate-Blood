using DonateBlood.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DonateBlood.Core.Entities
{
    public class Donors : BaseEntity
    {
        protected Donors()
        {
            
        }

        public Donors(
            string fullName, string email, 
            DateTime birthDate, string gender, 
            double weight, EBloodType bloodType,
            EFactorRh factorRh, Address address)
            : base()
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
            Address = address;
            Donations = new List<Donations>();
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EBloodType BloodType { get; private set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EFactorRh FactorRh { get; private set; }

        public List<Donations> Donations { get; set; }
        public Address Address { get; private set; }
    }
}
