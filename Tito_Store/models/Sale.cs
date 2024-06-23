using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tito_Store.models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public string? ProductName { get; set; }



        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public int QuantitySold { get; set; }


    }
}
