using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OBSFootballBoard.Dumper
{
    class Dumper
    {
        private Dictionary<FileTypes, FileStream> FileHandlers = new Dictionary<FileTypes, FileStream>();

        public Dumper()
        {
            foreach (FileTypes fileType in (FileTypes[]) Enum.GetValues(typeof(FileTypes)))
            {
                string fileName = fileType.ToString() + ".txt";
                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                FileHandlers.Add(fileType, stream);
            }
        }

        public void DumpMatch(FileTypes matchType, string FileData)
        {
            FileStream stream = FileHandlers[matchType];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Write(Encoding.UTF8.GetBytes(FileData), 0, FileData.Length);
            stream.SetLength(FileData.Length);
            stream.Flush();
        }
    }
}
