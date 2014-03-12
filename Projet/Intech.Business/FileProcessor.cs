using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intech.Business
{
    public class FileProcessor
    {
        public FileProcessor()
        {
        }

        public FileProcessorResult Process(String path)
        {
            FileProcessorResult result = new FileProcessorResult(path);
            if (Directory.Exists(path))
                process(new DirectoryInfo(path), result,false);
            else
                throw new Exception("Directory not exists");

            return result;
        }

        private void process(DirectoryInfo d, FileProcessorResult fpr, bool isParentHidden)
        {
            ++fpr.TotalDirectoryCount;
            bool thisDirectoryIsHidden=(d.Attributes & FileAttributes.Hidden) != 0;
            if (thisDirectoryIsHidden)
            {
                ++fpr.HiddenDirectoryCount;
            }

            IEnumerable<FileInfo> files = d.EnumerateFiles();
            IEnumerator<FileInfo> filesenumerator = files.GetEnumerator();
            try
            {
                while (filesenumerator.MoveNext())
                {
                    FileInfo File = filesenumerator.Current;
                    fpr.TotalFileCount++;
                    FileAttributes attr = File.Attributes;
                    bool isHidden = ((attr & FileAttributes.Hidden) != 0);
                    
                    if (isHidden)
                    {
                        ++fpr.HiddenFileCount;
                        ++fpr.UnaccessibleFileCount;
                    }
                    else if (isParentHidden)
                    {
                        ++fpr.UnaccessibleFileCount;
                    }                       
                }
            }
            finally
            {
                 filesenumerator.Dispose();
            }
   
            IEnumerable<DirectoryInfo> directories = d.EnumerateDirectories();
            foreach( var dir in directories)
            {
                process(dir, fpr, isParentHidden );
            }

        }
    }
}
