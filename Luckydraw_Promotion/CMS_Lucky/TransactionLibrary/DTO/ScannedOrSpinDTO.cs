using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.DTO
{
    public class ScannedOrSpinDTO
    {
        public int sosId { get; set; }
        public DateTime? scannedDate { get; set; }
        public DateTime? spinDate { get; set; }
        public int ccId { get; set; }
        public int cusId { get; set; }
    }
}
