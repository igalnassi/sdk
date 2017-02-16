﻿using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LibraryWithRid
{
    public class NativeCode
    {
        public static string InvokeNativeCodeAndReturnAString()
        {
            switch(GetRidStoredInAssemblyDescriptionAttribute())
            {
                case "'ubuntu.14.04-x64'":
                    return Marshal.PtrToStringAnsi(NativeMethod.sqlite3_libversion());
                case "'osx.10.11-x64'": 
                    return Marshal.PtrToStringAnsi(NativeMethod.sqlite3_dylibversion());
                case "'win10-x64'":
                    return Marshal.PtrToStringAnsi(NativeMethod.sqlite3_dllversion());
                default:
                    return "Unexpected RID. Cannot find sqlite3.";
            }            
        }

        public static string GetRidStoredInAssemblyDescriptionAttribute()
        {
            return typeof(NativeCode)
                .GetTypeInfo()
                .Assembly
                .GetCustomAttribute<AssemblyDescriptionAttribute>()
                ?.Description;
        }
    }
}
