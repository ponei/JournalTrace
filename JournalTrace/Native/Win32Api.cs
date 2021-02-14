using System;
using System.IO;
using System.Runtime.InteropServices;

namespace JournalTrace.Native
{
    public class Win32Api
    {
        #region enums

        public enum GetLastErrorEnum
        {
            INVALID_HANDLE_VALUE = -1,
            ERROR_SUCCESS = 0,
            ERROR_INVALID_FUNCTION = 1,
            ERROR_FILE_NOT_FOUND = 2,
            ERROR_PATH_NOT_FOUND = 3,
            ERROR_TOO_MANY_OPEN_FILES = 4,
            ERROR_ACCESS_DENIED = 5,
            ERROR_INVALID_HANDLE = 6,
            ERROR_INVALID_DATA = 13,
            ERROR_HANDLE_EOF = 38,
            ERROR_NOT_SUPPORTED = 50,
            ERROR_INVALID_PARAMETER = 87,
            ERROR_JOURNAL_DELETE_IN_PROGRESS = 1178,
            ERROR_JOURNAL_NOT_ACTIVE = 1179,
            ERROR_JOURNAL_ENTRY_DELETED = 1181,
            ERROR_INVALID_USER_BUFFER = 1784
        }


        public enum FILE_INFORMATION_CLASS
        {
            FileDirectoryInformation = 1,     // 1
            FileFullDirectoryInformation = 2,     // 2
            FileBothDirectoryInformation = 3,     // 3
            FileBasicInformation = 4,         // 4
            FileStandardInformation = 5,      // 5
            FileInternalInformation = 6,      // 6
            FileEaInformation = 7,        // 7
            FileAccessInformation = 8,        // 8
            FileNameInformation = 9,          // 9
            FileRenameInformation = 10,        // 10
            FileLinkInformation = 11,          // 11
            FileNamesInformation = 12,         // 12
            FileDispositionInformation = 13,       // 13
            FilePositionInformation = 14,      // 14
            FileFullEaInformation = 15,        // 15
            FileModeInformation = 16,     // 16
            FileAlignmentInformation = 17,     // 17
            FileAllInformation = 18,           // 18
            FileAllocationInformation = 19,    // 19
            FileEndOfFileInformation = 20,     // 20
            FileAlternateNameInformation = 21,     // 21
            FileStreamInformation = 22,        // 22
            FilePipeInformation = 23,          // 23
            FilePipeLocalInformation = 24,     // 24
            FilePipeRemoteInformation = 25,    // 25
            FileMailslotQueryInformation = 26,     // 26
            FileMailslotSetInformation = 27,       // 27
            FileCompressionInformation = 28,       // 28
            FileObjectIdInformation = 29,      // 29
            FileCompletionInformation = 30,    // 30
            FileMoveClusterInformation = 31,       // 31
            FileQuotaInformation = 32,         // 32
            FileReparsePointInformation = 33,      // 33
            FileNetworkOpenInformation = 34,       // 34
            FileAttributeTagInformation = 35,      // 35
            FileTrackingInformation = 36,      // 36
            FileIdBothDirectoryInformation = 37,   // 37
            FileIdFullDirectoryInformation = 38,   // 38
            FileValidDataLengthInformation = 39,   // 39
            FileShortNameInformation = 40,     // 40
            FileHardLinkInformation = 46    // 46
        }

        #endregion enums

        #region constants

        public const int INVALID_HANDLE_VALUE = -1;

        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint FILE_SHARE_READ = 0x00000001;
        public const uint FILE_SHARE_WRITE = 0x00000002;
        public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;

        public const uint CREATE_NEW = 1;
        public const uint CREATE_ALWAYS = 2;
        public const uint OPEN_EXISTING = 3;
        public const uint OPEN_ALWAYS = 4;
        public const uint TRUNCATE_EXISTING = 5;

        public const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        public const uint FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
        public const uint FileNameInformationClass = 9;
        public const uint FILE_OPEN_FOR_BACKUP_INTENT = 0x4000;
        public const uint FILE_OPEN_BY_FILE_ID = 0x2000;
        public const uint FILE_OPEN = 0x1;
        public const uint OBJ_CASE_INSENSITIVE = 0x40;
        //public const OBJ_KERNEL_HANDLE = 0x200;

