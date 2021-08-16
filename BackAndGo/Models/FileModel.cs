using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackAndGo.Models
{
    public class FileModel
    {
        public FileModel()
        {
            include = false;
            Canpreview = true;
        }
        public string paht { get; set; }

        public bool include  { get; set; }
        public bool Canpreview { get; set; }

        public void PreviewFile()
        {
            
                if ( Canpreview == true)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = paht;
                    process.Start();
                }           
        }

       
    }
}
