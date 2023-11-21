﻿namespace BackEnd.Models
{
    public class SeatDetailModel
    {
        public int? ID { get; set; }
        public int SEAT_ID { get; set; }
        public int ACCOUNT_ID { get; set; }
        public decimal AMOUNT { get; set; }
        public string DESCRIPTION { get; set; } = String.Empty;
    }
}
