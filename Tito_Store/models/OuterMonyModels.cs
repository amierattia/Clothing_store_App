using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tito_Store.models
{
    public class OuterMonyModels
    {
        [Key]
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public string? ProductName { get; set; }
        public decimal? outerPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
