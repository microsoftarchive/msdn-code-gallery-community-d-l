using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Model;
using Service.Mapper;
using Patient = Hl7.Fhir.Model.Patient;

namespace Service.Handler
{
    class PatientResourceHandler : IResourceHandler
    {
        private const string PATIENT = "Patient";
        private readonly IRepository _repository;

        private String Serialize(Model.Patient patient)
        {
            var resource = PatientMapper.MapModel(patient);

            String payload = String.Empty;
            if (WebOperationContext.Current != null)
            {
                var response = WebOperationContext.Current.OutgoingResponse;
                
                response.LastModified = patient.Timestamp;
                string accept = WebOperationContext.Current.IncomingRequest.Accept;
                if (!String.IsNullOrEmpty(accept) && accept == "application/json")
                {
                    payload = FhirSerializer.SerializeResourceToJson(resource);
                    response.ContentType = "application/json+fhir";
                }
                else
                {
                    payload = FhirSerializer.SerializeResourceToXml(resource);
                    response.ContentType = "application/xml+fhir";
                }
            }
            return payload;
        }

        private Resource Parse(String format, String data)
        {
            Resource resource = null;
            if (format == "json")
            {
                resource = FhirParser.ParseResourceFromJson(data);
            }
            else if (format == "xml")
            {
                resource = FhirParser.ParseResourceFromXml(data);
            }

            if (resource == null)
            {
                throw new Exception(String.Format("HTTP content is invalid - does not correspond to content type {0}", format));
            }
            return resource;
        }
        

        public string Type()
        {
            return PATIENT;
        }

        public HttpStatusCode Create(string format, string data)
        {
            var resource = Parse(format, data);
            var patient = PatientMapper.MapResource(resource);

            // Create a new "Patient" resource in the repository
            _repository.CreatePatient( patient );

            var response = WebOperationContext.Current.OutgoingResponse;

            var uri = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.BaseUri;
            string fhirbase = uri.AbsoluteUri;
            string host = uri.Host;

            response.LastModified = patient.Timestamp;
            response.StatusCode = HttpStatusCode.Created;
            response.Headers.Add( "Host", host);

            response.Location = String.Format("{0}/Patient/{1}/_history/{2}", fhirbase, patient.PatientId, patient.Version);
            return HttpStatusCode.OK;
        }


        public HttpStatusCode Update(string patid, String format, String data)
        {
            int id = Int32.Parse(patid);            
            
            var resource = Parse(format, data);
            var patient = PatientMapper.MapResource(resource);
            patient.PatientId = id;

            // Upate "Patient" resource in the repository
            _repository.UpdatePatient(patient);

            var response = WebOperationContext.Current.OutgoingResponse;

            var uri = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.BaseUri;
            string fhirbase = uri.AbsoluteUri;
            string host = uri.Host;

            response.LastModified = patient.Timestamp;
            response.StatusCode = HttpStatusCode.Created;
            response.Headers.Add("Host", host);

            response.Location = String.Format("{0}/Patient/{1}/_history/{2}", fhirbase, patient.PatientId, patient.Version);
            return HttpStatusCode.OK;
        }


        public string Read(string patid)
        {
            int id = Int32.Parse(patid);

            // Get "Patient" resource by it's id from the repository
            var patient = _repository.ReadPatient(id);
            if (patient == null)
            {
                return String.Empty;
            }

            // Create response string
            return Serialize(patient);
        }

        public HttpStatusCode Delete(string patid)
        {
            // We currently do not report any conflict that might occur during the deletion
            // Since at this point in time only the Patient resource is implemented, this
            // this is no issue - there can b no conflicts ;-)
            
            int id = Int32.Parse(patid);
            bool result = _repository.DeletePatient(id);
            if (result == false) return HttpStatusCode.NotFound;
            return HttpStatusCode.NoContent;
        }

        public string List()
        {
            throw new NotImplementedException();
        }

        public string VRead(string patid, string version)
        {
            int id = Int32.Parse(patid);
            int vid = Int32.Parse(version);

            // Get historic "Patient" resource by it's id from the repository
            var history = _repository.ReadPatientHistory(id, vid);
            if (history == null)
            {
                return String.Empty;
            }

            // Create response string
            var fPatient = Serialize(history);
            return fPatient;
        }

        public PatientResourceHandler(IRepository repository)
        {
            _repository = repository;
        }


        public Conformance.ConformanceRestResourceComponent Metadata()
        {
            var patientConformance = new Conformance.ConformanceRestResourceComponent
            {
                Type = PATIENT,
                ReadHistory = false,
                Operation = new List<Conformance.ConformanceRestResourceOperationComponent>
                {
                    new Conformance.ConformanceRestResourceOperationComponent
                    {
                        Code = Conformance.RestfulOperationType.Create
                    },
                    new Conformance.ConformanceRestResourceOperationComponent
                    {
                        Code = Conformance.RestfulOperationType.Read
                    },
                    new Conformance.ConformanceRestResourceOperationComponent
                    {
                        Code = Conformance.RestfulOperationType.Update
                    },
                    new Conformance.ConformanceRestResourceOperationComponent
                    {
                        Code = Conformance.RestfulOperationType.Delete
                    },
                    new Conformance.ConformanceRestResourceOperationComponent
                    {
                        Code = Conformance.RestfulOperationType.SearchType
                    }
                }
            };

            #region CRUD operation support

            #endregion

            #region search operation support

            #endregion

            #region version related operation support
            #if false
            patientConformance.Operation.Add(new Conformance.ConformanceRestResourceOperationComponent()
            {
                Code = Conformance.RestfulOperationType.HistoryInstance
            });
            patientConformance.Operation.Add(new Conformance.ConformanceRestResourceOperationComponent()
            {
                Code = Conformance.RestfulOperationType.HistoryType
            });
            patientConformance.Operation.Add(new Conformance.ConformanceRestResourceOperationComponent()
            {
                Code = Conformance.RestfulOperationType.Vread
            });
            #endif
            #endregion

            #region validation operation support
            #if false
            patientConformance.Operation.Add(new Conformance.ConformanceRestResourceOperationComponent()
            {
                Code = Conformance.RestfulOperationType.Validate
            });
            #endif
            #endregion

            return patientConformance;
        }
    }
}
