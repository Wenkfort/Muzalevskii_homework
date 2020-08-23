namespace RobotProject
{
    partial class Form1
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
            this.pb = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_xya = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtb_sensors = new System.Windows.Forms.RichTextBox();
            this.rtb_dataset = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_pause = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb.Location = new System.Drawing.Point(12, 12);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(749, 583);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            this.pb.DoubleClick += new System.EventHandler(this.Pb_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rtb_log
            // 
            this.rtb_log.Location = new System.Drawing.Point(767, 194);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.ReadOnly = true;
            this.rtb_log.Size = new System.Drawing.Size(222, 401);
            this.rtb_log.TabIndex = 1;
            this.rtb_log.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(767, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "V, W";
            // 
            // tb_xya
            // 
            this.tb_xya.Location = new System.Drawing.Point(767, 26);
            this.tb_xya.Name = "tb_xya";
            this.tb_xya.ReadOnly = true;
            this.tb_xya.Size = new System.Drawing.Size(222, 20);
            this.tb_xya.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(767, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "X, Y, A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(767, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sensors";
            // 
            // rtb_sensors
            // 
            this.rtb_sensors.Location = new System.Drawing.Point(767, 67);
            this.rtb_sensors.Name = "rtb_sensors";
            this.rtb_sensors.ReadOnly = true;
            this.rtb_sensors.Size = new System.Drawing.Size(222, 108);
            this.rtb_sensors.TabIndex = 5;
            this.rtb_sensors.Text = "";
            // 
            // rtb_dataset
            // 
            this.rtb_dataset.Location = new System.Drawing.Point(995, 55);
            this.rtb_dataset.Name = "rtb_dataset";
            this.rtb_dataset.ReadOnly = true;
            this.rtb_dataset.Size = new System.Drawing.Size(175, 537);
            this.rtb_dataset.TabIndex = 7;
            this.rtb_dataset.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1018, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dataset \r\nx_goal, y_goal, a_steer";
            // 
            // cb_pause
            // 
            this.cb_pause.AutoSize = true;
            this.cb_pause.Location = new System.Drawing.Point(1107, 12);
            this.cb_pause.Name = "cb_pause";
            this.cb_pause.Size = new System.Drawing.Size(56, 17);
            this.cb_pause.TabIndex = 9;
            this.cb_pause.Text = "Pause";
            this.cb_pause.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 604);
            this.Controls.Add(this.cb_pause);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtb_dataset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtb_sensors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_xya);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_log);
            this.Controls.Add(this.pb);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_xya;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtb_sensors;
        private System.Windows.Forms.RichTextBox rtb_dataset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_pause;
    }
}

