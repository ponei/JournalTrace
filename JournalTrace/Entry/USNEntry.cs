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

        public void ResolveInfo(string[] usnReasons)
        {
            DateTime epoch = new DateTime(1601, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            Time = epoch.AddTicks(rawTimestamp).ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss");
            List<string> reasons = new List<string>();

            uint value = rawReason & Win32Api.USN_REASON_DATA_OVERWRITE;
            if (0 != value)
            {
                reasons.Add(usnReasons[0]);
            }
            value = rawReason & Win32Api.USN_REASON_DATA_EXTEND;
            if (0 != value)
            {
                reasons.Add(usnReasons[1]);
            }
            value = rawReason & Win32Api.USN_REASON_DATA_TRUNCATION;
            if (0 != value)
            {
                reasons.Add(usnReasons[2]);
            }
            value = rawReason & Win32Api.USN_REASON_NAMED_DATA_OVERWRITE;
            if (0 != value)
            {
                reasons.Add(usnReasons[3]);
            }
            value = rawReason & Win32Api.USN_REASON_NAMED_DATA_EXTEND;
            if (0 != value)
            {
                reasons.Add(usnReasons[4]);
            }
            value = rawReason & Win32Api.USN_REASON_NAMED_DATA_TRUNCATION;
            if (0 != value)
            {
                reasons.Add(usnReasons[5]);
            }
            value = rawReason & Win32Api.USN_REASON_FILE_CREATE;
            if (0 != value)
            {
                reasons.Add(usnReasons[6]);
            }
            value = rawReason & Win32Api.USN_REASON_FILE_DELETE;
            if (0 != value)
            {
                reasons.Add(usnReasons[7]);
            }
            value = rawReason & Win32Api.USN_REASON_EA_CHANGE;
            if (0 != value)
            {
                reasons.Add(usnReasons[8]);
            }
            value = rawReason & Win32Api.USN_REASON_SECURITY_CHANGE;
            if (0 != value)
            {
                reasons.Add(usnReasons[9]);
            }
            value = rawReason & Win32Api.USN_REASON_RENAME_OLD_NAME;
            if (0 != value)
            {
                reasons.Add(usnReasons[10]);
            }
            value = rawReason & Win32Api.USN_REASON_RENAME_NEW_NAME;
            if (0 != value)
            {
                reasons.Add(usnReasons[11]);
            }
            value = rawReason & Win32Api.USN_REASON_INDEXABLE_CHANGE;
            if (0 != value)
            {
                reasons.Add(usnReasons[12]);
            }
            value = rawReason & Win32Api.USN_REASON_BASIC_INFO_CHANGE;
            if (0 != value)
            {
                reasons.Add(usnReasons[13]);
            }
            value = rawReason & Win32Api.USN_REASON_HARD_LINK_CHANGE;
            if (0 != value)
            {
                reasons.Add(usnReasons[14]);
            }
            value = rawReason & Win32Api.USN_REASON_COMPRESSION_CHANGE;
            if (0 != value)
            {
                reasons.Add(usnReasons[15]);
            }
            value = rawReason & Win32Api.USN_REASON_ENCRYPTION_CHANGE;
            if (0 != value)
            {
                reasons.Add(usnReasons[16]);
            }
            value = rawReason & Win32Api.USN_REASON_OBJECT_ID_CHANGE;
            if (0 != value)
            {
                reasons.Add(usnReasons[17]);
            }
            value = rawReason & Win32Api.USN_REASON_REPARSE_POINT_CHANGE;
            if (0 != value)
            {
                reasons.Add(usnReasons[18]);
            }
            value = rawReason & Win32Api.USN_REASON_STREAM_CHANGE;
            if (0 != value)
            {
                reasons.Add(usnReasons[19]);
            }
            value = rawReason & Win32Api.USN_REASON_CLOSE;
            if (0 != value)
            {
                reasons.Add(usnReasons[20]);
            }

            Reason = string.Join(" | ", reasons);
        }
    }
}