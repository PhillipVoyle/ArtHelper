namespace ArtHelper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button chooseImageButton;
        private System.Windows.Forms.Label outputDirectoryLabel;
        private System.Windows.Forms.TextBox outputDirectoryTextBox;
        private System.Windows.Forms.Button browseOutputButton;
        private System.Windows.Forms.Label gradeCountLabel;
        private System.Windows.Forms.NumericUpDown gradeCountNumericUpDown;
        private System.Windows.Forms.Label selectedImageLabel;
        private System.Windows.Forms.Label statusLabel;

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
            this.components = new System.ComponentModel.Container();
            this.chooseImageButton = new System.Windows.Forms.Button();
            this.outputDirectoryLabel = new System.Windows.Forms.Label();
            this.outputDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.browseOutputButton = new System.Windows.Forms.Button();
            this.gradeCountLabel = new System.Windows.Forms.Label();
            this.gradeCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectedImageLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gradeCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseImageButton
            // 
            this.chooseImageButton.Location = new System.Drawing.Point(24, 24);
            this.chooseImageButton.Name = "chooseImageButton";
            this.chooseImageButton.Size = new System.Drawing.Size(180, 30);
            this.chooseImageButton.TabIndex = 0;
            this.chooseImageButton.Text = "Choose JPEG image...";
            this.chooseImageButton.UseVisualStyleBackColor = true;
            this.chooseImageButton.Click += new System.EventHandler(this.chooseImageButton_Click);
            // 
            // outputDirectoryLabel
            // 
            this.outputDirectoryLabel.AutoSize = true;
            this.outputDirectoryLabel.Location = new System.Drawing.Point(24, 76);
            this.outputDirectoryLabel.Name = "outputDirectoryLabel";
            this.outputDirectoryLabel.Size = new System.Drawing.Size(100, 15);
            this.outputDirectoryLabel.TabIndex = 1;
            this.outputDirectoryLabel.Text = "Output directory:";
            // 
            // outputDirectoryTextBox
            // 
            this.outputDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDirectoryTextBox.Location = new System.Drawing.Point(24, 94);
            this.outputDirectoryTextBox.Name = "outputDirectoryTextBox";
            this.outputDirectoryTextBox.Size = new System.Drawing.Size(555, 23);
            this.outputDirectoryTextBox.TabIndex = 2;
            // 
            // browseOutputButton
            // 
            this.browseOutputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseOutputButton.Location = new System.Drawing.Point(585, 93);
            this.browseOutputButton.Name = "browseOutputButton";
            this.browseOutputButton.Size = new System.Drawing.Size(75, 25);
            this.browseOutputButton.TabIndex = 3;
            this.browseOutputButton.Text = "Browse...";
            this.browseOutputButton.UseVisualStyleBackColor = true;
            this.browseOutputButton.Click += new System.EventHandler(this.browseOutputButton_Click);
            // 
            // gradeCountLabel
            // 
            this.gradeCountLabel.AutoSize = true;
            this.gradeCountLabel.Location = new System.Drawing.Point(24, 140);
            this.gradeCountLabel.Name = "gradeCountLabel";
            this.gradeCountLabel.Size = new System.Drawing.Size(103, 15);
            this.gradeCountLabel.TabIndex = 4;
            this.gradeCountLabel.Text = "Number of grades:";
            // 
            // gradeCountNumericUpDown
            // 
            this.gradeCountNumericUpDown.Location = new System.Drawing.Point(133, 138);
            this.gradeCountNumericUpDown.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            this.gradeCountNumericUpDown.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.gradeCountNumericUpDown.Name = "gradeCountNumericUpDown";
            this.gradeCountNumericUpDown.Size = new System.Drawing.Size(60, 23);
            this.gradeCountNumericUpDown.TabIndex = 5;
            this.gradeCountNumericUpDown.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // selectedImageLabel
            // 
            this.selectedImageLabel.AutoEllipsis = true;
            this.selectedImageLabel.Location = new System.Drawing.Point(24, 180);
            this.selectedImageLabel.Name = "selectedImageLabel";
            this.selectedImageLabel.Size = new System.Drawing.Size(636, 23);
            this.selectedImageLabel.TabIndex = 6;
            this.selectedImageLabel.Text = "No image selected.";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoEllipsis = true;
            this.statusLabel.Location = new System.Drawing.Point(24, 215);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(636, 45);
            this.statusLabel.TabIndex = 7;
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 285);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.selectedImageLabel);
            this.Controls.Add(this.gradeCountNumericUpDown);
            this.Controls.Add(this.gradeCountLabel);
            this.Controls.Add(this.browseOutputButton);
            this.Controls.Add(this.outputDirectoryTextBox);
            this.Controls.Add(this.outputDirectoryLabel);
            this.Controls.Add(this.chooseImageButton);
            this.MinimumSize = new System.Drawing.Size(500, 315);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Art Helper";
            ((System.ComponentModel.ISupportInitialize)(this.gradeCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

