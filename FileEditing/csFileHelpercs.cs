using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FileEditing
{
    public class csPermission
    {
        /// <summary>
        /// Set to one when the property is assigned.
        /// When 
        /// </summary>
        public bool[] PropertyInit = new bool[2];
        public bool AllPropertyLoaded => IsAllPropertyLoaded();

        private bool _canRead;
        public bool CanRead
        {
            get { return _canRead; }
            set { _canRead = value; PropertyInit[0] = true; }
        }

        private bool _canWrite;
        public bool CanWrite
        {
            get { return _canWrite; }
            set { _canWrite = value; PropertyInit[1] = true; }
        }

        private bool IsAllPropertyLoaded()
        {
            int iSum = 0;
            foreach (bool item in PropertyInit)
            {
                if (item) iSum += 1;
            }

            return iSum == PropertyInit.Length;
        }

        public static csPermission GetDirectoryPermission(string folderPath)
        {
            csPermission permission = new csPermission();

            try
            {
                // Attempt to get a list of security permissions from the folder. 
                // This will raise an exception if the path is read only or do not have access to view the permissions. 
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(folderPath);

                //Get the actual access rule
                AuthorizationRuleCollection accessRules = ds.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

                foreach (FileSystemAccessRule rule in accessRules)
                {
                    //Check read
                    if (rule.FileSystemRights.HasFlag(FileSystemRights.Read))
                    {
                        permission.CanRead = true;
                        if (permission.AllPropertyLoaded) return permission;
                    }

                    //Check write
                    if (rule.FileSystemRights.HasFlag(FileSystemRights.Write))
                    {
                        permission.CanWrite = true;
                        if (permission.AllPropertyLoaded) return permission;
                    }
                }

                return permission;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetDirectoryPermission:\r\n" + ex.Message);
                return permission;
            }
        }
    }
}


 
