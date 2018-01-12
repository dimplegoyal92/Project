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
        public decimal ProductPrice { get; set; }
        [Display(Name = "Description")]
        public string ProductDescription { get; set; }
        [Required]
        [Display(Name = "Sub Category")]
        public int SubCategoryId { get; set; }
        public int? SchemeId { get; set; }
        public int? Quantity { get; set; }

        public int? OrderQuantityDuringScheme { get; set; }
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
        public int PrimaryCategoryId { get; set; }
        public int? SchemeId { get; set; }
    }

    public class PrimaryCategory
    {
        [Key]
        public int? PrimaryCategoryId { get; set; }
        [Required]
        public string PrimaryCategoryName { get; set; }
        public int? SchemeId { get; set; }

    }

    public class Schemes
    {
        [Key]
        public int? SchemeId { get; set; }
        [Required]
        public string SchemeName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]

        public string SchemeType { get; set; }
        public List<int> SchemeLevel { get; set; }
    }
}