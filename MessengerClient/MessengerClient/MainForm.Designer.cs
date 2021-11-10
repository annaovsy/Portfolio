
namespace MessengerClient
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSwitchOff = new System.Windows.Forms.Button();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.buttonSignIN = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Введите сообщение...";
            // 
            // buttonSwitchOff
            // 
            this.buttonSwitchOff.Location = new System.Drawing.Point(659, 125);
            this.buttonSwitchOff.Name = "buttonSwitchOff";
            this.buttonSwitchOff.Size = new System.Drawing.Size(172, 44);
            this.buttonSwitchOff.TabIndex = 23;
            this.buttonSwitchOff.Text = "Выйти";
            this.buttonSwitchOff.UseVisualStyleBackColor = true;
            this.buttonSwitchOff.Click += new System.EventHandler(this.buttonSwitchOff_Click);
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Location = new System.Drawing.Point(659, 75);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(172, 44);
            this.buttonSignUp.TabIndex = 22;
            this.buttonSignUp.Text = "Зарегистрироваться";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // buttonSignIN
            // 
            this.buttonSignIN.Location = new System.Drawing.Point(659, 25);
            this.buttonSignIN.Name = "buttonSignIN";
            this.buttonSignIN.Size = new System.Drawing.Size(172, 44);
            this.buttonSignIN.TabIndex = 21;
            this.buttonSignIN.Text = "Войти";
            this.buttonSignIN.UseVisualStyleBackColor = true;
            this.buttonSignIN.Click += new System.EventHandler(this.buttonSignIN_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(519, 525);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(105, 47);
            this.buttonSend.TabIndex = 20;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Location = new System.Drawing.Point(41, 546);
            this.textBoxMsg.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(467, 22);
            this.textBoxMsg.TabIndex = 19;
            // 
            // textBoxMain
            // 
            this.textBoxMain.Location = new System.Drawing.Point(27, 23);
            this.textBoxMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMain.Multiline = true;
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.ReadOnly = true;
            this.textBoxMain.Size = new System.Drawing.Size(597, 489);
            this.textBoxMain.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 595);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSwitchOff);
            this.Controls.Add(this.buttonSignUp);
            this.Controls.Add(this.buttonSignIN);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.textBoxMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Messenger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSwitchOff;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.Button buttonSignIN;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.TextBox textBoxMain;
    }
}

