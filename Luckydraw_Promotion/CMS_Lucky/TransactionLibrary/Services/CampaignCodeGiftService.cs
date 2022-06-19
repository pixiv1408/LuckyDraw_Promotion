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
    public class CampaignCodeGiftService : ICampaignCodeGiftService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public CampaignCodeGiftService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> CampaignCodeGiftDelete(int id)
        {
            if (await _unitOfWork.CampaignCodeGiftRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.CampaignCodeGiftRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<CampaignCodeGiftDTO>> CampaignCodeGiftGetAll()
        {
            var ccggetall = await _unitOfWork.CampaignCodeGiftRepo.GetAll();
            if (ccggetall == null)
            {
                return null;
            }
            return _mapper.Map<List<CampaignCodeGiftDTO>>(ccggetall);
        }

        public async Task<CampaignCodeGiftDTO> CampaignCodeGiftGetSingle(int id)
        {
            var ccgsingle = await _unitOfWork.CampaignCodeGiftRepo.GetById(id);
            if (ccgsingle == null)
            {
                return null;
            }
            return _mapper.Map<CampaignCodeGiftDTO>(ccgsingle);
        }

        public async Task<bool> CampaignCodeGiftInsert(CampaignCodeGiftDTO request)
        {
            var check = await _unitOfWork.CampaignCodeGiftRepo.Any(x => x.cgcId == request.cgcId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<CampaignCodeGift>(request);
            _unitOfWork.CampaignCodeGiftRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> CampaignCodeGiftUpdate(CampaignCodeGiftDTO request)
        {
            var check = await _unitOfWork.CampaignCodeGiftRepo.GetById(request.cgcId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.CampaignCodeGiftRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
}
