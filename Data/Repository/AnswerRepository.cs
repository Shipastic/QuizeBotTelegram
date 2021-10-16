using BotTelegramDB.Data.Interface;
using BotTelegramDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegramDB.Data.Repository
{
    public class AnswerRepository : IAnswer
    {
        /// <summary>
        /// Метод получения правильного ответа
        /// </summary>
        /// <param name="numberQuestion">глмер вопроса</param>
        /// <returns></returns>
        public string GetISRightAnswer(int numberQuestion)
        {
            using (TGBotContext tGBot = new TGBotContext())
            {
                IQueryable<Answer> answers = tGBot.Answers;

                IQueryable<Question> questions = tGBot.Questions;

                var valueIsRightAnswer = answers
                                  .Where(a => a.NumQuest == a.Question.NumQuestion && a.Question.NumQuestion == numberQuestion && a.IsRight == true)
                                  .Select(q => q.Value)
                                  .FirstOrDefault();

                return valueIsRightAnswer;
            }
        }

        /// <summary>
        /// Метод получения списка ответов на вопрос
        /// </summary>
        /// <param name="numberQuestion">номер вопроса</param>
        /// <returns></returns>
        public List<string> GetValueAnswer(int numberQuestion)
        {
            using (TGBotContext tGBot = new TGBotContext())
            {
                IQueryable<Answer> answers = tGBot.Answers;

                IQueryable<Question> questions = tGBot.Questions;

                var valueAnswer = answers
                                  .Where(a => a.NumQuest == a.Question.NumQuestion && a.Question.NumQuestion == numberQuestion)
                                  .Select(q => q.Value)
                                  .ToList();
                return valueAnswer;
            }
        }
    }
}
