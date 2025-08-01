using System.IO;

namespace LoginFormApp
{
    public partial class Form1 : Form
    {

        PictureBox userPicture;
        PictureBox passwordPicture;
        PictureBox passwordVisible;
        PictureBox loginButton;

        Panel loginPanel;
        Panel userNamePanel;
        Panel passwordPanel;

        Label loginTitle;
        Label signUp;

        TextBox userNameTextBox;
        TextBox passwordTextBox;

        bool visiblePassword = true;
        public Form1()
        {
            InitializeComponent();

            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Login Panel//

            loginPanel = new Panel();

            loginPanel.Size = new Size(400, 450);
            loginPanel.BackColor = Color.White;

            loginPanel.Left = (this.ClientSize.Width - loginPanel.Width) / 2;
            loginPanel.Top = (this.ClientSize.Height - loginPanel.Height) / 2;

            this.Controls.Add(loginPanel);

            //Login Title//

            loginTitle = new Label();

            loginTitle.Text = "Login";
            loginTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            loginTitle.AutoSize = true;
            loginTitle.TextAlign = ContentAlignment.MiddleCenter;

            loginTitle.ForeColor = Color.Black;

            loginPanel.Controls.Add(loginTitle);

            loginTitle.Left = (loginPanel.Width - loginTitle.Width) / 2;
            loginTitle.Top = 40;

            //Username Panel//

            userNamePanel = new Panel();

            userNamePanel.Size = new Size(300, 40);
            userNamePanel.BackColor = Color.FromArgb(245, 245, 245);

            userNamePanel.Left = (loginPanel.Width - userNamePanel.Width) / 2;
            userNamePanel.Top = loginTitle.Bottom + 30;

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
            loginPanel.Controls.Add(userNamePanel);

            this.ActiveControl = loginTitle;

            //Password Panel//

            passwordPanel = new Panel();

            passwordPanel.Size = new Size(300, 40);
            passwordPanel.BackColor = Color.FromArgb(245, 245, 245);

            passwordPanel.Left = (loginPanel.Width - passwordPanel.Width) / 2;
            passwordPanel.Top = loginTitle.Bottom + 90;

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
            loginPanel.Controls.Add(passwordPanel);

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

            //Login Button//

            loginButton = new PictureBox();

            loginButton.Size = new Size(300, 70);

            loginButton.Image = Resources.loginButton;
            loginButton.SizeMode = PictureBoxSizeMode.StretchImage;

            loginButton.Cursor = Cursors.Hand;

            loginButton.Left = (loginPanel.Width - loginButton.Width) / 2;
            loginButton.Top = passwordPanel.Bottom + 30;
            loginButton.BorderStyle = BorderStyle.None;

            loginButton.MouseEnter += (s, e) =>
            {

                loginButton.Image = Resources.loginButtonHover;

            };

            loginButton.MouseLeave += (s, e) =>
            {

                loginButton.Image = Resources.loginButton;

            };

            loginButton.Click += (s, e) =>
            {
                string usertxt = Path.Combine(Application.StartupPath, "users.txt");

                if (!File.Exists(usertxt))
                {

                    File.WriteAllText(usertxt, "admin,1234" + Environment.NewLine);

                }

                string[] intxt = File.ReadAllLines(usertxt);

                string inputUserName = userNameTextBox.Text;
                string inputPassword = passwordTextBox.Text;

                bool login = false;

                for (int i = 0; i < intxt.Length; i++)
                {
                    string[] users = intxt[i].Split(',');

                    if (users.Length == 2)
                    {

                        string username = users[0];
                        string password = users[1];

                        if (username == inputUserName && password == inputPassword)
                        {

                            login = true;

                            break;

                        }

                    }

                }

                if (login)
                {

                    MessageBox.Show("Login Successful", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

                else
                {

                    MessageBox.Show("Invalid Username or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            };

            loginPanel.Controls.Add(loginButton);

            //Sign Up Label//

            signUp = new Label();

            signUp.Text = "Sign Up";
            signUp.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            signUp.AutoSize = true;
            signUp.TextAlign = ContentAlignment.MiddleCenter;

            signUp.ForeColor = Color.Black;

            loginPanel.Controls.Add(signUp);

            signUp.Left = (loginPanel.Width - signUp.Width) / 2;
            signUp.Top = 375;

            signUp.MouseEnter += (s, e) =>
            {

                signUp.Font = new Font("Segoe UI", 16, FontStyle.Underline);

                Cursor = Cursors.Hand;

            };

            signUp.MouseLeave += (s, e) =>
            {

                signUp.Font = new Font("Segoe UI", 16, FontStyle.Regular);

                Cursor = Cursors.Default;

            };

            signUp.Click += (s, e) =>
            {

                Form2 signUpForm = new Form2(this);

                signUpForm.Show();

                this.Hide();

            };

        }
    }
}
