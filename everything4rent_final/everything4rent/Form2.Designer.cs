namespace everything4rent
{
    partial class Form2
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
            this.register_btn = new System.Windows.Forms.Button();
            this.user_lbl = new System.Windows.Forms.Label();
            this.user_txt = new System.Windows.Forms.TextBox();
            this.name_lbl = new System.Windows.Forms.Label();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.last_lbl = new System.Windows.Forms.Label();
            this.last_txt = new System.Windows.Forms.TextBox();
            this.email_lbl = new System.Windows.Forms.Label();
            this.email_txt = new System.Windows.Forms.TextBox();
            this.paypal_lbl = new System.Windows.Forms.Label();
            this.paypal_txt = new System.Windows.Forms.TextBox();
            this.pass_lbl = new System.Windows.Forms.Label();
            this.pass_txt = new System.Windows.Forms.TextBox();
            this.birth_lbl = new System.Windows.Forms.Label();
            this.birth_txt = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // register_btn
            // 
            this.register_btn.Location = new System.Drawing.Point(39, 345);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(126, 49);
            this.register_btn.TabIndex = 0;
            this.register_btn.Text = "Create Account";
            this.register_btn.UseVisualStyleBackColor = true;
            this.register_btn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // user_lbl
            // 
            this.user_lbl.AutoSize = true;
            this.user_lbl.Location = new System.Drawing.Point(36, 41);
            this.user_lbl.Name = "user_lbl";
            this.user_lbl.Size = new System.Drawing.Size(81, 17);
            this.user_lbl.TabIndex = 5;
            this.user_lbl.Text = "User name:";
            // 
            // user_txt
            // 
            this.user_txt.Location = new System.Drawing.Point(152, 36);
            this.user_txt.Name = "user_txt";
            this.user_txt.Size = new System.Drawing.Size(157, 22);
            this.user_txt.TabIndex = 4;
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.Location = new System.Drawing.Point(36, 158);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(49, 17);
            this.name_lbl.TabIndex = 9;
            this.name_lbl.Text = "Name:";
            // 
            // name_txt
            // 
            this.name_txt.Location = new System.Drawing.Point(152, 153);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(157, 22);
            this.name_txt.TabIndex = 10;
            // 
            // last_lbl
            // 
            this.last_lbl.AutoSize = true;
            this.last_lbl.Location = new System.Drawing.Point(36, 198);
            this.last_lbl.Name = "last_lbl";
            this.last_lbl.Size = new System.Drawing.Size(78, 17);
            this.last_lbl.TabIndex = 11;
            this.last_lbl.Text = "Last name:";
            // 
            // last_txt
            // 
            this.last_txt.Location = new System.Drawing.Point(152, 193);
            this.last_txt.Name = "last_txt";
            this.last_txt.Size = new System.Drawing.Size(157, 22);
            this.last_txt.TabIndex = 12;
            // 
            // email_lbl
            // 
            this.email_lbl.AutoSize = true;
            this.email_lbl.Location = new System.Drawing.Point(36, 121);
            this.email_lbl.Name = "email_lbl";
            this.email_lbl.Size = new System.Drawing.Size(46, 17);
            this.email_lbl.TabIndex = 13;
            this.email_lbl.Text = "Email:";
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(152, 116);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(157, 22);
            this.email_txt.TabIndex = 8;
            // 
            // paypal_lbl
            // 
            this.paypal_lbl.AutoSize = true;
            this.paypal_lbl.Location = new System.Drawing.Point(36, 274);
            this.paypal_lbl.Name = "paypal_lbl";
            this.paypal_lbl.Size = new System.Drawing.Size(110, 17);
            this.paypal_lbl.TabIndex = 15;
            this.paypal_lbl.Text = "Paypal Account:";
            // 
            // paypal_txt
            // 
            this.paypal_txt.Location = new System.Drawing.Point(152, 271);
            this.paypal_txt.Name = "paypal_txt";
            this.paypal_txt.Size = new System.Drawing.Size(157, 22);
            this.paypal_txt.TabIndex = 16;
            // 
            // pass_lbl
            // 
            this.pass_lbl.AutoSize = true;
            this.pass_lbl.Location = new System.Drawing.Point(36, 80);
            this.pass_lbl.Name = "pass_lbl";
            this.pass_lbl.Size = new System.Drawing.Size(73, 17);
            this.pass_lbl.TabIndex = 17;
            this.pass_lbl.Text = "Password:";
            // 
            // pass_txt
            // 
            this.pass_txt.Location = new System.Drawing.Point(152, 75);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.PasswordChar = '*';
            this.pass_txt.Size = new System.Drawing.Size(157, 22);
            this.pass_txt.TabIndex = 6;
            // 
            // birth_lbl
            // 
            this.birth_lbl.AutoSize = true;
            this.birth_lbl.Location = new System.Drawing.Point(36, 238);
            this.birth_lbl.Name = "birth_lbl";
            this.birth_lbl.Size = new System.Drawing.Size(75, 17);
            this.birth_lbl.TabIndex = 19;
            this.birth_lbl.Text = "Birth Date:";
            // 
            // birth_txt
            // 
            this.birth_txt.Location = new System.Drawing.Point(152, 233);
            this.birth_txt.Name = "birth_txt";
            this.birth_txt.Size = new System.Drawing.Size(157, 22);
            this.birth_txt.TabIndex = 14;
            this.birth_txt.Text = "dd/mm/yyyy";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 34);
            this.button1.TabIndex = 20;
            this.button1.Text = "Picture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(212, 306);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 429);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.birth_lbl);
            this.Controls.Add(this.birth_txt);
            this.Controls.Add(this.pass_lbl);
            this.Controls.Add(this.pass_txt);
            this.Controls.Add(this.paypal_lbl);
            this.Controls.Add(this.paypal_txt);
            this.Controls.Add(this.email_lbl);
            this.Controls.Add(this.email_txt);
            this.Controls.Add(this.last_lbl);
            this.Controls.Add(this.last_txt);
            this.Controls.Add(this.name_lbl);
            this.Controls.Add(this.name_txt);
            this.Controls.Add(this.user_lbl);
            this.Controls.Add(this.user_txt);
            this.Controls.Add(this.register_btn);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button register_btn;
        private System.Windows.Forms.Label user_lbl;
        private System.Windows.Forms.TextBox user_txt;
        private System.Windows.Forms.Label name_lbl;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Label last_lbl;
        private System.Windows.Forms.TextBox last_txt;
        private System.Windows.Forms.Label email_lbl;
        private System.Windows.Forms.TextBox email_txt;
        private System.Windows.Forms.Label paypal_lbl;
        private System.Windows.Forms.TextBox paypal_txt;
        private System.Windows.Forms.Label pass_lbl;
        private System.Windows.Forms.TextBox pass_txt;
        private System.Windows.Forms.Label birth_lbl;
        private System.Windows.Forms.TextBox birth_txt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}