using BotTelegramDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegramDB.Data.Interface
{
   public interface IAnswer
    {
        /// <summary>
        /// Получение списка ответов
        /// </summary>
        /// <param name="numberQuestion">номер вопроса</param>
        /// <returns></returns>
        List<string> GetValueAnswer(int numberQuestion);

       /// <summary>
       /// Получение правильного ответа для вопроса
       /// </summary>
       /// <param name="numberQuestion">номер вопроса</param>
       /// <returns></returns>
        string GetISRightAnswer(int numberQuestion);
    }
}
