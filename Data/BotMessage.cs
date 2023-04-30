using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegramDB
{
    
    /// <summary>
    /// Класс Сообщение
    /// </summary>
    public class BotMessage
    {
        public bool ok { get; set; }
        public Result[] result { get; set; }
    }

    /// <summary>
    /// Класс Result 
    /// </summary>
    public class Result
    {
        //ид последнего обновления
        public int update_id { get; set; }

        //информация по сообщению
        public Message message { get; set; }
        public Callback_Query callback_query { get; set; }
    }

    /// <summary>
    /// Объект сообщение
    /// </summary>
    public class Message
    {
        public int message_id { get; set; }
        public From from { get; set; }
        public Chat chat { get; set; }
        public int date { get; set; }
        public string text { get; set; }
    }

    /// <summary>
    /// Объект Входящий запрос от Инлайн-Кнопки
    /// </summary>
    public class Callback_Query
    {
        public string id { get; set; }
        public From from { get; set; }
        public Message message { get; set; }
        public string chat_instance { get; set; }
        public string data { get; set; }
    }
    public class From
    {
        public int id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string language_code { get; set; }
    }

    /// <summary>
    /// Объект Чат
    /// </summary>
    public class Chat
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string type { get; set; }
    }

}
