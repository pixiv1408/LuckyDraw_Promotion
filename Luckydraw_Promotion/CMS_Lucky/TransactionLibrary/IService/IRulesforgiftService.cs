using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface IRulesforgiftService
    {
        Task<List<RulesforgiftDTO>> RulesforgiftGetAll();
        Task<RulesforgiftDTO> RulesforgiftGetSingle(int id);
        Task<bool> RulesforgiftInsert(RulesforgiftDTO request);
        Task<bool> RulesforgiftUpdate(RulesforgiftDTO request);
        Task<bool> RulesforgiftDelete(int id);
    }
}
