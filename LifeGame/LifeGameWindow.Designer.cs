
namespace LifeGame
{
    partial class LifeGameWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nud_duration = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Change = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_height = new System.Windows.Forms.NumericUpDown();
            this.nud_width = new System.Windows.Forms.NumericUpDown();
            this.lifeGamePanel = new LifeGame.LifeGameControl();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_duration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_width)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Duration:";
            // 
            // nud_duration
            // 
            this.nud_duration.DecimalPlaces = 1;
            this.nud_duration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_duration.Location = new System.Drawing.Point(20, 27);
            this.nud_duration.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nud_duration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_duration.Name = "nud_duration";
            this.nud_duration.Size = new System.Drawing.Size(48, 23);
            this.nud_duration.TabIndex = 1;
            this.nud_duration.Value = new decimal(new int[] {
            13,
            0,
            0,
            65536});
            this.nud_duration.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "s";
            // 
            // btn_Change
            // 
            this.btn_Change.Enabled = false;
            this.btn_Change.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btn_Change.Location = new System.Drawing.Point(12, 144);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(116, 25);
            this.btn_Change.TabIndex = 4;
            this.btn_Change.Text = "Change";
            this.btn_Change.UseVisualStyleBackColor = true;
            this.btn_Change.Click += new System.EventHandler(this.btn_Change_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "GridHeight:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "GridWidth";
            // 
            // nud_height
            // 
            this.nud_height.Location = new System.Drawing.Point(20, 71);
            this.nud_height.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nud_height.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_height.Name = "nud_height";
            this.nud_height.Size = new System.Drawing.Size(48, 23);
            this.nud_height.TabIndex = 7;
            this.nud_height.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_height.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // nud_width
            // 
            this.nud_width.Location = new System.Drawing.Point(20, 115);
            this.nud_width.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nud_width.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_width.Name = "nud_width";
            this.nud_width.Size = new System.Drawing.Size(48, 23);
            this.nud_width.TabIndex = 8;
            this.nud_width.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_width.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // lifeGamePanel
            // 
            this.lifeGamePanel.BackColor = System.Drawing.Color.White;
            this.lifeGamePanel.CellCount = 0;
            this.lifeGamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lifeGamePanel.Duration = 1300;
            this.lifeGamePanel.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lifeGamePanel.Location = new System.Drawing.Point(146, 0);
            this.lifeGamePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lifeGamePanel.Name = "lifeGamePanel";
            this.lifeGamePanel.NowStatus = LifeGame.GameStatus.Stopped;
            this.lifeGamePanel.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lifeGamePanel.Period = 0;
            this.lifeGamePanel.Size = new System.Drawing.Size(764, 587);
            this.lifeGamePanel.TabIndex = 11;
            this.lifeGamePanel.Stopped += new LifeGame.LifeGameControl.GameStoppedHandle(this.lifeGamePanel_Stopped);
            this.lifeGamePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lifeGamePanel_MouseUp);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(12, 549);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(116, 26);
            this.btn_Stop.TabIndex = 12;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(12, 517);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(116, 26);
            this.btn_Start.TabIndex = 13;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btn_Clear.ForeColor = System.Drawing.Color.Red;
            this.btn_Clear.Location = new System.Drawing.Point(12, 293);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(116, 25);
            this.btn_Clear.TabIndex = 14;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.btn_load);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Clear);
            this.panel1.Controls.Add(this.nud_duration);
            this.panel1.Controls.Add(this.btn_Start);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_Stop);
            this.panel1.Controls.Add(this.btn_Change);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nud_width);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nud_height);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 587);
            this.panel1.TabIndex = 15;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btn_save.Location = new System.Drawing.Point(12, 355);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(116, 25);
            this.btn_save.TabIndex = 16;
            this.btn_save.Text = "Save as Template";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_load
            // 
            this.btn_load.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btn_load.Location = new System.Drawing.Point(12, 324);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(116, 25);
            this.btn_load.TabIndex = 15;
            this.btn_load.Text = "Open Template";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // LifeGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 587);
            this.Controls.Add(this.lifeGamePanel);
            this.Controls.Add(this.panel1);
            this.Name = "LifeGameWindow";
            this.Text = "Life Game";
            ((System.ComponentModel.ISupportInitialize)(this.nud_duration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_width)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_duration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_height;
        private LifeGameControl lifeGamePanel;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.NumericUpDown nud_width;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_load;
    }
}

