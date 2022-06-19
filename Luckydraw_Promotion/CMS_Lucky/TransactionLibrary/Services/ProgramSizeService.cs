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
    public class ProgramSizeService : IProgramSizeService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public ProgramSizeService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> ProgramSizeDelete(int id)
        {
            if (await _unitOfWork.ProgramSizeRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.ProgramSizeRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<ProgramSizeDTO>> ProgramSizeGetAll()
        {
            var psgetall = await _unitOfWork.ProgramSizeRepo.GetAll();
            if (psgetall == null)
            {
                return null;
            }
            return _mapper.Map<List<ProgramSizeDTO>>(psgetall);
        }

        public async Task<ProgramSizeDTO> ProgramSizeGetSingle(int id)
        {
            var pssingle = await _unitOfWork.ProgramSizeRepo.GetById(id);
            if (pssingle == null)
            {
                return null;
            }
            return _mapper.Map<ProgramSizeDTO>(pssingle);
        }

        public async Task<bool> ProgramSizeInsert(ProgramSizeDTO request)
        {
            var check = await _unitOfWork.ProgramSizeRepo.Any(x => x.psId == request.psId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<ProgramSize>(request);
            _unitOfWork.ProgramSizeRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public  async Task<bool> ProgramSizeUpdate(ProgramSizeDTO request)
        {
            var check = await _unitOfWork.ProgramSizeRepo.GetById(request.psId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.ProgramSizeRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
}
