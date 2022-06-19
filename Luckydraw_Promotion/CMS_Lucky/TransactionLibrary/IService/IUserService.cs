using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface IUserService
    {
        Task<List<UserDTO>> UserGetAll();
        Task<UserDTO> UserGetSingle(int id);
        Task<bool> UserInsert(UserDTO request);
        Task<bool> UserUpdate(UserDTO request);
        Task<bool> UserDelete(int id);
    }
}
