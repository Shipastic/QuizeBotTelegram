using System.Collections.Generic;
using System.Linq;

namespace BotTelegramDB.Model
{
    public class Question
    {
        /// <summary>
        /// ИД Вопроса
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Номер вопроса
        /// </summary>
        public int NumQuestion { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Количество очков за вопрос
        /// </summary>
        public int QuestionScore { get; set; }

        /// <summary>
        /// Содержит список ответов
        /// </summary>
        public List<Answer> Answers { get; set; }

    }
}
