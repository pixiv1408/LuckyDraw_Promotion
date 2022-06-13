using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;
using TransactionLibrary.IService;

namespace TransactionLibrary.Services
{
    public class PositionService : IPositionService
    {
        public Task<bool> PositionDelete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PositionDTO>> PositionGetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PositionDTO> PositionGetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PositionInsert(PositionDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PositionUpdate(PositionDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
