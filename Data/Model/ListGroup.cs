using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotTelegramDB.Model
{
    public class ListGroup
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        [Column("ListGroupId")]
        public int LGId { get; set; }

        /// <summary>
        /// Название Факультета
        /// </summary>
        public string NameGroupFromList { get; set; }

        /// <summary>
        /// Список групп в факультете
        /// </summary>
        public List<Group> Groups { get; set; }
    }
}
