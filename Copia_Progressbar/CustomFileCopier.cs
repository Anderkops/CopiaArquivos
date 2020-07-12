using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security.Principal;
using System.Windows.Forms;


namespace Copia_Progressbar
{
    public delegate void ProgressChangeDelegate(double Persentage, ref bool Cancel);
    public delegate void Completedelegate();
    
    class CustomFileCopier
    {
        public CustomFileCopier(string Source, string Dest)
        {
            this.SourceFilePath = Source;
            this.DestFilePath = Dest;

            OnProgressChanged += delegate { };
            OnComplete += delegate { };
        }

        public void Copy(System.Windows.Forms.ProgressBar prb_arquivo)
        {
            byte[] buffer = new byte[1024 * 1024]; // 1MB buffer
            bool cancelFlag = false;

            try
            {

                using (FileStream source = new FileStream(SourceFilePath, FileMode.Open, FileAccess.Read))
                {

                    long fileLength = source.Length;

                    using (FileStream dest = new FileStream(DestFilePath, FileMode.CreateNew, FileAccess.Write))
                    {

                        long totalBytes = 0;
                        int currentBlockSize = 0;
                        prb_arquivo.Maximum = 100;                        
                        prb_arquivo.Value = 0;

                        while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            totalBytes += currentBlockSize;
                            double persentage = (double)totalBytes * 100.0 / fileLength;
                            dest.Write(buffer, 0, currentBlockSize);

                            cancelFlag = false;
                            OnProgressChanged(persentage, ref cancelFlag);
                            prb_arquivo.Value = (int)persentage;
                                                        
                            if (cancelFlag == true)
                            {
                                // Delete dest file here
                                break;
                            }
                        }
                        
                    }
                    
                }
                prb_arquivo.Value = 0;
            }                         
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            OnComplete();
        }

        public string SourceFilePath { get; set; }
        public string DestFilePath { get; set; }

        public event ProgressChangeDelegate OnProgressChanged;
        public event Completedelegate OnComplete;    
    
    }


}
