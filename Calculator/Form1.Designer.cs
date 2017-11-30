namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.result_window = new System.Windows.Forms.RichTextBox();
            this.bt_MC = new System.Windows.Forms.Button();
            this.bt_Mplus = new System.Windows.Forms.Button();
            this.bt_Mminus = new System.Windows.Forms.Button();
            this.bt_Mread = new System.Windows.Forms.Button();
            this.bt_c = new System.Windows.Forms.Button();
            this.bt_pm = new System.Windows.Forms.Button();
            this.bt_div = new System.Windows.Forms.Button();
            this.bt_mul = new System.Windows.Forms.Button();
            this.bt_7 = new System.Windows.Forms.Button();
            this.bt_8 = new System.Windows.Forms.Button();
            this.bt_9 = new System.Windows.Forms.Button();
            this.bt_sub = new System.Windows.Forms.Button();
            this.bt_4 = new System.Windows.Forms.Button();
            this.bt_5 = new System.Windows.Forms.Button();
            this.bt_6 = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_1 = new System.Windows.Forms.Button();
            this.bt_2 = new System.Windows.Forms.Button();
            this.bt_3 = new System.Windows.Forms.Button();
            this.bt_result = new System.Windows.Forms.Button();
            this.bt_dot = new System.Windows.Forms.Button();
            this.bt_0 = new System.Windows.Forms.Button();
            this.history = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.서버연결ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.연결해제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // result_window
            // 
            this.result_window.Location = new System.Drawing.Point(12, 43);
            this.result_window.Name = "result_window";
            this.result_window.Size = new System.Drawing.Size(322, 82);
            this.result_window.TabIndex = 0;
            this.result_window.Text = "";
            // 
            // bt_MC
            // 
            this.bt_MC.Location = new System.Drawing.Point(12, 148);
            this.bt_MC.Name = "bt_MC";
            this.bt_MC.Size = new System.Drawing.Size(75, 25);
            this.bt_MC.TabIndex = 1;
            this.bt_MC.Text = "MC";
            this.bt_MC.UseVisualStyleBackColor = true;
            this.bt_MC.Click += new System.EventHandler(this.bt_MC_Click);
            this.bt_MC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_Mplus
            // 
            this.bt_Mplus.Location = new System.Drawing.Point(93, 148);
            this.bt_Mplus.Name = "bt_Mplus";
            this.bt_Mplus.Size = new System.Drawing.Size(75, 25);
            this.bt_Mplus.TabIndex = 1;
            this.bt_Mplus.Text = "M+";
            this.bt_Mplus.UseVisualStyleBackColor = true;
            this.bt_Mplus.Click += new System.EventHandler(this.bt_Mplus_Click);
            this.bt_Mplus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_Mminus
            // 
            this.bt_Mminus.Location = new System.Drawing.Point(174, 148);
            this.bt_Mminus.Name = "bt_Mminus";
            this.bt_Mminus.Size = new System.Drawing.Size(75, 25);
            this.bt_Mminus.TabIndex = 1;
            this.bt_Mminus.Text = "M-";
            this.bt_Mminus.UseVisualStyleBackColor = true;
            this.bt_Mminus.Click += new System.EventHandler(this.bt_Mminus_Click);
            this.bt_Mminus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_Mread
            // 
            this.bt_Mread.Location = new System.Drawing.Point(255, 148);
            this.bt_Mread.Name = "bt_Mread";
            this.bt_Mread.Size = new System.Drawing.Size(75, 25);
            this.bt_Mread.TabIndex = 1;
            this.bt_Mread.Text = "MR";
            this.bt_Mread.UseVisualStyleBackColor = true;
            this.bt_Mread.Click += new System.EventHandler(this.bt_Mread_Click);
            this.bt_Mread.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_c
            // 
            this.bt_c.Location = new System.Drawing.Point(12, 177);
            this.bt_c.Name = "bt_c";
            this.bt_c.Size = new System.Drawing.Size(30, 25);
            this.bt_c.TabIndex = 1;
            this.bt_c.Text = "C";
            this.bt_c.UseVisualStyleBackColor = true;
            this.bt_c.Click += new System.EventHandler(this.bt_c_Click);
            this.bt_c.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_pm
            // 
            this.bt_pm.Location = new System.Drawing.Point(93, 177);
            this.bt_pm.Name = "bt_pm";
            this.bt_pm.Size = new System.Drawing.Size(75, 25);
            this.bt_pm.TabIndex = 1;
            this.bt_pm.Text = "+-";
            this.bt_pm.UseVisualStyleBackColor = true;
            this.bt_pm.Click += new System.EventHandler(this.bt_pm_Click);
            this.bt_pm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_div
            // 
            this.bt_div.Location = new System.Drawing.Point(174, 177);
            this.bt_div.Name = "bt_div";
            this.bt_div.Size = new System.Drawing.Size(75, 25);
            this.bt_div.TabIndex = 1;
            this.bt_div.Text = "/";
            this.bt_div.UseVisualStyleBackColor = true;
            this.bt_div.Click += new System.EventHandler(this.oper_click);
            this.bt_div.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_mul
            // 
            this.bt_mul.Location = new System.Drawing.Point(255, 177);
            this.bt_mul.Name = "bt_mul";
            this.bt_mul.Size = new System.Drawing.Size(75, 25);
            this.bt_mul.TabIndex = 1;
            this.bt_mul.Text = "*";
            this.bt_mul.UseVisualStyleBackColor = true;
            this.bt_mul.Click += new System.EventHandler(this.oper_click);
            this.bt_mul.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_7
            // 
            this.bt_7.Location = new System.Drawing.Point(12, 206);
            this.bt_7.Name = "bt_7";
            this.bt_7.Size = new System.Drawing.Size(75, 25);
            this.bt_7.TabIndex = 1;
            this.bt_7.Text = "7";
            this.bt_7.UseVisualStyleBackColor = true;
            this.bt_7.Click += new System.EventHandler(this.num_click);
            this.bt_7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_8
            // 
            this.bt_8.Location = new System.Drawing.Point(93, 206);
            this.bt_8.Name = "bt_8";
            this.bt_8.Size = new System.Drawing.Size(75, 25);
            this.bt_8.TabIndex = 1;
            this.bt_8.Text = "8";
            this.bt_8.UseVisualStyleBackColor = true;
            this.bt_8.Click += new System.EventHandler(this.num_click);
            this.bt_8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_9
            // 
            this.bt_9.Location = new System.Drawing.Point(174, 206);
            this.bt_9.Name = "bt_9";
            this.bt_9.Size = new System.Drawing.Size(75, 25);
            this.bt_9.TabIndex = 1;
            this.bt_9.Text = "9";
            this.bt_9.UseVisualStyleBackColor = true;
            this.bt_9.Click += new System.EventHandler(this.num_click);
            this.bt_9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_sub
            // 
            this.bt_sub.Location = new System.Drawing.Point(255, 206);
            this.bt_sub.Name = "bt_sub";
            this.bt_sub.Size = new System.Drawing.Size(75, 25);
            this.bt_sub.TabIndex = 1;
            this.bt_sub.Text = "-";
            this.bt_sub.UseVisualStyleBackColor = true;
            this.bt_sub.Click += new System.EventHandler(this.oper_click);
            this.bt_sub.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_4
            // 
            this.bt_4.Location = new System.Drawing.Point(12, 235);
            this.bt_4.Name = "bt_4";
            this.bt_4.Size = new System.Drawing.Size(75, 25);
            this.bt_4.TabIndex = 1;
            this.bt_4.Text = "4";
            this.bt_4.UseVisualStyleBackColor = true;
            this.bt_4.Click += new System.EventHandler(this.num_click);
            this.bt_4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_5
            // 
            this.bt_5.Location = new System.Drawing.Point(93, 235);
            this.bt_5.Name = "bt_5";
            this.bt_5.Size = new System.Drawing.Size(75, 25);
            this.bt_5.TabIndex = 1;
            this.bt_5.Text = "5";
            this.bt_5.UseVisualStyleBackColor = true;
            this.bt_5.Click += new System.EventHandler(this.num_click);
            this.bt_5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_6
            // 
            this.bt_6.Location = new System.Drawing.Point(174, 235);
            this.bt_6.Name = "bt_6";
            this.bt_6.Size = new System.Drawing.Size(75, 25);
            this.bt_6.TabIndex = 1;
            this.bt_6.Text = "6";
            this.bt_6.UseVisualStyleBackColor = true;
            this.bt_6.Click += new System.EventHandler(this.num_click);
            this.bt_6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(255, 235);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 25);
            this.bt_add.TabIndex = 1;
            this.bt_add.Text = "+";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.oper_click);
            this.bt_add.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_1
            // 
            this.bt_1.Location = new System.Drawing.Point(12, 264);
            this.bt_1.Name = "bt_1";
            this.bt_1.Size = new System.Drawing.Size(75, 24);
            this.bt_1.TabIndex = 1;
            this.bt_1.Text = "1";
            this.bt_1.UseVisualStyleBackColor = true;
            this.bt_1.Click += new System.EventHandler(this.num_click);
            this.bt_1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_2
            // 
            this.bt_2.Location = new System.Drawing.Point(93, 264);
            this.bt_2.Name = "bt_2";
            this.bt_2.Size = new System.Drawing.Size(75, 24);
            this.bt_2.TabIndex = 1;
            this.bt_2.Text = "2";
            this.bt_2.UseVisualStyleBackColor = true;
            this.bt_2.Click += new System.EventHandler(this.num_click);
            this.bt_2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_3
            // 
            this.bt_3.Location = new System.Drawing.Point(174, 264);
            this.bt_3.Name = "bt_3";
            this.bt_3.Size = new System.Drawing.Size(75, 24);
            this.bt_3.TabIndex = 1;
            this.bt_3.Text = "3";
            this.bt_3.UseVisualStyleBackColor = true;
            this.bt_3.Click += new System.EventHandler(this.num_click);
            this.bt_3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_result
            // 
            this.bt_result.Location = new System.Drawing.Point(255, 264);
            this.bt_result.Name = "bt_result";
            this.bt_result.Size = new System.Drawing.Size(75, 54);
            this.bt_result.TabIndex = 1;
            this.bt_result.Text = "=";
            this.bt_result.UseVisualStyleBackColor = true;
            this.bt_result.Click += new System.EventHandler(this.bt_result_Click);
            this.bt_result.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_dot
            // 
            this.bt_dot.Location = new System.Drawing.Point(174, 294);
            this.bt_dot.Name = "bt_dot";
            this.bt_dot.Size = new System.Drawing.Size(75, 24);
            this.bt_dot.TabIndex = 1;
            this.bt_dot.Text = ".";
            this.bt_dot.UseVisualStyleBackColor = true;
            this.bt_dot.Click += new System.EventHandler(this.bt_dot_Click);
            this.bt_dot.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // bt_0
            // 
            this.bt_0.Location = new System.Drawing.Point(12, 294);
            this.bt_0.Name = "bt_0";
            this.bt_0.Size = new System.Drawing.Size(156, 24);
            this.bt_0.TabIndex = 1;
            this.bt_0.Text = "0";
            this.bt_0.UseVisualStyleBackColor = true;
            this.bt_0.Click += new System.EventHandler(this.bt_0_Click);
            this.bt_0.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(341, 43);
            this.history.Name = "history";
            this.history.ReadOnly = true;
            this.history.Size = new System.Drawing.Size(317, 277);
            this.history.TabIndex = 2;
            this.history.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(670, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메뉴ToolStripMenuItem
            // 
            this.메뉴ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.서버연결ToolStripMenuItem,
            this.연결해제ToolStripMenuItem});
            this.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem";
            this.메뉴ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.메뉴ToolStripMenuItem.Text = "메뉴";
            // 
            // 서버연결ToolStripMenuItem
            // 
            this.서버연결ToolStripMenuItem.Name = "서버연결ToolStripMenuItem";
            this.서버연결ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.서버연결ToolStripMenuItem.Text = "서버연결";
            this.서버연결ToolStripMenuItem.Click += new System.EventHandler(this.서버연결ToolStripMenuItem_Click);
            // 
            // 연결해제ToolStripMenuItem
            // 
            this.연결해제ToolStripMenuItem.Name = "연결해제ToolStripMenuItem";
            this.연결해제ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.연결해제ToolStripMenuItem.Text = "연결해제";
            this.연결해제ToolStripMenuItem.Click += new System.EventHandler(this.연결해제ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "CE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.bt_ce_Click);
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bt_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 337);
            this.Controls.Add(this.history);
            this.Controls.Add(this.bt_result);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.bt_sub);
            this.Controls.Add(this.bt_mul);
            this.Controls.Add(this.bt_Mread);
            this.Controls.Add(this.bt_0);
            this.Controls.Add(this.bt_dot);
            this.Controls.Add(this.bt_3);
            this.Controls.Add(this.bt_6);
            this.Controls.Add(this.bt_9);
            this.Controls.Add(this.bt_div);
            this.Controls.Add(this.bt_Mminus);
            this.Controls.Add(this.bt_2);
            this.Controls.Add(this.bt_1);
            this.Controls.Add(this.bt_5);
            this.Controls.Add(this.bt_4);
            this.Controls.Add(this.bt_8);
            this.Controls.Add(this.bt_7);
            this.Controls.Add(this.bt_pm);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_c);
            this.Controls.Add(this.bt_Mplus);
            this.Controls.Add(this.bt_MC);
            this.Controls.Add(this.result_window);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox result_window;
        private System.Windows.Forms.Button bt_MC;
        private System.Windows.Forms.Button bt_Mplus;
        private System.Windows.Forms.Button bt_Mminus;
        private System.Windows.Forms.Button bt_Mread;
        private System.Windows.Forms.Button bt_c;
        private System.Windows.Forms.Button bt_pm;
        private System.Windows.Forms.Button bt_div;
        private System.Windows.Forms.Button bt_mul;
        private System.Windows.Forms.Button bt_7;
        private System.Windows.Forms.Button bt_8;
        private System.Windows.Forms.Button bt_9;
        private System.Windows.Forms.Button bt_sub;
        private System.Windows.Forms.Button bt_4;
        private System.Windows.Forms.Button bt_5;
        private System.Windows.Forms.Button bt_6;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_1;
        private System.Windows.Forms.Button bt_2;
        private System.Windows.Forms.Button bt_3;
        private System.Windows.Forms.Button bt_result;
        private System.Windows.Forms.Button bt_dot;
        private System.Windows.Forms.Button bt_0;
        private System.Windows.Forms.RichTextBox history;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 서버연결ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 연결해제ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

