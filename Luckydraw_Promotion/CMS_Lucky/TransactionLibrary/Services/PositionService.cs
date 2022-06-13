using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;
using TransactionLibrary.Interface;
using TransactionLibrary.IService;

namespace TransactionLibrary.Services
{
    public class PositionService : IPositionService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public PositionService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;    
        }
        public Task<bool> PositionDelete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PositionDTO>> PositionGetAll()
        {
            var positionMap = await _unitOfWork.PositionRepo.GetAll();
            if (positionMap == null)
            {
                return null;
            }
            return _mapper.Map<List<PositionDTO>>(positionMap);
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
