namespace Text_Editor_App
{
    partial class form_Main
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
            this.menu_strip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.increaseFontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseFontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetFontSizeToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status_strip = new System.Windows.Forms.StatusStrip();
            this.status_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.text_content = new System.Windows.Forms.RichTextBox();
            this.dialog_open_file = new System.Windows.Forms.OpenFileDialog();
            this.dialog_save_file = new System.Windows.Forms.SaveFileDialog();
            this.open_file_bgWorker = new System.ComponentModel.BackgroundWorker();
            this.save_file_bgWorker = new System.ComponentModel.BackgroundWorker();
            this.menu_strip.SuspendLayout();
            this.status_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_strip
            // 
            this.menu_strip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu_strip.Location = new System.Drawing.Point(0, 0);
            this.menu_strip.Name = "menu_strip";
            this.menu_strip.Size = new System.Drawing.Size(800, 30);
            this.menu_strip.TabIndex = 0;
            this.menu_strip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.saveAsToolStripMenuItem.Text = "&Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordWrapOffToolStripMenuItem,
            this.toolStripSeparator2,
            this.increaseFontSizeToolStripMenuItem,
            this.decreaseFontSizeToolStripMenuItem,
            this.resetFontSizeToDefaultToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(70, 26);
            this.formatToolStripMenuItem.Text = "F&ormat";
            // 
            // wordWrapOffToolStripMenuItem
            // 
            this.wordWrapOffToolStripMenuItem.Name = "wordWrapOffToolStripMenuItem";
            this.wordWrapOffToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.wordWrapOffToolStripMenuItem.Text = "&Word Wrap is Off";
            this.wordWrapOffToolStripMenuItem.Click += new System.EventHandler(this.wordWrapOffToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(260, 6);
            // 
            // increaseFontSizeToolStripMenuItem
            // 
            this.increaseFontSizeToolStripMenuItem.Name = "increaseFontSizeToolStripMenuItem";
            this.increaseFontSizeToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.increaseFontSizeToolStripMenuItem.Text = "&Increase Font Size";
            this.increaseFontSizeToolStripMenuItem.Click += new System.EventHandler(this.increaseFontSizeToolStripMenuItem_Click);
            // 
            // decreaseFontSizeToolStripMenuItem
            // 
            this.decreaseFontSizeToolStripMenuItem.Name = "decreaseFontSizeToolStripMenuItem";
            this.decreaseFontSizeToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.decreaseFontSizeToolStripMenuItem.Text = "&Decrease Font Size";
            this.decreaseFontSizeToolStripMenuItem.Click += new System.EventHandler(this.decreaseFontSizeToolStripMenuItem_Click);
            // 
            // resetFontSizeToDefaultToolStripMenuItem
            // 
            this.resetFontSizeToDefaultToolStripMenuItem.Name = "resetFontSizeToDefaultToolStripMenuItem";
            this.resetFontSizeToDefaultToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.resetFontSizeToDefaultToolStripMenuItem.Text = "&Reset Font Size to Default";
            this.resetFontSizeToDefaultToolStripMenuItem.Click += new System.EventHandler(this.resetFontSizeToDefaultToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // status_strip
            // 
            this.status_strip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_label});
            this.status_strip.Location = new System.Drawing.Point(0, 424);
            this.status_strip.Name = "status_strip";
            this.status_strip.Size = new System.Drawing.Size(800, 26);
            this.status_strip.TabIndex = 1;
            this.status_strip.Text = "statusStrip1";
            // 
            // status_label
            // 
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(193, 20);
            this.status_label.Text = "Welcome to the Text Editor!";
            // 
            // text_content
            // 
            this.text_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_content.Location = new System.Drawing.Point(0, 30);
            this.text_content.Name = "text_content";
            this.text_content.Size = new System.Drawing.Size(800, 394);
            this.text_content.TabIndex = 2;
            this.text_content.Text = "";
            this.text_content.TextChanged += new System.EventHandler(this.text_content_TextChanged);
            this.text_content.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key_down);
            // 
            // dialog_open_file
            // 
            this.dialog_open_file.Filter = "Text Files (*.txt)|*.txt";
            // 
            // dialog_save_file
            // 
            this.dialog_save_file.Filter = "Text Files (*.txt)|*.txt";
            // 
            // open_file_bgWorker
            // 
            this.open_file_bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.open_file_bgWorker_DoWork);
            this.open_file_bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.open_file_bgWorker_RunWorkerCompleted);
            // 
            // form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.text_content);
            this.Controls.Add(this.status_strip);
            this.Controls.Add(this.menu_strip);
            this.MainMenuStrip = this.menu_strip;
            this.Name = "form_Main";
            this.Text = "Text Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_Main_FormClosing);
            this.Load += new System.EventHandler(this.form_Main_Load);
            this.menu_strip.ResumeLayout(false);
            this.menu_strip.PerformLayout();
            this.status_strip.ResumeLayout(false);
            this.status_strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_strip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordWrapOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem increaseFontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseFontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetFontSizeToDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip status_strip;
        private System.Windows.Forms.ToolStripStatusLabel status_label;
        private System.Windows.Forms.RichTextBox text_content;
        private System.Windows.Forms.OpenFileDialog dialog_open_file;
        private System.Windows.Forms.SaveFileDialog dialog_save_file;
        private System.ComponentModel.BackgroundWorker open_file_bgWorker;
        private System.ComponentModel.BackgroundWorker save_file_bgWorker;
    }
}

