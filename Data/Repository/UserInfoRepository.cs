using BotTelegramDB.Data.Interfaces;
using BotTelegramDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegramDB.Data.Repository
{
    public class UserInfoRepository : IUserInfo
    {
        /// <summary>
        /// Метод добавления пользователя
        /// </summary>
        /// <param name="userid">ID пользователя</param>
        /// <param name="SecondName">Фамилия</param>
        /// <param name="FirstName">Имя</param>
        /// <param name="userName">Логин</param>
        public void AddFIOUser(int userid, string SecondName, string FirstName, string userName)
        {
            UserInfo userInfo = new UserInfo();
            Group group = new Group();
            TGBotContext tGBot = new TGBotContext();

            //Если пользователь  с таким ИД уже есть в бд
            if (GetUserID(userid))
            {
                userInfo.UserID = tGBot
                                  .UserInfos
                                  .Where(u => u.UserID == userid)
                                  .Select(u => u.UserID)
                                  .Take(1)
                                  .SingleOrDefault();
                userInfo.UserName = tGBot
                                  .UserInfos
                                  .Where(u => u.UserID == userid)
                                  .Select(u => u.UserName)
                                  .Take(1)
                                  .SingleOrDefault();
                userInfo.LastName = tGBot
                                  .UserInfos
                                  .Where(u => u.UserID == userid)
                                  .Select(u => u.LastName)
                                  .Take(1)
                                  .SingleOrDefault();
                userInfo.FirstName = tGBot
                                  .UserInfos
                                  .Where(u => u.UserID == userid)
                                  .Select(u => u.FirstName)
                                  .Take(1)
                                  .SingleOrDefault();
                userInfo.GroupName = tGBot
                                  .UserInfos
                                  .Where(u => u.UserID == userid)
                                  .Select(u => u.GroupName)
                                  .Take(1)
                                  .SingleOrDefault();
                userInfo.GroupId = tGBot
                                  .UserInfos
                                  .Where(u => u.UserID == userid)
                                  .Select(u => u.GroupId)
                                  .Take(1)
                                  .SingleOrDefault();
                userInfo.score = 0;
            }
            else
            {
                userInfo.UserID = userid;
                userInfo.UserName = userName;
                userInfo.LastName = SecondName;
                userInfo.FirstName = FirstName;
                userInfo.GroupName = tGBot
                                   .Groups
                                   .OrderByDescending(g => g.GroupId)
                                   .Select(g => g.NameGroup)
                                   .Take(1)
                                   .SingleOrDefault();
                userInfo.GroupId = tGBot
                                   .Groups
                                    .OrderByDescending(g => g.GroupId)
                                   .Select(g => g.GroupId)
                                   .Take(1)
                                   .SingleOrDefault();
                userInfo.score = 0;
            }
            tGBot.UserInfos.Add(userInfo);
            tGBot.SaveChangesAsync();
        }

        /// <summary>
        /// Метод добавления пользователя
        /// </summary>
        /// <param name="scoreUser">количество очков</param>
        /// <param name="userid">ИД пользователя</param>
        /// <returns></returns>
        public int AddUser(int scoreUser, int userid)
        {
            Group group = new Group();
            TGBotContext tGBot = new TGBotContext();

            UserInfo userInfo = tGBot.UserInfos
                                     .Where(u => u.UserID == userid)
                                     .Take(1)
                                     .FirstOrDefault();

            if (GetUserID(userid))
            {
                userInfo.score = scoreUser;
            }

            tGBot.UserInfos.Add(userInfo);
            tGBot.SaveChangesAsync();
            return scoreUser;
        }

        /// <summary>
        /// Метод получения списка лидеров по очкам
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetLidersUser()
        {
            UserInfo userInfo = new UserInfo();

            using (TGBotContext tGBot = new TGBotContext())
            {
                var userLider = tGBot
                               .UserInfos
                               .OrderByDescending(u => u.score)
                               .Take(3)
                               .ToList();
                return userLider;
            }
        }

        /// <summary>
        /// Метод получения максимальной суммы набранных очков для пользователя
        /// </summary>
        /// <param name="userid">ID пользователя</param>
        /// <returns></returns>
        public int GEtMaxScoreUser(int userid)
        {
            using (TGBotContext tGBot = new TGBotContext())
            {
                var MaxScore = tGBot
                    .UserInfos
                    .Where(u => u.UserID == userid)
                    .Max(u => (int?)u.score) ?? 0;

                return MaxScore;
            }
        }

        /// <summary>
        /// Метод проверки наличия пользователя с переданным ИД
        /// </summary>
        /// <param name="idUser">ID пользователя</param>
        /// <returns></returns>
        public bool GetUserID(int idUser)
        {
            List<int> ArrayUserId = new List<int>();
            Boolean flag = false;
            UserInfo userInfo = new UserInfo();
            TGBotContext tGBot = new TGBotContext();
            var item = tGBot
                       .UserInfos
                       .Select(u => u.UserID)
                       .ToList();
            tGBot.SaveChangesAsync();
            foreach (var element in item)
            {
                if (element == idUser)
                {
                    flag = true;
                    break;
                }
            }
            tGBot.SaveChangesAsync();
            return flag;
        }
    }
}
