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
            //
            this.CreateMap<RepeatScheduleDTO, RepeatScheduleRP>();
            this.CreateMap<RepeatSchedule, RepeatScheduleDTO>();
            this.CreateMap<RepeatScheduleDTO, RepeatSchedule>();
            //
            this.CreateMap<ScannedOrSpinDTO, ScannedOrSpinRP>();
            this.CreateMap<ScannedOrSpin, ScannedOrSpinDTO>();
            this.CreateMap<ScannedOrSpinDTO, ScannedOrSpin>();
            //
            this.CreateMap<WinnerDTO, WinnerRP>();
            this.CreateMap<Winner, WinnerDTO>();
            this.CreateMap<WinnerDTO, Winner>();
            //
            this.CreateMap<CampaignCodeDTO, CampaignCodeRP>();
            this.CreateMap<CampaignCode, CampaignCodeDTO>();
            this.CreateMap<CampaignCodeDTO, CampaignCode>();
            //
            this.CreateMap<CampaignCodeGiftDTO, CampaignCodeGiftRP>();
            this.CreateMap<CampaignCodeGift, CampaignCodeGiftDTO>();
            this.CreateMap<CampaignCodeGiftDTO, CampaignCodeGift>();
        }
    }
}
