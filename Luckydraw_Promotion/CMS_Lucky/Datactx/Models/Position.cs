using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int posId { get; set; }
        public string posName { get; set; } = null!;

        public ICollection<Customer> Customers { get; set; } 
    }
}