        // CTL_CODE( DeviceType, Function, Method, Access ) (((DeviceType) << 16) | ((Access) << 14) | ((Function) << 2) | (Method))
        private const uint FILE_DEVICE_FILE_SYSTEM = 0x00000009;

        private const uint METHOD_NEITHER = 3;
        private const uint METHOD_BUFFERED = 0;
        private const uint FILE_ANY_ACCESS = 0;

        public const uint USN_REASON_DATA_OVERWRITE = 0x00000001;
        public const uint USN_REASON_DATA_EXTEND = 0x00000002;
        public const uint USN_REASON_DATA_TRUNCATION = 0x00000004;
        public const uint USN_REASON_NAMED_DATA_OVERWRITE = 0x00000010;
        public const uint USN_REASON_NAMED_DATA_EXTEND = 0x00000020;
        public const uint USN_REASON_NAMED_DATA_TRUNCATION = 0x00000040;
        public const uint USN_REASON_FILE_CREATE = 0x00000100;
        public const uint USN_REASON_FILE_DELETE = 0x00000200;
        public const uint USN_REASON_EA_CHANGE = 0x00000400;
        public const uint USN_REASON_SECURITY_CHANGE = 0x00000800;
        public const uint USN_REASON_RENAME_OLD_NAME = 0x00001000;
        public const uint USN_REASON_RENAME_NEW_NAME = 0x00002000;
        public const uint USN_REASON_INDEXABLE_CHANGE = 0x00004000;
        public const uint USN_REASON_BASIC_INFO_CHANGE = 0x00008000;
        public const uint USN_REASON_HARD_LINK_CHANGE = 0x00010000;
        public const uint USN_REASON_COMPRESSION_CHANGE = 0x00020000;
        public const uint USN_REASON_ENCRYPTION_CHANGE = 0x00040000;
        public const uint USN_REASON_OBJECT_ID_CHANGE = 0x00080000;
        public const uint USN_REASON_REPARSE_POINT_CHANGE = 0x00100000;
        public const uint USN_REASON_STREAM_CHANGE = 0x00200000;
        public const uint USN_REASON_CLOSE = 0x80000000;

        public static int GWL_EXSTYLE = -20;
        public static int WS_EX_LAYERED = 0x00080000;
        public static int WS_EX_TRANSPARENT = 0x00000020;

        public const uint FSCTL_GET_OBJECT_ID = 0x9009c;

        // FSCTL_ENUM_USN_DATA = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 44,  METHOD_NEITHER, FILE_ANY_ACCESS)
        public const uint FSCTL_ENUM_USN_DATA = (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_ANY_ACCESS << 14) | (44 << 2) | METHOD_NEITHER;

        // FSCTL_READ_USN_JOURNAL = CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 46,  METHOD_NEITHER, FILE_ANY_ACCESS)
        public const uint FSCTL_READ_USN_JOURNAL = (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_ANY_ACCESS << 14) | (46 << 2) | METHOD_NEITHER;

        //  FSCTL_CREATE_USN_JOURNAL        CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 57,  METHOD_NEITHER, FILE_ANY_ACCESS)
        public const uint FSCTL_CREATE_USN_JOURNAL = (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_ANY_ACCESS << 14) | (57 << 2) | METHOD_NEITHER;

        //  FSCTL_QUERY_USN_JOURNAL         CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 61, METHOD_BUFFERED, FILE_ANY_ACCESS)
        public const uint FSCTL_QUERY_USN_JOURNAL = (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_ANY_ACCESS << 14) | (61 << 2) | METHOD_BUFFERED;

        // FSCTL_DELETE_USN_JOURNAL        CTL_CODE(FILE_DEVICE_FILE_SYSTEM, 62, METHOD_BUFFERED, FILE_ANY_ACCESS)
        public const uint FSCTL_DELETE_USN_JOURNAL = (FILE_DEVICE_FILE_SYSTEM << 16) | (FILE_ANY_ACCESS << 14) | (62 << 2) | METHOD_BUFFERED;

        #endregion constants

