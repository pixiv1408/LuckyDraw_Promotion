using AutoMapper;
using Datactx.Models;
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
        public async Task<bool> PositionDelete(int id)
        {
            if (await _unitOfWork.PositionRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.PositionRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<PositionDTO>> PositionGetAll()
        {
            var positgetall = await _unitOfWork.PositionRepo.GetAll();
            if (positgetall == null)
            {
                return null;
            }
            return _mapper.Map<List<PositionDTO>>(positgetall);
        }

        public async Task<PositionDTO> PositionGetSingle(int id)
        {
            var positgetsingle = await _unitOfWork.PositionRepo.GetById(id);
            if (positgetsingle == null) { return null; }
            return _mapper.Map<PositionDTO>(positgetsingle);
        }

        public async Task<bool> PositionInsert(PositionDTO request)
        {
            var check = await _unitOfWork.PositionRepo.Any(x => x.posId == request.posId);
            if (check) { return false; }
            var obj = _mapper.Map<Position>(request);
            _unitOfWork.PositionRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> PositionUpdate(PositionDTO request)
        {
            var check = await _unitOfWork.PositionRepo.GetById(request.posId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.PositionRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
}
