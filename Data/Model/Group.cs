using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BotTelegramDB.Model
{
    public class Group
    {

        /// <summary>
        /// Ид Группы
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Название Группы
        /// </summary>
        public string NameGroup { get; set; }

        /// <summary>
        /// Название Факультета
        /// </summary>
        public string NameListGroup { get; set; }

        public List<UserInfo> UserInfos { get; set; }

        /// <summary>
        /// Внешний ключ на таблицу Факультет
        /// </summary>
        [ForeignKey("ListGroup")]
        [Column("ListGroupId")]
        public int LGId { get; set; }

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public virtual ListGroup ListGroup { get; set; }
    }
}
