using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class Customer
    {
        public Customer()
        {
            ScannedOrSpins = new HashSet<ScannedOrSpin>();
            Winners = new HashSet<Winner>();
        }
        [Key]
        public int cusId { get; set; }
        public string cusName { get; set; } = null!;
        public string cusPhone { get; set; } = null!;
        public string cusAddress { get; set; } = null!;
        public DateTime cusDoB { get; set; }
        public bool cusStatus { get; set; } = false;


        public int posId { get; set; }
        public Position Position { get; set; } = null!;
        public int userId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<ScannedOrSpin> ScannedOrSpins { get; set; }
        public ICollection<Winner> Winners { get; set; } 
    }
}
