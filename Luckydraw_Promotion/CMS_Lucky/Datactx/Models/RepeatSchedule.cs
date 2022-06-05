using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class RepeatSchedule
    {
        public RepeatSchedule()
        {
            Rulesforgifts = new HashSet<Rulesforgift>();
        }
        [Key]
        public int repeatId { get; set; }
        public string repeatName { get; set; } = null!;



        public ICollection<Rulesforgift> Rulesforgifts { get; set; }
    }
}
