using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MailSlot
{
    class csMailSlotHelper
    {

        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateMailslot(string lpName,
                                            uint nMaxMessageSize,
                                            uint lReadTimeout,
                                            IntPtr lpSecurityAttributes);

        [DllImport("kernel32.dll")]
        public static extern bool GetMailslotInfo(IntPtr hMailslot,
                                           int lpMaxMessageSize,
                                           ref int lpNextSize,
                                           IntPtr lpMessageCount,
                                           IntPtr lpReadTimeout);


        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFile(string fileName,
                                        [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
                                        [MarshalAs(UnmanagedType.U4)] FileShare fileShare,
                                        int securityAttributes,
                                        [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
                                        int flags,
                                        IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        public unsafe static extern bool ReadFile(
                                    IntPtr hFile,                      // handle to file
                                    void* lpBuffer,                // data buffer
                                    int nNumberOfBytesToRead,       // number of bytes to read
                                    int* lpNumberOfBytesRead,    // number of bytes read
                                    int overlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite,
                                     out uint lpNumberOfBytesWritten, [In] ref System.Threading.NativeOverlapped lpOverlapped);
    }
}