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
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> UserDelete(int id)
        {
            if (await _unitOfWork.UserRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.UserRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<UserDTO>> UserGetAll()
        {
            var usertgetall = await _unitOfWork.UserRepo.GetAll();
            if (usertgetall == null)
            {
                return null;
            }
            return _mapper.Map<List<UserDTO>>(usertgetall);
        }

        public async Task<UserDTO> UserGetSingle(int id)
        {
            var usergetsingle = await _unitOfWork.UserRepo.GetById(id);
            if (usergetsingle == null)
            {
                return null;
            }
            return _mapper.Map<UserDTO>(usergetsingle);
        }

        public async Task<bool> UserInsert(UserDTO request)
        {
            var check = await _unitOfWork.UserRepo.Any(x => x.userId == request.userId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<User>(request);
            _unitOfWork.UserRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> UserUpdate(UserDTO request)
        {
            var check = await _unitOfWork.UserRepo.GetById(request.userId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.UserRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
}
