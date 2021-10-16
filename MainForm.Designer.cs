
namespace BotTelegramDB
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.timerUpdates = new System.Windows.Forms.Timer(this.components);
            this.dataQuestions = new System.Windows.Forms.DataGridView();
            this.butAddQuestions = new System.Windows.Forms.Button();
            this.butDeleteQuestions = new System.Windows.Forms.Button();
            this.dataAnswers = new System.Windows.Forms.DataGridView();
            this.butAddAnswer = new System.Windows.Forms.Button();
            this.butDeleteAnswer = new System.Windows.Forms.Button();
            this.butChangeQuest = new System.Windows.Forms.Button();
            this.butChangeAnswer = new System.Windows.Forms.Button();
            this.butChangeUser = new System.Windows.Forms.Button();
            this.butDelYser = new System.Windows.Forms.Button();
            this.butAddUser = new System.Windows.Forms.Button();
            this.dataUserInfo = new System.Windows.Forms.DataGridView();
            this.butChangeGroup = new System.Windows.Forms.Button();
            this.butDelGroup = new System.Windows.Forms.Button();
            this.butAddGroup = new System.Windows.Forms.Button();
            this.dataGroup = new System.Windows.Forms.DataGridView();
            this.butChangeListGroup = new System.Windows.Forms.Button();
            this.butDelListGroup = new System.Windows.Forms.Button();
            this.butAddListGroup = new System.Windows.Forms.Button();
            this.dataListGroup = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAnswers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListGroup)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(1381, 105);
            this.textBoxLog.TabIndex = 0;
            this.textBoxLog.Text = "Лог чата:\r\n";
            // 
            // timerUpdates
            // 
            this.timerUpdates.Interval = 1000;
            this.timerUpdates.Tick += new System.EventHandler(this.TimerUpdates_Tick);
            // 
            // dataQuestions
            // 
            this.dataQuestions.AllowUserToOrderColumns = true;
            this.dataQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataQuestions.Location = new System.Drawing.Point(15, 33);
            this.dataQuestions.Name = "dataQuestions";
            this.dataQuestions.RowHeadersWidth = 51;
            this.dataQuestions.RowTemplate.Height = 24;
            this.dataQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataQuestions.Size = new System.Drawing.Size(750, 127);
            this.dataQuestions.TabIndex = 2;
            // 
            // butAddQuestions
            // 
            this.butAddQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butAddQuestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddQuestions.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddQuestions.Location = new System.Drawing.Point(15, 164);
            this.butAddQuestions.Name = "butAddQuestions";
            this.butAddQuestions.Size = new System.Drawing.Size(172, 37);
            this.butAddQuestions.TabIndex = 3;
            this.butAddQuestions.Text = "Добавить вопрос";
            this.butAddQuestions.UseVisualStyleBackColor = false;
            this.butAddQuestions.Click += new System.EventHandler(this.ButAddQuestions_Click);
            // 
            // butDeleteQuestions
            // 
            this.butDeleteQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butDeleteQuestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeleteQuestions.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDeleteQuestions.Location = new System.Drawing.Point(593, 164);
            this.butDeleteQuestions.Name = "butDeleteQuestions";
            this.butDeleteQuestions.Size = new System.Drawing.Size(172, 36);
            this.butDeleteQuestions.TabIndex = 4;
            this.butDeleteQuestions.Text = "Удалить вопрос";
            this.butDeleteQuestions.UseVisualStyleBackColor = false;
            this.butDeleteQuestions.Click += new System.EventHandler(this.ButDeleteQuestions_Click);
            // 
            // dataAnswers
            // 
            this.dataAnswers.AllowUserToOrderColumns = true;
            this.dataAnswers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAnswers.Location = new System.Drawing.Point(15, 33);
            this.dataAnswers.Name = "dataAnswers";
            this.dataAnswers.RowHeadersWidth = 51;
            this.dataAnswers.RowTemplate.Height = 24;
            this.dataAnswers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataAnswers.Size = new System.Drawing.Size(750, 187);
            this.dataAnswers.TabIndex = 5;
            // 
            // butAddAnswer
            // 
            this.butAddAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butAddAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddAnswer.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddAnswer.Location = new System.Drawing.Point(15, 226);
            this.butAddAnswer.Name = "butAddAnswer";
            this.butAddAnswer.Size = new System.Drawing.Size(172, 35);
            this.butAddAnswer.TabIndex = 6;
            this.butAddAnswer.Text = "Добавить ответ";
            this.butAddAnswer.UseVisualStyleBackColor = false;
            this.butAddAnswer.Click += new System.EventHandler(this.ButAddAnswer_Click);
            // 
            // butDeleteAnswer
            // 
            this.butDeleteAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butDeleteAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeleteAnswer.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDeleteAnswer.Location = new System.Drawing.Point(593, 226);
            this.butDeleteAnswer.Name = "butDeleteAnswer";
            this.butDeleteAnswer.Size = new System.Drawing.Size(172, 35);
            this.butDeleteAnswer.TabIndex = 7;
            this.butDeleteAnswer.Text = "Удалить ответ";
            this.butDeleteAnswer.UseVisualStyleBackColor = false;
            this.butDeleteAnswer.Click += new System.EventHandler(this.ButDeleteAnswer_Click);
            // 
            // butChangeQuest
            // 
            this.butChangeQuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butChangeQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChangeQuest.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butChangeQuest.Location = new System.Drawing.Point(328, 165);
            this.butChangeQuest.Name = "butChangeQuest";
            this.butChangeQuest.Size = new System.Drawing.Size(144, 36);
            this.butChangeQuest.TabIndex = 8;
            this.butChangeQuest.Text = "Изменить";
            this.butChangeQuest.UseVisualStyleBackColor = false;
            this.butChangeQuest.Click += new System.EventHandler(this.ButChangeQuest_Click);
            // 
            // butChangeAnswer
            // 
            this.butChangeAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butChangeAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChangeAnswer.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butChangeAnswer.Location = new System.Drawing.Point(328, 226);
            this.butChangeAnswer.Name = "butChangeAnswer";
            this.butChangeAnswer.Size = new System.Drawing.Size(144, 35);
            this.butChangeAnswer.TabIndex = 9;
            this.butChangeAnswer.Text = "Изменить";
            this.butChangeAnswer.UseVisualStyleBackColor = false;
            this.butChangeAnswer.Click += new System.EventHandler(this.ButChangeAnswer_Click);
            // 
            // butChangeUser
            // 
            this.butChangeUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butChangeUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChangeUser.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butChangeUser.Location = new System.Drawing.Point(501, 178);
            this.butChangeUser.Name = "butChangeUser";
            this.butChangeUser.Size = new System.Drawing.Size(144, 35);
            this.butChangeUser.TabIndex = 13;
            this.butChangeUser.Text = "Изменить";
            this.butChangeUser.UseVisualStyleBackColor = false;
            this.butChangeUser.Click += new System.EventHandler(this.ButChangeUser_Click);
            // 
            // butDelYser
            // 
            this.butDelYser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butDelYser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelYser.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDelYser.Location = new System.Drawing.Point(1077, 178);
            this.butDelYser.Name = "butDelYser";
            this.butDelYser.Size = new System.Drawing.Size(274, 35);
            this.butDelYser.TabIndex = 12;
            this.butDelYser.Text = "Удалить пользователя";
            this.butDelYser.UseVisualStyleBackColor = false;
            this.butDelYser.Click += new System.EventHandler(this.ButDelYser_Click);
            // 
            // butAddUser
            // 
            this.butAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddUser.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddUser.Location = new System.Drawing.Point(15, 177);
            this.butAddUser.Name = "butAddUser";
            this.butAddUser.Size = new System.Drawing.Size(261, 35);
            this.butAddUser.TabIndex = 11;
            this.butAddUser.Text = "Добавить пользователя";
            this.butAddUser.UseVisualStyleBackColor = false;
            this.butAddUser.Click += new System.EventHandler(this.ButAddUser_Click);
            // 
            // dataUserInfo
            // 
            this.dataUserInfo.AllowUserToOrderColumns = true;
            this.dataUserInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUserInfo.Location = new System.Drawing.Point(15, 21);
            this.dataUserInfo.Name = "dataUserInfo";
            this.dataUserInfo.RowHeadersWidth = 51;
            this.dataUserInfo.RowTemplate.Height = 24;
            this.dataUserInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataUserInfo.Size = new System.Drawing.Size(1336, 150);
            this.dataUserInfo.TabIndex = 10;
            // 
            // butChangeGroup
            // 
            this.butChangeGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butChangeGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChangeGroup.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butChangeGroup.Location = new System.Drawing.Point(234, 163);
            this.butChangeGroup.Name = "butChangeGroup";
            this.butChangeGroup.Size = new System.Drawing.Size(107, 37);
            this.butChangeGroup.TabIndex = 17;
            this.butChangeGroup.Text = "Изменить";
            this.butChangeGroup.UseVisualStyleBackColor = false;
            this.butChangeGroup.Click += new System.EventHandler(this.ButChangeGroup_Click);
            // 
            // butDelGroup
            // 
            this.butDelGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butDelGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelGroup.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDelGroup.Location = new System.Drawing.Point(397, 163);
            this.butDelGroup.Name = "butDelGroup";
            this.butDelGroup.Size = new System.Drawing.Size(172, 37);
            this.butDelGroup.TabIndex = 16;
            this.butDelGroup.Text = "Удалить группу";
            this.butDelGroup.UseVisualStyleBackColor = false;
            this.butDelGroup.Click += new System.EventHandler(this.ButDelGroup_Click);
            // 
            // butAddGroup
            // 
            this.butAddGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddGroup.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddGroup.Location = new System.Drawing.Point(19, 166);
            this.butAddGroup.Name = "butAddGroup";
            this.butAddGroup.Size = new System.Drawing.Size(172, 36);
            this.butAddGroup.TabIndex = 15;
            this.butAddGroup.Text = "Добавить группу";
            this.butAddGroup.UseVisualStyleBackColor = false;
            this.butAddGroup.Click += new System.EventHandler(this.ButAddGroup_Click);
            // 
            // dataGroup
            // 
            this.dataGroup.AllowUserToOrderColumns = true;
            this.dataGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGroup.Location = new System.Drawing.Point(19, 33);
            this.dataGroup.Name = "dataGroup";
            this.dataGroup.RowHeadersWidth = 51;
            this.dataGroup.RowTemplate.Height = 24;
            this.dataGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGroup.Size = new System.Drawing.Size(550, 127);
            this.dataGroup.TabIndex = 14;
            // 
            // butChangeListGroup
            // 
            this.butChangeListGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butChangeListGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butChangeListGroup.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butChangeListGroup.Location = new System.Drawing.Point(234, 226);
            this.butChangeListGroup.Name = "butChangeListGroup";
            this.butChangeListGroup.Size = new System.Drawing.Size(120, 35);
            this.butChangeListGroup.TabIndex = 21;
            this.butChangeListGroup.Text = "Изменить";
            this.butChangeListGroup.UseVisualStyleBackColor = false;
            this.butChangeListGroup.Click += new System.EventHandler(this.ButChangeListGroup_Click);
            // 
            // butDelListGroup
            // 
            this.butDelListGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butDelListGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelListGroup.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDelListGroup.Location = new System.Drawing.Point(360, 226);
            this.butDelListGroup.Name = "butDelListGroup";
            this.butDelListGroup.Size = new System.Drawing.Size(209, 35);
            this.butDelListGroup.TabIndex = 20;
            this.butDelListGroup.Text = "Удалить Факультет";
            this.butDelListGroup.UseVisualStyleBackColor = false;
            this.butDelListGroup.Click += new System.EventHandler(this.ButDelListGroup_Click);
            // 
            // butAddListGroup
            // 
            this.butAddListGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butAddListGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddListGroup.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAddListGroup.Location = new System.Drawing.Point(19, 226);
            this.butAddListGroup.Name = "butAddListGroup";
            this.butAddListGroup.Size = new System.Drawing.Size(209, 35);
            this.butAddListGroup.TabIndex = 19;
            this.butAddListGroup.Text = "Добавить Факультет";
            this.butAddListGroup.UseVisualStyleBackColor = false;
            this.butAddListGroup.Click += new System.EventHandler(this.ButAddListGroup_Click);
            // 
            // dataListGroup
            // 
            this.dataListGroup.AllowUserToOrderColumns = true;
            this.dataListGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataListGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListGroup.Location = new System.Drawing.Point(19, 33);
            this.dataListGroup.Name = "dataListGroup";
            this.dataListGroup.RowHeadersWidth = 51;
            this.dataListGroup.RowTemplate.Height = 24;
            this.dataListGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListGroup.Size = new System.Drawing.Size(550, 187);
            this.dataListGroup.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.dataGroup);
            this.groupBox1.Controls.Add(this.butAddGroup);
            this.groupBox1.Controls.Add(this.butDelGroup);
            this.groupBox1.Controls.Add(this.butChangeGroup);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(794, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 214);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Группы";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.dataListGroup);
            this.groupBox2.Controls.Add(this.butAddListGroup);
            this.groupBox2.Controls.Add(this.butChangeListGroup);
            this.groupBox2.Controls.Add(this.butDelListGroup);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(794, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 267);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Кафедры";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.dataQuestions);
            this.groupBox3.Controls.Add(this.butAddQuestions);
            this.groupBox3.Controls.Add(this.butDeleteQuestions);
            this.groupBox3.Controls.Add(this.butChangeQuest);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(12, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 214);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вопросы";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.dataAnswers);
            this.groupBox4.Controls.Add(this.butAddAnswer);
            this.groupBox4.Controls.Add(this.butDeleteAnswer);
            this.groupBox4.Controls.Add(this.butChangeAnswer);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(12, 331);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(776, 267);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ответы";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.dataUserInfo);
            this.groupBox5.Controls.Add(this.butAddUser);
            this.groupBox5.Controls.Add(this.butDelYser);
            this.groupBox5.Controls.Add(this.butChangeUser);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(12, 598);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1357, 219);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Пользователи";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(761, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 35);
            this.button1.TabIndex = 14;
            this.button1.Text = "Обновить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1381, 820);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelegramBot MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAnswers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListGroup)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Timer timerUpdates;
        private System.Windows.Forms.DataGridView dataQuestions;
        private System.Windows.Forms.Button butAddQuestions;
        private System.Windows.Forms.Button butDeleteQuestions;
        private System.Windows.Forms.DataGridView dataAnswers;
        private System.Windows.Forms.Button butAddAnswer;
        private System.Windows.Forms.Button butDeleteAnswer;
        private System.Windows.Forms.Button butChangeQuest;
        private System.Windows.Forms.Button butChangeAnswer;
        private System.Windows.Forms.Button butChangeUser;
        private System.Windows.Forms.Button butDelYser;
        private System.Windows.Forms.Button butAddUser;
        private System.Windows.Forms.DataGridView dataUserInfo;
        private System.Windows.Forms.Button butChangeGroup;
        private System.Windows.Forms.Button butDelGroup;
        private System.Windows.Forms.Button butAddGroup;
        private System.Windows.Forms.DataGridView dataGroup;
        private System.Windows.Forms.Button butChangeListGroup;
        private System.Windows.Forms.Button butDelListGroup;
        private System.Windows.Forms.Button butAddListGroup;
        private System.Windows.Forms.DataGridView dataListGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

