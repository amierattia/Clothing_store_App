using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tito_Store.models
{
    public class OrderModels
    {
        [Key]
        public int? Id { get; set; }
        public string? OrderName { get; set; }
        public int? OrderQuntity { get; set; }

    }
}
