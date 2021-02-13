using System.Collections.Generic;

namespace JournalTrace.Entry
{
    public class USNCollection
    {
        public ulong ReferenceNumber { get; }

        public List<long> USNList { get; set; }

        public USNCollection(ulong referenceNumber)
        {
            ReferenceNumber = referenceNumber;
            USNList = new List<long>();
        }

        public USNCollection(ulong referenceNumber, long firstUSN)
        {
            ReferenceNumber = referenceNumber;
            USNList = new List<long>();
            USNList.Add(firstUSN);
        }
    }
}