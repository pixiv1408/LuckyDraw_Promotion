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
    public class CharsetService : ICharsetService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public CharsetService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> CharsetDelete(int id)
        {
            if (await _unitOfWork.CharsetRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.CharsetRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<CharsetDTO>> CharsetGetAll()
        {
            var chargetall = await _unitOfWork.CharsetRepo.GetAll();
            if (chargetall == null)
            {
                return null;
            }
            return _mapper.Map<List<CharsetDTO>>(chargetall);
        }

        public async Task<CharsetDTO> CharsetGetSingle(int id)
        {
            var chargetsingle = await _unitOfWork.CharsetRepo.GetById(id);
            if (chargetsingle == null)
            {
                return null;
            }
            return _mapper.Map<CharsetDTO>(chargetsingle);
        }

        public async Task<bool> CharsetInsert(CharsetDTO request)
        {
            var check = await _unitOfWork.CharsetRepo.Any(x => x.charId == request.charId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<Charset>(request);
            _unitOfWork.CharsetRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> CharsetUpdate(CharsetDTO request)
        {
            var check = await _unitOfWork.CharsetRepo.GetById(request.charId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.CharsetRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
}
