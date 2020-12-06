// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

[assembly: System.Security.AllowPartiallyTrustedCallers]
[assembly: System.Security.SecurityCritical]
namespace Microsoft.Tools.WindowsInstallerXml.Bootstrapper
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Contains native constants, functions, and structures for this assembly.
    /// </summary>
    internal static class NativeMethods
    {
        #region Error Constants
        internal const int S_OK = 0;
        internal const int E_MOREDATA = unchecked((int)0x800700ea);
        internal const int E_INSUFFICIENT_BUFFER = unchecked((int)0x8007007a);
        internal const int E_CANCELLED = unchecked((int)0x800704c7);
        internal const int E_ALREADYINITIALIZED = unchecked((int)0x800704df);
        internal const int E_NOTFOUND = unchecked((int)0x80070490);
        internal const int E_UNEXPECTED = unchecked((int)0x8000ffff);
        #endregion

        #region Functions
        [SuppressUnmanagedCodeSecurity]
        [SecurityCritical]
        [DllImport("shell32.dll", EntryPoint = "CommandLineToArgvW", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr CommandLineToArgvWNative(
            [MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine,
            out int pNumArgs
            );
        [SecurityTreatAsSafe]
        [SecurityCritical]
        internal static IntPtr CommandLineToArgvW(string lpCmdLine, out int pNumArgs)
        {
            return CommandLineToArgvWNative(lpCmdLine, out pNumArgs);
        }

        [SuppressUnmanagedCodeSecurity]
        [SecurityCritical]
        [DllImport("kernel32.dll", EntryPoint = "LocalFree", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr LocalFreeNative(
            IntPtr hMem
            );
        [SecurityTreatAsSafe]
        [SecurityCritical]
        internal static IntPtr LocalFree(IntPtr hMem)
        {
            return LocalFreeNative(hMem);
        }
        #endregion
    }
}