        #region dll imports

        /// <summary>
        /// Creates the file specified by 'lpFileName' with desired access, share mode, security attributes,
        /// creation disposition, flags and attributes.
        /// </summary>
        /// <param name="lpFileName">Fully qualified path to a file</param>
        /// <param name="dwDesiredAccess">Requested access (write, read, read/write, none)</param>
        /// <param name="dwShareMode">Share mode (read, write, read/write, delete, all, none)</param>
        /// <param name="lpSecurityAttributes">IntPtr to a 'SECURITY_ATTRIBUTES' structure</param>
        /// <param name="dwCreationDisposition">Action to take on file or device specified by 'lpFileName' (CREATE_NEW,
        /// CREATE_ALWAYS, OPEN_ALWAYS, OPEN_EXISTING, TRUNCATE_EXISTING)</param>
        /// <param name="dwFlagsAndAttributes">File or device attributes and flags (typically FILE_ATTRIBUTE_NORMAL)</param>
        /// <param name="hTemplateFile">IntPtr to a valid handle to a template file with 'GENERIC_READ' access right</param>
        /// <returns>IntPtr handle to the 'lpFileName' file or device or 'INVALID_HANDLE_VALUE'</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr
            CreateFile(string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        /// <summary>
        /// Closes the file specified by the IntPtr 'hObject'.
        /// </summary>
        /// <param name="hObject">IntPtr handle to a file</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
		[DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool
            CloseHandle(
            IntPtr hObject);

        /// <summary>
        /// Fills the 'BY_HANDLE_FILE_INFORMATION' structure for the file specified by 'hFile'.
        /// </summary>
        /// <param name="hFile">Fully qualified name of a file</param>
        /// <param name="lpFileInformation">Out BY_HANDLE_FILE_INFORMATION argument</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool
            GetFileInformationByHandle(
            IntPtr hFile,
            out BY_HANDLE_FILE_INFORMATION lpFileInformation);

        /// <summary>
        /// Deletes the file specified by 'fileName'.
        /// </summary>
        /// <param name="fileName">Fully qualified path to the file to delete</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteFile(
            string fileName);

        /// <summary>
        /// Read data from the file specified by 'hFile'.
        /// </summary>
        /// <param name="hFile">IntPtr handle to the file to read</param>
        /// <param name="lpBuffer">IntPtr to a buffer of bytes to receive the bytes read from 'hFile'</param>
        /// <param name="nNumberOfBytesToRead">Number of bytes to read from 'hFile'</param>
        /// <param name="lpNumberOfBytesRead">Number of bytes read from 'hFile'</param>
        /// <param name="lpOverlapped">IntPtr to an 'OVERLAPPED' structure</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
		[DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadFile(
            IntPtr hFile,
            IntPtr lpBuffer,
            uint nNumberOfBytesToRead,
            out uint lpNumberOfBytesRead,
            IntPtr lpOverlapped);

        /// <summary>
        /// Writes the
        /// </summary>
        /// <param name="hFile">IntPtr handle to the file to write</param>
        /// <param name="bytes">IntPtr to a buffer of bytes to write to 'hFile'</param>
        /// <param name="nNumberOfBytesToWrite">Number of bytes in 'lpBuffer' to write to 'hFile'</param>
        /// <param name="lpNumberOfBytesWritten">Number of bytes written to 'hFile'</param>
        /// <param name="overlapped">IntPtr to an 'OVERLAPPED' structure</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteFile(
            IntPtr hFile,
            IntPtr bytes,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            int overlapped);

        /// <summary>
        /// Sends the 'dwIoControlCode' to the device specified by 'hDevice'.
        /// </summary>
        /// <param name="hDevice">IntPtr handle to the device to receive 'dwIoControlCode'</param>
        /// <param name="dwIoControlCode">Device IO Control Code to send</param>
        /// <param name="lpInBuffer">Input buffer if required</param>
        /// <param name="nInBufferSize">Size of input buffer</param>
        /// <param name="lpOutBuffer">Output buffer if required</param>
        /// <param name="nOutBufferSize">Size of output buffer</param>
        /// <param name="lpBytesReturned">Number of bytes returned in output buffer</param>
        /// <param name="lpOverlapped">IntPtr to an 'OVERLAPPED' structure</param>
        /// <returns>'true' if successful, otherwise 'false'</returns>
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            IntPtr lpInBuffer,
            int nInBufferSize,
            out USN_JOURNAL_DATA lpOutBuffer,
            int nOutBufferSize,
            out uint lpBytesReturned,
            IntPtr lpOverlapped);

