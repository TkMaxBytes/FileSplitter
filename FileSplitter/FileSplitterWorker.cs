﻿using System;
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
        private Int16 mintChars = 4;
        private Int64 mintSplitSize = 0;

        public delegate void FileSplitEventHandler(object source, FileSplitterArgs args);
        public event FileSplitEventHandler FileSplit;
        public event FileSplitEventHandler FileSplitProgress;
        
        public FileSplitterWorker(FileInfo objFileToSplit, Int16 intChars)
        {
            mobjFileToSplit = objFileToSplit;
            mintChars = intChars;
            mintSplitSize = objFileToSplit.Length / 2;
        }

        public Int64 SplitSize
        {
            get { return mintSplitSize; }
            set { mintSplitSize = value; }
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
            this.SplitFileBin(mobjFileToSplit, mintChars);

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

        private void SplitFileBin(FileInfo theFile, Int16 intBytesToRead)
        {
            BinaryReader strmIn = null;
            BinaryWriter strmOut = null;
            strmIn = new BinaryReader(new FileStream(theFile.FullName, FileMode.Open));
            string strOutputFile = "c:\\temp\\test.txt";
            if (File.Exists(strOutputFile))
            {
                File.Delete(strOutputFile);
            }
            strmOut = new BinaryWriter(new FileStream(strOutputFile, FileMode.CreateNew));
            Int64 intBytesWritten = 0;
            Byte[] buff = { };
            while (strmIn.PeekChar() != -1)
            {
                buff = new Byte[intBytesToRead];
                strmIn.Read(buff, 0, buff.Length);
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

                    Byte[] altBuf = new Byte[idx];
                    Array.Copy(buff, altBuf, idx);
                    strmOut.Write(altBuf);
                }
                else
                {
                    strmOut.Write(buff);
                }
                
                intBytesWritten += buff.Length;
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