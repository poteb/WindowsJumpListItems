using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

DoSomeStuff();

void DoSomeStuff()
{
    if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        return;

    Console.WriteLine("Update jump list maximum number of items to: ");
    var input = Console.ReadLine();
    if (!int.TryParse(input, out _))
    {
        Console.WriteLine("Not an int.");
        return;
    }

    var reg = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
    if (reg == null)
    {
        Console.WriteLine("Could not find key");
        return;
    }

    reg.SetValue("JumpListItems_Maximum", input, RegistryValueKind.DWord);
}