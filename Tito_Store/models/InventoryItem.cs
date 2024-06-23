using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tito_Store.models
{
    public class InventoryItem
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string? ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        //public virtual ICollection<Sale> Sales { get; set; }
        //public virtual ICollection<Return> Returns { get; set; }
    }
}
