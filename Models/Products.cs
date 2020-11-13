using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IGSService.Models
{
    public class Products
    {
       
        [Key]
        [Required]
        [Display(Name = "id")]
        public int ProductCode { get; set; }
                
        [Display(Name = "name")]
        public string Name { get; set; }
        
        [Display(Name = "price")]
        public double Price { get; set; }

    }
}
