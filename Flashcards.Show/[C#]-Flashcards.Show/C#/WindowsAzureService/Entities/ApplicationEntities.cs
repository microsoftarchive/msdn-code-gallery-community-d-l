using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data.Services.Common;

namespace FlashCardsService.Entities
{
    /// <summary>
    /// File information
    /// </summary>
    //[DataServiceKey("PartitionKey", "Name")]
    public class FlashCardFileInfo : TableServiceEntity
    {
        public FlashCardFileInfo()
        {
            PartitionKey = DateTime.UtcNow.ToString("MMddyyyy");
            RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
        }

        /// <summary>
        /// The partition key is the date
        /// </summary>
        //public string PartitionKey { get; set; }

        /// <summary>
        /// The name of the blbo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the blob container
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// The blob Uri
        /// </summary>
        public string BlobUri { get; set; }

        /// <summary>
        /// The token that must be presented to get access to the blob
        /// </summary>
        public Guid Token { get; set; }
    }

    /// <summary>
    /// User information 
    /// </summary>
    //[DataServiceKey("PartitionKey", "Email")]
    public class UserProfile : TableServiceEntity
    {

        public UserProfile() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">The email of the user</param>
        public UserProfile(string email)
        {
            var validator = new Regex(RegularExpressions.Email);
            if (!validator.IsMatch(email))
                throw new ArgumentException("email is not in the write format");

            //The partition key is the suffix of the email
            var parts = email.Split('.');
            PartitionKey = parts[parts.Length - 1];
            Email = email;

            RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
        }
       

        /// <summary>
        /// The email of the user acts as a username. 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The serialized list of blob names the user is allowed to access
        /// </summary>
        public byte[] VisibleBlobNames { get; set; }

       
        /// <summary>
        /// Get the list of visible blobs from the serialized list.
        /// </summary>
        /// <returns></returns>
        private List<string> GetListOfVisibleBlobs()
        {
            if (VisibleBlobNames == null)
                return null;

            try
            {
                var serilaizer = new DataContractSerializer(typeof(List<string>));
                var reader = XmlDictionaryReader.CreateBinaryReader(VisibleBlobNames, XmlDictionaryReaderQuotas.Max);
               
                return serilaizer.ReadObject(reader) as List<string>;                
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }          

        }

        /// <summary>
        /// Add a blob to the list of blobs the user is allowed to access
        /// </summary>
        /// <param name="blobName">The name of the blob</param>
        public void AddVisibleBlob(string blobName)
        {
            if (string.IsNullOrEmpty(blobName))
                return;

            var tmpList = GetListOfVisibleBlobs();
            if (tmpList != null)
                tmpList.Add(blobName);
            else
                tmpList = new List<string>() { blobName };

            var serilaizer = new DataContractSerializer(typeof(List<string>));
            var memStrm = new MemoryStream();
            var byteWriter = XmlDictionaryWriter.CreateBinaryWriter(memStrm);
            serilaizer.WriteObject(byteWriter, tmpList);
            byteWriter.Flush();
            VisibleBlobNames = memStrm.ToArray();            
        }


        /// <summary>
        /// Add blob names to the list of blobs the user is allowed to access
        /// </summary>
        /// <param name="blobNames">list of blob names to enter</param>
        public void AddVisibleBlobs(IEnumerable<string> blobNames)
        {
            if ((blobNames == null) || (blobNames.Count() == 0))
                return;

            var tmpList = GetListOfVisibleBlobs();
            if (tmpList != null)
            {
                tmpList.AddRange(blobNames);
                tmpList = tmpList.Distinct().ToList();
            }
            else
                tmpList = blobNames.ToList();

            var serilaizer = new DataContractSerializer(typeof(List<string>));  
            var memStrm = new MemoryStream();
            var byteWriter = XmlDictionaryWriter.CreateBinaryWriter(memStrm);
            serilaizer.WriteObject(byteWriter, tmpList);
            byteWriter.Flush();
            VisibleBlobNames= memStrm.ToArray();


         }
    }
}
