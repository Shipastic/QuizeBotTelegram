using BotTelegramDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegramDB.Data.Interfaces
{
   public interface IUserInfo
    {
        int GEtMaxScoreUser(int userid);
        int AddUser(int scoreUser, int userid);
        List<UserInfo> GetLidersUser();
        void AddFIOUser(int userid, string SecondName, string FirstName, string userName);
        bool GetUserID(int idUser);

    }
}
