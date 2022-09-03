namespace 扫雷
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.text_width = new System.Windows.Forms.TextBox();
            this.text_height = new System.Windows.Forms.TextBox();
            this.button_generate = new System.Windows.Forms.Button();
            this.text_mine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timebar = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_restart = new System.Windows.Forms.Button();
            this.flag_display = new System.Windows.Forms.Label();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            this.SuspendLayout();
            // 
            // text_width
            // 
            this.text_width.Location = new System.Drawing.Point(39, 35);
            this.text_width.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.text_width.Name = "text_width";
            this.text_width.Size = new System.Drawing.Size(65, 25);
            this.text_width.TabIndex = 2;
            this.text_width.Text = "16";
            // 
            // text_height
            // 
            this.text_height.Location = new System.Drawing.Point(135, 35);
            this.text_height.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.text_height.Name = "text_height";
            this.text_height.Size = new System.Drawing.Size(65, 25);
            this.text_height.TabIndex = 3;
            this.text_height.Text = "16";
            // 
            // button_generate
            // 
            this.button_generate.Location = new System.Drawing.Point(307, 34);
            this.button_generate.Margin = new System.Windows.Forms.Padding(4);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(84, 25);
            this.button_generate.TabIndex = 5;
            this.button_generate.Text = "生成";
            this.button_generate.UseVisualStyleBackColor = true;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // text_mine
            // 
            this.text_mine.Location = new System.Drawing.Point(247, 35);
            this.text_mine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.text_mine.Name = "text_mine";
            this.text_mine.Size = new System.Drawing.Size(48, 25);
            this.text_mine.TabIndex = 4;
            this.text_mine.Text = "40";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "宽";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "高";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "雷数";
            // 
            // timebar
            // 
            this.timebar.AutoSize = true;
            this.timebar.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timebar.ForeColor = System.Drawing.Color.Red;
            this.timebar.Location = new System.Drawing.Point(72, 26);
            this.timebar.Name = "timebar";
            this.timebar.Size = new System.Drawing.Size(28, 30);
            this.timebar.TabIndex = 10;
            this.timebar.Text = "0";
            this.timebar.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_restart
            // 
            this.button_restart.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_restart.Location = new System.Drawing.Point(135, 26);
            this.button_restart.Margin = new System.Windows.Forms.Padding(4);
            this.button_restart.Name = "button_restart";
            this.button_restart.Size = new System.Drawing.Size(164, 48);
            this.button_restart.TabIndex = 11;
            this.button_restart.Text = "重新开始";
            this.button_restart.UseVisualStyleBackColor = true;
            this.button_restart.Visible = false;
            this.button_restart.Click += new System.EventHandler(this.button_restart_Click);
            // 
            // flag_display
            // 
            this.flag_display.AutoSize = true;
            this.flag_display.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flag_display.ForeColor = System.Drawing.Color.Red;
            this.flag_display.Location = new System.Drawing.Point(324, 25);
            this.flag_display.Name = "flag_display";
            this.flag_display.Size = new System.Drawing.Size(58, 30);
            this.flag_display.TabIndex = 12;
            this.flag_display.Text = "000";
            this.flag_display.Visible = false;
            // 
            // pic1
            // 
            this.pic1.Image = ((System.Drawing.Image)(resources.GetObject("pic1.Image")));
            this.pic1.Location = new System.Drawing.Point(1, 0);
            this.pic1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(25, 25);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 13;
            this.pic1.TabStop = false;
            this.pic1.Visible = false;
            // 
            // pic2
            // 
            this.pic2.Image = ((System.Drawing.Image)(resources.GetObject("pic2.Image")));
            this.pic2.Location = new System.Drawing.Point(44, 30);
            this.pic2.Margin = new System.Windows.Forms.Padding(4);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(27, 25);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 14;
            this.pic2.TabStop = false;
            this.pic2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 440);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.timebar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_mine);
            this.Controls.Add(this.button_generate);
            this.Controls.Add(this.text_height);
            this.Controls.Add(this.text_width);
            this.Controls.Add(this.button_restart);
            this.Controls.Add(this.flag_display);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "你瞅啥？";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_width;
        private System.Windows.Forms.TextBox text_height;
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.TextBox text_mine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label timebar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_restart;
        private System.Windows.Forms.Label flag_display;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox pic2;
    }
}

