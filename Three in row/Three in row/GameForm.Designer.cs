namespace Three_in_row
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
            this.Restart_button = new System.Windows.Forms.Button();
            this.Clear_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Start_button = new System.Windows.Forms.Button();
            this.ColorsBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MapBar = new System.Windows.Forms.TrackBar();
            this.SizeBar = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Maplabel = new System.Windows.Forms.Label();
            this.Sizelabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ColorsBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Restart_button
            // 
            this.Restart_button.Location = new System.Drawing.Point(127, 43);
            this.Restart_button.Name = "Restart_button";
            this.Restart_button.Size = new System.Drawing.Size(82, 28);
            this.Restart_button.TabIndex = 0;
            this.Restart_button.Text = "Restart";
            this.Restart_button.UseVisualStyleBackColor = true;
            this.Restart_button.Click += new System.EventHandler(this.Restart_click);
            // 
            // Clear_button
            // 
            this.Clear_button.Location = new System.Drawing.Point(127, 77);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(82, 28);
            this.Clear_button.TabIndex = 1;
            this.Clear_button.Text = "Clear";
            this.Clear_button.UseVisualStyleBackColor = true;
            this.Clear_button.Click += new System.EventHandler(this.Clear);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Score";
            // 
            // Start_button
            // 
            this.Start_button.Location = new System.Drawing.Point(127, 8);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(82, 28);
            this.Start_button.TabIndex = 4;
            this.Start_button.Text = "Start";
            this.Start_button.UseVisualStyleBackColor = true;
            this.Start_button.Click += new System.EventHandler(this.Start_Click);
            // 
            // ColorsBar
            // 
            this.ColorsBar.Location = new System.Drawing.Point(77, 162);
            this.ColorsBar.Minimum = 3;
            this.ColorsBar.Name = "ColorsBar";
            this.ColorsBar.Size = new System.Drawing.Size(104, 45);
            this.ColorsBar.TabIndex = 5;
            this.ColorsBar.Value = 6;
            this.ColorsBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Colors";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.Sizelabel);
            this.groupBox1.Controls.Add(this.Maplabel);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.SizeBar);
            this.groupBox1.Controls.Add(this.MapBar);
            this.groupBox1.Controls.Add(this.Start_button);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Restart_button);
            this.groupBox1.Controls.Add(this.Clear_button);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ColorsBar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(604, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 441);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // MapBar
            // 
            this.MapBar.LargeChange = 1;
            this.MapBar.Location = new System.Drawing.Point(77, 240);
            this.MapBar.Maximum = 15;
            this.MapBar.Minimum = 3;
            this.MapBar.Name = "MapBar";
            this.MapBar.Size = new System.Drawing.Size(104, 45);
            this.MapBar.TabIndex = 10;
            this.MapBar.Value = 8;
            this.MapBar.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // SizeBar
            // 
            this.SizeBar.Location = new System.Drawing.Point(14, 320);
            this.SizeBar.Maximum = 100;
            this.SizeBar.Minimum = 10;
            this.SizeBar.Name = "SizeBar";
            this.SizeBar.Size = new System.Drawing.Size(177, 45);
            this.SizeBar.SmallChange = 5;
            this.SizeBar.TabIndex = 11;
            this.SizeBar.Value = 50;
            this.SizeBar.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(89, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Size";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(108, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Map";
            // 
            // Maplabel
            // 
            this.Maplabel.AutoSize = true;
            this.Maplabel.Location = new System.Drawing.Point(116, 274);
            this.Maplabel.Name = "Maplabel";
            this.Maplabel.Size = new System.Drawing.Size(13, 13);
            this.Maplabel.TabIndex = 16;
            this.Maplabel.Text = "8";
            // 
            // Sizelabel
            // 
            this.Sizelabel.AutoSize = true;
            this.Sizelabel.Location = new System.Drawing.Point(98, 353);
            this.Sizelabel.Name = "Sizelabel";
            this.Sizelabel.Size = new System.Drawing.Size(19, 13);
            this.Sizelabel.TabIndex = 17;
            this.Sizelabel.Text = "50";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(58, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(178, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "15";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 441);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Three in  row";
            ((System.ComponentModel.ISupportInitialize)(this.ColorsBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Restart_button;
        private System.Windows.Forms.Button Clear_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.TrackBar ColorsBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Sizelabel;
        private System.Windows.Forms.Label Maplabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar SizeBar;
        private System.Windows.Forms.TrackBar MapBar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}

