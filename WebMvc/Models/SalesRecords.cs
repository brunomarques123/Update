using System;

using WebMvc.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebMvc.Models
{
    public class SalesRecords
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }



        public SalesRecords()
        {
        }

        public SalesRecords(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}