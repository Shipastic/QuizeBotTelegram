using BotTelegramDB.Data.Repository;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BotTelegramDB.Model
{

    /// <summary>
    /// Хранение состояний бота
    /// </summary>
    enum StateBot
    {
        wait, //ожидание
        send  //отправка
    }

    /// <summary>
    /// Класс настройки бота
    /// </summary>
   public class BotClass
    {
        /// <summary>
        /// токен
        /// </summary>
        readonly string token = "YOU TOKEN HERE";

        /// <summary>
        /// Адресс API Telegramm
        /// </summary>
        readonly string BaseUrl = "https://api.telegram.org/bot";

        /// <summary>
        /// Номер последнего обновления
        /// </summary>
        int LastUpdateID = 0;

        /// <summary>
        /// Экземпляр класса ВэбКлиента
        /// </summary>
        WebClient client;

        /// <summary>
        /// Экземпляр класса TextBox
        /// </summary>
        TextBox logTxt;

        /// <summary>
        /// Экземпляр класса Question
        /// </summary>
        Question question = new Question();
        QuestionRepository questionRepository = new QuestionRepository();
        /// <summary>
        /// Экземпляр класса Logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Счетчик вопросов
        /// </summary>
        int NumberQuestion = 1;

        /// <summary>
        /// Флаг использования подсказки компьютера
        /// </summary>
        bool trg = false;

        /// <summary>
        /// Флаг использования подсказки 50/50
        /// </summary>
        bool trgFifFif = false;

        StateBot stateBot;

        /// <summary>
        /// Конструктор Бота
        /// </summary>
        /// <param name="textBox">Текстовое поле</param>
        public BotClass(TextBox textBox)
        {
            logTxt = textBox;           

            Init();

            if(logger == null)
            {
                logger = LogManager.GetCurrentClassLogger();
            }
        }       
        /// <summary>
        /// Метод инициализации
        /// </summary>
        private void Init()
        {
           client = new WebClient();

           stateBot = StateBot.wait;

        }

        /// <summary>
        /// Создаем список который будет содержать все ответы
        /// </summary>
        List<string> correctAnswer = new List<string>();

        /// <summary>
        /// Список, который будет содержать правильные ответы
        /// </summary>
        List<string> resultAnswer = new List<string>();

        /// <summary>
        /// Переменная для хранения суммы очков
        /// </summary>
        int sumScoreUser = 0;

        /// <summary>
        /// Метод обработки нажатия инлайн-кнопки
        /// </summary>
        /// <param name="item">Массив данных</param>
        /// <param name="chatID">ИД чаиа</param>
        private void AnswerIsMessage(Result item, int chatID)
        {
            try
            {
                if (chatID == item.message.chat.id)
                {
                    logger.Info(message: $"Сообщение {item.message.text} От {item.message.from.username}");

                    WriteLog(item.message.text, item.message.from.id);

                    if (item.message.text != null)
                    {
                        SendAnswer(item.message.chat.id, item.message.text, item);
                    }
                }
                else
                {
                    MessageBox.Show("Chat not found");
                }
            }
            catch(Exception e)
            {
                logger.Error(e, e.Message);
                throw;
            }
        }

        /// <summary>
        /// Метод отправки введенного текста
        /// </summary>
        /// <param name="message">введенное сообщение</param>
        private void SendMessageToAdmin(string message)
        {
            //1134205187 - жестко закодировано ИД, нужно бы реализовать времени нет 
            SendMessageTo(1134205187, message);
        }

        /// <summary>
        /// Метод получения обновлений
        /// </summary>
        public void GetUpdates()
        {
            using (WebClient client = new WebClient() { Encoding = Encoding.UTF8 })
            {
                //Формирование строки для получения обновлений(getUpdates - метод для получения входящих обновлений, offset - идентификатор первого возвращаемого обновления)
                string address = BaseUrl + token + "/getUpdates?offset=" + (LastUpdateID + 1);

                //Строка, загруженная с помощью webClient и содержащая всю информацию, полученную по адресу- address
                string str = client.DownloadString(address);

                //Десериализуем сообщение в Json формат
                BotMessage botMessage = JsonConvert.DeserializeObject<BotMessage>(str);

                From from = JsonConvert.DeserializeObject<From>(str);

                Chat chat = JsonConvert.DeserializeObject<Chat>(str);

                try
                {
                    //Чтобы offset не проверялся за пределами допустимого
                    if (!botMessage.ok || botMessage.result.Length == 0)
                        return;

                    foreach (Result item in botMessage.result)
                    {
                        //Устанавливаем переменной значение последнего обновления
                        LastUpdateID = item.update_id;

                        //Если это сообщение и оно не пустое
                        if (item.message != null)
                        {
                            AnswerIsMessage(item, item.message.chat.id);
                        }
                        else
                            //Если это коллбек-запрос и он не пустой
                            if (item.callback_query != null)
                        {
                            AnswerIsCallbackQueryAsync(item, item.callback_query.message.chat.id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, ex.Message);
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Кнопки помощи в игре
        /// </summary>
        /// <param name="keyboard">клавиатура в которую передаем кнопки</param>
        private void AddHelpButtons(InlineKeyboard keyboard)
        {
            List<InlineKeyboardButton> line = new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("\ud83d\udcbb Подсказка компьютера", "prompt"),
                new InlineKeyboardButton("\u2702\ufe0f 50/50" , "fifty_fifty")
            };
            keyboard.AddLineButtons(line);
        }

        private void AddHelpButtonPrompt(InlineKeyboard keyboard)
        {
            List<InlineKeyboardButton> line = new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("\ud83d\udcbb Подсказка компьютера", "prompt")
            };
            keyboard.AddLineButtons(line);
        }


        private void AddHelpButtonFifty(InlineKeyboard keyboard)
        {
            List<InlineKeyboardButton> line = new List<InlineKeyboardButton>()
            {
                 new InlineKeyboardButton("\u2702\ufe0f 50/50" , "fifty_fifty")
            };
            keyboard.AddLineButtons(line);
        }
        /// <summary>
        /// Метод добавления кнопки Закончить
        /// </summary>
        /// <param name="keyboard"></param>
        private void AddBreakButton(InlineKeyboard keyboard)
        {
            List<InlineKeyboardButton> buttons = new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("\ud83c\udfc1 Закончить попытку", "breakButton")
            };
            keyboard.AddLineButtons(buttons);
        }
        
        /// <summary>
        /// Метод добавления кнопки Статистики
        /// </summary>
        /// <param name="keyboard">текущая клавиатура</param>
        private void AddScoreButtons(InlineKeyboard keyboard)
        {
            List<InlineKeyboardButton> line = new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("Узнать статистику", "raiting")
            };
            keyboard.AddLineButtons(line);
        }

        /// <summary>
        /// Метод добавления кнопки Назад
        /// </summary>
        /// <param name="keyboard"></param>
        private void AddBackButtons(InlineKeyboard keyboard)
        {
            List<InlineKeyboardButton> line = new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("\u2b05\ufe0f Назад", "back")
            };
            keyboard.AddLineButtons(line);
        }

        /// <summary>
        /// Метод обработки выбора ответа пользователя
        /// </summary>
        /// <param name="item"></param>
         private void AnswerIsCallbackQueryAsync(Result item, int chatID)
        {
            logger.Info(message: $"Ответ на коллбек-кнопки");
            WriteLog(item.callback_query.data, item.callback_query.message.from.id);

            string replyMarkup = "";
            try
            {
                if (chatID == item.callback_query.message.chat.id)
                {
                    string answer;
                    switch (item.callback_query.data.ToLower())
                    {
                        //Выбрана подсказка 50/50
                        case "fifty_fifty":
                            answer = DeleteTwoAnswer(item.callback_query.message.chat.id, out replyMarkup, trgFifFif);
                            trgFifFif = true;
                            return;

                        //Выбрана подсказка Помощь компьютера
                        case "prompt":
                            answer = AnswerToPrompt(item.callback_query.message.chat.id, item.callback_query.data, out replyMarkup, resultAnswer[NumberQuestion - 1], trg);
                            trg = true;
                            return;

                        //Выбран пункт Рейтинг пользователей
                        case "raiting":
                            answer = UserScore(item, out replyMarkup, item.callback_query.message.chat.id);
                            replyMarkup = null;
                            break;

                        case "back":
                            answer = "\u2611\ufe0f В начало -->:/start\n";
                            SendMessageTo(item.callback_query.message.chat.id, answer, replyMarkup);
                            replyMarkup = null;
                            return;

                        case "breakbutton":

                            replyMarkup = "";

                            int scoreUser = 0;

                            UserInfoRepository userInfoRepository = new UserInfoRepository();

                            scoreUser = userInfoRepository.AddUser(sumScoreUser, item.callback_query.from.id);

                            answer = $"\ud83e\uddee Вы набрали {scoreUser} очков";

                            InlineKeyboard keyboard2 = new InlineKeyboard();

                            AddBackButtons(keyboard2);

                            replyMarkup = JsonConvert.SerializeObject(keyboard2);
                            SendMessageTo(item.callback_query.message.chat.id, answer, replyMarkup);
                            replyMarkup = null;
                            return;

                        default:
                            answer = AnswerToQuestions(item.callback_query.message.chat.id, item.callback_query.data, out replyMarkup, resultAnswer[NumberQuestion - 1]);
                            if (NumberQuestion < questionRepository.GetCountQuestions())
                            {
                                NumberQuestion++;
                                QuizDB(item.callback_query.message.chat.id, replyMarkup);
                                break;
                            }
                            else
                            {
                                InlineKeyboard keyboard = new InlineKeyboard();
                                AddScoreButtons(keyboard);
                                replyMarkup = JsonConvert.SerializeObject(keyboard);
                                SendMessageTo(item.callback_query.message.chat.id, "Закончились вопросы", replyMarkup);
                                replyMarkup = null;
                                NumberQuestion = 0;
                                break;
                            }
                    }
                    answer += Environment.NewLine + item.callback_query.data;

                    ChangeMessage(item, answer, replyMarkup);
                }
                else
                {
                    MessageBox.Show("ChatID not Found");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Метод подсчета количества очков за ответ
        /// </summary>
        /// <param name="numberquest">номер вопроса</param>
        /// <param name="sumscore___">сумма набранных очков</param>
        /// <returns></returns>
        int GetScoreAnswerAsync(int numberquest, int sumscore___)
        {
            return GetScoreAnswer(NumberQuestion, sumScoreUser);
        }

        /// <summary>
        /// Метод подсчета количества очков за ответ
        /// </summary>
        /// <param name="numberquest">номер вопроса</param>
        /// <param name="sumscore___">сумма очков</param>
        /// <returns></returns>
       private int GetScoreAnswer(int numberquest, int sumscore___)
        {
            QuestionRepository questionRepository1 = new QuestionRepository();
            sumscore___ += questionRepository1.GetScore(numberquest);

            return sumscore___;       
        }

        /// <summary>
        /// Метод для вывода рейтинга пользователя
        /// </summary>
        /// <param name="item"></param>
        /// <param name="replyMarkup"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GetRaiting(int userid)
        {
            UserInfoRepository userInfoRepository = new UserInfoRepository();

            return userInfoRepository.GEtMaxScoreUser(userid).ToString();
        }

        /// <summary>
        /// Метод вывода суммы очков пользователя
        /// </summary>
        /// <param name="item"></param>
        /// <param name="replyMarkup"></param>
        /// <returns></returns>
        /// 
        private string UserScore(Result item, out string replyMarkup, int chatID)
        {
            try
            {
                string answer = "";

                replyMarkup = "";

                int scoreUser = 0;
                if (chatID == item.callback_query.message.chat.id)
                {
                    UserInfoRepository userInfoRepository = new UserInfoRepository();

                    switch (item.callback_query.data)
                    {
                        case "raiting":

                            scoreUser = userInfoRepository.AddUser(sumScoreUser, item.callback_query.from.id);

                            answer = $"\ud83e\uddee Вы набрали {scoreUser} очков";

                            InlineKeyboard keyboard = new InlineKeyboard();

                            AddBackButtons(keyboard);

                            replyMarkup = JsonConvert.SerializeObject(keyboard);

                            SendMessageTo(item.callback_query.message.chat.id, answer, replyMarkup);

                            break;

                        default:
                            break;
                    }

                    replyMarkup = null;

                    return replyMarkup;
                }
                else
                {
                    logger.Warn("Неверный подсчет очков!");
                    return null;
                }
            }
            catch(Exception e)
            {
                logger.Error(e, e.Message);
                throw;
            }
        }
     
        /// <summary>
        /// Метод для вычисляющий правильность ответа и сумму очков
        /// </summary>
        /// <param name="chat_id"></param>
        /// <param name="ValueCurrentAnswer">ответ выбранный пользователем</param>
        /// <param name="corrAnswer">правильный ответ</param>
        /// <returns></returns>
        private string AnswerToQuestions(int chat_id, string ValueCurrentAnswer,  out string replyMarkup, string corrAnswer)
        {
            replyMarkup = "";

            //Нужна была для отладки, подсчет символов в строке с правильным ответом
            int lenVal = ValueCurrentAnswer.Length;

            //Если ответ правильный, то пересчитаем сумму очков, первые 4 символа - эмодзи
            if (ValueCurrentAnswer.Substring(4) == corrAnswer)
                {
                    SendMessageTo(chat_id, "\u2705 Это правильный ответ!");

                    sumScoreUser =GetScoreAnswerAsync(NumberQuestion, sumScoreUser);
                }

                else
                {
                    SendMessageTo(chat_id, "\ud83d\udeab  Ответ неверный");
                }

            return replyMarkup;
        }

         private  string DeleteTwoAnswer(int chat_id, out string replyMarkup,bool trig_flsg)
        {
            replyMarkup = "";
            
            if (trgFifFif == false )
            {
                Random rnd = new Random();
                int value = rnd.Next(0, 3);
                int i = 0;
                InlineKeyboard keyboard = new InlineKeyboard();
                List<string> _resultAnswer = new List<string>(); ;
                List<string> _correctAnswer = new List<string>(); ;
                //Answer answer = new Answer();
                AnswerRepository answerRepository = new AnswerRepository();
             
                if (answerRepository.GetISRightAnswer(NumberQuestion).Length > 0)
                {             
                        _resultAnswer.Add(answerRepository.GetISRightAnswer(NumberQuestion));
                }             

                if (answerRepository.GetValueAnswer(NumberQuestion).Count > 0)
                {
                    foreach (var it in answerRepository.GetValueAnswer(NumberQuestion))
                    {
                        _correctAnswer.Add(it);
                    }
                }

                string[] icons = new string[] { "1\ufe0f\u20e3", "2\ufe0f\u20e3", "3\ufe0f\u20e3", "4\ufe0f\u20e3" };
                for (int cnt = 0; cnt < _correctAnswer.Count; cnt++)
                {
                    if (_correctAnswer[cnt].Equals(_resultAnswer[0]))
                        continue;
                    else
                    {
                        keyboard.AddButton(new InlineKeyboardButton(icons[cnt] + " " + _correctAnswer[cnt]), i++ / 2);
                        break;
                    }
                        
                }
                keyboard.AddButton(new InlineKeyboardButton(icons[value] + " " + _resultAnswer[0]), i++ / 2);
                replyMarkup = JsonConvert.SerializeObject(keyboard);

                SendMessageTo(chat_id, "\ud83d\udd0a  \u27a1\ufe0f <b> Варианты ответов </b> \u2b05\ufe0f  \ud83d\udd0a", replyMarkup);

                replyMarkup = null;

                _correctAnswer.Clear();

            }
            else
            {
                SendMessageTo(chat_id, $"\u261d\ufe0f Вы уже использовали подсказку!");
                NumberQuestion--;

            }
            return replyMarkup;
        }

        /// <summary>
        /// Метод обработки Подсказки компьютера
        /// </summary>
        /// <param name="chat_id"></param>
        /// <param name="ValueCurrentAnswer">ответ пользователя</param>
        /// <param name="corrAnswer">правильный ответ</param>
        /// <param name="trig_flsg">флаг состояния использования подсказки</param>
        /// <returns></returns>
        private string AnswerToPrompt(int chat_id, string ValueCurrentAnswer, out string replyMarkup, string corrAnswer, bool trig_flsg)
        {
            replyMarkup = "";
            int lenVal = ValueCurrentAnswer.Length;
            
            if (ValueCurrentAnswer == "prompt" && trig_flsg == false)
            {
                SendMessageTo(chat_id, $"\u2757\ufe0f \ud83d\udcbb Компьютер уверен, что правильный ответ: {corrAnswer}");
            }
            else
                if(trig_flsg == true)
            {
                SendMessageTo(chat_id, $"\u261d\ufe0f Вы уже использовали подсказку!");
            }         
            return replyMarkup;
        }

        /// <summary>
        /// Метод записи в текстовое поле и в лог-файл
        /// </summary>
        /// <param name="text">отправленное сообщение</param>
        /// <param name="idUser">ИД пользователя</param>
        private void WriteLog(string text, int idUser)
        {
         logTxt.Text += DateTime.Now + $"  {idUser} {text} {Environment.NewLine}";
         logger.Info(logTxt.Text);
        }

        /// <summary>
        /// Вывод меню для выбора
        /// </summary>
        /// <param name="chat_id"></param>
        /// <param name="message"></param>
        private void SendAnswer(int chat_id, string message, Result item)
        {
            string replyMarkup = "";
            string answer;
            if (stateBot == StateBot.send)
            {
                SendMessageToAdmin(chat_id + ":\n " + message);
                answer = "\ud83d\udc4c Ваше сообщение отправлено";

                //Парсинг данных, полученных от пользователя
                stateBot = StateBot.wait;

                //Формируем массив стро, разбиваем по пробелу
                string[] dataUser = message.Split(' ');

                //Дальше добавляем данные в таблицы

                ListGroupRepository listGroupRepository = new ListGroupRepository();
                listGroupRepository.AddListGroup(dataUser[2], item.message.from.id);

                GroupRepository groupRepository = new GroupRepository();
                groupRepository.AddGroup(dataUser[3], dataUser[2]);

                UserInfoRepository userInfoRepository = new UserInfoRepository();
                userInfoRepository.AddFIOUser(item.message.from.id, dataUser[0], dataUser[1], item.message.from.username);
            }
            else
            {
                switch (message.ToLower())
                {
                    case "/start":
                        answer =
                            "\ud83d\udcac Приветствую тебя! \ud83d\udd14 \n\n" +
                            "\u2611\ufe0f Заполнить информацию о себе \ud83d\udcdd--->:/about_myself\n" +
                            "\u2611\ufe0f Запустить викторину \ud83d\udd79-------------------->:/begin\n" +
                            "\u2611\ufe0f Рейтинг пользователей \ud83c\udfc6--------------->:/raiting\n" +
                            "\u2611\ufe0f Личный рейтинг \ud83d\udc51-------------------------->:/stat\n";
                        break;

                    case "/begin":
                        logger.Info(message: "Начало викторины");
                        //Обнуляем использование подсазок
                        trgFifFif = false;
                        trg = false;
                        NumberQuestion = 1;

                        answer =
                            QuizDB(chat_id, replyMarkup);
                        return;

                    case "/raiting":
                        answer =
                            "\ud83d\udc4f \ud83d\udc4f \ud83d\udc4f \ud83d\udc4f \ud83d\udc4f \ud83d\udc4f \n";

                        replyMarkup = GetLiderUsers(item);
                        break;

                    case "/stat":
                        answer = "\ud83c\udfc6 Ваш максимальный рейтинг равен: " + GetRaiting(item.message.from.id);
                        replyMarkup = null;
                        break;

                    case "/about_myself":
                        UserInfo userInfo = new UserInfo();
                        UserInfoRepository userInfoRepository = new UserInfoRepository();
                        if (userInfoRepository.GetUserID(item.message.from.id))
                        {
                            answer = "\u2757\ufe0f Пользователь с данным ИД уже существует в БД \nВсе личные данные будут взяты из ранее заполненных \n\n" +
                                     "\u2611\ufe0f Запустить викторину \ud83d\udd79-------------------->:/begin\n" +
                                     "\u2611\ufe0f Рейтинг пользователей \ud83c\udfc6--------------->:/raiting\n" +
                                     "\u2611\ufe0f Личный рейтинг \ud83d\udc51-------------------------->:/stat\n";
                        }
                        else
                        {
                            answer = "\u2755 Введите фамилию, имя, название факультета(например ИТ) и учебной группы(ИСз-118) через пробелы:";
                            stateBot = StateBot.send;
                        }

                        break;

                    default:
                        answer =
                                "\u2757\ufe0f Не знаю такой команды: " + message + "\n\n" +
                                "\u2611\ufe0f Заполнить информацию о себе \ud83d\udcdd--->:/about_myself\n" +
                                "\u2611\ufe0f Запустить викторину \ud83d\udd79-------------------->:/begin\n" +
                                "\u2611\ufe0f Рейтинг пользователей \ud83c\udfc6--------------->:/raiting\n" +
                                "\u2611\ufe0f Личный рейтинг \ud83d\udc51-------------------------->:/stat\n";

                        break;
                }
            }
            SendMessageTo(chat_id: chat_id, answer, replyMarkup);
        }

        /// <summary>
        /// Метод для изменения сообщения
        /// </summary>
        /// <param name="item">Массив данных</param>
        /// <param name="message">текст сообщения</param>
        /// <param name="replyMarkup"></param>
        private void ChangeMessage(Result item, string message, string replyMarkup = "")
        {
            try
            {
                Uri uri = new Uri($"{BaseUrl}{token}/editMessageText");

                NameValueCollection nameValueCollection = new NameValueCollection
                {
                    { "chat_id", item.callback_query.message.chat.id.ToString() },

                    { "message_id", item.callback_query.message.message_id.ToString() },

                    { "text", message },

                    { "parse_mode", "HTML" }
                };

                if (replyMarkup != "")
                {
                    nameValueCollection.Add("reply_markup", replyMarkup);
                }
                using (var client = new WebClient())
                {
                    client.UploadValues(uri, nameValueCollection);
                }
            }
            catch(Exception e)
            {
                logger.Error(e);
                throw;
            }
        }
 
        /// <summary>
        /// Метод обработки и отправки сообщения в чат
        /// </summary>
        /// <param name="chat_id"></param>
        /// <param name="textMessage"></param>
        /// <param name="replyMarkup"></param>
        private  void SendMessageTo(int chat_id, string textMessage, string replyMarkup = "")
        {
            try
            {
                Uri uri = new Uri($"{BaseUrl}{token}/sendMessage");

                NameValueCollection valueCollection = new NameValueCollection
                {
                    { "chat_id", chat_id.ToString() },

                    { "text", textMessage },

                    { "parse_mode", "HTML" }
                };

                if (replyMarkup != "")
                {
                    valueCollection.Add("reply_markup", replyMarkup);
                }
                using (var client = new WebClient())
                {
                    client.UploadValuesAsync(uri, valueCollection);
                }
            }
            catch(Exception e)
            {
               logger.Error(e);
               throw;
            }
        }       

        /// <summary>
        /// Метод, содержащий логику работы викторины
        /// </summary>
        /// <param name="chat_id">ИД чата</param>
        /// <returns>Возвращает текст на выбранной кнопке</returns>
        private  string QuizDB(int chat_id, string replyMarkup)
        {
            QuestionRepository questionRepository1 = new QuestionRepository();
            questionRepository1.GetValueQuestion();

            //Создаем экземпляры клавиатур
            InlineKeyboard keyboard = new InlineKeyboard();

            replyMarkup = JsonConvert.SerializeObject(keyboard);
            
            int i = 0;

            string QuestMessage = "";

            InsertAnswerFromKeyboard(chat_id, ref replyMarkup, questionRepository1.GetValueQuestion(), resultAnswer, correctAnswer, ref keyboard, ref i, questionRepository1.GetCountQuestions(), ref QuestMessage, NumberQuestion);

            return replyMarkup;
        }


        /// <summary>
        /// Метод формирования кнопок викторины
        /// </summary>
        /// <param name="chat_id"></param>
        /// <param name="replyMarkup"></param>
        /// <param name="countQuestion"></param>
        /// <param name="resultAnswer"></param>
        /// <param name="correctAnswer"></param>
        /// <param name="keyboard"></param>
        /// <param name="i"></param>
        /// <param name="CountQuestions"></param>
        /// <param name="QuestMessage"></param>
        /// <param name="item"></param>
        /// <param name="NumberQuestion"></param>
        private void InsertAnswerFromKeyboard(int chat_id, ref string replyMarkup, List<string> countQuestion, List<string> resultAnswer, List<string> correctAnswer, ref InlineKeyboard keyboard, ref int i, int CountQuestions, ref string QuestMessage, int NumberQuestion)
        {

            //Получаем очередной вопрос
           QuestMessage = $"\u2754<i> {countQuestion[NumberQuestion-1]} </i>";

           SendMessageTo(chat_id, QuestMessage, replyMarkup);

           AnswerRepository answerRepository = new AnswerRepository();

            if (answerRepository.GetISRightAnswer(NumberQuestion).Length > 0)
            {
                    resultAnswer.Add(answerRepository.GetISRightAnswer(NumberQuestion));
            }

            //Добавляем в список варианты ответов
            if (answerRepository.GetValueAnswer(NumberQuestion).Count > 0)
            {
                foreach (var it in answerRepository.GetValueAnswer(NumberQuestion))
                {
                    correctAnswer.Add(it);
                }
            }

            string[] icons = new string[] { "1\ufe0f\u20e3", "2\ufe0f\u20e3", "3\ufe0f\u20e3", "4\ufe0f\u20e3" };

            for (int cnt = 0; cnt < correctAnswer.Count; cnt++)
            {
                keyboard.AddButton(new InlineKeyboardButton(icons[cnt] + " " + correctAnswer[cnt]), i++ / 2);

            }

            if (trgFifFif == true && trg == false)
            {
                AddHelpButtonPrompt(keyboard);
            }
            else
                if (trgFifFif == false && trg == true)
            {
                AddHelpButtonFifty(keyboard);
            }
            else
                if (trgFifFif == false && trg == false)
            {
                AddHelpButtons(keyboard);
            }

            AddBreakButton(keyboard);

            replyMarkup = JsonConvert.SerializeObject(keyboard);

            SendMessageTo(chat_id, "\ud83d\udd0a \ud83d\udd0a \u27a1\ufe0f \u27a1\ufe0f<b> Варианты ответов </b>\u2b05\ufe0f \u2b05\ufe0f \ud83d\udd0a \ud83d\udd0a", replyMarkup);

            keyboard = new InlineKeyboard();

            replyMarkup = null;

            correctAnswer.Clear();
        }

        /// <summary>
        /// Метод вывода списка лидеров
        /// </summary>
        /// <param name="chat_id"></param>
        /// <param name="mess"></param>
        /// <param name="replyMarkup"></param>
        private string GetLiderUsers(Result item)
        {
            List<string> oneUser = new List<string>();

            UserInfoRepository userInfoRepository = new UserInfoRepository();
            string replyMarkup = "";

            string answer = $"\ud83d\udc51 Список лидеров \ud83d\udc51";
            SendMessageTo(item.message.chat.id, answer, replyMarkup);

            string[] liderIcon = new string[] { "\ud83e\udd47", "\ud83e\udd48", "\ud83e\udd49" };

            foreach (var user in userInfoRepository.GetLidersUser())
            {
                oneUser.Add( $"{user.FirstName} {user.LastName} гр. {user.GroupName} --> {user.score } очков \ud83d\udccc\n");              
            }
            for (int i = 0; i < oneUser.Count; i++)
            {
                SendMessageTo(item.message.chat.id, liderIcon[i] + oneUser[i], replyMarkup);

            }
            return replyMarkup;
        }
    }
}
