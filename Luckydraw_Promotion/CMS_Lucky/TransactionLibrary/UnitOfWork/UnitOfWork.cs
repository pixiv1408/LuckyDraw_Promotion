using Datactx.Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.Interface;
using TransactionLibrary.Repository;

namespace TransactionLibrary.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DatabaseContext _data;
        public UnitOfWork(DatabaseContext data)
        {
            _data = data;
            PositionRepo = new PositionRepo(_data);
            CustomerRepo = new CustomerRepo(_data);
            UserRepo = new UserRepo(_data);
            CharsetRepo = new CharsetRepo(_data);
            ProgramSizeRepo = new ProgramSizeRepo(_data);
            RepeatScheduleRepo = new RepeatScheduleRepo(_data);
            ScannedOrSpinRepo = new ScannedOrSpinRepo(_data);
            WinnerRepo = new WinnerRepo(_data);
            CampaignCodeGiftRepo = new CampaignCodeGiftRepo(_data);
            CampaignCodeRepo = new CampaignCodeRepo(_data);
        }

        public IPositionRepo PositionRepo { get; private set; }
        public ICustomerRepo CustomerRepo { get; private set; }
        public IUserRepo UserRepo { get; private set; } 
        public ICharsetRepo CharsetRepo { get; private set; }
        public IProgramSizeRepo ProgramSizeRepo { get; private set; }   
        public IWinnerRepo WinnerRepo { get; private set; }    
        public IRepeatScheduleRepo RepeatScheduleRepo { get; private set; }
        public IScannedOrSpinRepo ScannedOrSpinRepo { get; private set; }
        public ICampaignCodeRepo CampaignCodeRepo { get; private set; }
        public ICampaignCodeGiftRepo CampaignCodeGiftRepo { get; private set; }

        public void Dispose()
        {
            _data?.Dispose();
        }

        public void save()
        {
            _data.SaveChanges();

        }
    }
}
