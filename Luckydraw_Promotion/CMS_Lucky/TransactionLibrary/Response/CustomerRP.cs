using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.Response
{
    public class CustomerRP
    {
        public int cusId { get; set; }
        public string cusName { get; set; }
        public string? cusPhone { get; set; }
        public string? cusAddress { get; set; }
        public DateTime? cusDoB { get; set; }
        public bool? cusStatus { get; set; }
        public int posId { get; set; }
        public int userId { get; set; }
    }
}
