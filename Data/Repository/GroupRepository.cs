using BotTelegramDB.Data.Interfaces;
using BotTelegramDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegramDB.Data.Repository
{
    public class GroupRepository : IGroup
    {
       /// <summary>
       /// Метод добавления группы в бд
       /// </summary>
       /// <param name="_NameGroup">название группы</param>
       /// <param name="_nameListGroup">название факультета</param>
        public void AddGroup(string _NameGroup, string _nameListGroup)
        {
            TGBotContext tGBot = new TGBotContext();

            Group group = new Group
            {
                NameGroup = _NameGroup,


                LGId = tGBot
                        .ListGroups
                        .OrderByDescending(g => g.LGId)
                        .Select(g => g.LGId)
                        .Take(1)
                        .SingleOrDefault(),

                NameListGroup = _nameListGroup
            };

            tGBot.Groups.Add(group);

            tGBot.SaveChangesAsync();
        }
    }
}
