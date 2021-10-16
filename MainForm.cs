using BotTelegramDB.Model;
using NLog;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace BotTelegramDB
{
    public partial class MainForm : Form
    {
        BotClass botClass;
        TGBotContext tGBot;
        BackgroundWorker bwr;
        private static Logger logger;
        public MainForm()
        {
            InitializeComponent();

            bwr = new BackgroundWorker();
            bwr.DoWork += Bwr_Dowork;

            Init();
            try
            {
                tGBot = new TGBotContext();

                tGBot.Questions.Load();
                tGBot.Answers.Load();
                tGBot.UserInfos.Load();
                tGBot.Groups.Load();
                tGBot.ListGroups.Load();
                // tGBot.TGBOTLOGs.Load();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неполадки при подключении к БД!!");
                logger.Error(ex);
            }
            dataQuestions.DataSource = tGBot.Questions.Local.ToBindingList();
            dataAnswers.DataSource = tGBot.Answers.Local.ToBindingList();
            dataUserInfo.DataSource = tGBot.UserInfos.Local.ToBindingList();
            dataGroup.DataSource = tGBot.Groups.Local.ToBindingList();
            dataListGroup.DataSource = tGBot.ListGroups.Local.ToBindingList();

            dataQuestions.Columns[0].HeaderText = "ID вопроса";
            dataQuestions.Columns[1].HeaderText = "Номер вопроса";
            dataQuestions.Columns[2].HeaderText = "Текст вопроса";
            dataQuestions.Columns[3].HeaderText = "Количество очков";

            dataAnswers.Columns[0].HeaderText = "ID Ответа";
            dataAnswers.Columns[1].HeaderText = "Номер вопроса";
            dataAnswers.Columns[2].HeaderText = "Варианты ответов";
            dataAnswers.Columns[3].HeaderText = "Выбор правильного ответа";
            dataAnswers.Columns[4].HeaderText = "ID вопроса";
            dataAnswers.Columns[5].Visible = false;

            dataUserInfo.Columns[0].HeaderText = "Номер Пользователя в таблице";
            dataUserInfo.Columns[1].HeaderText = "ИД Пользователя в Телеграм";
            dataUserInfo.Columns[2].HeaderText = "Логин в Телеграм(при наличии)";
            dataUserInfo.Columns[3].HeaderText = "Имя";
            dataUserInfo.Columns[4].HeaderText = "Фамилия";
            dataUserInfo.Columns[5].HeaderText = "Группа";
            dataUserInfo.Columns[6].HeaderText = "Набранные очки";
            dataUserInfo.Columns[7].HeaderText = "ID Группы";
            dataUserInfo.Columns[8].Visible = false;
            //dataUserInfo.Columns[1].Visible = false;

            dataGroup.Columns[0].HeaderText = "ID Группы";
            dataGroup.Columns[1].HeaderText = "Название Группы";
            dataGroup.Columns[2].HeaderText = "Название факультета";
            dataGroup.Columns[3].Visible = false;
            dataGroup.Columns[4].Visible = false;

            dataListGroup.Columns[0].HeaderText = "ID факультета";
            dataListGroup.Columns[1].HeaderText = "Название факультета";
        }

        private void Bwr_Dowork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
        }

        private void Init()
        {
            botClass = new BotClass(textBoxLog);
            //if (bwr.IsBusy != true)
            //{
            //    bwr.RunWorkerAsync();
            //}
            //Запуска таймера
            timerUpdates.Enabled = true;
        }

        /// <summary>
        /// Метод для зауска в таймере получение обновлений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUpdates_Tick(object sender, EventArgs e)
        {
            try
            {
                //  ThreadStart threadStart = new ThreadStart(botClass.GetUpdates);
                botClass.GetUpdates();
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Ошибка:{ex.Data} \nТекст: {ex.Message}\r\n");
            }

        }

        /// <summary>
        /// Обработчик кнопки добавить вопрос
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButAddQuestions_Click(object sender, EventArgs e)
        {
            QuestionsForm qForm = new QuestionsForm();

            DialogResult result = qForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            try
            {
                Question question = new Question
                {
                    NumQuestion = Int32.Parse(qForm.textIdQuest.Text),
                    Value = qForm.textBoxQuestiomValue.Text,
                    QuestionScore = Int32.Parse(qForm.textBoxquestionScore.Text)
                };

                tGBot.Questions.Add(question);
                await tGBot.SaveChangesAsync();
                MessageBox.Show("Вопрос добавлен");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show($"Ошибка при добавлении вопроса, повторите ввод!");
            }
        }

        /// <summary>
        /// Обработчик кнопки изменить вопрос
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void ButChangeQuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataQuestions.SelectedRows.Count > 0)
                {
                    int index = dataQuestions.SelectedRows[0].Index;
                    bool converted = Int32.TryParse(dataQuestions[0, index].Value.ToString(), out int id);
                    if (converted == false)
                        return;

                    Question question = tGBot.Questions.Find(id);

                    QuestionsForm qForm = new QuestionsForm();

                    qForm.textIdQuest.Text = question.NumQuestion.ToString();
                    qForm.textBoxQuestiomValue.Text = question.Value;
                    qForm.textBoxquestionScore.Text = question.QuestionScore.ToString();

                    DialogResult result = qForm.ShowDialog(this);

                    if (result == DialogResult.Cancel)
                        return;

                    question.NumQuestion = Int32.Parse(qForm.textIdQuest.Text);
                    question.Value = qForm.textBoxQuestiomValue.Text;
                    question.QuestionScore = Int32.Parse(qForm.textBoxquestionScore.Text);

                    await tGBot.SaveChangesAsync();
                    dataQuestions.Refresh(); // обновляем грид
                    MessageBox.Show("Вопросы обновлены");
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Ошибка при редактировании вопроса!");
            }
        }

        /// <summary>
        /// Обработчик кнопки удалить вопрос
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void ButDeleteQuestions_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataQuestions.SelectedRows.Count > 0)
                {
                    int index = dataQuestions.SelectedRows[0].Index;
                    bool converted = Int32.TryParse(dataQuestions[0, index].Value.ToString(), out int id);
                    if (converted == false)
                        return;

                    Question question = tGBot.Questions.Find(id);
                    tGBot.Questions.Remove(question);
                    await tGBot.SaveChangesAsync();

                    MessageBox.Show("Вопрос удален");
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки добавить ответ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void ButAddAnswer_Click(object sender, EventArgs e)
        {
            AnswersForm aForm = new AnswersForm();

            DialogResult result = aForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            try
            {
                //QuestionsForm qForm = new QuestionsForm();
                Answer answer = new Answer
                {
                    QuestionId = Int32.Parse(aForm.textBoxIDQuest.Text),
                    NumQuest = Int32.Parse(aForm.texidQuest.Text),
                    Value = aForm.textAnswerValue.Text,
                    IsRight = bool.Parse(aForm.comboBoxIsRight.SelectedItem.ToString())
                };

                tGBot.Answers.Add(answer);
                await tGBot.SaveChangesAsync();
                MessageBox.Show("Ответ добавлен");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Ошибка при добавлении ответа, повторите ввод!!!");
            }
        }

        /// <summary>
        /// Обработчик кнопки Изменить Ответ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void ButChangeAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataAnswers.SelectedRows.Count > 0)
                {
                    int index = dataAnswers.SelectedRows[0].Index;
                    bool converted = Int32.TryParse(dataAnswers[0, index].Value.ToString(), out int id);
                    if (converted == false)
                        return;

                    Answer answer = tGBot.Answers.Find(id);

                    AnswersForm aForm = new AnswersForm();

                    aForm.textBoxIDQuest.Text = answer.QuestionId.ToString();
                    aForm.texidQuest.Text = answer.NumQuest.ToString();
                    aForm.textAnswerValue.Text = answer.Value;
                    aForm.comboBoxIsRight.SelectedItem = answer.IsRight;

                    DialogResult result = aForm.ShowDialog(this);

                    if (result == DialogResult.Cancel)
                        return;

                    answer.QuestionId = Int32.Parse(aForm.textBoxIDQuest.Text);
                    answer.Value = aForm.textAnswerValue.Text;
                    answer.IsRight = bool.Parse(aForm.comboBoxIsRight.SelectedItem.ToString());
                    answer.NumQuest = Int32.Parse(aForm.texidQuest.Text);

                    await tGBot.SaveChangesAsync();
                    dataAnswers.Refresh(); // обновляем грид
                    MessageBox.Show("Ответы обновлены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                logger.Error(ex);
            }
        }

        /// <summary>
        /// Обработчик кнопки Удалить ответ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void ButDeleteAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataAnswers.SelectedRows.Count > 0)
                {
                    int index = dataAnswers.SelectedRows[0].Index;
                    bool converted = Int32.TryParse(dataAnswers[0, index].Value.ToString(), out int id);
                    if (converted == false)
                        return;

                    Answer answer = tGBot.Answers.Find(id);
                    tGBot.Answers.Remove(answer);
                    await tGBot.SaveChangesAsync();

                    MessageBox.Show("Ответ удален");
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Ошибка при удалении!");
            }
        }

        /// <summary>
        /// Обработчик кнопки Добавить пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButAddUser_Click(object sender, EventArgs e)
        {

            UserInfoForm userInfoForm = new UserInfoForm();

            DialogResult result = userInfoForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            try
            {
                UserInfo userInfo = new UserInfo
                {
                    UserName = userInfoForm.textLogin.Text,
                    FirstName = userInfoForm.textName.Text,
                    LastName = userInfoForm.textSername.Text,
                    GroupName = userInfoForm.textGroupUser.Text,
                    GroupId = Int32.Parse(userInfoForm.textIDGroup.Text),
                    score = Int32.Parse(userInfoForm.textUserScore.Text)
                };

                tGBot.UserInfos.Add(userInfo);
                await tGBot.SaveChangesAsync();
                MessageBox.Show("Пользователь добавлен");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Ошибка при добавлении пользователя!!");
            }
        }

        /// <summary>
        /// Обработчик кнопки Добавить группу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButAddGroup_Click(object sender, EventArgs e)
        {
            GroupForm groupForm = new GroupForm();

            DialogResult result = groupForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            try
            {
                Group group = new Group
                {
                    NameGroup = groupForm.textGroupName.Text,
                    LGId = Int32.Parse(groupForm.texIDListGroup.Text)
                };


                tGBot.Groups.Add(group);
                await tGBot.SaveChangesAsync();
                MessageBox.Show("Группа добавлена");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Ошибка при добавлении группы!!");
            }
        }

        /// <summary>
        /// Обработчик кнопки Добавить Факультет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButAddListGroup_Click(object sender, EventArgs e)
        {
            ListGroupForm listGroupForm = new ListGroupForm();

            DialogResult result = listGroupForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            try
            {
                ListGroup listGroup = new ListGroup
                {
                    NameGroupFromList = listGroupForm.textListName.Text
                };


                tGBot.ListGroups.Add(listGroup);
                await tGBot.SaveChangesAsync();
                MessageBox.Show("Факультет добавлен");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Ошибка при добавлении факультета!!!");
            }
        }

        /// <summary>
        /// Обработчик кнопки Удалить Факультет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButDelListGroup_Click(object sender, EventArgs e)
        {
            if (dataListGroup.SelectedRows.Count > 0)
            {
                int index = dataListGroup.SelectedRows[0].Index;
                bool converted = Int32.TryParse(dataListGroup[0, index].Value.ToString(), out int id);
                if (converted == false)
                    return;

                ListGroup listGroup = tGBot.ListGroups.Find(id);

                tGBot.ListGroups.Remove(listGroup);
                await tGBot.SaveChangesAsync();

                MessageBox.Show("Факультет удален");
            }
        }

        /// <summary>
        /// Обработчик кнопки обновить Все гриды
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                await tGBot.SaveChangesAsync();

                tGBot.UserInfos.Load();
                tGBot.Groups.Load();
                tGBot.ListGroups.Load();

                dataUserInfo.DataSource = tGBot.UserInfos.Local.ToBindingList();
                dataGroup.DataSource = tGBot.Groups.Local.ToBindingList();
                dataListGroup.DataSource = tGBot.ListGroups.Local.ToBindingList();

                dataUserInfo.EndEdit();
                dataGroup.EndEdit();
                dataListGroup.EndEdit();

                dataUserInfo.Update();
                dataGroup.Update();
                dataListGroup.Update();

                dataUserInfo.Refresh();
                dataGroup.Refresh();
                dataListGroup.Refresh();
                MessageBox.Show("Обновление всех гридов выполнено!");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Ошибка при обновлении таблиц!!!");
            }
        }

        /// <summary>
        /// Обработчик кнопки Удалить пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButDelYser_Click(object sender, EventArgs e)
        {
            if (dataUserInfo.SelectedRows.Count > 0)
            {
                int index = dataUserInfo.SelectedRows[0].Index;
                bool converted = Int32.TryParse(dataUserInfo[0, index].Value.ToString(), out int id);
                if (converted == false)
                    return;

                UserInfo userInfo = tGBot.UserInfos.Find(id);

                tGBot.UserInfos.Remove(userInfo);
                await tGBot.SaveChangesAsync();

                MessageBox.Show("Пользователь удален");
            }
        }

        /// <summary>
        /// Обработчик кнопки Изменить пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButChangeUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataUserInfo.SelectedRows.Count > 0)
                {
                    int index = dataAnswers.SelectedRows[0].Index;
                    bool converted = Int32.TryParse(dataUserInfo[0, index].Value.ToString(), out int id);
                    if (converted == false)
                        return;

                    UserInfo userInfo = tGBot.UserInfos.Find(id);

                    UserInfoForm userInfoForm = new UserInfoForm();

                    userInfoForm.textLogin.Text = userInfo.UserName;
                    userInfoForm.textName.Text = userInfo.FirstName;
                    userInfoForm.textSername.Text = userInfo.LastName;
                    userInfoForm.textGroupUser.Text = userInfo.GroupName;
                    userInfoForm.textIDGroup.Text = userInfo.GroupId.ToString();
                    userInfoForm.textUserScore.Text = userInfo.score.ToString();

                    DialogResult result = userInfoForm.ShowDialog(this);

                    if (result == DialogResult.Cancel)
                        return;

                    userInfo.UserName = userInfoForm.textLogin.Text;
                    userInfo.FirstName = userInfoForm.textName.Text;
                    userInfo.LastName = userInfoForm.textSername.Text;
                    userInfo.GroupName = userInfoForm.textGroupUser.Text;
                    userInfo.GroupId = Int32.Parse(userInfoForm.textIDGroup.Text);
                    userInfo.score = Int32.Parse(userInfoForm.textUserScore.Text);

                    await tGBot.SaveChangesAsync();
                    dataUserInfo.Refresh(); // обновляем грид
                    MessageBox.Show("Пользователи обновлены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании пользователя!!!");
                logger.Error(ex);
            }
        }

        /// <summary>
        /// Обработчик кнопки Удалить Группу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButDelGroup_Click(object sender, EventArgs e)
        {
            if (dataGroup.SelectedRows.Count > 0)
            {
                int index = dataGroup.SelectedRows[0].Index;
                bool converted = Int32.TryParse(dataGroup[0, index].Value.ToString(), out int id);
                if (converted == false)
                    return;

                Group group = tGBot.Groups.Find(id);

                tGBot.Groups.Remove(group);
                await tGBot.SaveChangesAsync();

                MessageBox.Show("Группа удалена");
            }
        }

        /// <summary>
        /// Обработчик кнопки Изменить группу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButChangeGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGroup.SelectedRows.Count > 0)
                {
                    int index = dataGroup.SelectedRows[0].Index;
                    bool converted = Int32.TryParse(dataGroup[0, index].Value.ToString(), out int id);
                    if (converted == false)
                        return;

                    Group group = tGBot.Groups.Find(id);

                    GroupForm groupForm = new GroupForm();

                    groupForm.textGroupName.Text = group.NameGroup;
                    groupForm.texIDListGroup.Text = group.LGId.ToString();


                    DialogResult result = groupForm.ShowDialog(this);

                    if (result == DialogResult.Cancel)
                        return;

                    group.NameGroup = groupForm.textGroupName.Text;
                    group.LGId = Int32.Parse(groupForm.texIDListGroup.Text);


                    await tGBot.SaveChangesAsync();
                    dataGroup.Refresh(); // обновляем грид
                    MessageBox.Show("Группы обновлены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании Группы");
                logger.Error(ex);
            }
        }

        private async void ButChangeListGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListGroup.SelectedRows.Count > 0)
                {
                    int index = dataListGroup.SelectedRows[0].Index;
                    bool converted = Int32.TryParse(dataListGroup[0, index].Value.ToString(), out int id);
                    if (converted == false)
                        return;

                    ListGroup listGroup = tGBot.ListGroups.Find(id);
                    ListGroupForm listGroupForm = new ListGroupForm();


                    listGroupForm.textListName.Text = listGroup.NameGroupFromList;

                    DialogResult result = listGroupForm.ShowDialog(this);

                    if (result == DialogResult.Cancel)
                        return;

                    listGroup.NameGroupFromList = listGroupForm.textListName.Text;

                    await tGBot.SaveChangesAsync();
                    dataListGroup.Refresh(); // обновляем грид
                    MessageBox.Show("Факультеты обновлены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                logger.Error(ex);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (logger == null)
            {
                logger = LogManager.GetCurrentClassLogger();
            }
        }
    }
}
