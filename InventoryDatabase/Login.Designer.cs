namespace InventoryDatabase
{
    partial class Login
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
            txtPass = new TextBox();
            txtUser = new TextBox();
            label6 = new Label();
            label3 = new Label();
            btnLogin = new Button();
            lblSignup = new Label();
            SuspendLayout();
            // 
            // txtPass
            // 
            txtPass.BorderStyle = BorderStyle.FixedSingle;
            txtPass.Font = new Font("Swis721 Cn BT", 9F);
            txtPass.Location = new Point(48, 145);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(252, 25);
            txtPass.TabIndex = 16;
            // 
            // txtUser
            // 
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtUser.Font = new Font("Swis721 Cn BT", 9F);
            txtUser.Location = new Point(49, 81);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(252, 25);
            txtUser.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Swis721 Cn BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(49, 122);
            label6.Name = "label6";
            label6.Size = new Size(74, 20);
            label6.TabIndex = 14;
            label6.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Swis721 Cn BT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(48, 58);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 13;
            label3.Text = "Username";
            // 
            // btnLogin
            // 
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(127, 211);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 17;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblSignup
            // 
            lblSignup.AutoSize = true;
            lblSignup.Cursor = Cursors.Hand;
            lblSignup.Font = new Font("Swis721 Cn BT", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSignup.Location = new Point(246, 269);
            lblSignup.Name = "lblSignup";
            lblSignup.Size = new Size(93, 20);
            lblSignup.TabIndex = 18;
            lblSignup.Text = "Go to Signup";
            lblSignup.Click += lblSignup_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 298);
            Controls.Add(lblSignup);
            Controls.Add(btnLogin);
            Controls.Add(txtPass);
            Controls.Add(txtUser);
            Controls.Add(label6);
            Controls.Add(label3);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPass;
        private TextBox txtUser;
        private Label label6;
        private Label label3;
        private Button btnLogin;
        private Label lblSignup;
    }
}