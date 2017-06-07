using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class UpdateStudentScore : Form
    {
        List<string> studentUpdate = new List<string>();
        public static string setValueForText4 = "";
        public UpdateStudentScore()
        {
            InitializeComponent();
        }
        
        private void UpdateStudentScore_Load(object sender, EventArgs e)
        {
            
            setValueForText4 = "";
            string name = Form1.setValueForText1;
            string scores = Form1.setValueForText2;
            string[] value1 = Regex.Split(scores, @"\D+");
            
            string[] value = Regex.Split(name, "[^A-Za-z]+");
            string FullName = null;
            foreach (string letter in value)
            {
                if (!string.IsNullOrEmpty(letter))
                {
                    FullName += letter;
                }
            }
            txtName.Text = FullName;
            
            
            foreach (string number in value1)
            {
                    studentUpdate.Add(number);
            }
            studentUpdate.RemoveAt(0);
            foreach (string item in studentUpdate)
            {
                lbScores.Items.Add(item);
            }
            lbScores.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form AddScore = new AddScore();
            DialogResult selectedButton = AddScore.ShowDialog();
            if (selectedButton == DialogResult.OK)
            {

                studentUpdate.Add((string)AddScore.Tag);

                lbScores.Items.Add((string)AddScore.Tag);


            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (var item in studentUpdate)
            {
                setValueForText4 += item.ToString() + " ";
            }

            string newVal;
            newVal = txtName.Text + " " + setValueForText4.TrimEnd();
            this.Tag = newVal.TrimEnd();
            this.DialogResult = DialogResult.OK;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int i = lbScores.SelectedIndex;
            Form UpdateScore = new UpdateScore();
            DialogResult selectedButton = UpdateScore.ShowDialog();
            if (selectedButton == DialogResult.OK)
            {
                if (lbScores.SelectedIndex != -1)
                {
                    studentUpdate.RemoveAt(i);
                    studentUpdate.Insert(i, (string)UpdateScore.Tag);
                    lbScores.Items[lbScores.SelectedIndex] = (string)UpdateScore.Tag;
                }
                }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int i = lbScores.SelectedIndex;
            string message = "   Are you sure you want to remove the score from the list?";
            DialogResult button =
                MessageBox.Show(message, "Confirm Delete",
                MessageBoxButtons.YesNo);
            if (button == DialogResult.Yes)
            {
                studentUpdate.RemoveAt(i);
                lbScores.Items.RemoveAt(i);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string message = "   Are you sure you want to delete all scores from the list?";
            DialogResult button =
                MessageBox.Show(message, "Confirm Delete",
                MessageBoxButtons.YesNo);
            if (button == DialogResult.Yes)
            {
                studentUpdate.Clear();
                lbScores.Items.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
