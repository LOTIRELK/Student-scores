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
    public partial class addStudent : Form
    {
        public addStudent()
        {
            InitializeComponent();
        }
       
        private void btnAddScore_Click(object sender, EventArgs e)
        {
            txtScores.Text += txtScoreEntered.Text + " ";
            txtScoreEntered.Text = "";
            txtScoreEntered.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string message = "   Are you sure you want to remove the scores entered?";
            DialogResult button =
                MessageBox.Show(message, "Confirm Delete",
                MessageBoxButtons.YesNo);
            if (button == DialogResult.Yes)
            {
                txtScores.Clear();
                txtScores.Text = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string msg = null;
            if (!string.IsNullOrEmpty(txtScores.Text))
            {
                msg = txtName.Text + " " + txtScores.Text.Trim();
            }
            else
                msg = txtName.Text;
            this.Tag = msg;
            this.DialogResult = DialogResult.OK;
        }

        
    }
}