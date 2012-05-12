using System;
using System.Data;
using System.Windows.Forms;

//test

namespace MCMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "mcmsDataSet.user". Sie können sie bei Bedarf verschieben oder entfernen.
            this.userTableAdapter.Fill(this.mcmsDataSet.user);
            //Ich bin ein Kommentar...
            //Ich bin ein zweiter Kommentar...
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list_user.Items.Clear();
            DataSet test = new DataSet();
            test = mcmsDataSet;
            foreach (DataRow row in mcmsDataSet.Tables["user"].Rows)
            {
                list_user.Items.Add(row[1].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userTableAdapter.Insert(textBox1.Text, textBox2.Text, "-", "-", int.Parse(comboBox1.Text), textBox3.Text, "no_avatar.jpg", 0);
            //this.table1TableAdapter.Fill(this.database1DataSet.Table1);
            userTableAdapter.Fill(this.mcmsDataSet.user);
            userTableAdapter.Update(this.mcmsDataSet.user);
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}