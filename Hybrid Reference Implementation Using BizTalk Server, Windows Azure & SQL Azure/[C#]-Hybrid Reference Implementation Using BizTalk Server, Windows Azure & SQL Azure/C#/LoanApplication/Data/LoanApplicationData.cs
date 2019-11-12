using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Contoso.Cloud.Integration.Demo.LoanApplication.Data
{
    [DataContract(Name = "LoanApplicationData", Namespace = "Contoso.Cloud.Integration.Demo")]
    public class LoanApplicationData
    {
        [DataMember(Name = "ApplicationID")]
        public string ApplicationID { get; set; }

        [DataMember()]
        public string Ssn { get; set; }

        [DataMember()]
        public string PropertyType { get; set; }

        [DataMember()]
        public string PropertyUse { get; set; }

        [DataMember()]
        public string CreditDescription { get; set; }

        [DataMember()]
        public string PropertyZip { get; set; }

        [DataMember()]
        public int EstimatedHomeValue { get; set; }

        [DataMember()]
        public int CurrentMorgagePayment { get; set; }

        [DataMember()]
        public int FirstMorgageBalance { get; set; }

        [DataMember()]
        public double CurrentInterestRate { get; set; }

        [DataMember()]
        public string FirstName { get; set; }

        [DataMember()]
        public string LastName { get; set; }

        [DataMember()]
        public DateTime DateOfBirth { get; set; }

        [DataMember()]
        public string Email { get; set; }

        [DataMember()]
        public string StreetAddress { get; set; }

        [DataMember()]
        public string City { get; set; }

        [DataMember()]
        public string State { get; set; }

        [DataMember()]
        public string MailingZip { get; set; }

        [DataMember()]
        public string Phone { get; set; }

        [DataMember()]
        public string Decision { get; set; }
    }
}
