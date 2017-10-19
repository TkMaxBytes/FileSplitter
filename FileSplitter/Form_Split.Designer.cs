namespace FileSplitter
{
    partial class Form_Split
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
            this.button_BrowseFiles = new System.Windows.Forms.Button();
            this.button_CancelSplit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_FileToSplit = new System.Windows.Forms.TextBox();
            this.button_SplitFile = new System.Windows.Forms.Button();
            this.label_Progress = new System.Windows.Forms.Label();
            this.openFileDialog_BrowseFiles = new System.Windows.Forms.OpenFileDialog();
            this.textBox_NumberOfFiles = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_SplitSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_FileSize = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_BrowseFiles
            // 
            this.button_BrowseFiles.Location = new System.Drawing.Point(470, 24);
            this.button_BrowseFiles.Name = "button_BrowseFiles";
            this.button_BrowseFiles.Size = new System.Drawing.Size(32, 21);
            this.button_BrowseFiles.TabIndex = 0;
            this.button_BrowseFiles.Text = "...";
            this.button_BrowseFiles.UseVisualStyleBackColor = true;
            this.button_BrowseFiles.Click += new System.EventHandler(this.button_BrowseFiles_Click);
            // 
            // button_CancelSplit
            // 
            this.button_CancelSplit.Location = new System.Drawing.Point(194, 134);
            this.button_CancelSplit.Name = "button_CancelSplit";
            this.button_CancelSplit.Size = new System.Drawing.Size(105, 38);
            this.button_CancelSplit.TabIndex = 1;
            this.button_CancelSplit.Text = "Cancel";
            this.button_CancelSplit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File To Split";
            // 
            // textBox_FileToSplit
            // 
            this.textBox_FileToSplit.Location = new System.Drawing.Point(12, 26);
            this.textBox_FileToSplit.Name = "textBox_FileToSplit";
            this.textBox_FileToSplit.Size = new System.Drawing.Size(458, 20);
            this.textBox_FileToSplit.TabIndex = 3;
            // 
            // button_SplitFile
            // 
            this.button_SplitFile.Enabled = false;
            this.button_SplitFile.Location = new System.Drawing.Point(12, 134);
            this.button_SplitFile.Name = "button_SplitFile";
            this.button_SplitFile.Size = new System.Drawing.Size(105, 38);
            this.button_SplitFile.TabIndex = 4;
            this.button_SplitFile.Text = "Split File";
            this.button_SplitFile.UseVisualStyleBackColor = true;
            this.button_SplitFile.Click += new System.EventHandler(this.button_SplitFile_Click);
            // 
            // label_Progress
            // 
            this.label_Progress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Progress.Location = new System.Drawing.Point(12, 186);
            this.label_Progress.Name = "label_Progress";
            this.label_Progress.Size = new System.Drawing.Size(490, 18);
            this.label_Progress.TabIndex = 5;
            this.label_Progress.Text = "label2";
            // 
            // openFileDialog_BrowseFiles
            // 
            this.openFileDialog_BrowseFiles.DefaultExt = "*.*";
            this.openFileDialog_BrowseFiles.FileName = "Select File";
            // 
            // textBox_NumberOfFiles
            // 
            this.textBox_NumberOfFiles.Location = new System.Drawing.Point(194, 67);
            this.textBox_NumberOfFiles.Name = "textBox_NumberOfFiles";
            this.textBox_NumberOfFiles.Size = new System.Drawing.Size(38, 20);
            this.textBox_NumberOfFiles.TabIndex = 8;
            this.textBox_NumberOfFiles.Text = "100";
            this.textBox_NumberOfFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_NumberOfFiles_KeyUp);
            this.textBox_NumberOfFiles.Leave += new System.EventHandler(this.textBox_NumberOfFiles_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "# Files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Split Size (bytes)";
            // 
            // textBox_SplitSize
            // 
            this.textBox_SplitSize.Enabled = false;
            this.textBox_SplitSize.Location = new System.Drawing.Point(284, 67);
            this.textBox_SplitSize.Name = "textBox_SplitSize";
            this.textBox_SplitSize.Size = new System.Drawing.Size(155, 20);
            this.textBox_SplitSize.TabIndex = 10;
            this.textBox_SplitSize.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Size Of File (Bytes)";
            // 
            // textBox_FileSize
            // 
            this.textBox_FileSize.Location = new System.Drawing.Point(12, 67);
            this.textBox_FileSize.Name = "textBox_FileSize";
            this.textBox_FileSize.Size = new System.Drawing.Size(155, 20);
            this.textBox_FileSize.TabIndex = 12;
            this.textBox_FileSize.Text = "100";
            // 
            // Form_Split
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 213);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_FileSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_SplitSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_NumberOfFiles);
            this.Controls.Add(this.label_Progress);
            this.Controls.Add(this.button_SplitFile);
            this.Controls.Add(this.textBox_FileToSplit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_CancelSplit);
            this.Controls.Add(this.button_BrowseFiles);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(528, 252);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(528, 252);
            this.Name = "Form_Split";
            this.Text = "File Splitter";
            this.Load += new System.EventHandler(this.Form_Split_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_BrowseFiles;
        private System.Windows.Forms.Button button_CancelSplit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_FileToSplit;
        private System.Windows.Forms.Button button_SplitFile;
        private System.Windows.Forms.Label label_Progress;
        private System.Windows.Forms.OpenFileDialog openFileDialog_BrowseFiles;
        private System.Windows.Forms.TextBox textBox_NumberOfFiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_SplitSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_FileSize;
    }
}

