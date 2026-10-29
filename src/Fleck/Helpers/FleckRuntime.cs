using System;
using System.Runtime.InteropServices;

namespace Fleck.Helpers
{
    internal static class FleckRuntime
    {
        public static bool IsRunningOnMono()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e7828b25-a6b4-4a3d-b4b2-449c24393821" + System.Environment.NewLine);
            return Type.GetType("Mono.Runtime") != null;
        }

        public static bool IsRunningOnWindows()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "166c2031-a356-4047-bc66-214ba594d517" + System.Environment.NewLine);
#if NET45 || NET40
            return true;
#else
            return (RuntimeInformation.IsOSPlatform(OSPlatform.Windows));
#endif
        }
    }
}