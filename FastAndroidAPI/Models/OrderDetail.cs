namespace FastAndroidAPI.Models
{
    using System;
    using System.Collections.Generic;

    public partial class OrderDetail
    {
        public int SKUID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal GSTRate { get; set; }
        public decimal Amount { get; set; }
        public decimal StandardDiscount { get; set; }
        public decimal ExtraDiscount { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TSTAmount { get; set; }
        public decimal SedAmount { get; set; }
        public int Unit_In_Case { get; set; }
        public decimal ExtraTax { get; set; }
        public decimal GSTPrice { get; set; }
        public decimal StandardDiscountByValue { get; set; }
        public decimal StandardDiscountPerValue { get; set; }
        public decimal SedAmountByValue { get; set; }
        public decimal SedAmountPerValue { get; set; }
        public decimal StandardDiscountByValueTo { get; set; }
        public decimal StandardDiscountByValueAd { get; set; }
        public decimal StandardDiscountPerValueTo { get; set; }
        public decimal StandardDiscountPerValueAd { get; set; }
        public decimal SedAmountByValueTo { get; set; }
        public decimal SedAmountByValueAD { get; set; }
        public decimal SedAmountPerValueTo { get; set; }
        public decimal SedAmountPerValueAd { get; set; }
    }

    public class OrderModal
    {
        public List<OrderDetail> OrderDetail { get; set; }
        public List<FreeSKU> FreeSKU { get; set; }
    }
}