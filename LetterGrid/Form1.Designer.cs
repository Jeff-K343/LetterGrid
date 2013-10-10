namespace LetterGrid
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squaresModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numberSquaresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theLetters = new LetterGrid.LetterGridBoxes();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(622, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveTemplateToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveTemplateToolStripMenuItem
            // 
            this.saveTemplateToolStripMenuItem.Name = "saveTemplateToolStripMenuItem";
            this.saveTemplateToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveTemplateToolStripMenuItem.Text = "Save Template...";
            this.saveTemplateToolStripMenuItem.Click += new System.EventHandler(this.saveTemplateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.squaresModeToolStripMenuItem,
            this.resizeGridToolStripMenuItem,
            this.moveHorizontalToolStripMenuItem,
            this.numberSquaresToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // squaresModeToolStripMenuItem
            // 
            this.squaresModeToolStripMenuItem.Checked = true;
            this.squaresModeToolStripMenuItem.CheckOnClick = true;
            this.squaresModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.squaresModeToolStripMenuItem.Name = "squaresModeToolStripMenuItem";
            this.squaresModeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.squaresModeToolStripMenuItem.Text = "Square Edit";
            this.squaresModeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.squaresModeToolStripMenuItem_CheckedChanged);
            // 
            // resizeGridToolStripMenuItem
            // 
            this.resizeGridToolStripMenuItem.Name = "resizeGridToolStripMenuItem";
            this.resizeGridToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resizeGridToolStripMenuItem.Text = "Resize Grid...";
            this.resizeGridToolStripMenuItem.Click += new System.EventHandler(this.resizeGridToolStripMenuItem_Click);
            // 
            // moveHorizontalToolStripMenuItem
            // 
            this.moveHorizontalToolStripMenuItem.Checked = true;
            this.moveHorizontalToolStripMenuItem.CheckOnClick = true;
            this.moveHorizontalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.moveHorizontalToolStripMenuItem.Name = "moveHorizontalToolStripMenuItem";
            this.moveHorizontalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moveHorizontalToolStripMenuItem.Text = "Move Horizontal";
            this.moveHorizontalToolStripMenuItem.CheckedChanged += new System.EventHandler(this.moveHorizontalToolStripMenuItem_CheckedChanged);
            // 
            // numberSquaresToolStripMenuItem
            // 
            this.numberSquaresToolStripMenuItem.Checked = true;
            this.numberSquaresToolStripMenuItem.CheckOnClick = true;
            this.numberSquaresToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.numberSquaresToolStripMenuItem.Name = "numberSquaresToolStripMenuItem";
            this.numberSquaresToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.numberSquaresToolStripMenuItem.Text = "Show Numbers";
            this.numberSquaresToolStripMenuItem.CheckedChanged += new System.EventHandler(this.numberSquaresToolStripMenuItem_CheckedChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyCommandsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // keyCommandsToolStripMenuItem
            // 
            this.keyCommandsToolStripMenuItem.Name = "keyCommandsToolStripMenuItem";
            this.keyCommandsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.keyCommandsToolStripMenuItem.Text = "Key Commands";
            this.keyCommandsToolStripMenuItem.Click += new System.EventHandler(this.keyCommandsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // theLetters
            // 
            this.theLetters.cursorMovesHorizontal = false;
            this.theLetters.Location = new System.Drawing.Point(12, 40);
            this.theLetters.Name = "theLetters";
            this.theLetters.Size = new System.Drawing.Size(202, 202);
            this.theLetters.TabIndex = 6;
            this.theLetters.Text = "letterGridBoxes1";
            this.theLetters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.theLetters_KeyDown);
            this.theLetters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.theLetters_KeyPress);
            this.theLetters.MouseDown += new System.Windows.Forms.MouseEventHandler(this.theLetters_MouseDown);
            this.theLetters.MouseMove += new System.Windows.Forms.MouseEventHandler(this.theLetters_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 453);
            this.Controls.Add(this.theLetters);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "LetterGrid 1.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squaresModeToolStripMenuItem;
        private LetterGridBoxes theLetters;
        private System.Windows.Forms.ToolStripMenuItem resizeGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numberSquaresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyCommandsToolStripMenuItem;
    }
}

