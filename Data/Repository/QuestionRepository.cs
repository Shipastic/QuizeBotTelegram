using BotTelegramDB.Data.Interfaces;
using BotTelegramDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegramDB.Data.Repository
{
    public class QuestionRepository : IQuestion
    {
        /// <summary>
        /// Метод получения количества вопросов
        /// </summary>
        /// <returns></returns>
        public int GetCountQuestions()
        {
            using (TGBotContext tGBot = new TGBotContext())
            {
                var countQuest = tGBot.Questions.Count();
                return countQuest;
            }
        }

        /// <summary>
        /// Метод для получения количества очков для конкретного вопроса
        /// </summary>
        /// <param name="numberQuestion">номер вопроса</param>
        /// <returns></returns>
        public int GetScore(int numberQuestion)
        {
            using (TGBotContext tGBot = new TGBotContext())
            {
                var getScore = tGBot
                    .Questions
                    .Where(q => q.NumQuestion == numberQuestion)
                    .Select(q => q.QuestionScore)
                    .SingleOrDefault();
                return getScore;
            }
        }

        /// <summary>
        /// Метод получения списка вопросов
        /// </summary>
        /// <returns></returns>
        public List<string> GetValueQuestion()
        {
            using (TGBotContext tGBot = new TGBotContext())
            {
                IQueryable<Question> questions = tGBot.Questions;

                var getValueQuest = questions
                                    .Select(q => q.Value)
                                    .ToList();

                return getValueQuest;
            }
        }
    }
}
