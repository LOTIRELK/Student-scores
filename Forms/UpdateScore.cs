using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class UpdateScore : Form
    {
        public UpdateScore()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            msg = txtScore.Text.TrimEnd();
            this.Tag = msg.TrimEnd();
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateScore_Load(object sender, EventArgs e)
        {
            txtScore.Focus();
        }
    }
}
