using JournalTrace.Native;
using System;
using System.Collections.Generic;

namespace JournalTrace.Entry
{
    public class USNEntry
    {
        public long USN { get; set; }
        public string Name { get; set; }
        public ulong FileReference { get; set; }
        public ulong ParentFileReference { get; set; }
        public string Time { get; set; }
        public string Reason { get; set; }

        public USNEntry(long usn, string name, ulong fileReference, ulong parentFileReference, long dateTime, uint reason)
        {
            USN = usn;
            Name = name;
            FileReference = fileReference;
            ParentFileReference = parentFileReference;

            this.rawTimestamp = dateTime;
            this.rawReason = reason;
        }

        private long rawTimestamp;
        private uint rawReason;

        public void ResolveInfo()
        {
            DateTime epoch = new DateTime(1601, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            Time = epoch.AddTicks(rawTimestamp).ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss");
            List<string> reasons = new List<string>();

            uint value = rawReason & Win32Api.USN_REASON_DATA_OVERWRITE;
            if (0 != value)
            {
                reasons.Add("Data overwrite");
            }
            value = rawReason & Win32Api.USN_REASON_DATA_EXTEND;
            if (0 != value)
            {
                reasons.Add("Data extend");
            }
            value = rawReason & Win32Api.USN_REASON_DATA_TRUNCATION;
            if (0 != value)
            {
                reasons.Add("Data truncation");
            }
            value = rawReason & Win32Api.USN_REASON_NAMED_DATA_OVERWRITE;
            if (0 != value)
            {
                reasons.Add("Named data overwrite");
            }
            value = rawReason & Win32Api.USN_REASON_NAMED_DATA_EXTEND;
            if (0 != value)
            {
                reasons.Add("Named data extend");
            }
            value = rawReason & Win32Api.USN_REASON_NAMED_DATA_TRUNCATION;
            if (0 != value)
            {
                reasons.Add("Named data truncation");
            }
            value = rawReason & Win32Api.USN_REASON_FILE_CREATE;
            if (0 != value)
            {
                reasons.Add("File create");
            }
            value = rawReason & Win32Api.USN_REASON_FILE_DELETE;
            if (0 != value)
            {
                reasons.Add("File delete");
            }
            value = rawReason & Win32Api.USN_REASON_EA_CHANGE;
            if (0 != value)
            {
                reasons.Add("EA change");
            }
            value = rawReason & Win32Api.USN_REASON_SECURITY_CHANGE;
            if (0 != value)
            {
                reasons.Add("Security change");
            }
            value = rawReason & Win32Api.USN_REASON_RENAME_OLD_NAME;
            if (0 != value)
            {
                reasons.Add("Rename old name");
            }
            value = rawReason & Win32Api.USN_REASON_RENAME_NEW_NAME;
            if (0 != value)
            {
                reasons.Add("Rename new name");
            }
            value = rawReason & Win32Api.USN_REASON_INDEXABLE_CHANGE;
            if (0 != value)
            {
                reasons.Add("Indexable change");
            }
            value = rawReason & Win32Api.USN_REASON_BASIC_INFO_CHANGE;
            if (0 != value)
            {
                reasons.Add("Basic info change");
            }
            value = rawReason & Win32Api.USN_REASON_HARD_LINK_CHANGE;
            if (0 != value)
            {
                reasons.Add("Hard link change");
            }
            value = rawReason & Win32Api.USN_REASON_COMPRESSION_CHANGE;
            if (0 != value)
            {
                reasons.Add("Compression change");
            }
            value = rawReason & Win32Api.USN_REASON_ENCRYPTION_CHANGE;
            if (0 != value)
            {
                reasons.Add("Encryption change");
            }
            value = rawReason & Win32Api.USN_REASON_OBJECT_ID_CHANGE;
            if (0 != value)
            {
                reasons.Add("Object id change");
            }
            value = rawReason & Win32Api.USN_REASON_REPARSE_POINT_CHANGE;
            if (0 != value)
            {
                reasons.Add("Reparse point change");
            }
            value = rawReason & Win32Api.USN_REASON_STREAM_CHANGE;
            if (0 != value)
            {
                reasons.Add("Stream change");
            }
            value = rawReason & Win32Api.USN_REASON_CLOSE;
            if (0 != value)
            {
                reasons.Add("Close");
            }

            Reason = string.Join(" | ", reasons);
        }
    }
}