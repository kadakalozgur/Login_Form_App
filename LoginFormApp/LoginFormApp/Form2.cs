using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoginFormApp
{
    public partial class Form2 : Form
    {

        PictureBox userPicture;
        PictureBox passwordPicture;
        PictureBox passwordVisible;
        PictureBox registerButton;

        Panel registerPanel;
        Panel userNamePanel;
        Panel passwordPanel;

        Label registerTitle;
        Label loginLabel;

        TextBox userNameTextBox;
        TextBox passwordTextBox;

        bool visiblePassword = true;

        Form1 _login;
        public Form2(Form1 login)
        {
            InitializeComponent();

            _login = login;

            this.FormClosed += Form2_FormClosed;

            this.BackgroundImageLayout = ImageLayout.Stretch;
            _login = login;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

                Application.Exit();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //Register Panel//

            registerPanel = new Panel();

            registerPanel.Size = new Size(400, 450);
            registerPanel.BackColor = Color.White;

            registerPanel.Left = (this.ClientSize.Width - registerPanel.Width) / 2;
            registerPanel.Top = (this.ClientSize.Height - registerPanel.Height) / 2;

            this.Controls.Add(registerPanel);

            //Register Title//

            registerTitle = new Label();

            registerTitle.Text = "Sign Up";
            registerTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            registerTitle.AutoSize = true;
            registerTitle.TextAlign = ContentAlignment.MiddleCenter;

            registerTitle.ForeColor = Color.Black;

            registerPanel.Controls.Add(registerTitle);

            registerTitle.Left = (registerPanel.Width - registerTitle.Width) / 2;
            registerTitle.Top = 40;

            //Username Panel//

            userNamePanel = new Panel();

            userNamePanel.Size = new Size(300, 40);
            userNamePanel.BackColor = Color.FromArgb(245, 245, 245);

            userNamePanel.Left = (registerPanel.Width - userNamePanel.Width) / 2;
            userNamePanel.Top = registerTitle.Bottom + 30;

            userPicture = new PictureBox();

            userPicture.Size = new Size(24, 24);
            userPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            userPicture.Location = new Point(8, 8);

            userPicture.Image = Resources.User;

            userNameTextBox = new TextBox();

            userNameTextBox.Text = "Username";

            userNameTextBox.Font = new Font("Segoe UI", 11);
            userNameTextBox.BorderStyle = BorderStyle.None;

            userNameTextBox.BackColor = Color.FromArgb(245, 245, 245);
            userNameTextBox.ForeColor = Color.FromArgb(140, 140, 140);

            userNameTextBox.Width = 240;
            userNameTextBox.Location = new Point(40, 10);

            userNameTextBox.Enter += (s, e) =>
            {

                if (userNameTextBox.Text == "Username")
                {

                    userNameTextBox.Text = "";

                    userNameTextBox.ForeColor = Color.Black;

                }

            };

            userNameTextBox.Leave += (s, e) =>
            {

                if (string.IsNullOrWhiteSpace(userNameTextBox.Text))
                {

                    userNameTextBox.Text = "Username";

                    userNameTextBox.ForeColor = Color.FromArgb(160, 160, 160);

                }

            };

            userNamePanel.Controls.Add(userNameTextBox);
            userNamePanel.Controls.Add(userPicture);
            registerPanel.Controls.Add(userNamePanel);

            this.ActiveControl = registerTitle;

            //Password Panel//

            passwordPanel = new Panel();

            passwordPanel.Size = new Size(300, 40);
            passwordPanel.BackColor = Color.FromArgb(245, 245, 245);

            passwordPanel.Left = (registerPanel.Width - passwordPanel.Width) / 2;
            passwordPanel.Top = registerTitle.Bottom + 90;

            passwordPicture = new PictureBox();

            passwordPicture.Size = new Size(24, 24);
            passwordPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            passwordPicture.Location = new Point(8, 8);

            passwordPicture.Image = Resources.Password;

            passwordTextBox = new TextBox();

            passwordTextBox.Text = "Password";

            passwordTextBox.Font = new Font("Segoe UI", 11);
            passwordTextBox.BorderStyle = BorderStyle.None;

            passwordTextBox.BackColor = Color.FromArgb(245, 245, 245);
            passwordTextBox.ForeColor = Color.FromArgb(140, 140, 140);

            passwordTextBox.Width = 200;
            passwordTextBox.Location = new Point(40, 10);

            passwordTextBox.Enter += (s, e) =>
            {

                if (passwordTextBox.Text == "Password")
                {

                    passwordTextBox.Text = "";

                    passwordTextBox.ForeColor = Color.Black;

                    passwordTextBox.UseSystemPasswordChar = true;

                }

            };

            passwordTextBox.Leave += (s, e) =>
            {

                if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
                {

                    passwordTextBox.Text = "Password";

                    passwordTextBox.ForeColor = Color.FromArgb(160, 160, 160);

                    passwordTextBox.UseSystemPasswordChar = false;

                }
            };

            passwordPanel.Controls.Add(passwordTextBox);
            passwordPanel.Controls.Add(passwordPicture);
            registerPanel.Controls.Add(passwordPanel);

            passwordVisible = new PictureBox();

            passwordVisible.Size = new Size(24, 24);
            passwordVisible.SizeMode = PictureBoxSizeMode.StretchImage;

            passwordVisible.Location = new Point(270, 8);

            passwordVisible.Image = Resources.Eye;

            passwordVisible.Cursor = Cursors.Hand;

            passwordVisible.Click += (s, e) =>
            {

                if (passwordTextBox.Text == "Password")
                {

                    return;

                }

                else if (visiblePassword)
                {

                    passwordTextBox.UseSystemPasswordChar = false;

                    passwordTextBox.ForeColor = Color.Black;

                    visiblePassword = false;

                }

                else if (!visiblePassword)
                {

                    passwordTextBox.UseSystemPasswordChar = true;

                    passwordTextBox.ForeColor = Color.Black;

                    visiblePassword = true;

                }
            };

            passwordPanel.Controls.Add(passwordVisible);

            //Sign Up Button//

            registerButton = new PictureBox();

            registerButton.Size = new Size(300, 70);

            registerButton.Image = Resources.signButton;
            registerButton.SizeMode = PictureBoxSizeMode.StretchImage;

            registerButton.Cursor = Cursors.Hand;

            registerButton.Left = (registerPanel.Width - registerButton.Width) / 2;
            registerButton.Top = passwordPanel.Bottom + 30;
            registerButton.BorderStyle = BorderStyle.None;

            registerButton.MouseEnter += (s, e) =>
            {

                registerButton.Image = Resources.signButtonHover;

            };

            registerButton.MouseLeave += (s, e) =>
            {

                registerButton.Image = Resources.signButton;

            };

            registerButton.Click += (s, e) =>
            {

                string usertxt = Path.Combine(Application.StartupPath, "users.txt");

                if (!File.Exists(usertxt))
                {

                    File.WriteAllText(usertxt, "admin,1234" + Environment.NewLine);

                }

                string newUserName = userNameTextBox.Text;
                string newPassword = passwordTextBox.Text;

                bool haveUser = false;

                if(newUserName == "Username" || newPassword == "Password" || string.IsNullOrWhiteSpace(newUserName) || string.IsNullOrWhiteSpace(newPassword))
                {

                    MessageBox.Show("Please enter a valid username and password.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }

                string[] intxt = File.ReadAllLines(usertxt);

                for(int i=0;i<intxt.Length;i++)
                {

                    string[] users = intxt[i].Split(',');

                    if(users.Length == 2)
                    {

                        string userName = users[0];

                        if(userName == newUserName)
                        {

                            haveUser = true;

                            break;

                        }
                    }
                }

                if(haveUser)
                {


                    MessageBox.Show("This username is already taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else
                {

                    File.AppendAllText(usertxt, $"{newUserName},{newPassword}{Environment.NewLine}");

                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    userNameTextBox.Text = "Username";
                    userNameTextBox.ForeColor = Color.FromArgb(160, 160, 160);

                    passwordTextBox.Text = "Password";
                    passwordTextBox.ForeColor = Color.FromArgb(160, 160, 160);
                    passwordTextBox.UseSystemPasswordChar = false;

                }

            };

            registerPanel.Controls.Add(registerButton);

            //Sign Up Label//

            loginLabel = new Label();

            loginLabel.Text = "Login";
            loginLabel.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            loginLabel.AutoSize = true;
            loginLabel.TextAlign = ContentAlignment.MiddleCenter;

            loginLabel.ForeColor = Color.Black;

            registerPanel.Controls.Add(loginLabel);

            loginLabel.Left = (registerPanel.Width - loginLabel.Width) / 2;
            loginLabel.Top = 375;

            loginLabel.MouseEnter += (s, e) =>
            {

                loginLabel.Font = new Font("Segoe UI", 16, FontStyle.Underline);

                Cursor = Cursors.Hand;

            };

            loginLabel.MouseLeave += (s, e) =>
            {

                loginLabel.Font = new Font("Segoe UI", 16, FontStyle.Regular);

                Cursor = Cursors.Default;

            };

            loginLabel.Click += (s, e) =>
            {

                _login.Show();

                this.Hide();

            };

        }
    }
}
