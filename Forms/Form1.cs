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
    public partial class Form1 : Form
    {
        List<string> student = new List<string>();
        public static string setValueForText1 = "";
        public static string setValueForText2 = "";
        public static string setValueForText3 = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "   Are you sure you want to exit the application?";
            DialogResult button =
                MessageBox.Show(message, "Confirm Exit",
                MessageBoxButtons.YesNo);
            if (button == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectedIndex = lbStudents.SelectedIndex;
            string curItem;
            curItem = student[selectedIndex];
            string[] value = Regex.Split(curItem, @"\D+");
            int total = 0;
            int count = 0;
            foreach (string num in value)
            {
                if (!string.IsNullOrEmpty(num))
                {
                    total += int.Parse(num);
                    count++;
                }
            }
            txtScoreTotal.Text = Convert.ToString(total);
            txtScoreCount.Text = Convert.ToString(count);
            if (count > 0)
            {
                txtAverage.Text = Convert.ToString(total / count);
            }
            else
                txtAverage.Text = "0";
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            student.Add("Joel Murach 97 71 83");
            student.Add("Doug Lowel 99 93 97");
            student.Add("Anne Boehm 100 100 100");
            foreach (string item in student)
            {
                lbStudents.Items.Add(item);
            }
            lbStudents.SelectedIndex = 0;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form NewStudent = new addStudent();
            DialogResult selectedButton = NewStudent.ShowDialog();
            if (selectedButton == DialogResult.OK)
            {
                string i = (string)NewStudent.Tag;
                student.Add(i);
                lbStudents.Items.Add(i);
            }
        }

        private void FillProductListBox()
        {
            
            lbStudents.Items.Clear();
            
            foreach (string p in student)
            {
                lbStudents.Items.Add(p);
            }
        }
        public static int i = 0;
        private void btnDelete_Click(object sender, EventArgs e)
        {

            int i = lbStudents.SelectedIndex;

            if (lbStudents.SelectedIndex != -1)
            {
                string message = "   Are you sure you want to remove the student from the list?";
                DialogResult button =
                    MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    student.RemoveAt(i);
                    lbStudents.Items.Clear();
                    FillProductListBox();
                }

            }
            txtScoreTotal.Text = "";
            txtScoreCount.Text = "";
            txtAverage.Text = "";
            
            lbStudents.SelectedIndex = 0;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbStudents.SelectedIndex;
            setValueForText1 = student[selectedIndex];
            setValueForText2 = student[selectedIndex].TrimStart();
            setValueForText3 = student[selectedIndex];
            Form update = new UpdateStudentScore();
            DialogResult selectedButton = update.ShowDialog();

            if (selectedButton == DialogResult.OK)
            {


                student.RemoveAt(selectedIndex);
                student.Insert(selectedIndex, (string)update.Tag);
                lbStudents.Items.Clear();
                FillProductListBox();

            }
        }
    }
}
