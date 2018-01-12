using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Project.Models
{
    public class Products
    {
        [Key]
        public int? ProductId { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }
        [Display(Name = "Price")]
        [Required]
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        public decimal ProductPrice { get; set; }
        [Display(Name = "Description")]
        public string ProductDescription { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Sub Category")]
        public int SubCategoryId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int? SchemeId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int? Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]

        public int? OrderQuantityDuringScheme { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int? OrderQuantityNoScheme { get; set; }



    }

    public class SubCategory
    {
        [Key]
        public int? SubCategoryId { get; set; }
        [Required]
        public string SubCategoryName { get; set; }
        [Display(Name = "Primary Category")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int PrimaryCategoryId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int? SchemeId { get; set; }
    }

    public class PrimaryCategory
    {
        [Key]
        public int? PrimaryCategoryId { get; set; }
        [Required]
        public string PrimaryCategoryName { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int? SchemeId { get; set; }

    }

    public class Schemes
    {
        [Key]
        public int? SchemeId { get; set; }
        [Required]
        public string SchemeName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Required]

        public string SchemeType { get; set; }
        [RegularExpression(@"^[1-3],([1-9],)+$",ErrorMessage = "enter SchemeLevel in interger seperated by comma(1,1,1,)")]
        public string SchemeLevel { get; set; }
    }
}