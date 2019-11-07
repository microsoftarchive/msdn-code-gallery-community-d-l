namespace SignatureAddin
{
    using Microsoft.Dynamics.Framework.UI.Extensibility;

    /// <summary>
    /// Interface definition for the signature addin.
    /// </summary>
    [ControlAddInExport("SignatureControl")]
    public interface ISignatureAddin
    {
        [ApplicationVisible]
        event ApplicationEventHandler AddInReady;

        [ApplicationVisible]
        event ApplicationEventHandler UpdateSignature;
        
        [ApplicationVisible]
        event SaveSignatureEventHandler SaveSignature;

        [ApplicationVisible]
        void ClearSignature();

        [ApplicationVisible]
        void PutSignature(string signatureData);
    }

    public delegate void SaveSignatureEventHandler(string signatureData);
}

