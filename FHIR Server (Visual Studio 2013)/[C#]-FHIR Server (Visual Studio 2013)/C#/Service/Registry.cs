using System;
using System.Collections.Generic;
using Model;
using Service.Handler;
using Hl7.Fhir.Model;

namespace Service
{
    public class Registry
    {
        private readonly Dictionary<string, IResourceHandler> _servants;
        private readonly IRepository _repository;

        public Registry(IRepository repository)
        {
            _repository = repository;

            // Wire up all available handlers
            _servants = new Dictionary<string, IResourceHandler>();

            var patientHandler = new PatientResourceHandler( repository );
            _servants.Add( patientHandler.Type(), patientHandler);
        }

        public IResourceHandler GetHandler(String type)
        {
            if (_servants.ContainsKey(type))
            {
                return _servants[type];
            }
            return null;
        }



        /// <summary>
        /// Gets the conformance reflecting the capabilities of all registred servants.
        /// </summary>
        /// <returns>Conformance.</returns>
        public Conformance Metadata()
        {
            var conformance = new Conformance
            {
                Description = "This is an example implementation of an FHIR server - for demonstration purpose only.",
                Date = DateTime.UtcNow.ToString("s"),
                Experimental = true,
                AcceptUnknown = false,
                FhirVersion = "DSTU 1.1",
                Name = "FHIR Server for Patient Resources",
                Publisher = "MSDN Code Gallery, Stefan Heesch",
                Telecom =
                    new List<Contact>
                    {
                        new Contact {System = Contact.ContactSystem.Url, Value = "https://twitter.com/hb9tws"}
                    },
                Rest = new List<Conformance.ConformanceRestComponent>()
            };

            var rc = new Conformance.ConformanceRestComponent
            {
                Mode = Conformance.RestfulConformanceMode.Server,
                Resource = new List<Conformance.ConformanceRestResourceComponent>()
            };

            foreach (var servant in _servants.Values)
            {
                rc.Resource.Add( servant.Metadata() );
            }
            conformance.Rest.Add(rc);

            return conformance;
        }
    }
}
