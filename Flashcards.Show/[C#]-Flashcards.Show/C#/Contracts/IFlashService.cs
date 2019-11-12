using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ServiceModel;

namespace FlashCardsService.Contracts
{
    [MessageContract]
    public class UploadFileContentMessage
    {
        [MessageHeader(MustUnderstand = true)]
        public string SenderName { get; set; }

        [MessageBodyMember]
        public Stream FileByteStream { get; set; }
    }

    [MessageContract]
    public class UploadFileTokenMessage
    {
        [MessageBodyMember]
        public string Password { get; set; }
    }



    [ServiceContract]
    public interface IFlashCardService
    {
        [OperationContract]
        UploadFileTokenMessage UploadFile(UploadFileContentMessage fileToLoad);
        
        [OperationContract]
        string GetFileUri(string senderName, string password);
    }
}
