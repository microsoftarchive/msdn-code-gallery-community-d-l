using System.Linq;
using System.ServiceModel;

using Services.Properties;

namespace Services
{
    [ServiceContract]
    public class SchemaService
    {
        [OperationContract]
        public byte GetSchemaVersion()
        {
            return Settings.Default.SchemaVersion;
        }

        [OperationContract()]
        public Range GetIdRange(string machine)
        {
            IdRange range;
            using (var context = new IdRangesDataContext()) {
                var ranges = context.IdRanges;
                //fetch existing range if there is one
                if ((range = ranges.SingleOrDefault(r => r.Machine == machine)) == null) {
                    //otherwise generate a new range
                    range = new IdRange() { Machine = machine };
                    range.Min = ranges.Count() > 0 ? ranges.Max(r => r.Max) + 1 : Settings.Default.MinClientId;
                    range.Max = range.Min + Settings.Default.IdRange - 1;
                    context.IdRanges.InsertOnSubmit(range);
                    context.SubmitChanges();
                }
                return new Range(range.Min, range.Max);
            }
        }
    }
}