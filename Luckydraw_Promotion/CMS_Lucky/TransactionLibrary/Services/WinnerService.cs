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
    public class WinnerService : IWinnerService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public WinnerService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> WinnerDelete(int id)
        {
            if (await _unitOfWork.WinnerRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.WinnerRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<WinnerDTO>> WinnerGetAll()
        {
            var wingetall = await _unitOfWork.WinnerRepo.GetAll();
            if (wingetall == null)
            {
                return null;
            }
            return _mapper.Map<List<WinnerDTO>>(wingetall);
        }

        public async Task<WinnerDTO> WinnerGetSingle(int id)
        {
            var winsingle = await _unitOfWork.WinnerRepo.GetById(id);
            if (winsingle == null)
            {
                return null;
            }
            return _mapper.Map<WinnerDTO>(winsingle);
        }

        public async Task<bool> WinnerInsert(WinnerDTO request)
        {
            var check = await _unitOfWork.WinnerRepo.Any(x => x.winId == request.winId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<Winner>(request);
            _unitOfWork.WinnerRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> WinnerUpdate(WinnerDTO request)
        {
            var check = await _unitOfWork.WinnerRepo.GetById(request.winId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.WinnerRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
    
}
