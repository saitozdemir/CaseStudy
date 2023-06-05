using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        //[Required(ErrorMessage = "Bu alanı girmek zorunludur!")]
        //[StringLength(35, MinimumLength = 2, ErrorMessage = "En az 2 en fazla 35 karakter girebilirsin!")]
        public string ProductName { get; set; }
        //[MaxLength(500, ErrorMessage = "En fazla 500 karakter girebilirsin!")]
        public string ProductStatement { get; set; }
        //[MinLength(0, ErrorMessage = "Lütfen geçerli bir sayı giriniz!")]
        public decimal ProductPrice { get; set; }
        //[Required(ErrorMessage = "Bu alanı girmek zorunludur!")]
        //[MinLength(0, ErrorMessage = "Lütfen geçerli bir sayı giriniz!")]
        public int StockPiece { get; set; }

    }
}