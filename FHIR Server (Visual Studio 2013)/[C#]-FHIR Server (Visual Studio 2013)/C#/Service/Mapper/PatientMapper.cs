// ***********************************************************************
// Assembly         : Service
// Author           : SH
// Created          : 05-14-2014
//
// Last Modified By : SH
// Last Modified On : 05-14-2014
// ***********************************************************************
// <copyright file="PatientMapper.cs" author="Stefan Heesch">
//     Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Model;

namespace Service.Mapper
{
    /// <summary>
    /// Class PatientMapper
    /// Provides mappings between the HL7 FHIR Patient resource and our Model.Patient class
    /// </summary>
    /// <remarks>N/A</remarks>
    public class PatientMapper
    {
        public static Model.Patient MapResource(Resource resource)
        {
            var source = resource as Hl7.Fhir.Model.Patient;
            if (source == null)
            {
                throw new ArgumentException("Resource in not a HL7 FHIR Patient resouce");
            }

            var patient = new Model.Patient();

            patient.Active = source.Active ?? true;
            var deceased = source.Deceased as FhirBoolean;
            if (deceased != null)
                patient.Deceased = deceased.Value ?? false;

            patient.FirstName = source.Name[0].Given.FirstOrDefault();
            patient.LastName = source.Name[0].Family.FirstOrDefault();

            var phone = source.Telecom.FirstOrDefault(t => t.System == Contact.ContactSystem.Phone && t.Use == Contact.ContactUse.Home);
            if (phone != null)
                patient.Phone = phone.Value;

            var mobile = source.Telecom.FirstOrDefault(t => t.System == Contact.ContactSystem.Phone && t.Use == Contact.ContactUse.Mobile);
            if (mobile != null)
                patient.Mobile = mobile.Value;

            var email = source.Telecom.FirstOrDefault(t => t.System == Contact.ContactSystem.Email && t.Use == Contact.ContactUse.Home);
            if (email != null)
                patient.EMail = email.Value;

            var gender = source.Gender.Coding[0].Code.ToUpper();
            switch (gender)
            {
                case "U":
                    patient.Gender = GenderCode.Unknown;
                    break;
                case "F":
                    patient.Gender = GenderCode.Female;
                    break;
                case "M":
                    patient.Gender = GenderCode.Male;
                    break;
                case "UNK":
                    patient.Gender = GenderCode.Undetermined;
                    break;
                default:
                    patient.Gender = GenderCode.Unknown;
                    break;
            }

            // Example for extension "nationality"
            //
            var firstOrDefault = source.Extension.FirstOrDefault(x => x.Url.AbsolutePath == "http://www.englishclub.com/vocabulary/world-countries-nationality.htm");
            if (firstOrDefault != null)
            {
                var element = firstOrDefault.Value;
                var nationality = (FhirString) firstOrDefault.Value;
                patient.Nationality = nationality.Value;
            }

            var birthday = source.BirthDate;
            patient.Birthday = DateTime.Parse(birthday);

            return patient;
        }

        public static Hl7.Fhir.Model.Patient MapModel(Model.Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException("patient");   
            }

            var resource = new Hl7.Fhir.Model.Patient();

            resource.Id = patient.PatientId.ToString("D");

            resource.Active = patient.Active;
            resource.Deceased = new FhirBoolean(patient.Deceased);

            resource.Name = new List<HumanName>();
            var name = new HumanName()
            {
                Family = new[] { patient.LastName},
                Given = new[] { patient.FirstName},
                Use = HumanName.NameUse.Official
            };
            resource.Name.Add(name);

            resource.BirthDate = patient.Birthday.ToString("s");

            switch (patient.Gender)
            {
                case GenderCode.Female:
                    resource.Gender = new CodeableConcept("http://hl7.org/fhir/v3/AdministrativeGender","F","Female");
                    break;

                case GenderCode.Male:
                    resource.Gender = new CodeableConcept("http://hl7.org/fhir/v3/AdministrativeGender", "M", "Male");
                    break;

                case GenderCode.Undetermined:
                    resource.Gender = new CodeableConcept("http://hl7.org/fhir/v3/AdministrativeGender", "U", "Undetermined");
                    break;

                default:
                    resource.Gender = new CodeableConcept("http://hl7.org/fhir/v3/NullFlavor","UNK","Unknown");
                    break;
            }
            
            resource.Telecom = new List<Contact>
            {
                new Contact() {
                    Value = patient.Phone,
                    System = Contact.ContactSystem.Phone,
                    Use = Contact.ContactUse.Home
                },
                new Contact() {
                    Value = patient.Mobile,
                    System = Contact.ContactSystem.Phone,
                    Use = Contact.ContactUse.Mobile
                },
                new Contact() {
                        Value = patient.EMail,
                        System = Contact.ContactSystem.Email,
                        Use = Contact.ContactUse.Home
                },
            };

            resource.Address = new List<Address>
            {
                new Address()
                {
                    Country = patient.Country,
                    City = patient.City,
                    Zip = patient.Zip,
                    Line = new[]
                    {
                        patient.AddressLine1,
                        patient.AddressLine2
                    }
                }
            };

            // Make use of extensions ...
            //
            resource.Extension = new List<Extension>(1);
            resource.Extension.Add( new Extension( new Uri("http://www.englishclub.com/vocabulary/world-countries-nationality.htm"),
                                                   new FhirString(patient.Nationality)
                                                 ));

            return resource;
        }

    }
}
