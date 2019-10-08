using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixedAssetsWebApp.Models
{
    public class Assets
    {
        // Class properties
        [Key]
        public int AssetID { get; set; }

        [Required(ErrorMessage = "Please provide asset description")]
        [StringLength(50)]
        [Display(Name = "Description")]
        public string AssetDescription { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Tax code")]
        [Required(ErrorMessage = "Please enter asset tax code. For example, 1 - software, 3 - short equipment (phone, data storage)," +
            "5 - furniture, 12 - computer, 8 - machine (mirowave, fridge, etc). " +
            "For more information, plea visit https://propertytax.utah.gov/personal/classification-guide")]
        public int TaxClassification { get; set; }

        [Display(Name = "Service Date")]
        public DateTime ServiceDate { get; set; }

        public string Quantity { get; set; }

        [Display(Name = "Asset Cost")]
        public double Cost { get; set; }

        [Display(Name = "Asset Location")]
        public string Location { get; set; }

        [Display(Name = "Tag number")]
        public string TagNubmer { get; set; }

        [Display(Name = "Serial number")]
        public string SerialNumber { get; set; }

        [Display(Name = "Asset status")]
        public string Status { get; set; }

        [Display(Name = "Department")]
        public string Department { get; set; }

        [Display(Name = "Invoice Number")]
        public string Invoice { get; set; }

        [Display(Name = "Purchase Order")]
        public string PO { get; set; }

        [Display(Name = "Vendor Name")]
        public string Vendor { get; set; }
    }
}