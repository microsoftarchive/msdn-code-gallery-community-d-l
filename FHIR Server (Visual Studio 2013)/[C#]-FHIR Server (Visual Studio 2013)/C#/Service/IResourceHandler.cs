using System;
using System.Net;
using Hl7.Fhir.Model;

namespace Service
{
    public interface IResourceHandler
    {
        String Type();

        Conformance.ConformanceRestResourceComponent Metadata();

        String Read(string patid);
        String VRead(string patid, string version);
        String List();

        HttpStatusCode Create(string format, string data);
        HttpStatusCode Update(string patid, string format, string data);
        HttpStatusCode Delete(String patid);
    }
}
