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
    public class GiftService : IGiftService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public GiftService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> GiftDelete(int id)
        {
            if (await _unitOfWork.GiftRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.GiftRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<GiftDTO>> GiftGetAll()
        {
            var giftgetall = await _unitOfWork.GiftRepo.GetAll();
            if (giftgetall == null)
            {
                return null;
            }
            return _mapper.Map<List<GiftDTO>>(giftgetall);
        }

        public async Task<GiftDTO> GiftGetSingle(int id)
        {
            var giftsingle = await _unitOfWork.GiftRepo.GetById(id);
            if (giftsingle == null)
            {
                return null;
            }
            return _mapper.Map<GiftDTO>(giftsingle);
        }

        public async Task<bool> GiftInsert(GiftDTO request)
        {
            var check = await _unitOfWork.GiftRepo.Any(x => x.giftId == request.giftId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<Gift>(request);
            _unitOfWork.GiftRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> GiftUpdate(GiftDTO request)
        {
            var check = await _unitOfWork.GiftRepo.GetById(request.giftId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.GiftRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
}
