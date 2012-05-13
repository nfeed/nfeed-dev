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

        private void button1_Click(object sender, System.EventArgs e)
        {
            list_user.Items.Clear();
            user usr = new user(MCMS.Properties.Settings.Default.host, MCMS.Properties.Settings.Default.username, MCMS.Properties.Settings.Default.password, MCMS.Properties.Settings.Default.database);

            foreach (string result in usr.get_all_user())
            {
                list_user.Items.Add(result);
            }

            //MessageBox.Show(usr.get_user_by_id("teyhouse").ToString());
            //MessageBox.Show(usr.getlastid().ToString());

            /*
            if (usr.adduser("mama", "papa", "mama@papa.de", 0))
            {
                MessageBox.Show("Nutzer wurde angelegt!");
            }*/

            /*
            if (usr.delete_user_by_id(24))
            {
                MessageBox.Show("Nutzer gelöscht!");
            }
             * */
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //MCMS.Properties.Settings.Default.Reset();
            //Prüfen, ob alle Einstellungen gesetzt wurden
            checksettings();
        }

        private void checksettings()
        {
            if (MCMS.Properties.Settings.Default.host == "" && MCMS.Properties.Settings.Default.username == "" && MCMS.Properties.Settings.Default.password == "" && MCMS.Properties.Settings.Default.database == "")
            {
                SomeCustomForm myForm = new SomeCustomForm();
                myForm.Message = "Bitte Servername eingeben!";
                myForm.ShowDialog(new Form());
                string result = myForm.Message;

                SomeCustomForm myForm2 = new SomeCustomForm();
                myForm2.Message = "Bitte Datenbankname eingeben!";
                myForm2.ShowDialog(new Form());
                string result2 = myForm2.Message;

                SomeCustomForm myForm3 = new SomeCustomForm();
                myForm3.Message = "Bitte Benutzername eingeben!";
                myForm3.ShowDialog(new Form());
                string result3 = myForm3.Message;

                SomeCustomForm myForm4 = new SomeCustomForm();
                myForm4.Message = "Bitte Kennwort eingeben!";
                myForm4.ShowDialog(new Form());
                string result4 = myForm4.Message;

                MCMS.Properties.Settings.Default.host = result;
                MCMS.Properties.Settings.Default.database = result2;
                MCMS.Properties.Settings.Default.username = result3;
                MCMS.Properties.Settings.Default.password = result4;
                MCMS.Properties.Settings.Default.Save();
            }
        }

        public void enable()
        {
            Form1.ActiveForm.Enabled = true;
        }

        public void disable()
        {
            Form1.ActiveForm.Enabled = false;
        }

        public class SomeCustomForm : System.Windows.Forms.Form
        {
            private System.ComponentModel.Container components;
            private System.Windows.Forms.Button btnCancel;
            private System.Windows.Forms.Button btnOK;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.TextBox txtMessage;

            public SomeCustomForm()
            {
                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;
            }

            private string strMessage;

            public string Message
            {
                get { return strMessage; }
                set
                {
                    strMessage = value;
                    txtMessage.Text = strMessage;
                }
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.label1 = new System.Windows.Forms.Label();
                this.btnOK = new System.Windows.Forms.Button();
                this.btnCancel = new System.Windows.Forms.Button();
                this.txtMessage = new System.Windows.Forms.TextBox();
                label1.Location = new System.Drawing.Point(12, 8);
                label1.Text = "Einstellungen";
                label1.Size = new System.Drawing.Size(240, 48);
                label1.TabIndex = 1;

                btnOK.Location = new System.Drawing.Point(16, 104);
                btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
                btnOK.Size = new System.Drawing.Size(96, 24);
                btnOK.TabIndex = 2;
                btnOK.Text = "OK";
                btnOK.Click += new System.EventHandler(this.btnOK_Click);
                btnCancel.Location = new System.Drawing.Point(152, 104);
                btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                btnCancel.Size = new System.Drawing.Size(96, 24);
                btnCancel.TabIndex = 3;
                btnCancel.Text = "Cancel";
                txtMessage.Location = new System.Drawing.Point(16, 72);
                txtMessage.TabIndex = 0;
                txtMessage.Size = new System.Drawing.Size(232, 20);
                this.Text = "Einstellungen nicht gefunden!";
                this.MaximizeBox = false;
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.ControlBox = false;
                this.MinimizeBox = false;
                this.ClientSize = new System.Drawing.Size(266, 151);
                this.Controls.Add(this.btnCancel);
                this.Controls.Add(this.btnOK);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.txtMessage);
            }

            #endregion Windows Form Designer generated code

            protected void btnOK_Click(object sender, System.EventArgs e)
            {
                // OK button clicked.
                // get new message.
                strMessage = txtMessage.Text;
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            user usr = new user(MCMS.Properties.Settings.Default.host, MCMS.Properties.Settings.Default.username, MCMS.Properties.Settings.Default.password, MCMS.Properties.Settings.Default.database);
            if (usr.adduser(textBox1.Text, textBox2.Text, textBox3.Text, int.Parse(textBox4.Text)))
            {
                MessageBox.Show("Nutzer wurde angelegt!");
            }
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            if (list_user.SelectedItems.Count > 0)
            {
                user usr = new user(MCMS.Properties.Settings.Default.host, MCMS.Properties.Settings.Default.username, MCMS.Properties.Settings.Default.password, MCMS.Properties.Settings.Default.database);
                if (usr.delete_user_by_id(usr.get_user_by_id(list_user.SelectedItem.ToString())))
                {
                    MessageBox.Show("Nutzer gelöscht!");
                }
            }
            else
            {
                MessageBox.Show("Bitte einen Nutzer auswählen!");
            }
            button1_Click(sender, e);
        }
    }
}