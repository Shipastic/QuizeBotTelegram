using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegramDB.Data.Interfaces
{
   public interface IListGroup
    {
        void AddListGroup(string NameListGr, int usrId);
    }
}
