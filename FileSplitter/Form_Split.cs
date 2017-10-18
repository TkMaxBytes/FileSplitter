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
                textBox_FileSize.Enabled = true;
                textBox_FileSize.Text = mobjFileToSplit.Length.ToString();
                textBox_FileSize.Enabled = false;
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
            Int64 intBufSize = Int64.Parse(textBox_SplitSize.Text);
            mobjFileSplitter = new FileSplitterWorker(mobjFileToSplit, intBufSize);
            //Subscribe for the event.
            label_Progress.Text = "";
            label_Progress.Refresh();
            mobjFileSplitter.SplitSize = intBufSize;
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

        private void Form_Split_Load(object sender, EventArgs e)
        {
            textBox_FileSize.Enabled = false;
        }

        private void textBox_NumberOfFiles_KeyUp(object sender, KeyEventArgs e)
        {


       
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress);
            messageBoxCS.AppendLine();
            Console.WriteLine("KeyValue:=" + e.KeyValue);
            //MessageBox.Show(messageBoxCS.ToString(), "KeyDown Event");
            e.Handled = true;
            /**Terrence Knoesen 
             * Handle Non Numbers frist
            **/


            if(!KeyUpCheckNumerics(e.KeyValue))
            {
                textBox_NumberOfFiles.Clear();
                textBox_NumberOfFiles.Text = "2";
            }

        }

        private void textBox_NumberOfFiles_Leave(object sender, EventArgs e)
        {
            int numFiles = 2;
            
            if (int.TryParse(textBox_NumberOfFiles.Text, out numFiles))
            {
                Int64 intFileSize = Int64.Parse(textBox_FileSize.Text);
                textBox_SplitSize.Text = (intFileSize / numFiles).ToString();
            }
        }

        private bool KeyUpCheckNumerics(int intKeyValue)
        {
            if (intKeyValue == 35 || intKeyValue == 36 || intKeyValue == 37 || intKeyValue == 40)
            {
                return true;
            }
            if (intKeyValue == 8 || intKeyValue == 13 || intKeyValue == 46)
            {
                return true;
            }
            if ((intKeyValue >= 48 & intKeyValue <= 57) || (intKeyValue >= 96 & intKeyValue <= 105))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
