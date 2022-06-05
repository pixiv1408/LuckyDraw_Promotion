using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class Charset
    {
        public Charset()
        {
            Campaigns = new HashSet<Campaign>();
        }

        [Key]
        public int charId { get; set; }
        public string charName { get; set; } = null!;
        public string charValue { get; set; } = null!;

        public ICollection<Campaign> Campaigns { get; set; } 

    }
}
