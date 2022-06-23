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
    public class RulesforgiftService : IRulesforgiftService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public RulesforgiftService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> RulesforgiftDelete(int id)
        {
            if (await _unitOfWork.RulesforgiftRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.RulesforgiftRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<RulesforgiftDTO>> RulesforgiftGetAll()
        {
            var rulegetall = await _unitOfWork.RulesforgiftRepo.GetAll();
            if (rulegetall == null)
            {
                return null;
            }
            return _mapper.Map<List<RulesforgiftDTO>>(rulegetall);
        }

        public async Task<RulesforgiftDTO> RulesforgiftGetSingle(int id)
        {
            var rulesingle = await _unitOfWork.RulesforgiftRepo.GetById(id);
            if (rulesingle == null)
            {
                return null;
            }
            return _mapper.Map<RulesforgiftDTO>(rulesingle);
        }

        public async Task<bool> RulesforgiftInsert(RulesforgiftDTO request)
        {
            var check = await _unitOfWork.RulesforgiftRepo.Any(x => x.ruleId == request.ruleId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<Rulesforgift>(request);
            _unitOfWork.RulesforgiftRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> RulesforgiftUpdate(RulesforgiftDTO request)
        {
            var check = await _unitOfWork.RulesforgiftRepo.GetById(request.ruleId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.RulesforgiftRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
}
