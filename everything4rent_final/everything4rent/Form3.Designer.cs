namespace everything4rent
{
    partial class Form3
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
            this.show_pnl = new System.Windows.Forms.Panel();
            this.items_show_lbl = new System.Windows.Forms.Label();
            this.adv_show_lbl = new System.Windows.Forms.Label();
            this.show_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // show_pnl
            // 
            this.show_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.show_pnl.Controls.Add(this.items_show_lbl);
            this.show_pnl.Controls.Add(this.adv_show_lbl);
            this.show_pnl.Location = new System.Drawing.Point(17, 12);
            this.show_pnl.Name = "show_pnl";
            this.show_pnl.Size = new System.Drawing.Size(1264, 648);
            this.show_pnl.TabIndex = 9;
            this.show_pnl.Visible = false;
            // 
            // items_show_lbl
            // 
            this.items_show_lbl.AutoSize = true;
            this.items_show_lbl.Location = new System.Drawing.Point(385, 21);
            this.items_show_lbl.Name = "items_show_lbl";
            this.items_show_lbl.Size = new System.Drawing.Size(46, 17);
            this.items_show_lbl.TabIndex = 1;
            this.items_show_lbl.Text = "label2";
            // 
            // adv_show_lbl
            // 
            this.adv_show_lbl.AutoSize = true;
            this.adv_show_lbl.Location = new System.Drawing.Point(12, 21);
            this.adv_show_lbl.Name = "adv_show_lbl";
            this.adv_show_lbl.Size = new System.Drawing.Size(46, 17);
            this.adv_show_lbl.TabIndex = 0;
            this.adv_show_lbl.Text = "label1";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 700);
            this.Controls.Add(this.show_pnl);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.show_pnl.ResumeLayout(false);
            this.show_pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel show_pnl;
        private System.Windows.Forms.Label items_show_lbl;
        private System.Windows.Forms.Label adv_show_lbl;
    }
}