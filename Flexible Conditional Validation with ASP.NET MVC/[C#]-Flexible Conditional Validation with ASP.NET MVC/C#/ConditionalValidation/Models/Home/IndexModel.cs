using System.Collections.Generic;

namespace ConditionalValidation.Models.Home
{
    public class IndexModel
    {
        public string Message { get; set; }
        public IEnumerable<PendingRequestModel> PendingRequests { get; set; }
    }
}