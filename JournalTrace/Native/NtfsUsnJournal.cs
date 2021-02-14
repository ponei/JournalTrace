using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace JournalTrace.Native
{
    public class NtfsUsnJournal : IDisposable
    {
        #region enum(s)

        public enum UsnJournalReturnCode
        {
            INVALID_HANDLE_VALUE = -1,
            USN_JOURNAL_SUCCESS = 0,
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
            USN_JOURNAL_NOT_ACTIVE = 1179,
            ERROR_JOURNAL_ENTRY_DELETED = 1181,
            ERROR_INVALID_USER_BUFFER = 1784,
            USN_JOURNAL_INVALID = 17001,
            VOLUME_NOT_NTFS = 17003,
            INVALID_FILE_REFERENCE_NUMBER = 17004,
            USN_JOURNAL_ERROR = 17005
        }

        #endregion enum(s)

        #region private member variables

        private DriveInfo _driveInfo = null;
        private uint _volumeSerialNumber;
        private IntPtr _usnJournalRootHandle;

        private bool bNtfsVolume;

        #endregion private member variables

        #region constructor(s)

        public NtfsUsnJournal(DriveInfo driveInfo)
        {
            _driveInfo = driveInfo;

            bNtfsVolume = true;

            IntPtr rootHandle = IntPtr.Zero;
            UsnJournalReturnCode usnRtnCode = GetRootHandle(out rootHandle);

            if (usnRtnCode == UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
            {
                _usnJournalRootHandle = rootHandle;
                usnRtnCode = GetVolumeSerialNumber(_driveInfo, out _volumeSerialNumber);
                if (usnRtnCode != UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
                {
                    throw new Win32Exception((int)usnRtnCode);
                }
            }
            else
            {
                throw new Win32Exception((int)usnRtnCode);
            }
        }

        #endregion constructor(s)

        #region public methods

        public UsnJournalReturnCode GetUsnJournalState(ref Win32Api.USN_JOURNAL_DATA usnJournalState)
        {
            UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS;

            if (bNtfsVolume)
            {
                if (_usnJournalRootHandle.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
                {
                    usnRtnCode = QueryUsnJournal(ref usnJournalState);
                }
                else
                {
                    usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE;
                }
            }

            return usnRtnCode;
        }

        public UsnJournalReturnCode GetUsnJournalEntries(Win32Api.USN_JOURNAL_DATA previousUsnState, UInt32 reasonMask, out List<Win32Api.UsnEntry> usnEntries, out Win32Api.USN_JOURNAL_DATA newUsnState)
        {
            DateTime startTime = DateTime.Now;
            usnEntries = new List<Win32Api.UsnEntry>();
            newUsnState = new Win32Api.USN_JOURNAL_DATA();
            UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.VOLUME_NOT_NTFS;

            if (bNtfsVolume)
            {
                if (_usnJournalRootHandle.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
                {
                    usnRtnCode = QueryUsnJournal(ref newUsnState);
                    if (usnRtnCode == UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
                    {
                        bool bReadMore = true;
                        int pbDataSize = sizeof(UInt64) * 0x4000;
                        IntPtr pbData = Marshal.AllocHGlobal(pbDataSize);
                        Win32Api.ZeroMemory(pbData, pbDataSize);
                        uint outBytesReturned = 0;

                        Win32Api.READ_USN_JOURNAL_DATA rujd = new Win32Api.READ_USN_JOURNAL_DATA();
                        rujd.StartUsn = previousUsnState.FirstUsn;
                        rujd.ReasonMask = reasonMask;
                        rujd.ReturnOnlyOnClose = 0;
                        rujd.Timeout = 0;
                        rujd.bytesToWaitFor = 0;
                        rujd.UsnJournalId = previousUsnState.UsnJournalID;
                        int sizeRujd = Marshal.SizeOf(rujd);

                        IntPtr rujdBuffer = Marshal.AllocHGlobal(sizeRujd);
                        Win32Api.ZeroMemory(rujdBuffer, sizeRujd);
                        Marshal.StructureToPtr(rujd, rujdBuffer, true);

                        Win32Api.UsnEntry usnEntry = null;

                        while (bReadMore)
                        {
                            bool bRtn = Win32Api.DeviceIoControl(
                                _usnJournalRootHandle,
                                Win32Api.FSCTL_READ_USN_JOURNAL,
                                rujdBuffer,
                                sizeRujd,
                                pbData,
                                pbDataSize,
                                out outBytesReturned,
                                IntPtr.Zero);
                            if (bRtn)
                            {
                                IntPtr pUsnRecord = new IntPtr(pbData.ToInt32() + sizeof(UInt64));
                                while (outBytesReturned > 60)   // while there are at least one entry in the usn journal
                                {
                                    usnEntry = new Win32Api.UsnEntry(pUsnRecord);
                                    if (usnEntry.USN >= newUsnState.NextUsn)
                                    {
                                        bReadMore = false;
                                        break;
                                    }
                                    usnEntries.Add(usnEntry);

                                    pUsnRecord = new IntPtr(pUsnRecord.ToInt32() + usnEntry.RecordLength);
                                    outBytesReturned -= usnEntry.RecordLength;
                                }
                            }
                            else
                            {
                                Win32Api.GetLastErrorEnum lastWin32Error = (Win32Api.GetLastErrorEnum)Marshal.GetLastWin32Error();
                                if (lastWin32Error == Win32Api.GetLastErrorEnum.ERROR_HANDLE_EOF)
                                {
                                    usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
                                }
                                else
                                {
                                    usnRtnCode = ConvertWin32ErrorToUsnError(lastWin32Error);
                                }
                                break;
                            }

                            Int64 nextUsn = Marshal.ReadInt64(pbData, 0);
                            if (nextUsn >= newUsnState.NextUsn)
                            {
                                break;
                            }
                            Marshal.WriteInt64(rujdBuffer, nextUsn);
                        }

                        Marshal.FreeHGlobal(rujdBuffer);
                        Marshal.FreeHGlobal(pbData);
                    }
                }
                else
                {
                    usnRtnCode = UsnJournalReturnCode.INVALID_HANDLE_VALUE;
                }
            }

           
            return usnRtnCode;
        }

        #endregion public methods

        #region private member functions

        /// <summary>
        /// Converts a Win32 Error to a UsnJournalReturnCode
        /// </summary>
        /// <param name="Win32LastError">The 'last' Win32 error.</param>
        /// <returns>
        /// INVALID_HANDLE_VALUE                error generated by Win32 Api calls.
        /// USN_JOURNAL_SUCCESS                 usn journal function succeeded.
        /// ERROR_INVALID_FUNCTION              error generated by Win32 Api calls.
        /// ERROR_FILE_NOT_FOUND                error generated by Win32 Api calls.
        /// ERROR_PATH_NOT_FOUND                error generated by Win32 Api calls.
        /// ERROR_TOO_MANY_OPEN_FILES           error generated by Win32 Api calls.
        /// ERROR_ACCESS_DENIED                 accessing the usn journal requires admin rights.
        /// ERROR_INVALID_HANDLE                error generated by Win32 Api calls.
        /// ERROR_INVALID_DATA                  error generated by Win32 Api calls.
        /// ERROR_HANDLE_EOF                    error generated by Win32 Api calls.
        /// ERROR_NOT_SUPPORTED                 error generated by Win32 Api calls.
        /// ERROR_INVALID_PARAMETER             error generated by Win32 Api calls.
        /// ERROR_JOURNAL_DELETE_IN_PROGRESS    usn journal delete is in progress.
        /// ERROR_JOURNAL_ENTRY_DELETED         usn journal entry lost, no longer available.
        /// ERROR_INVALID_USER_BUFFER           error generated by Win32 Api calls.
        /// USN_JOURNAL_INVALID                 usn journal is invalid, id's don't match or required entries lost.
        /// USN_JOURNAL_NOT_ACTIVE              usn journal is not active on volume.
        /// VOLUME_NOT_NTFS                     volume is not an NTFS volume.
        /// INVALID_FILE_REFERENCE_NUMBER       bad file reference number - see remarks.
        /// USN_JOURNAL_ERROR                   unspecified usn journal error.
        /// </returns>
        private UsnJournalReturnCode ConvertWin32ErrorToUsnError(Win32Api.GetLastErrorEnum Win32LastError)
        {
            UsnJournalReturnCode usnRtnCode;

            switch (Win32LastError)
            {
                case Win32Api.GetLastErrorEnum.ERROR_JOURNAL_NOT_ACTIVE:
                    usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_NOT_ACTIVE;
                    break;

                case Win32Api.GetLastErrorEnum.ERROR_SUCCESS:
                    usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
                    break;

                case Win32Api.GetLastErrorEnum.ERROR_HANDLE_EOF:
                    usnRtnCode = UsnJournalReturnCode.ERROR_HANDLE_EOF;
                    break;

                default:
                    usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_ERROR;
                    break;
            }

            return usnRtnCode;
        }

        /// <summary>
        /// Gets a Volume Serial Number for the volume represented by driveInfo.
        /// </summary>
        /// <param name="driveInfo">DriveInfo object representing the volume in question.</param>
        /// <param name="volumeSerialNumber">out parameter to hold the volume serial number.</param>
        /// <returns></returns>
        private UsnJournalReturnCode GetVolumeSerialNumber(DriveInfo driveInfo, out uint volumeSerialNumber)
        {
            //Console.WriteLine("GetVolumeSerialNumber() function entered for drive '{0}'", driveInfo.Name);

            volumeSerialNumber = 0;
            UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
            string pathRoot = string.Concat("\\\\.\\", driveInfo.Name);

            IntPtr hRoot = Win32Api.CreateFile(pathRoot,
                0,
                Win32Api.FILE_SHARE_READ | Win32Api.FILE_SHARE_WRITE,
                IntPtr.Zero,
                Win32Api.OPEN_EXISTING,
                Win32Api.FILE_FLAG_BACKUP_SEMANTICS,
                IntPtr.Zero);

            if (hRoot.ToInt32() != Win32Api.INVALID_HANDLE_VALUE)
            {
                Win32Api.BY_HANDLE_FILE_INFORMATION fi = new Win32Api.BY_HANDLE_FILE_INFORMATION();
                bool bRtn = Win32Api.GetFileInformationByHandle(hRoot, out fi);

                if (bRtn)
                {
                    UInt64 fileIndexHigh = (UInt64)fi.FileIndexHigh;
                    UInt64 indexRoot = (fileIndexHigh << 32) | fi.FileIndexLow;
                    volumeSerialNumber = fi.VolumeSerialNumber;
                }
                else
                {
                    usnRtnCode = (UsnJournalReturnCode)Marshal.GetLastWin32Error();
                }

                Win32Api.CloseHandle(hRoot);
            }
            else
            {
                usnRtnCode = (UsnJournalReturnCode)Marshal.GetLastWin32Error();
            }

            return usnRtnCode;
        }

        private UsnJournalReturnCode GetRootHandle(out IntPtr rootHandle)
        {
            //
            // private functions don't need to check for an NTFS volume or
            // a valid _usnJournalRootHandle handle
            //
            UsnJournalReturnCode usnRtnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
            rootHandle = IntPtr.Zero;
            string vol = string.Concat("\\\\.\\", _driveInfo.Name.TrimEnd('\\'));

            rootHandle = Win32Api.CreateFile(vol,
                 Win32Api.GENERIC_READ | Win32Api.GENERIC_WRITE,
                 Win32Api.FILE_SHARE_READ | Win32Api.FILE_SHARE_WRITE,
                 IntPtr.Zero,
                 Win32Api.OPEN_EXISTING,
                 0,
                 IntPtr.Zero);

            if (rootHandle.ToInt32() == Win32Api.INVALID_HANDLE_VALUE)
            {
                usnRtnCode = (UsnJournalReturnCode)Marshal.GetLastWin32Error();
            }

            return usnRtnCode;
        }

        /// <summary>
        /// This function queries the usn journal on the volume.
        /// </summary>
        /// <param name="usnJournalState">the USN_JOURNAL_DATA object that is associated with this volume</param>
        /// <returns></returns>
        private UsnJournalReturnCode QueryUsnJournal(ref Win32Api.USN_JOURNAL_DATA usnJournalState)
        {
            //
            // private functions don't need to check for an NTFS volume or
            // a valid _usnJournalRootHandle handle
            //
            UsnJournalReturnCode usnReturnCode = UsnJournalReturnCode.USN_JOURNAL_SUCCESS;
            int sizeUsnJournalState = Marshal.SizeOf(usnJournalState);
            UInt32 cb;

            bool fOk = Win32Api.DeviceIoControl(
                _usnJournalRootHandle,
                Win32Api.FSCTL_QUERY_USN_JOURNAL,
                IntPtr.Zero,
                0,
                out usnJournalState,
                sizeUsnJournalState,
                out cb,
                IntPtr.Zero);

            if (!fOk)
            {
                int lastWin32Error = Marshal.GetLastWin32Error();
                usnReturnCode = ConvertWin32ErrorToUsnError((Win32Api.GetLastErrorEnum)Marshal.GetLastWin32Error());
            }

            return usnReturnCode;
        }

        #endregion private member functions

        #region IDisposable Members

        public void Dispose()
        {
            Win32Api.CloseHandle(_usnJournalRootHandle);
        }

        #endregion IDisposable Members
    }
}