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
            this.textBox_CharBuffSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.button_CancelSplit.Location = new System.Drawing.Point(397, 95);
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
            this.textBox_FileToSplit.Location = new System.Drawing.Point(12, 27);
            this.textBox_FileToSplit.Name = "textBox_FileToSplit";
            this.textBox_FileToSplit.Size = new System.Drawing.Size(458, 20);
            this.textBox_FileToSplit.TabIndex = 3;
            // 
            // button_SplitFile
            // 
            this.button_SplitFile.Enabled = false;
            this.button_SplitFile.Location = new System.Drawing.Point(12, 95);
            this.button_SplitFile.Name = "button_SplitFile";
            this.button_SplitFile.Size = new System.Drawing.Size(105, 38);
            this.button_SplitFile.TabIndex = 4;
            this.button_SplitFile.Text = "Split File";
            this.button_SplitFile.UseVisualStyleBackColor = true;
            this.button_SplitFile.Click += new System.EventHandler(this.button_SplitFile_Click);
            // 
            // label_Progress
            // 
            this.label_Progress.Location = new System.Drawing.Point(12, 145);
            this.label_Progress.Name = "label_Progress";
            this.label_Progress.Size = new System.Drawing.Size(233, 13);
            this.label_Progress.TabIndex = 5;
            this.label_Progress.Text = "label2";
            // 
            // openFileDialog_BrowseFiles
            // 
            this.openFileDialog_BrowseFiles.DefaultExt = "*.*";
            this.openFileDialog_BrowseFiles.FileName = "Select File";
            // 
            // textBox_CharBuffSize
            // 
            this.textBox_CharBuffSize.Location = new System.Drawing.Point(12, 70);
            this.textBox_CharBuffSize.Name = "textBox_CharBuffSize";
            this.textBox_CharBuffSize.Size = new System.Drawing.Size(100, 20);
            this.textBox_CharBuffSize.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Char Buff Size";
            // 
            // Form_Split
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 168);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_CharBuffSize);
            this.Controls.Add(this.label_Progress);
            this.Controls.Add(this.button_SplitFile);
            this.Controls.Add(this.textBox_FileToSplit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_CancelSplit);
            this.Controls.Add(this.button_BrowseFiles);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(528, 207);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(528, 207);
            this.Name = "Form_Split";
            this.Text = "File Splitter";
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
        private System.Windows.Forms.TextBox textBox_CharBuffSize;
        private System.Windows.Forms.Label label2;
    }
}

