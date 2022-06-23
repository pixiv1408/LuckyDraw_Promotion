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
    public class CampaignService : ICampaignService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public CampaignService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> CampaignDelete(int id)
        {
            if (await _unitOfWork.CampaignRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.CampaignRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<CampaignDTO>> CampaignGetAll()
        {
            var camgetall = await _unitOfWork.CampaignRepo.GetAll();
            if (camgetall == null)
            {
                return null;
            }
            return _mapper.Map<List<CampaignDTO>>(camgetall);
        }

        public async Task<CampaignDTO> CampaignGetSingle(int id)
        {
            var camsingle = await _unitOfWork.CampaignRepo.GetById(id);
            if (camsingle == null)
            {
                return null;
            }
            return _mapper.Map<CampaignDTO>(camsingle);
        }

        public async Task<bool> CampaignInsert(CampaignDTO request)
        {
            var check = await _unitOfWork.CampaignRepo.Any(x => x.camId == request.camId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<Campaign>(request);
            _unitOfWork.CampaignRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> CampaignUpdate(CampaignDTO request)
        {
            var check = await _unitOfWork.CampaignRepo.GetById(request.camId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.CampaignRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
}
