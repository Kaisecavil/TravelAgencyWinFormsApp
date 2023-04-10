namespace TravelAgencyWinFormsApp
{
    partial class ClientForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.fName = new System.Windows.Forms.Label();
            this.sName = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.oName = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.passport = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 27);
            this.textBox1.TabIndex = 1;
            // 
            // fName
            // 
            this.fName.AutoSize = true;
            this.fName.Location = new System.Drawing.Point(12, 9);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(39, 20);
            this.fName.TabIndex = 2;
            this.fName.Text = "Имя";
            // 
            // sName
            // 
            this.sName.AutoSize = true;
            this.sName.Location = new System.Drawing.Point(12, 103);
            this.sName.Name = "sName";
            this.sName.Size = new System.Drawing.Size(73, 20);
            this.sName.TabIndex = 4;
            this.sName.Text = "Фамилия";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 140);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 27);
            this.textBox2.TabIndex = 3;
            // 
            // oName
            // 
            this.oName.AutoSize = true;
            this.oName.Location = new System.Drawing.Point(12, 212);
            this.oName.Name = "oName";
            this.oName.Size = new System.Drawing.Size(72, 20);
            this.oName.TabIndex = 6;
            this.oName.Text = "Отчество";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 249);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(154, 27);
            this.textBox3.TabIndex = 5;
            // 
            // passport
            // 
            this.passport.AutoSize = true;
            this.passport.Location = new System.Drawing.Point(250, 9);
            this.passport.Name = "passport";
            this.passport.Size = new System.Drawing.Size(68, 20);
            this.passport.TabIndex = 8;
            this.passport.Text = "Паспорт";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(250, 46);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(154, 27);
            this.textBox4.TabIndex = 7;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(250, 138);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(154, 29);
            this.buttonOk.TabIndex = 11;
            this.buttonOk.Text = "Сохранить";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(250, 247);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(154, 29);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 335);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.passport);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.oName);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.sName);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.fName);
            this.Controls.Add(this.textBox1);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Label fName;
        private Label sName;
        private TextBox textBox2;
        private Label oName;
        private TextBox textBox3;
        private Label passport;
        private TextBox textBox4;
        private Button buttonOk;
        private Button buttonCancel;
    }
}