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
        }
    }
}
