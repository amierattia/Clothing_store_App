using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tito_Store.models
{
    public class Return
    {
        [Key]
        public int ReturnId { get; set; }

        [Required]
        public string? ReturnName { get; set; }

        [Required]
        public int? QuantityReturned { get; set; }

        public DateTime ReturnDate { get; set; }

       
    }
}
