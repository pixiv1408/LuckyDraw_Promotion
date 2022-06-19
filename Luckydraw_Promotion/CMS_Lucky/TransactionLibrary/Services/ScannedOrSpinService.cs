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
    public class ScannedOrSpinService : IScannedOrSpinService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public ScannedOrSpinService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> SosDelete(int id)
        {
            if (await _unitOfWork.ScannedOrSpinRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.ScannedOrSpinRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<ScannedOrSpinDTO>> SosGetAll()
        {
            var sosgetall = await _unitOfWork.ScannedOrSpinRepo.GetAll();
            if (sosgetall == null)
            {
                return null;
            }
            return _mapper.Map<List<ScannedOrSpinDTO>>(sosgetall);
        }

        public async Task<ScannedOrSpinDTO> SosGetSingle(int id)
        {
            var sossingle = await _unitOfWork.ScannedOrSpinRepo.GetById(id);
            if (sossingle == null)
            {
                return null;
            }
            return _mapper.Map<ScannedOrSpinDTO>(sossingle);
        }

        public async Task<bool> SosInsert(ScannedOrSpinDTO request)
        {
            var check = await _unitOfWork.ScannedOrSpinRepo.Any(x => x.sosId == request.sosId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<ScannedOrSpin>(request);
            _unitOfWork.ScannedOrSpinRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> SosUpdate(ScannedOrSpinDTO request)
        {
            var check = await _unitOfWork.ScannedOrSpinRepo.GetById(request.sosId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.ScannedOrSpinRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
    
}
