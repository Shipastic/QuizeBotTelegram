
namespace BotTelegramDB
{
    partial class AnswersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIDQuest = new System.Windows.Forms.TextBox();
            this.comboBoxIsRight = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textAnswerValue = new System.Windows.Forms.TextBox();
            this.texidQuest = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxIDQuest);
            this.panel1.Controls.Add(this.comboBoxIsRight);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textAnswerValue);
            this.panel1.Controls.Add(this.texidQuest);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.butOk);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 359);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "ID вопроса";
            // 
            // textBoxIDQuest
            // 
            this.textBoxIDQuest.Location = new System.Drawing.Point(223, 97);
            this.textBoxIDQuest.Name = "textBoxIDQuest";
            this.textBoxIDQuest.Size = new System.Drawing.Size(134, 22);
            this.textBoxIDQuest.TabIndex = 9;
            // 
            // comboBoxIsRight
            // 
            this.comboBoxIsRight.FormattingEnabled = true;
            this.comboBoxIsRight.Items.AddRange(new object[] {
            "false",
            "true"});
            this.comboBoxIsRight.Location = new System.Drawing.Point(223, 238);
            this.comboBoxIsRight.Name = "comboBoxIsRight";
            this.comboBoxIsRight.Size = new System.Drawing.Size(134, 24);
            this.comboBoxIsRight.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Верный ответ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Номер вопроса";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Вариант ответа";
            // 
            // textAnswerValue
            // 
            this.textAnswerValue.Location = new System.Drawing.Point(223, 172);
            this.textAnswerValue.Name = "textAnswerValue";
            this.textAnswerValue.Size = new System.Drawing.Size(134, 22);
            this.textAnswerValue.TabIndex = 3;
            // 
            // texidQuest
            // 
            this.texidQuest.Location = new System.Drawing.Point(223, 31);
            this.texidQuest.Name = "texidQuest";
            this.texidQuest.Size = new System.Drawing.Size(134, 22);
            this.texidQuest.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(247, 301);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // butOk
            // 
            this.butOk.BackColor = System.Drawing.Color.LightSteelBlue;
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butOk.Location = new System.Drawing.Point(12, 301);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(107, 45);
            this.butOk.TabIndex = 0;
            this.butOk.Text = "OK";
            this.butOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butOk.UseCompatibleTextRendering = true;
            this.butOk.UseVisualStyleBackColor = false;
            // 
            // AnswersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(416, 390);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Name = "AnswersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить ответ";
            this.Load += new System.EventHandler(this.AnswersForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        protected internal System.Windows.Forms.ComboBox comboBoxIsRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.TextBox textAnswerValue;
        protected internal System.Windows.Forms.TextBox texidQuest;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Label label4;
        protected internal System.Windows.Forms.TextBox textBoxIDQuest;
    }
}