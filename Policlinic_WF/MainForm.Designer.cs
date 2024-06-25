namespace Policlinic_WF
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btnVisits = new System.Windows.Forms.Button();
            this.btnPacient = new System.Windows.Forms.Button();
            this.btbDoctors = new System.Windows.Forms.Button();
            this.btnDivision = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1122, 35);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(757, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поликлинические отделения ГБУЗ Московской Области «Дмитровская больница»";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.btnVisits);
            this.panel2.Controls.Add(this.btnPacient);
            this.panel2.Controls.Add(this.btbDoctors);
            this.panel2.Controls.Add(this.btnDivision);
            this.panel2.Location = new System.Drawing.Point(-1, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 453);
            this.panel2.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(0, 398);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(151, 44);
            this.button5.TabIndex = 6;
            this.button5.Text = "Отчеты";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // btnVisits
            // 
            this.btnVisits.BackColor = System.Drawing.Color.Transparent;
            this.btnVisits.FlatAppearance.BorderSize = 0;
            this.btnVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVisits.Location = new System.Drawing.Point(-1, 151);
            this.btnVisits.Name = "btnVisits";
            this.btnVisits.Size = new System.Drawing.Size(153, 44);
            this.btnVisits.TabIndex = 5;
            this.btnVisits.Text = "Посещения";
            this.btnVisits.UseVisualStyleBackColor = false;
            // 
            // btnPacient
            // 
            this.btnPacient.BackColor = System.Drawing.Color.Transparent;
            this.btnPacient.FlatAppearance.BorderSize = 0;
            this.btnPacient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPacient.Location = new System.Drawing.Point(-1, 101);
            this.btnPacient.Name = "btnPacient";
            this.btnPacient.Size = new System.Drawing.Size(151, 44);
            this.btnPacient.TabIndex = 4;
            this.btnPacient.Text = "Пациенты";
            this.btnPacient.UseVisualStyleBackColor = false;
            this.btnPacient.Click += new System.EventHandler(this.btnPacient_Click);
            // 
            // btbDoctors
            // 
            this.btbDoctors.BackColor = System.Drawing.Color.Transparent;
            this.btbDoctors.FlatAppearance.BorderSize = 0;
            this.btbDoctors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btbDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btbDoctors.Location = new System.Drawing.Point(0, 51);
            this.btbDoctors.Name = "btbDoctors";
            this.btbDoctors.Size = new System.Drawing.Size(150, 44);
            this.btbDoctors.TabIndex = 3;
            this.btbDoctors.Text = "Врачи";
            this.btbDoctors.UseVisualStyleBackColor = false;
            this.btbDoctors.Click += new System.EventHandler(this.btbDoctors_Click);
            // 
            // btnDivision
            // 
            this.btnDivision.BackColor = System.Drawing.Color.Transparent;
            this.btnDivision.FlatAppearance.BorderSize = 0;
            this.btnDivision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivision.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDivision.Location = new System.Drawing.Point(0, 3);
            this.btnDivision.Name = "btnDivision";
            this.btnDivision.Size = new System.Drawing.Size(150, 44);
            this.btnDivision.TabIndex = 2;
            this.btnDivision.Text = "Подразделения";
            this.btnDivision.UseVisualStyleBackColor = false;
            this.btnDivision.Click += new System.EventHandler(this.btnDivision_Click);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(150, 34);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(960, 453);
            this.panelMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 487);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1126, 526);
            this.MinimumSize = new System.Drawing.Size(1126, 526);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поликлинические отделения ГБУЗ Московской Области «Дмитровская больница»";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDivision;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnVisits;
        private System.Windows.Forms.Button btnPacient;
        private System.Windows.Forms.Button btbDoctors;
        private System.Windows.Forms.Panel panelMain;
    }
}

