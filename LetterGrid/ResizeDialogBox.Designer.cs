namespace LetterGrid
{
    partial class ResizeDialogBox
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
            this.columnCountSelector = new System.Windows.Forms.NumericUpDown();
            this.rowCountSelector = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ResizeGridOKButton = new System.Windows.Forms.Button();
            this.ResizeGridCancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowCountSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // columnCountSelector
            // 
            this.columnCountSelector.Location = new System.Drawing.Point(138, 12);
            this.columnCountSelector.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.columnCountSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnCountSelector.Name = "columnCountSelector";
            this.columnCountSelector.Size = new System.Drawing.Size(58, 20);
            this.columnCountSelector.TabIndex = 0;
            this.columnCountSelector.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // rowCountSelector
            // 
            this.rowCountSelector.Location = new System.Drawing.Point(138, 38);
            this.rowCountSelector.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.rowCountSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rowCountSelector.Name = "rowCountSelector";
            this.rowCountSelector.Size = new System.Drawing.Size(58, 20);
            this.rowCountSelector.TabIndex = 1;
            this.rowCountSelector.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Columns";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rows";
            // 
            // ResizeGridOKButton
            // 
            this.ResizeGridOKButton.Location = new System.Drawing.Point(193, 103);
            this.ResizeGridOKButton.Name = "ResizeGridOKButton";
            this.ResizeGridOKButton.Size = new System.Drawing.Size(75, 23);
            this.ResizeGridOKButton.TabIndex = 4;
            this.ResizeGridOKButton.Text = "OK";
            this.ResizeGridOKButton.UseVisualStyleBackColor = true;
            this.ResizeGridOKButton.Click += new System.EventHandler(this.ResizeGridOKButton_Click);
            // 
            // ResizeGridCancelButton
            // 
            this.ResizeGridCancelButton.Location = new System.Drawing.Point(12, 103);
            this.ResizeGridCancelButton.Name = "ResizeGridCancelButton";
            this.ResizeGridCancelButton.Size = new System.Drawing.Size(75, 23);
            this.ResizeGridCancelButton.TabIndex = 5;
            this.ResizeGridCancelButton.Text = "Cancel";
            this.ResizeGridCancelButton.UseVisualStyleBackColor = true;
            this.ResizeGridCancelButton.Click += new System.EventHandler(this.ResizeGridCancelButton_Click);
            // 
            // ResizeDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 138);
            this.Controls.Add(this.ResizeGridCancelButton);
            this.Controls.Add(this.ResizeGridOKButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rowCountSelector);
            this.Controls.Add(this.columnCountSelector);
            this.MaximumSize = new System.Drawing.Size(288, 165);
            this.MinimumSize = new System.Drawing.Size(288, 165);
            this.Name = "ResizeDialogBox";
            this.Text = "Resize Grid";
            ((System.ComponentModel.ISupportInitialize)(this.columnCountSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowCountSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown columnCountSelector;
        private System.Windows.Forms.NumericUpDown rowCountSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ResizeGridOKButton;
        private System.Windows.Forms.Button ResizeGridCancelButton;
    }
}