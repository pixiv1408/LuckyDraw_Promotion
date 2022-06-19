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
    public class CustomerService : ICustomerService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        public CustomerService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<bool> CustomerDelete(int id)
        {
            if (await _unitOfWork.PositionRepo.GetById(id) == null)
            {
                return false;
            }
            _unitOfWork.PositionRepo.Delete(id);
            _unitOfWork.save();
            return true;
        }

        public async Task<List<CustomerDTO>> CustomerGetAll()
        {
            var Custgetall = await _unitOfWork.CustomerRepo.GetAll();
            if (Custgetall == null)
            {
                return null;
            }
            return _mapper.Map<List<CustomerDTO>>(Custgetall);
        }

        public async Task<CustomerDTO> CustomerGetSingle(int id)
        {
            var Custgetsingle = await _unitOfWork.CustomerRepo.GetById(id);
            if (Custgetsingle == null)
            {
                return null;
            }
            return _mapper.Map<CustomerDTO>(Custgetsingle);
        }

        public async Task<bool> CustomerInsert(CustomerDTO request)
        {
            var check = await _unitOfWork.CustomerRepo.Any(x => x.cusId == request.cusId);
            if (check)
            {
                return false;
            }
            var obj = _mapper.Map<Customer>(request);
            _unitOfWork.CustomerRepo.Insert(obj);
            _unitOfWork.save();
            return true;
        }

        public async Task<bool> CustomerUpdate(CustomerDTO request)
        {
            var check = await _unitOfWork.CustomerRepo.GetById(request.cusId);
            if (check == null)
            {
                return false;
            }
            _mapper.Map(request, check);
            _unitOfWork.CustomerRepo.Update(check);
            _unitOfWork.save();
            return true;
        }
    }
}
