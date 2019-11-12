using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkNorthWind_cs
{
    [MetadataTypeAttribute(typeof(CustomerMetadata))]
    public partial class Customer : IValidatableObject
    {
        public Customer ShallowCopy()
        {
            return (Customer)this.MemberwiseClone();
        }
        /// <summary>
        /// When presented to the UI, you might want to tweak the messages e.g. remove names
        /// from message and just have the 'can not be empty message or other tweaks as desired.
        /// </summary>
        /// <param name="validationContext">ValidationContext</param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string message = "can not be empty";
            if (string.IsNullOrWhiteSpace(this.CompanyName))
            {
                yield return new ValidationResult($"Company name {message}", new[] { "CompanyName" });
            }
            if (string.IsNullOrWhiteSpace(this.ContactName))
            {
                yield return new ValidationResult($"Contact name {message}", new[] { "ContactName" });
            }
            if (string.IsNullOrWhiteSpace(this.ContactTitle))
            {
                yield return new ValidationResult($"Contact title {message}", new[] { "ContactTitle" });
            }
        }
    }
    /// <summary>
    /// This ensures these fields are not empty
    /// </summary>
    public class CustomerMetadata
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string ContactTitle { get; set; }
    }
}
