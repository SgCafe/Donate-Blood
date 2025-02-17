﻿namespace DonateBlood.Core.Entities
{
    public class Donations : BaseEntity
    {
        private Donations()
        {
            
        }

        public Donations(int donorId, DateTime donationDate, int quantity)
            : base()
        {
            DonorId = donorId;
            DonationDate = donationDate;
            Quantity = quantity;
        }

        public int Id { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int Quantity { get; private set; }

        public int DonorId { get; private set; }
        public Donors Donor { get; private set; }

        public int StockId { get; set; }
        public Stocks Stock { get; private set; }
        public List<StockDonation> StockDonation { get; private set; }
    }
}
