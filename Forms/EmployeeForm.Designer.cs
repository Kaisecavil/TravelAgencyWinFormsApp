namespace TravelAgencyWinFormsApp.Forms
{
    partial class EmployeeForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.passport = new System.Windows.Forms.Label();
            this.oName = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.sName = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.fName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(257, 254);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(248, 29);
            this.buttonCancel.TabIndex = 22;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(257, 145);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(248, 29);
            this.buttonOk.TabIndex = 21;
            this.buttonOk.Text = "Сохранить";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // passport
            // 
            this.passport.AutoSize = true;
            this.passport.Location = new System.Drawing.Point(257, 16);
            this.passport.Name = "passport";
            this.passport.Size = new System.Drawing.Size(86, 20);
            this.passport.TabIndex = 20;
            this.passport.Text = "Должность";
            // 
            // oName
            // 
            this.oName.AutoSize = true;
            this.oName.Location = new System.Drawing.Point(19, 219);
            this.oName.Name = "oName";
            this.oName.Size = new System.Drawing.Size(72, 20);
            this.oName.TabIndex = 18;
            this.oName.Text = "Отчество";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(19, 256);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(154, 27);
            this.textBox3.TabIndex = 17;
            // 
            // sName
            // 
            this.sName.AutoSize = true;
            this.sName.Location = new System.Drawing.Point(19, 110);
            this.sName.Name = "sName";
            this.sName.Size = new System.Drawing.Size(73, 20);
            this.sName.TabIndex = 16;
            this.sName.Text = "Фамилия";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(19, 147);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 27);
            this.textBox2.TabIndex = 15;
            // 
            // fName
            // 
            this.fName.AutoSize = true;
            this.fName.Location = new System.Drawing.Point(19, 16);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(39, 20);
            this.fName.TabIndex = 14;
            this.fName.Text = "Имя";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 27);
            this.textBox1.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(257, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(248, 28);
            this.comboBox1.TabIndex = 33;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 378);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.passport);
            this.Controls.Add(this.oName);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.sName);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.fName);
            this.Controls.Add(this.textBox1);
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonCancel;
        private Button buttonOk;
        private Label passport;
        private Label oName;
        private TextBox textBox3;
        private Label sName;
        private TextBox textBox2;
        private Label fName;
        private TextBox textBox1;
        private ComboBox comboBox1;
    }
}