        /// <summary>
        /// Sends the control code 'dwIoControlCode' to the device driver specified by 'hDevice'.
        /// </summary>
        /// <param name="hDevice">IntPtr handle to the device to receive 'dwIoControlCode</param>
        /// <param name="dwIoControlCode">Device IO Control Code to send</param>
        /// <param name="lpInBuffer">Input buffer if required</param>
        /// <param name="nInBufferSize">Size of input buffer </param>
        /// <param name="lpOutBuffer">Output buffer if required</param>
        /// <param name="nOutBufferSize">Size of output buffer</param>
        /// <param name="lpBytesReturned">Number of bytes returned</param>
        /// <param name="lpOverlapped">Pointer to an 'OVERLAPPED' struture</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            IntPtr lpInBuffer,
            int nInBufferSize,
            IntPtr lpOutBuffer,
            int nOutBufferSize,
            out uint lpBytesReturned,
            IntPtr lpOverlapped);

        /// <summary>
        /// Sets the number of bytes specified by 'size' of the memory associated with the argument 'ptr'
        /// to zero.
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="size"></param>
        [DllImport("kernel32.dll")]
        public static extern void ZeroMemory(IntPtr ptr, int size);

        /// <summary>
        /// Creates a new file or directory, or opens an existing file, device, directory, or volume
        /// </summary>
        /// <param name="handle">A pointer to a variable that receives the file handle if the call is successful (out)</param>
        /// <param name="access">ACCESS_MASK value that expresses the type of access that the caller requires to the file or directory (in)</param>
        /// <param name="objectAttributes">A pointer to a structure already initialized with InitializeObjectAttributes (in)</param>
        /// <param name="ioStatus">A pointer to a variable that receives the final completion status and information about the requested operation (out)</param>
        /// <param name="allocSize">The initial allocation size in bytes for the file (in)(optional)</param>
        /// <param name="fileAttributes">file attributes (in)</param>
        /// <param name="share">type of share access that the caller would like to use in the file (in)</param>
        /// <param name="createDisposition">what to do, depending on whether the file already exists (in)</param>
        /// <param name="createOptions">options to be applied when creating or opening the file (in)</param>
        /// <param name="eaBuffer">Pointer to an EA buffer used to pass extended attributes (in)</param>
        /// <param name="eaLength">Length of the EA buffer</param>
        /// <returns>either STATUS_SUCCESS or an appropriate error status. If it returns an error status, the caller can find more information about the cause of the failure by checking the IoStatusBlock</returns>
        [DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtCreateFile(
            ref IntPtr handle,
            FileAccess access,
            ref OBJECT_ATTRIBUTES objectAttributes,
            ref IO_STATUS_BLOCK ioStatus,
            ref long allocSize,
            uint fileAttributes,
            FileShare share,
            uint createDisposition,
            uint createOptions,
            IntPtr eaBuffer,
            uint eaLength);

        /// <summary>
        ///
        /// </summary>
        /// <param name="fileHandle"></param>
        /// <param name="IoStatusBlock"></param>
        /// <param name="pInfoBlock"></param>
        /// <param name="length"></param>
        /// <param name="fileInformation"></param>
        /// <returns></returns>
        [DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtQueryInformationFile(
            IntPtr fileHandle,
            ref IO_STATUS_BLOCK IoStatusBlock,
            IntPtr pInfoBlock,
            uint length,
            FILE_INFORMATION_CLASS fileInformation);

        #endregion dll imports

        #region structures

        /// <summary>
        /// By Handle File Information structure, contains File Attributes(32bits), Creation Time(FILETIME),
        /// Last Access Time(FILETIME), Last Write Time(FILETIME), Volume Serial Number(32bits),
        /// File Size High(32bits), File Size Low(32bits), Number of Links(32bits), File Index High(32bits),
        /// File Index Low(32bits).
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BY_HANDLE_FILE_INFORMATION
        {
            public uint FileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME CreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastWriteTime;
            public uint VolumeSerialNumber;
            public uint FileSizeHigh;
            public uint FileSizeLow;
            public uint NumberOfLinks;
            public uint FileIndexHigh;
            public uint FileIndexLow;
        }

        /// <summary>
        /// USN Journal Data structure, contains USN Journal ID(64bits), First USN(64bits), Next USN(64bits),
        /// Lowest Valid USN(64bits), Max USN(64bits), Maximum Size(64bits) and Allocation Delta(64bits).
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct USN_JOURNAL_DATA
        {
            public ulong UsnJournalID;
            public long FirstUsn;
            public long NextUsn;
            public long LowestValidUsn;
            public long MaxUsn;
            public ulong MaximumSize;
            public ulong AllocationDelta;
        }

        
        /// </summary>
        public class UsnEntry
        {
            //https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_record_v2
            //     typedef struct {
            //          DWORD RecordLength;
            //          WORD MajorVersion;
            //          WORD MinorVersion;
            //          DWORDLONG FileReferenceNumber;
            //          DWORDLONG ParentFileReferenceNumber;
            //          USN Usn;
            //          LARGE_INTEGER TimeStamp;
            //          DWORD Reason;
            //          DWORD SourceInfo;
            //          DWORD SecurityId;
            //          DWORD FileAttributes;
            //          WORD FileNameLength;
            //          WORD FileNameOffset;
            //          WCHAR FileName[1];
            //      }
            //      USN_RECORD_V2, *PUSN_RECORD_V2;

            //USN = lomg, long
            //LARGE_INTEGER = long, long
            //DWORDLONG = ulong, long
            //DWORD = uint, int32
            //WORD = short, int16

            private const int USN_LENGTH = sizeof(long); // 8
            private const int LARGE_INTEGER = sizeof(long); // 8
            private const int DWORDLONG = sizeof(ulong); // 8
            private const int DWORD = sizeof(uint); // 4
            private const int WORD = sizeof(short); // 2

            //offset = last offset + length of last type
            private const int REC_OFFSET = 0;

            private const int MAJV_OFFSET = REC_OFFSET + DWORD; // 4
            private const int MINV_OFFSET = MAJV_OFFSET + WORD; // 6
            private const int FR_OFFSET = MINV_OFFSET + WORD; // 8
            private const int PFR_OFFSET = FR_OFFSET + DWORDLONG; // 16
            private const int USN_OFFSET = PFR_OFFSET + DWORDLONG; // 24
            private const int TIME_OFFSET = USN_OFFSET + USN_LENGTH; // 32
            private const int REASON_OFFSET = TIME_OFFSET + LARGE_INTEGER; // 40
            private const int SRCINFO_OFFSET = REASON_OFFSET + DWORD; // 44
            private const int SECID_OFFSET = SRCINFO_OFFSET + DWORD; // 48
            private const int FA_OFFSET = SECID_OFFSET + DWORD; // 52
            private const int FNL_OFFSET = FA_OFFSET + DWORD; // 56
            private const int FNO_OFFSET = FNL_OFFSET + WORD; // 58

            public UsnEntry(IntPtr ptrToUsnRecord)
            {
                RecordLength = (uint)Marshal.ReadInt32(ptrToUsnRecord);
                MajorVersion = Marshal.ReadInt16(ptrToUsnRecord, MAJV_OFFSET);
                MinorVersion = Marshal.ReadInt16(ptrToUsnRecord, MINV_OFFSET);
                FileReferenceNumber = (ulong)Marshal.ReadInt64(ptrToUsnRecord, FR_OFFSET);
                ParentFileReferenceNumber = (ulong)Marshal.ReadInt64(ptrToUsnRecord, PFR_OFFSET);
                USN = Marshal.ReadInt64(ptrToUsnRecord, USN_OFFSET);
                TimeStamp = Marshal.ReadInt64(ptrToUsnRecord, TIME_OFFSET);
                Reason = (uint)Marshal.ReadInt32(ptrToUsnRecord, REASON_OFFSET);
                SourceInfo = (uint)Marshal.ReadInt32(ptrToUsnRecord, SRCINFO_OFFSET);
                SecurityId = (uint)Marshal.ReadInt32(ptrToUsnRecord, SECID_OFFSET);
                FileAttributes = (uint)Marshal.ReadInt32(ptrToUsnRecord, FA_OFFSET);
                short fileNameLength = Marshal.ReadInt16(ptrToUsnRecord, FNL_OFFSET);
                short fileNameOffset = Marshal.ReadInt16(ptrToUsnRecord, FNO_OFFSET);
                Name = Marshal.PtrToStringUni(new IntPtr(ptrToUsnRecord.ToInt32() + fileNameOffset), fileNameLength / sizeof(char));
            }

            public uint RecordLength { get; }

            public short MajorVersion { get; }

            public short MinorVersion { get; }

            public ulong FileReferenceNumber { get; }

            public ulong ParentFileReferenceNumber { get; }

            public long USN { get; }

            public long TimeStamp { get; }

            public uint Reason { get; }

            public uint SourceInfo { get; }

            public uint SecurityId { get; }

            public uint FileAttributes { get; }

            //FileNameLength and FileNameOffset are used to calculate Name, no reason to store it

            public string Name { get; }

            public bool IsFolder
            {
                get
                {
                    bool bRtn = false;
                    if (0 != (FileAttributes & FILE_ATTRIBUTE_DIRECTORY))
                    {
                        bRtn = true;
                    }
                    return bRtn;
                }
            }

            public bool IsFile
            {
                get
                {
                    bool bRtn = false;
                    if (0 == (FileAttributes & FILE_ATTRIBUTE_DIRECTORY))
                    {
                        bRtn = true;
                    }
                    return bRtn;
                }
            }

            public override string ToString()
            {
                return Name;
            }
        }

        /// <summary>
        /// Contains the Start USN(64bits), Reason Mask(32bits), Return Only on Close flag(32bits),
        /// Time Out(64bits), Bytes To Wait For(64bits), and USN Journal ID(64bits).
        /// </summary>
        /// <remarks> possible reason bits are from Win32Api
        /// USN_REASON_DATA_OVERWRITE
        /// USN_REASON_DATA_EXTEND
        /// USN_REASON_DATA_TRUNCATION
        /// USN_REASON_NAMED_DATA_OVERWRITE
        /// USN_REASON_NAMED_DATA_EXTEND
        /// USN_REASON_NAMED_DATA_TRUNCATION
        /// USN_REASON_FILE_CREATE
        /// USN_REASON_FILE_DELETE
        /// USN_REASON_EA_CHANGE
        /// USN_REASON_SECURITY_CHANGE
        /// USN_REASON_RENAME_OLD_NAME
        /// USN_REASON_RENAME_NEW_NAME
        /// USN_REASON_INDEXABLE_CHANGE
        /// USN_REASON_BASIC_INFO_CHANGE
        /// USN_REASON_HARD_LINK_CHANGE
        /// USN_REASON_COMPRESSION_CHANGE
        /// USN_REASON_ENCRYPTION_CHANGE
        /// USN_REASON_OBJECT_ID_CHANGE
        /// USN_REASON_REPARSE_POINT_CHANGE
        /// USN_REASON_STREAM_CHANGE
        /// USN_REASON_CLOSE
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct READ_USN_JOURNAL_DATA
        {
            public long StartUsn;
            public uint ReasonMask;
            public uint ReturnOnlyOnClose;
            public ulong Timeout;
            public ulong bytesToWaitFor;
            public ulong UsnJournalId;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IO_STATUS_BLOCK
        {
            public uint status;
            public ulong information;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct OBJECT_ATTRIBUTES
        {
            public int Length;
            public IntPtr RootDirectory;
            public IntPtr ObjectName;
            public int Attributes;
            public int SecurityDescriptor;
            public int SecurityQualityOfService;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct UNICODE_STRING
        {
            public short Length;
            public short MaximumLength;
            public IntPtr Buffer;
        }

        #endregion structures
    }
}