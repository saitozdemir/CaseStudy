using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebbApi.Controllers;

namespace CaseStudy.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        //[Required(ErrorMessage = "Bu alanı girmek zorunludur!")]
        //[MinLength(1, ErrorMessage = "Lütfen geçerli bir sayı giriniz!")]
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        public List<Clients> Clients { get; set; }
        public List<Products> Products { get; set; }

    }
}