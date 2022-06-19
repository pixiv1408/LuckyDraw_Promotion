using AutoMapper;
using Datactx.Models;
using TransactionLibrary.DTO;
using TransactionLibrary.Response;

namespace CMS_Lucky.Mapper
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            this.CreateMap<PositionDTO, PositionRP>();
            this.CreateMap<Position, PositionDTO>();
            this.CreateMap<PositionDTO, Position>();
            //
            this.CreateMap<CustomerDTO, CustomerRP>(); 
            this.CreateMap<Customer, CustomerDTO>();
            this.CreateMap<CustomerDTO, Customer>();
            //
            this.CreateMap<UserDTO, UserRP>();
            this.CreateMap<User, UserDTO>();
            this.CreateMap<UserDTO, User>();
            //
            this.CreateMap<CharsetDTO, CharsetRP>();
            this.CreateMap<Charset, CharsetDTO>();
            this.CreateMap<CharsetDTO, Charset>(); 
            //
            this.CreateMap<ProgramSizeDTO, ProgramSizeRP>();
            this.CreateMap<ProgramSize, ProgramSizeDTO>();
            this.CreateMap<ProgramSizeDTO, ProgramSize>();
        }
    }
}
