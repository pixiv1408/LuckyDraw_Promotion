using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> CustomerGetAll();
        Task<CustomerDTO> CustomerGetSingle(int id);
        Task<bool> CustomerInsert(CustomerDTO request);
        Task<bool> CustomerUpdate(CustomerDTO request);
        Task<bool> CustomerDelete(int id);
    }
}
