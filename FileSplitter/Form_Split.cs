using System;
using System.IO;
using System.Windows.Forms;

namespace FileSplitter
{
    public partial class Form_Split : Form
    {
        FileInfo mobjFileToSplit = null;
        private FileSplitterWorker mobjFileSplitter = null;
        public Form_Split()
        {
            InitializeComponent();
        }

        public FileInfo GetWork()
        {
            return mobjFileToSplit;
        }


        private void button_BrowseFiles_Click(object sender, EventArgs e)
        {
            openFileDialog_BrowseFiles.ShowDialog();
            string strFileToSplit = openFileDialog_BrowseFiles.FileName;
            FileInfo splitFile = null;
            if (!string.IsNullOrEmpty(strFileToSplit))
            {

                mobjFileToSplit = new FileInfo(strFileToSplit);
                textBox_FileToSplit.Text = strFileToSplit;
                textBox_FileToSplit.Enabled = false;
                button_SplitFile.Enabled = true;
            }
            else
            {
                button_SplitFile.Enabled = false;
            }


        }

        private void button_SplitFile_Click(object sender, EventArgs e)
        {
            if (mobjFileToSplit == null)
            {
                MessageBox.Show("No File to split! ");
                return;
            }
            Int16 intBufSize = Int16.Parse(textBox_CharBuffSize.Text);
            mobjFileSplitter = new FileSplitterWorker(mobjFileToSplit, intBufSize);
            //Subscribe for the event.
            label_Progress.Text = "";
            label_Progress.Refresh();
            mobjFileSplitter.SplitSize = 1000;
            mobjFileSplitter.FileSplit += this.OnFileSplit;
            mobjFileSplitter.FileSplitProgress += this.OnFileSplitProgress;
            mobjFileSplitter.Start();

        }

        public void OnFileSplit(object source, FileSplitterArgs args)
        {

            Console.WriteLine("Completed File Split of file " + args.InputFile);
        }

        public void OnFileSplitProgress(object source, FileSplitterArgs args)
        {
            this.label_Progress.Text = "Split " + args.CharsWritten;
            this.label_Progress.Refresh();
        }
    }
}
