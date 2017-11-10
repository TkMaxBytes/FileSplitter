using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FileSplitter
{
    public class FileSplitterArgs : EventArgs
    {
        public Int64 CharsWritten { get; set; }
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
    }

    public class FileSplitterWorker
    {
        private FileInfo mobjFileToSplit = null;
        
        /// <summary>
        /// The segment size of each of the segments for the file.
        /// </summary>
        private Int64 mintSplitSize = 0;
        private string mstrOutputDirectory;

        public delegate void FileSplitEventHandler(object source, FileSplitterArgs args);
        public event FileSplitEventHandler FileSplit;
        public event FileSplitEventHandler FileSplitProgress;
        
        public FileSplitterWorker(FileInfo objFileToSplit, Int64 intSplitSize)
        {
            mobjFileToSplit = objFileToSplit;
            mintSplitSize = intSplitSize;
        }

        public Int64 SplitSize
        {
            get { return mintSplitSize; }
            set { mintSplitSize = value + 1 ; }
        }

        /// <summary>
        /// The directory to which the segments will be written to
        /// </summary>
        public string OutputDirectory
        {
            get { return mstrOutputDirectory; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Please specify an output directory.");
                }
                if (Directory.Exists(value))
                {
                    throw new ArgumentException("The output doesn't exist.");
                }
                mstrOutputDirectory = value;

            }
        }

        /// <summary>
        /// Start the work on splitting the file
        /// </summary>
        public void Start()
        {

            /**Terrence Knoesen 
             * Get the file to work on first.
            **/

            //this.SplitFileChar(mobjFileToSplit, mintChars);
            //this.SplitFileBin(mobjFileToSplit, mintChars);
            this.SplitFileBin(mobjFileToSplit, this.SplitSize, "c:\\temp\\");

        }

        private void SplitFileChar(FileInfo theFile, Int16 intCharsToRead)
        {
            Console.WriteLine("Starting split");
            //Thread.Sleep(4000);
            StreamReader strmIn = null;
            StreamWriter strmOut = null;
            strmIn = new StreamReader(theFile.FullName);
            strmOut = new StreamWriter("c:\\temp\\test.txt");
            Int64 intCharWritten = 0;
            char[] buff = null;
            while (!strmIn.EndOfStream)
            {
                buff = new char[intCharsToRead];
                strmIn.Read(buff, 0, buff.Length);
                strmOut.Write(buff);
                intCharWritten += buff.Length;
                OnFileSplitProgress(intCharWritten);
            }
            strmIn.Close();
            strmOut.Close();
            /**Terrence Knoesen 
             * Completed the split
            **/
            OnFileSplit();
        }

        private void SplitFileBin(FileInfo theFile, Int64  intBytesToRead, string strOutputDirectory)
        {
            BinaryReader strmIn = null;
            BinaryWriter strmOut = null;
            /**Terrence Knoesen 
             * Open the original file for reading.
            **/
            strmIn = new BinaryReader(new FileStream(theFile.FullName, FileMode.Open));
            /**Terrence Knoesen 
             * Create the name of the split file.  This is jus the name with out number.
            **/
            string strOutputFile = theFile.FullName + ".split.";
 
            
            Int64 intBytesWritten = 0;
            Byte[] buff = { };
            int intCurrFileNum = 0;
            while (strmIn.PeekChar() != -1)
            {
                /**Terrence Knoesen
                 * Read from the file in to the buff variable.
                **/
                buff = new Byte[intBytesToRead];
                strmIn.Read(buff, 0, buff.Length);

                /**Terrence Knoesen 
                 * Check to see if there is a file by the same
                 * name as the output file if there is then
                 * delete it first.
                **/
                intCurrFileNum++;
                if (File.Exists(strOutputFile + intCurrFileNum))
                {
                    File.Delete(strOutputFile + intCurrFileNum);
                }
                /**Terrence Knoesen 
                 * Create the output stream to disk.
                **/
                strmOut = new BinaryWriter(new FileStream(strOutputFile + intCurrFileNum, FileMode.CreateNew));
                /**Terrence Knoesen 
                * Check to see if the last item in the array
                * is not null.  If it is then we know
                * that we have reached the end of the file
                * and should only be writting the non null 
                * bytes to the file.
                **/
                if (buff[buff.Length - 1] == 0)
                {
                    byte byteFind = 0;
                    int idx = Array.IndexOf(buff, byteFind);

                    Byte[] altbuff = new Byte[idx];
                    Array.Copy(buff, altbuff, idx);
                    
                    strmOut.Write(altbuff);
                    intBytesWritten += altbuff.Length;
                }
                else
                {
                    strmOut.Write(buff);
                    intBytesWritten += buff.Length;
                }
                strmOut.Close();

                /**Terrence Knoesen 
                 * Let the subscribers know that some progress has been made
                **/
                OnFileSplitProgress(intBytesWritten);
            }
            strmIn.Close();
            strmOut.Close();
            /**Terrence Knoesen 
             * Raise the splitting of file complete event.
            **/
            OnFileSplit();
        }
        
        private void SplitFileBinEX(FileInfo theFile, Int64 intSplitSize, string strOutputDirectory)
        {
            BinaryReader strmIn = null;
            BinaryWriter strmOut = null;
            strmIn = new BinaryReader(new FileStream(theFile.FullName, FileMode.Open));
            int intNumberOfSegments = 0;
            intNumberOfSegments = (int)(theFile.Length / intSplitSize);



            string strOutputFile = "c:\\temp\\test.txt";
            if (File.Exists(strOutputFile))
            {
                File.Delete(strOutputFile);
            }
            Int64 intBytesToRead = 100;
            strmOut = new BinaryWriter(new FileStream(strOutputFile, FileMode.CreateNew));
            Int64 intBytesWritten = 0;
            Byte[] buff = new Byte[1];
            int intPer = 0;
            Int64 intPerReport = (Int64)(theFile.Length * 0.5F);
            while (strmIn.PeekChar() != -1)
            {

                strmOut.Write(strmIn.ReadByte());
                intBytesWritten++;
                intPer =  (int)((intBytesWritten / theFile.Length) * 100);
               
                if ((intBytesWritten % intPerReport) == 0)
                {
                    /**Terrence Knoesen 
                    * Let the subscribers know that some progress has been made
                    **/
                    OnFileSplitProgress(intBytesWritten);
                }
                
            }
            strmIn.Close();
            strmOut.Close();
            /**Terrence Knoesen 
             * Raise the splitting of file complete event.
            **/
            OnFileSplit();

        }

        protected virtual void OnFileSplit()
        {

            if (FileSplit != null)
            {
                FileSplitterArgs arg = new FileSplitterArgs();
                arg.InputFile = mobjFileToSplit.FullName;
                arg.OutputFile = null;
                arg.CharsWritten = 0;
                FileSplit(this, arg);
            }
        }

        protected virtual void OnFileSplitProgress(Int64 intCharWritten)
        {
            if (FileSplitProgress != null)
            {
                FileSplitterArgs arg = new FileSplitterArgs();
                arg.InputFile = mobjFileToSplit.FullName;
                arg.OutputFile = null;
                arg.CharsWritten = intCharWritten;
                FileSplitProgress(this, arg);
            }
        }

    }
}