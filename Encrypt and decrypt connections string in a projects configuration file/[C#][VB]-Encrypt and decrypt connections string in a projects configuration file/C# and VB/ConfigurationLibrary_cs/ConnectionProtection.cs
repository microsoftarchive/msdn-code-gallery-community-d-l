using System;
using System.Configuration;
using System.IO;

namespace ConfigurationLibrary_cs
{
    public class ConnectionProtection
    {
        public string FileName { get; set; }
        public ConnectionProtection(string ExecutableFileName)
        {
            if (!(File.Exists(string.Concat(ExecutableFileName, ".config"))))
            {
                throw new FileNotFoundException(string.Concat(ExecutableFileName, ".config"));
            }
            FileName = ExecutableFileName;
        }
        private bool EncryptConnectionString(bool encrypt, string fileName)
        {
            bool success = true;
            Configuration configuration = null;

            try
            {

                configuration = ConfigurationManager.OpenExeConfiguration(fileName);
                ConnectionStringsSection configSection = configuration.GetSection("connectionStrings") 
                    as ConnectionStringsSection;

                if ((!(configSection.ElementInformation.IsLocked)) && (!(configSection.SectionInformation.IsLocked)))
                {
                    if (encrypt && (!configSection.SectionInformation.IsProtected))
                    {
                        // encrypt the file
                        configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }

                    if ((!encrypt) && configSection.SectionInformation.IsProtected) //encrypt is true so encrypt
                    {
                        // decrypt the file. 
                        configSection.SectionInformation.UnprotectSection();
                    }

                    configSection.SectionInformation.ForceSave = true;
                    configuration.Save();

                    success = true;

                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success;

        }
        public bool IsProtected()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(FileName);
            ConnectionStringsSection configSection = configuration.GetSection("connectionStrings") as ConnectionStringsSection;
            return configSection.SectionInformation.IsProtected;
        }
        public bool EncryptFile()
        {
            if (File.Exists(FileName))
            {
                return EncryptConnectionString(true, FileName);
            }
            else
            {
                return false;
            }
        }
        public bool DecryptFile()
        {
            if (File.Exists(FileName))
            {

                return EncryptConnectionString(false, FileName);

            }
            else
            {
                return false;
            }
        }

    }
}
