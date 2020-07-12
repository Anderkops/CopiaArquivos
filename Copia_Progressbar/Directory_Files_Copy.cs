using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security.Principal;
using Copia_Progressbar;
using System.Diagnostics;
using System.Windows.Forms;



namespace Copia_Progressbar
{
    class Directory_Files_Copy
    {
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        protected int quantidade_arq_dir = 0;

        /********************************************************************************/
        //***********Passeia em todos arquivos e diretorios de um diretorio raiz*********/
        /********************************************************************************/
        public void Passeio_Raiz_Diretorios(System.IO.DirectoryInfo raiz)
        {

            System.IO.FileInfo[] arquivos = null;
            System.IO.DirectoryInfo[] subDiretorios = null;

            // Pega todos arquivos no diretorio atual
            try
            {
                arquivos = raiz.GetFiles("*.*");
            }
            // Joga a excessão se o arquivo requer mais permissão do que o programa exige.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse. 
                // You may decide to do something different here. For example, you 
                // can try to elevate your privileges and access the file again.
                log.Add(e.Message);
                Console.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                log.Add(e.Message);
            }

            if (arquivos != null)
            {
                foreach (System.IO.FileInfo arq in arquivos)
                {
                    //Console.WriteLine(arq.FullName);
                    quantidade_arq_dir++;
                }

                // Encontra todos os subdiretorios do diretorio atual.
                subDiretorios = raiz.GetDirectories();

                foreach (System.IO.DirectoryInfo subdir in subDiretorios)
                {
                    // Chamada Recursiva para cada subdiretorio.
                    Passeio_Raiz_Diretorios(subdir);
                }
            }
        }

        /********************************************************************************/
        //***************Copia todos arquivos de um diretório para outro*****************/
        /********************************************************************************/
        public void Copia_Todos_Arquivos(System.IO.DirectoryInfo origem, System.IO.DirectoryInfo destino)
        {
            if (origem.FullName.ToLower() == destino.FullName.ToLower())
            {
                return;
            }

            if (!System.IO.Directory.Exists(destino.FullName))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(destino.FullName);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    log.Add(e.Message);
                }
            }

            foreach (System.IO.FileInfo fi in origem.GetFiles())
            {

                try
                {
                    Console.WriteLine(@"Copiando ... {0}\{1}", destino.FullName, fi.Name);
                    fi.CopyTo(System.IO.Path.Combine(destino.ToString(), fi.Name), true);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    log.Add(e.Message);
                }

            }

            foreach (System.IO.DirectoryInfo diSourceSubDir in origem.GetDirectories())
            {
                System.IO.DirectoryInfo nextTargetSubDir = destino.CreateSubdirectory(diSourceSubDir.Name);
                Copia_Todos_Arquivos(diSourceSubDir, nextTargetSubDir);
            }

        }
        /********************************************************************************/
        //***Copia todos arquivos de um diretório para outro com progress****************/
        /********************************************************************************/
        public void Copia_Todos_Arquivos_2(System.IO.DirectoryInfo origem, System.IO.DirectoryInfo destino, System.Windows.Forms.ProgressBar prb, 
                                           System.Windows.Forms.ProgressBar prb_arquivo)
        {
            if (origem.FullName.ToLower() == destino.FullName.ToLower())
            {
                return;
            }

            if (!System.IO.Directory.Exists(destino.FullName))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(destino.FullName);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    log.Add(e.Message);
                }
            }

            foreach (System.IO.FileInfo fi in origem.GetFiles())
            {

                try
                {
                    CustomFileCopier copia = new CustomFileCopier(fi.FullName, Path.Combine(destino.ToString(), fi.Name));
                    copia.Copy(prb_arquivo);
                    prb.PerformStep();
                    //Console.WriteLine(@"Copiando ... {0}\{1}", destino.FullName, fi.Name);
                    //fi.CopyTo(System.IO.Path.Combine(destino.ToString(), fi.Name), true);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    log.Add(e.Message);
                }

            }

            foreach (System.IO.DirectoryInfo diSourceSubDir in origem.GetDirectories())
            {
                System.IO.DirectoryInfo nextTargetSubDir = destino.CreateSubdirectory(diSourceSubDir.Name);
                Copia_Todos_Arquivos_2(diSourceSubDir, nextTargetSubDir, prb, prb_arquivo);
            }

        }
        /********************************************************************************/
        //*************Verifica arquivos com acesso restrito*****************************/
        /********************************************************************************/
        public void ArquivosRestritos()
        {
            Console.WriteLine("Arquivos com acesso restrito:");
            foreach (string s in log)
            {
                Console.WriteLine(s);
            }
        }
        /********************************************************************************/
        //*************Verifica arquivos com acesso restrito*****************************/
        /********************************************************************************/
        public int GetNumArquivos()
        {
            return (quantidade_arq_dir);
        }

        /********************************************************************************/
        //**************Seta o Diretorio Passado como Diretorio Padrão*******************/
        /********************************************************************************/
        public void SetDiretorioAtual(string path)
        {
            System.IO.Directory.SetCurrentDirectory(path);
        }
        /********************************************************************************/
        //**************Pega o Diretorio Padrão******************************************/
        /********************************************************************************/
        public string GetDiretorioAtual()
        {
            return (System.IO.Directory.GetCurrentDirectory());
        }
        /********************************************************************************/
        //**************Montar Particao de acordo com os parametros**********************/
        /********************************************************************************/
        public void Montar_Particao(string montagem, string estacao, string unidade, string diretorio)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            //p.StartInfo.Arguments = @"/C net use x: \\stg-ope1010\c$\Windows armYR0om /USER:Administrador /PERSISTENT:yes";
            p.StartInfo.Arguments = @"/C net use " + montagem + ":" + " \\" + "\\" + estacao + "\\" + unidade + "$" + "\\" + diretorio + " armYR0om /USER:Administrador /PERSISTENT:yes";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();

            string teste = @"/C net use " + montagem + ":" + " \\" + "\\" + estacao + "\\" + unidade + "$" + "\\" + diretorio + " armYR0om /USER:Administrador /PERSISTENT:yes";

            string resposta = p.StandardOutput.ReadToEnd();

            Console.WriteLine("Resposta: ");
            Console.WriteLine("{0}", resposta);
            Console.WriteLine("String: ");
            Console.WriteLine("{0}", teste);
        }
        /********************************************************************************/
        //**************Desmontar Particao de acordo com os parametros*******************/
        /********************************************************************************/
        public void Desmontar_Particao(string montagem)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            //p.StartInfo.Arguments = @"/C net use x: \\stg-ope1010\c$\Windows armYR0om /USER:Administrador /PERSISTENT:yes";
            p.StartInfo.Arguments = @"/C net use " + montagem + ":" + " /DELETE";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();

            string resposta = p.StandardOutput.ReadToEnd();
            string teste = @"/C net use " + montagem + ":" + " /DELETE";

            Console.WriteLine("Resposta: ");
            Console.WriteLine("{0}", teste);

        }



    }
}
