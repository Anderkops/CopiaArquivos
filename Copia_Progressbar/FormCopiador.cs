using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.IO;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security.Principal;

namespace Copia_Progressbar
{
    public partial class FormCopiador : Form
    {
        public FormCopiador()
        {
            InitializeComponent();
        }

        private void btn_Iniciar_Copia_Click(object sender, EventArgs e)
        {
          string Origem, Destino;

          //Origem = @"C:\A\Mus.mp3";//txt_Path_Origem.Text;
          //Destino = @"C:\B\Mus.mp3";//txt_Path_Destino.Text;

          Origem = txt_Path_Origem.Text;
          Destino = txt_Path_Destino.Text;
          lbl_Progress_Bar.Text = "";
            
          if (Origem != "" && Destino != "")          
          {
              System.IO.DirectoryInfo Diretorio_Origem = new System.IO.DirectoryInfo(Origem);
              System.IO.DirectoryInfo Diretorio_Destino = new System.IO.DirectoryInfo(Destino);

              Directory_Files_Copy di = new Directory_Files_Copy();

              di.Passeio_Raiz_Diretorios(Diretorio_Origem);
              lbl_Progress_Bar.Text += Convert.ToString(di.GetNumArquivos());
              prb_Copia.Maximum = di.GetNumArquivos();
              prb_Copia.Step = 1;
              prb_Copia.Value = 0;
              
              di.Copia_Todos_Arquivos_2(Diretorio_Origem, Diretorio_Destino, prb_Copia, prb_Arquivo);

              //CustomFileCopier copia = new CustomFileCopier(Origem, Destino);
              //copia.Copy();
          }            
          else
          {
            MessageBox.Show("Favor selecionar a origem e o destino");
          }
            
            

/*            while (contar <= 100)
            {
                prb_Copia.Value = contar;
                contar++;
            }

 */
            /*prb_Copia.Maximum = 1000;
            prb_Copia.Step = 1;      // Esse é o valor que a progress bar vai subir quando você char a methodo PerformStep então ela vai ser incrementada esse valor até atingir o valor Maximum
            prb_Copia.Value = 0;
            contar = 1;
            while (contar <= 1000)
            {
                prb_Copia.PerformStep();
                contar++;
            }
            MessageBox.Show("A progress bar chegou ao seu fim.");
            prb_Copia.Value = 0; //Zera a progress bar*/

            //UpdateProgressBarDelegate updatePbDelegate = new UpdateProgressBarDelegate(ProgressBar1.SetValue);

            //Dispatcher.Invoke(updatePbDelegate, System.Windows.Threading.DispatcherPriority.Background, new object[] { ProgressBar.ValueProperty, value });


        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
 

        private void btn_Escolhe_Diretorio_Origem_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog opn_Folder = new FolderBrowserDialog();

            opn_Folder.Description = "Selecione uma pasta para realizar o Backup";
            opn_Folder.RootFolder = Environment.SpecialFolder.MyComputer;
            opn_Folder.ShowNewFolderButton = true;

            DialogResult dr = opn_Folder.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    txt_Path_Origem.Text = opn_Folder.SelectedPath;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show("Erro de segurança Contate o administrador de segurança da rede.\n\n" +
                                                      "Mensagem : " + ex.Message + "\n\n" +
                                                      "Detalhes (enviar ao suporte):\n\n" + ex.StackTrace);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Não foi possivel selecionar o diretorio pelas seguintes razoes: \n" + ex.Message);
                }

            }            
        }

        private void btn_Escolhe_Diretorio_Destino_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog opn_Folder = new FolderBrowserDialog();

            opn_Folder.Description = "Selecione uma pasta para realizar o Backup";
            opn_Folder.RootFolder = Environment.SpecialFolder.MyComputer;
            opn_Folder.ShowNewFolderButton = true;

            DialogResult dr = opn_Folder.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                  txt_Path_Destino.Text = opn_Folder.SelectedPath;
                }
                catch (SecurityException ex)
                {
                  MessageBox.Show("Erro de segurança Contate o administrador de segurança da rede.\n\n" +
                                                   "Mensagem : " + ex.Message + "\n\n" +
                                                   "Detalhes (enviar ao suporte):\n\n" + ex.StackTrace);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel selecionar o diretorio pelas seguintes razoes: \n"+ ex.Message);
                }
            }   
        }
    }
}




/************************************************************************************/
/************************* Funcionou Copia por Byte *********************************/
/************************************************************************************

          Origem = @"C:\A\Mus.mp3";//txt_Path_Origem.Text;
          Destino = @"C:\B\Mus.mp3";//txt_Path_Destino.Text;
 
          byte[] buffer = new byte[1024 * 1024]; // 1MB buffer
          bool cancelFlag = false; 

              try
              {
                  using (FileStream source = new FileStream(Origem, FileMode.Open, FileAccess.Read))
                  {
                      long fileLength = source.Length;

                      using (FileStream dest = new FileStream(Destino, FileMode.CreateNew, FileAccess.Write))
                      {
                          long totalBytes = 0;
                          int currentBlockSize = 0;

                          while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                          {
                              totalBytes += currentBlockSize;
                              double persentage = (double)totalBytes * 100.0 / fileLength;

                              dest.Write(buffer, 0, currentBlockSize);
                              cancelFlag = false;

                              //OnProgressChanged(persentage, ref cancelFlag);
                              Console.WriteLine("Porcentagem: {0}", persentage);

                              if (cancelFlag == true)
                              {
                                  // Delete dest file here
                                  break;
                              }

                          }




                      }

                  }
              }
              catch (UnauthorizedAccessException ex)
              {
                  Console.WriteLine(ex);
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex);
              }


/************************************************************************************/
/************************************************************************************/



/************************************************************************************/
/************************* Funcionou ************************************************/
/************************************************************************************

string Origem, Destino;

Origem = @"C:\A\Mus.mp3";//txt_Path_Origem.Text;
Destino = @"C:\B\Mus.mp3";//txt_Path_Destino.Text;

using (FileStream fs = new FileStream(Origem, FileMode.Open, FileAccess.Read))
{
    byte[] b = new byte[fs.Length];                                    
    int Bytes_Lidos = (int)fs.Length;
    int Bytes_Faltam = 0;

    while (Bytes_Lidos > 0)
    { 
        int n = fs.Read(b, Bytes_Faltam, Bytes_Lidos);
                      
        if( n == 0) break;

        Bytes_Faltam += n;
        Bytes_Lidos -= n;
    }

    Bytes_Lidos = b.Length;

    using (FileStream fs_new = new FileStream(Destino, FileMode.Create, FileAccess.Write))
    {
        fs_new.Write(b, 0, Bytes_Lidos);
    }                      
}
/************************************************************************************/
/************************************************************************************/
/************************************************************************************/