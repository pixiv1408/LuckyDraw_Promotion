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
    public class CampaignCodeService : ICampaignCodeService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public CampaignCodeService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> CampaignCodeDelete(int id)
        {
            if (await _unitOfWork.CampaignCodeRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.CampaignCodeRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<CampaignCodeDTO>> CampaignCodeGetAll()
        {
            var chargetall = await _unitOfWork.CampaignCodeRepo.GetAll();
            if (chargetall == null)
            {
                return null;
            }
            return _mapper.Map<List<CampaignCodeDTO>>(chargetall);
        }

        public async Task<CampaignCodeDTO> CampaignCodeGetSingle(int id)
        {
            var chargetsingle = await _unitOfWork.CampaignCodeRepo.GetById(id);
            if (chargetsingle == null)
            {
                return null;
            }
            return _mapper.Map<CampaignCodeDTO>(chargetsingle);
        }

        public async Task<bool> CampaignCodeInsert(CampaignCodeDTO request)
        {
            var check = await _unitOfWork.CampaignCodeRepo.Any(x => x.ccId == request.ccId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<CampaignCode>(request);
            _unitOfWork.CampaignCodeRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> CampaignCodeUpdate(CampaignCodeDTO request)
        {
            var check = await _unitOfWork.CampaignCodeRepo.GetById(request.ccId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.CampaignCodeRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
}
