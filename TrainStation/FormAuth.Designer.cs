
namespace TrainStation
{
    partial class FormAuth
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAuth));
            this.labelName = new System.Windows.Forms.Label();
            this.buttonCapchaRefresh = new System.Windows.Forms.Button();
            this.textBoxCaptcha = new System.Windows.Forms.TextBox();
            this.pictureBoxCaptcha = new System.Windows.Forms.PictureBox();
            this.buttonLook = new System.Windows.Forms.Button();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxAlert = new System.Windows.Forms.TextBox();
            this.textBoxTimer = new System.Windows.Forms.TextBox();
            this.timerDeny = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(59, 43);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(201, 18);
            this.labelName.TabIndex = 48;
            this.labelName.Text = "Железнодорожная станция";
            // 
            // buttonCapchaRefresh
            // 
            this.buttonCapchaRefresh.Location = new System.Drawing.Point(216, 292);
            this.buttonCapchaRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCapchaRefresh.Name = "buttonCapchaRefresh";
            this.buttonCapchaRefresh.Size = new System.Drawing.Size(93, 23);
            this.buttonCapchaRefresh.TabIndex = 47;
            this.buttonCapchaRefresh.TabStop = false;
            this.buttonCapchaRefresh.Text = "Обновить";
            this.buttonCapchaRefresh.UseVisualStyleBackColor = true;
            this.buttonCapchaRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // textBoxCaptcha
            // 
            this.textBoxCaptcha.Location = new System.Drawing.Point(24, 292);
            this.textBoxCaptcha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCaptcha.Name = "textBoxCaptcha";
            this.textBoxCaptcha.Size = new System.Drawing.Size(185, 22);
            this.textBoxCaptcha.TabIndex = 40;
            // 
            // pictureBoxCaptcha
            // 
            this.pictureBoxCaptcha.Location = new System.Drawing.Point(24, 178);
            this.pictureBoxCaptcha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            this.pictureBoxCaptcha.Size = new System.Drawing.Size(285, 108);
            this.pictureBoxCaptcha.TabIndex = 46;
            this.pictureBoxCaptcha.TabStop = false;
            // 
            // buttonLook
            // 
            this.buttonLook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLook.Location = new System.Drawing.Point(269, 144);
            this.buttonLook.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLook.Name = "buttonLook";
            this.buttonLook.Size = new System.Drawing.Size(40, 27);
            this.buttonLook.TabIndex = 45;
            this.buttonLook.TabStop = false;
            this.buttonLook.UseVisualStyleBackColor = true;
            this.buttonLook.Click += new System.EventHandler(this.buttonLook_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.Location = new System.Drawing.Point(13, 9);
            this.labelWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(273, 20);
            this.labelWelcome.TabIndex = 44;
            this.labelWelcome.Text = "Д О Б Р О   П О Ж А Л О В А Т Ь";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(20, 124);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(57, 17);
            this.labelPassword.TabIndex = 43;
            this.labelPassword.Text = "Пароль";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(20, 66);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(47, 17);
            this.labelLogin.TabIndex = 42;
            this.labelLogin.Text = "Логин";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(24, 322);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(285, 28);
            this.buttonLogin.TabIndex = 41;
            this.buttonLogin.Text = "ВОЙТИ";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(24, 144);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassword.MaxLength = 20;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(236, 22);
            this.textBoxPassword.TabIndex = 39;
            this.textBoxPassword.Text = "cashier";
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(24, 87);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLogin.MaxLength = 30;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(285, 22);
            this.textBoxLogin.TabIndex = 38;
            this.textBoxLogin.Text = "cashier";
            // 
            // textBoxAlert
            // 
            this.textBoxAlert.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAlert.Location = new System.Drawing.Point(17, 7);
            this.textBoxAlert.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAlert.Multiline = true;
            this.textBoxAlert.Name = "textBoxAlert";
            this.textBoxAlert.Size = new System.Drawing.Size(292, 162);
            this.textBoxAlert.TabIndex = 49;
            this.textBoxAlert.Text = "Вы заблокированы в системе\r\nза неудачные попытки входа";
            this.textBoxAlert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAlert.Visible = false;
            // 
            // textBoxTimer
            // 
            this.textBoxTimer.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTimer.Location = new System.Drawing.Point(16, 188);
            this.textBoxTimer.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTimer.Multiline = true;
            this.textBoxTimer.Name = "textBoxTimer";
            this.textBoxTimer.Size = new System.Drawing.Size(292, 162);
            this.textBoxTimer.TabIndex = 50;
            this.textBoxTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTimer.Visible = false;
            // 
            // timerDeny
            // 
            this.timerDeny.Interval = 1000;
            // 
            // FormAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 361);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonCapchaRefresh);
            this.Controls.Add(this.textBoxCaptcha);
            this.Controls.Add(this.pictureBoxCaptcha);
            this.Controls.Add(this.buttonLook);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.textBoxAlert);
            this.Controls.Add(this.textBoxTimer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAuth";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.FormAuth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonCapchaRefresh;
        private System.Windows.Forms.TextBox textBoxCaptcha;
        private System.Windows.Forms.PictureBox pictureBoxCaptcha;
        private System.Windows.Forms.Button buttonLook;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        public System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxAlert;
        private System.Windows.Forms.TextBox textBoxTimer;
        private System.Windows.Forms.Timer timerDeny;
    }
}

