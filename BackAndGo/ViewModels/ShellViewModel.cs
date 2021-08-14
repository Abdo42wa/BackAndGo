using BackAndGo.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Windows;
using System.IO.Compression;
using BackAndGo.Views;
using System.Diagnostics;

namespace BackAndGo.ViewModels
{
    public class ShellViewModel : Caliburn.Micro.Screen
    {


        private BindableCollection<FileModel> _fileModels = new BindableCollection<FileModel>();

        private string _getFileButtonTitle = "Add File...";

        private string _closeButtonTitle = "Close";

        private string _packButtonTitle = "pack";

        string filePth = @"C:\Users\abdoa\Downloads\firmosPavadinimai.txt";
     

        public string GetFileButtonTitle
        {
            get { return _getFileButtonTitle; }
            set { _getFileButtonTitle = value; }
        }


        public string PackButtonTitle
        {
            get { return _packButtonTitle ; }
            set { _packButtonTitle = value; }
        }

       
        public string CloseButtonTitle
        {
            get { return _closeButtonTitle; }
            set { _closeButtonTitle = value; }
        }


        public ShellViewModel()
        {
            
            Files.Add(new FileModel { paht = filePth , Canpreview = true});

            



        }
        public BindableCollection<FileModel> Files
        {
            get { return _fileModels; }
            set { _fileModels = value; }
        }


        public void GetFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                string filName = openFileDialog.FileName;
                Console.WriteLine(filName);
                Files.Add(new FileModel { paht = filName });
            }

        }


        public void CloseWindow()
        {
            TryCloseAsync();

        }

        public void Pack()
        {
            
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    using (var archive = ZipFile.Open(saveFileDialog.FileName + ".zip", ZipArchiveMode.Create))
                    {

                            foreach (var pt in Files)
                            {
                                Console.WriteLine(pt.paht);

                                if (pt.include == true)
                                {
                                      archive.CreateEntryFromFile(pt.paht, Path.GetFileName(pt.paht));
                                        
                                }
                            }
                  
                            string directoryNmae = Path.GetDirectoryName(saveFileDialog.FileName);
                    
                            Process.Start(directoryNmae);
                    }
                    


                }
        }



        public void PreviewFile()
        {
            
            foreach (var item in Files)
            {
                if (item.Canpreview == true)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = item.paht;
                    process.Start();

                    Console.WriteLine("wow");
                }


            }

        }



    }
}
