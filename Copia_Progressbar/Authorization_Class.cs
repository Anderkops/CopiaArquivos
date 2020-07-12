using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Copia_Progressbar
{
    class Authorization_Class
    {

            /*DirectoryInfo di = new DirectoryInfo(directoryName);
            int i = 0;
            FileInfo[] files = di.GetFiles("*.txt");
            WindowsIdentity winID;
            FileSystemAccessRule rule;
 
            foreach (FileInfo f in files)            
            {
              Console.WriteLine(f.FullName.ToString());
 
              f.CreationTime = DateTime.Now;
              {
                winID = System.Security.Principal.WindowsIdentity.GetCurrent();
                rule = new FileSystemAccessRule(winID.Name, FileSystemRights.Read, AccessControlType.Deny);
                //AccessControlType.Deny // dont do this for impt files
 
                FileSecurity filerule = File.GetAccessControl(f.FullName.ToString());
                AuthorizationRuleCollection acl = filerule.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                //filerule.AddAccessRule(rule);
                filerule.RemoveAccessRule(rule);
                // Cehck before u do this 
         
                File.SetAccessControl(f.FullName.ToString(), filerule);
               }
        
               {
                winID = System.Security.Principal.WindowsIdentity.GetCurrent();
                rule = new FileSystemAccessRule(
                winID.Name, FileSystemRights.Read, AccessControlType.Allow);
                //AccessControlType.Deny // dont do this for impt files
 
                FileSecurity filerule = File.GetAccessControl(f.FullName.ToString());
                AuthorizationRuleCollection acl = filerule.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                filerule.AddAccessRule(rule);
                //filerule.RemoveAccessRule(rule);
                // Cehck before u do this 
                File.SetAccessControl(f.FullName.ToString(), filerule);
               }       

             }*/
      }
}

