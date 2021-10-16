using BotTelegramDB.Data.Interfaces;
using BotTelegramDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegramDB.Data.Repository
{
    public class ListGroupRepository : IListGroup
    {
       /// <summary>
       /// Метод добавления факультета в бд
       /// </summary>
       /// <param name="NameListGr">название факультета</param>
       /// <param name="userName"></param>
        public void AddListGroup(string NameListGr, int usrId)
        {
            TGBotContext tGBot = new TGBotContext();

            ListGroup listGroup = new ListGroup
            {
                NameGroupFromList = NameListGr
            };

            tGBot.ListGroups.Add(listGroup);

            tGBot.SaveChangesAsync();
        }
    }
}
