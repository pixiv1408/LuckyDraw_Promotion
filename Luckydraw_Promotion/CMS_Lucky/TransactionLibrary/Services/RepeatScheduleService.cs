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
    public class RepeatScheduleService : IRepeatScheduleService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public RepeatScheduleService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> ResDelete(int id)
        {
            if (await _unitOfWork.RepeatScheduleRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.RepeatScheduleRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<RepeatScheduleDTO>> ResGetAll()
        {
            var resgetall = await _unitOfWork.RepeatScheduleRepo.GetAll();
            if (resgetall == null)
            {
                return null;
            }
            return _mapper.Map<List<RepeatScheduleDTO>>(resgetall);
        }

        public async Task<RepeatScheduleDTO> ResGetSingle(int id)
        {
            var ressingle = await _unitOfWork.RepeatScheduleRepo.GetById(id);
            if (ressingle == null)
            {
                return null;
            }
            return _mapper.Map<RepeatScheduleDTO>(ressingle);
        }

        public async Task<bool> ResInsert(RepeatScheduleDTO request)
        {
            var check = await _unitOfWork.RepeatScheduleRepo.Any(x => x.repeatId == request.repeatId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<RepeatSchedule>(request);
            _unitOfWork.RepeatScheduleRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> ResUpdate(RepeatScheduleDTO request)
        {
            var check = await _unitOfWork.RepeatScheduleRepo.GetById(request.repeatId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.RepeatScheduleRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
    
}
