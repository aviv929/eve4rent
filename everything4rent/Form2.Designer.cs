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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // register_btn
            // 
            this.register_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.register_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.register_btn.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_btn.Image = ((System.Drawing.Image)(resources.GetObject("register_btn.Image")));
            this.register_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.register_btn.Location = new System.Drawing.Point(-1, 460);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(380, 64);
            this.register_btn.TabIndex = 0;
            this.register_btn.Text = "Create Account";
            this.register_btn.UseVisualStyleBackColor = false;
            this.register_btn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // user_lbl
            // 
            this.user_lbl.AutoSize = true;
            this.user_lbl.BackColor = System.Drawing.Color.Transparent;
            this.user_lbl.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_lbl.Location = new System.Drawing.Point(23, 64);
            this.user_lbl.Name = "user_lbl";
            this.user_lbl.Size = new System.Drawing.Size(85, 19);
            this.user_lbl.TabIndex = 5;
            this.user_lbl.Text = "User name:";
            // 
            // user_txt
            // 
            this.user_txt.Location = new System.Drawing.Point(152, 60);
            this.user_txt.Name = "user_txt";
            this.user_txt.Size = new System.Drawing.Size(192, 22);
            this.user_txt.TabIndex = 4;
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.BackColor = System.Drawing.Color.Transparent;
            this.name_lbl.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_lbl.Location = new System.Drawing.Point(23, 176);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(82, 19);
            this.name_lbl.TabIndex = 9;
            this.name_lbl.Text = "First name:";
            this.name_lbl.Click += new System.EventHandler(this.name_lbl_Click);
            // 
            // name_txt
            // 
            this.name_txt.Location = new System.Drawing.Point(152, 174);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(192, 22);
            this.name_txt.TabIndex = 10;
            // 
            // last_lbl
            // 
            this.last_lbl.AutoSize = true;
            this.last_lbl.BackColor = System.Drawing.Color.Transparent;
            this.last_lbl.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.last_lbl.Location = new System.Drawing.Point(23, 219);
            this.last_lbl.Name = "last_lbl";
            this.last_lbl.Size = new System.Drawing.Size(84, 19);
            this.last_lbl.TabIndex = 11;
            this.last_lbl.Text = "Last name:";
            // 
            // last_txt
            // 
            this.last_txt.Location = new System.Drawing.Point(152, 215);
            this.last_txt.Name = "last_txt";
            this.last_txt.Size = new System.Drawing.Size(192, 22);
            this.last_txt.TabIndex = 12;
            // 
            // email_lbl
            // 
            this.email_lbl.AutoSize = true;
            this.email_lbl.BackColor = System.Drawing.Color.Transparent;
            this.email_lbl.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_lbl.Location = new System.Drawing.Point(23, 138);
            this.email_lbl.Name = "email_lbl";
            this.email_lbl.Size = new System.Drawing.Size(50, 19);
            this.email_lbl.TabIndex = 13;
            this.email_lbl.Text = "Email:";
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(152, 137);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(192, 22);
            this.email_txt.TabIndex = 8;
            // 
            // paypal_lbl
            // 
            this.paypal_lbl.AutoSize = true;
            this.paypal_lbl.BackColor = System.Drawing.Color.Transparent;
            this.paypal_lbl.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paypal_lbl.Location = new System.Drawing.Point(21, 338);
            this.paypal_lbl.Name = "paypal_lbl";
            this.paypal_lbl.Size = new System.Drawing.Size(125, 19);
            this.paypal_lbl.TabIndex = 15;
            this.paypal_lbl.Text = "Paypal Account:";
            // 
            // paypal_txt
            // 
            this.paypal_txt.Location = new System.Drawing.Point(152, 337);
            this.paypal_txt.Name = "paypal_txt";
            this.paypal_txt.Size = new System.Drawing.Size(192, 22);
            this.paypal_txt.TabIndex = 16;
            // 
            // pass_lbl
            // 
            this.pass_lbl.AutoSize = true;
            this.pass_lbl.BackColor = System.Drawing.Color.Transparent;
            this.pass_lbl.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass_lbl.Location = new System.Drawing.Point(23, 102);
            this.pass_lbl.Name = "pass_lbl";
            this.pass_lbl.Size = new System.Drawing.Size(76, 19);
            this.pass_lbl.TabIndex = 17;
            this.pass_lbl.Text = "Password:";
            // 
            // pass_txt
            // 
            this.pass_txt.Location = new System.Drawing.Point(152, 98);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.PasswordChar = '*';
            this.pass_txt.Size = new System.Drawing.Size(192, 22);
            this.pass_txt.TabIndex = 6;
            // 
            // birth_lbl
            // 
            this.birth_lbl.AutoSize = true;
            this.birth_lbl.BackColor = System.Drawing.Color.Transparent;
            this.birth_lbl.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birth_lbl.Location = new System.Drawing.Point(23, 298);
            this.birth_lbl.Name = "birth_lbl";
            this.birth_lbl.Size = new System.Drawing.Size(80, 19);
            this.birth_lbl.TabIndex = 19;
            this.birth_lbl.Text = "Birth Date:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CadetBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(25, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 34);
            this.button1.TabIndex = 20;
            this.button1.Text = "Picture";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(199, 384);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(152, 298);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.MaxDate = new System.DateTime(2000, 1, 10, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(192, 22);
            this.dateTimePicker1.TabIndex = 23;
            this.dateTimePicker1.Value = new System.DateTime(2000, 1, 10, 0, 0, 0, 0);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Location = new System.Drawing.Point(27, 259);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 21);
            this.radioButton1.TabIndex = 24;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Male";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.Location = new System.Drawing.Point(152, 259);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 21);
            this.radioButton2.TabIndex = 25;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Female";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(378, 521);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.birth_lbl);
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
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}