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
            this.cb_pause = new System.Windows.Forms.CheckBox();
            this.robotsBox = new System.Windows.Forms.GroupBox();
            this.robotsNumber = new System.Windows.Forms.NumericUpDown();
            this.RobotsTable = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alpha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goalsBox = new System.Windows.Forms.GroupBox();
            this.goalsNumber = new System.Windows.Forms.NumericUpDown();
            this.GoalsTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.stopSim = new System.Windows.Forms.Button();
            this.set_Scene = new System.Windows.Forms.Button();
            this.obstaclesTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obstaclesBox = new System.Windows.Forms.GroupBox();
            this.obstaclesNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.robotsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.robotsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotsTable)).BeginInit();
            this.goalsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goalsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoalsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstaclesTable)).BeginInit();
            this.obstaclesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obstaclesNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb.Location = new System.Drawing.Point(18, 18);
            this.pb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(700, 537);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            this.pb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetPriorityPoint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cb_pause
            // 
            this.cb_pause.AutoSize = true;
            this.cb_pause.Location = new System.Drawing.Point(1148, 527);
            this.cb_pause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_pause.Name = "cb_pause";
            this.cb_pause.Size = new System.Drawing.Size(80, 24);
            this.cb_pause.TabIndex = 9;
            this.cb_pause.Text = "Pause";
            this.cb_pause.UseVisualStyleBackColor = true;
            // 
            // robotsBox
            // 
            this.robotsBox.Controls.Add(this.robotsNumber);
            this.robotsBox.Controls.Add(this.RobotsTable);
            this.robotsBox.Location = new System.Drawing.Point(764, 20);
            this.robotsBox.Name = "robotsBox";
            this.robotsBox.Size = new System.Drawing.Size(200, 374);
            this.robotsBox.TabIndex = 99;
            this.robotsBox.TabStop = false;
            this.robotsBox.Text = "Robots";
            // 
            // robotsNumber
            // 
            this.robotsNumber.Location = new System.Drawing.Point(6, 342);
            this.robotsNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.robotsNumber.Name = "robotsNumber";
            this.robotsNumber.Size = new System.Drawing.Size(185, 26);
            this.robotsNumber.TabIndex = 108;
            this.robotsNumber.ValueChanged += new System.EventHandler(this.robotsNumber_ValueChanged);
            // 
            // RobotsTable
            // 
            this.RobotsTable.AllowUserToAddRows = false;
            this.RobotsTable.AllowUserToDeleteRows = false;
            this.RobotsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RobotsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y,
            this.Alpha});
            this.RobotsTable.Location = new System.Drawing.Point(6, 26);
            this.RobotsTable.Name = "RobotsTable";
            this.RobotsTable.RowHeadersVisible = false;
            this.RobotsTable.RowHeadersWidth = 10;
            this.RobotsTable.RowTemplate.Height = 28;
            this.RobotsTable.Size = new System.Drawing.Size(185, 300);
            this.RobotsTable.TabIndex = 103;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.MinimumWidth = 40;
            this.X.Name = "X";
            this.X.Width = 40;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.MinimumWidth = 40;
            this.Y.Name = "Y";
            this.Y.Width = 40;
            // 
            // Alpha
            // 
            this.Alpha.HeaderText = "Alpha";
            this.Alpha.MinimumWidth = 40;
            this.Alpha.Name = "Alpha";
            this.Alpha.Width = 40;
            // 
            // goalsBox
            // 
            this.goalsBox.Controls.Add(this.goalsNumber);
            this.goalsBox.Controls.Add(this.GoalsTable);
            this.goalsBox.Location = new System.Drawing.Point(970, 20);
            this.goalsBox.Name = "goalsBox";
            this.goalsBox.Size = new System.Drawing.Size(141, 374);
            this.goalsBox.TabIndex = 100;
            this.goalsBox.TabStop = false;
            this.goalsBox.Text = "Goals";
            // 
            // goalsNumber
            // 
            this.goalsNumber.Location = new System.Drawing.Point(6, 342);
            this.goalsNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.goalsNumber.Name = "goalsNumber";
            this.goalsNumber.Size = new System.Drawing.Size(124, 26);
            this.goalsNumber.TabIndex = 109;
            this.goalsNumber.ValueChanged += new System.EventHandler(this.goalsNumber_ValueChanged);
            // 
            // GoalsTable
            // 
            this.GoalsTable.AllowUserToAddRows = false;
            this.GoalsTable.AllowUserToDeleteRows = false;
            this.GoalsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GoalsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.GoalsTable.Location = new System.Drawing.Point(6, 25);
            this.GoalsTable.Name = "GoalsTable";
            this.GoalsTable.RowHeadersVisible = false;
            this.GoalsTable.RowHeadersWidth = 10;
            this.GoalsTable.RowTemplate.Height = 28;
            this.GoalsTable.Size = new System.Drawing.Size(124, 300);
            this.GoalsTable.TabIndex = 104;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "X";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Y";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1235, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 101;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.start_simulation);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(764, 455);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(336, 96);
            this.logTextBox.TabIndex = 106;
            this.logTextBox.Text = "";
            // 
            // stopSim
            // 
            this.stopSim.Location = new System.Drawing.Point(1235, 520);
            this.stopSim.Name = "stopSim";
            this.stopSim.Size = new System.Drawing.Size(75, 31);
            this.stopSim.TabIndex = 107;
            this.stopSim.Text = "stop";
            this.stopSim.UseVisualStyleBackColor = true;
            this.stopSim.Click += new System.EventHandler(this.StopSimClick);
            // 
            // set_Scene
            // 
            this.set_Scene.Location = new System.Drawing.Point(1230, 431);
            this.set_Scene.Name = "set_Scene";
            this.set_Scene.Size = new System.Drawing.Size(80, 29);
            this.set_Scene.TabIndex = 103;
            this.set_Scene.Text = "set";
            this.set_Scene.UseVisualStyleBackColor = true;
            this.set_Scene.Click += new System.EventHandler(this.setSceneClick);
            // 
            // obstaclesTable
            // 
            this.obstaclesTable.AllowUserToAddRows = false;
            this.obstaclesTable.AllowUserToDeleteRows = false;
            this.obstaclesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.obstaclesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.R});
            this.obstaclesTable.Location = new System.Drawing.Point(6, 26);
            this.obstaclesTable.Name = "obstaclesTable";
            this.obstaclesTable.RowHeadersVisible = false;
            this.obstaclesTable.RowHeadersWidth = 10;
            this.obstaclesTable.RowTemplate.Height = 28;
            this.obstaclesTable.Size = new System.Drawing.Size(176, 300);
            this.obstaclesTable.TabIndex = 104;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "X";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Y";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 40;
            // 
            // R
            // 
            this.R.HeaderText = "R";
            this.R.MinimumWidth = 40;
            this.R.Name = "R";
            this.R.Width = 40;
            // 
            // obstaclesBox
            // 
            this.obstaclesBox.Controls.Add(this.obstaclesNumber);
            this.obstaclesBox.Controls.Add(this.obstaclesTable);
            this.obstaclesBox.Location = new System.Drawing.Point(1117, 20);
            this.obstaclesBox.Name = "obstaclesBox";
            this.obstaclesBox.Size = new System.Drawing.Size(193, 374);
            this.obstaclesBox.TabIndex = 105;
            this.obstaclesBox.TabStop = false;
            this.obstaclesBox.Text = "Obstacles";
            // 
            // obstaclesNumber
            // 
            this.obstaclesNumber.Location = new System.Drawing.Point(6, 342);
            this.obstaclesNumber.Name = "obstaclesNumber";
            this.obstaclesNumber.Size = new System.Drawing.Size(181, 26);
            this.obstaclesNumber.TabIndex = 110;
            this.obstaclesNumber.ValueChanged += new System.EventHandler(this.obstaclesNumber_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 572);
            this.Controls.Add(this.stopSim);
            this.Controls.Add(this.set_Scene);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.goalsBox);
            this.Controls.Add(this.robotsBox);
            this.Controls.Add(this.cb_pause);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.obstaclesBox);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.robotsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.robotsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotsTable)).EndInit();
            this.goalsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.goalsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoalsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstaclesTable)).EndInit();
            this.obstaclesBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.obstaclesNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cb_pause;
        private System.Windows.Forms.GroupBox robotsBox;
        private System.Windows.Forms.GroupBox goalsBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView RobotsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alpha;
        private System.Windows.Forms.DataGridView GoalsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.Button stopSim;
        private System.Windows.Forms.NumericUpDown robotsNumber;
        private System.Windows.Forms.NumericUpDown goalsNumber;
        private System.Windows.Forms.Button set_Scene;
        private System.Windows.Forms.DataGridView obstaclesTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn R;
        private System.Windows.Forms.GroupBox obstaclesBox;
        private System.Windows.Forms.NumericUpDown obstaclesNumber;
    }
}

