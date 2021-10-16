using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegramDB
{
    public class BotButtons
    {
        public List<List<KeyboardButtom>> Keyboard { get; set; }

        public bool One_time_keyboard { get; set; }
        public BotButtons(List<List<KeyboardButtom>> keysInput, bool OneTimeKeyboard = true)
        {
            Keyboard = keysInput;

            One_time_keyboard = OneTimeKeyboard;
        }

        public string RetReplyMarkup()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// Класс обычной кнопки
    /// </summary>
    public class KeyboardButtom
    {
        /// <summary>
        /// Текст кнопки
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// Контакты пользователя
        /// </summary>
        public bool request_contact { get; set; }
        /// <summary>
        /// Местоположение пользователя
        /// </summary>
        public bool request_location { get; set; }
        /// <summary>
        /// Конструктор класса кнопки
        /// </summary>
        /// <param name="_text">Текст кнопки</param>
        /// <param name="_request_contact">Контакты пользователя</param>
        /// <param name="_request_location">Местоположение пользователя</param>
        public KeyboardButtom(string _text, bool _request_contact = false, bool _request_location = false)
        {
            text = _text;
            request_contact = _request_contact;
            request_location = _request_location;
        }
    }

    public class RemoveButtons
    {
        public bool Remove_keyboard { get; set; }
        public RemoveButtons()
        {
            Remove_keyboard = true;
        }
    }

    /// <summary>
    /// Класс инлайн-кнопки
    /// </summary>
    public class InlineKeyboard
    {
        /// <summary>
        /// Создаем массив массивов инлайн-кнопок
        /// </summary>
        public List<List<InlineKeyboardButton>> inline_keyboard { get; set; }

        public InlineKeyboard(List<List<InlineKeyboardButton>> inInlineKeyboard)
        {
            inline_keyboard = inInlineKeyboard;
        }

        /// <summary>
        /// Конструктор массива инлайн-кнопок
        /// </summary>
        public InlineKeyboard()
        {
            inline_keyboard = new List<List<InlineKeyboardButton>>();
        }

        /// <summary>
        /// Длбавить кнопку
        /// </summary>
        /// <param name="button"></param>
        public void AddButton(InlineKeyboardButton button)
        {
            inline_keyboard.Add(new List<InlineKeyboardButton> { button });
        }

        /// <summary>
        /// Метод для добавления кнопок на другую строку
        /// </summary>
        /// <param name="button">кнопка</param>
        /// <param name="NumLine">номер строки для кнопки</param>
        public void AddButton(InlineKeyboardButton button, int NumLine)
        {
            //Пока не дошли до нужной строки добавляем пустые кнопки
            while (inline_keyboard.Count <= NumLine)
            {
                inline_keyboard.Add(new List<InlineKeyboardButton>());
            }
            //Добавляем кнопку на нужную строку(начинаются с 0)
            inline_keyboard[NumLine].Add(button);
        }

        /// <summary>
        /// Добавление кнопок на линию
        /// </summary>
        public void AddLineButtons(List<InlineKeyboardButton> inlines)
        {
            inline_keyboard.Add(inlines);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class InlineKeyboardButton
    {
        /// <summary>
        /// Текст на кнопке
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Коллбек-данные, передаваемые в запросе боту
        /// </summary>
        public string callback_data { get; set; }


        /// <summary>
        /// Конструктор инлайн-кнопки
        /// </summary>
        /// <param name="_text">текст на кнопке</param>
        /// <param name="_callback_data">данные для обработки ботом, по умолчанию используется тоже, что и в поле текст</param>
        public InlineKeyboardButton(string _text, string _callback_data = "")
        {
            text = _text;

            callback_data = _callback_data == "" ? _text : _callback_data;
        }
    }
}
