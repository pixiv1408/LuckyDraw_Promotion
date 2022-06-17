using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class Position
    {
        public Position()
        {
            Customers = new HashSet<Customer>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int posId { get; set; }
        public string? posName { get; set; }

        public ICollection<Customer> Customers { get; set; } 
    }
}
