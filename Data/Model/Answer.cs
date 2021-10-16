using BotTelegramDB.Data.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BotTelegramDB.Model
{
    public class Answer
    {
        /// <summary>
        /// Идентификатор Ответа
        /// </summary>
        public int AnswerId { get; set; }

        /// <summary>
        /// Номер вопроса
        /// </summary>
        public int NumQuest { get; set; }

        /// <summary>
        /// Текст ответа
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Флаг правильности ответа
        /// </summary>
        public bool IsRight { get; set; }

        /// <summary>
        /// Внешний ключ на сущность Вопросы
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public virtual Question Question { get; set; }
    }
}
