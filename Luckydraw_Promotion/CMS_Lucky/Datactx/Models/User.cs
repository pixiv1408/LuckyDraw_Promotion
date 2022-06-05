using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Datactx.Models
{

    public class User
    {
        public User()
        {
            Customers = new HashSet<Customer>();
        }
        [Key]
        public int userId { get; set; }
        public string userEmail { get; set; } = null!;
        public string userPassword { get; set; } = null!;
        public ICollection<Customer> Customers { get; set; }
    }
}
