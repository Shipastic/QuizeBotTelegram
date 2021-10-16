using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotTelegramDB
{
    public partial class AnswersForm : Form
    {
        public AnswersForm()
        {
            InitializeComponent();
        }

        private void AnswersForm_Load(object sender, EventArgs e)
        {
            comboBoxIsRight.Text = "false";
        }
    }
}
