using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class ProgramSize
    {
        public ProgramSize()
        {
            Campaigns = new HashSet<Campaign>();
        }
        [Key]
        public int psId { get; set; }
        public string psName { get; set; } = null!;
        public string psDescription { get; set; } = null!;


        public ICollection<Campaign> Campaigns { get; set; } 
    }
}
