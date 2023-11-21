﻿namespace Entities.Entities
{
    public class SeatModel
    {
        public int? ID { get; set; }
        public string CURRENCY { get; set; } = String.Empty;
        public decimal? EXCHANGE_RATE { get; set; }
        public string REFERENCE { get; set; } = String.Empty;
        public bool STATUS { get; set; }
    }
}
