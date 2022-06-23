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
    public class CampGiftService : ICampGiftService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public CampGiftService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> CampGiftDelete(int id)
        {
            if (await _unitOfWork.CampGiftRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.CampGiftRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<CampGiftDTO>> CampGiftGetAll()
        {
            var camggetall = await _unitOfWork.CampGiftRepo.GetAll();
            if (camggetall == null)
            {
                return null;
            }
            return _mapper.Map<List<CampGiftDTO>>(camggetall);
        }

        public async Task<CampGiftDTO> CampGiftGetSingle(int id)
        {
            var camgsingle = await _unitOfWork.CampGiftRepo.GetById(id);
            if (camgsingle == null)
            {
                return null;
            }
            return _mapper.Map<CampGiftDTO>(camgsingle);
        }

        public async Task<bool> CampGiftInsert(CampGiftDTO request)
        {
            var check = await _unitOfWork.CampGiftRepo.Any(x => x.camId == request.camId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<CampGift>(request);
            _unitOfWork.CampGiftRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> CampGiftUpdate(CampGiftDTO request)
        {
            var check = await _unitOfWork.CampGiftRepo.GetById(request.camId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.CampGiftRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
}
