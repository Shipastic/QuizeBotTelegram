using BotTelegramDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegramDB.Data.Interfaces
{
   public interface IQuestion
    {
        int GetCountQuestions();

        int GetScore(int numberQuestion);

        List<string> GetValueQuestion();

    }
}
