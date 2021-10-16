using System;
using System.Collections.Generic;
using System.Linq;

namespace BotTelegramDB.Model
{
    public class UserInfo
    {
       /// <summary>
       /// ИД Пользователя
       /// </summary>
        public int UserInfoID { get; set; }

        /// <summary>
        /// Номер пользователя
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Название группы для пользователя
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Сумма очков пользователя
        /// </summary>
        public int score { get; set; }


        /// <summary>
        /// Внешний ключ на таблицу Группа
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public virtual Group Group { get; set; }

    }
}
