using System;

namespace Fleck
{
    public static class IntExtensions
    {
        public static byte[] ToBigEndianBytes<T>(this int source)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "619b973b-996b-4203-b2be-2910dbd07d27" + System.Environment.NewLine);
            byte[] bytes;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ccb5afdb-1af0-43a0-b034-ec7be3994d32" + System.Environment.NewLine);
            var type = typeof(T);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d3d2cd5f-18d9-4793-9cd1-a291168ee034" + System.Environment.NewLine);
            if (type == typeof(ushort))
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "51337ca5-d122-40f6-bb88-724a87ecd6df" + System.Environment.NewLine);
                bytes = BitConverter.GetBytes((ushort)source);
            }
            else if (type == typeof(ulong))
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4a97c14b-907c-450d-8ef7-c75d5735f200" + System.Environment.NewLine);
                bytes = BitConverter.GetBytes((ulong)source);
            }
            else if (type == typeof(int))
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3ae1120c-bb89-425f-88c7-2b1c7780a99c" + System.Environment.NewLine);
                bytes = BitConverter.GetBytes(source);
            }
            else
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2058f6c4-2099-4a29-9183-fa3ebf2b4425" + System.Environment.NewLine);
                throw new InvalidCastException("Cannot be cast to T");
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ad1b48a4-c76e-43c5-b95b-a7c56b4f1173" + System.Environment.NewLine);
            if (BitConverter.IsLittleEndian)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e6fc312f-7815-4e2d-9586-d2fa17e58937" + System.Environment.NewLine);
                Array.Reverse(bytes);
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d4d6985b-235f-4c8b-be72-4800e263432a" + System.Environment.NewLine);
            return bytes;
        }

        public static int ToLittleEndianInt(this byte[] source)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "935e6051-304a-4335-b2a3-1fa77ffe06ce" + System.Environment.NewLine);
            if (BitConverter.IsLittleEndian)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f0ffcd9c-a1e4-4ca8-be4d-06484307b30f" + System.Environment.NewLine);
                Array.Reverse(source);
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b191f27f-4e2f-47d0-800c-8e3b6ed26450" + System.Environment.NewLine);
            if (source.Length == 2)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9873f690-f9e9-44b5-9fe8-a188116a4d4d" + System.Environment.NewLine);
                return BitConverter.ToUInt16(source, 0);
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0f91d485-2d44-4f27-bad8-0b4c13f56b56" + System.Environment.NewLine);
            if (source.Length == 8)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ef46ba41-d946-44c9-a63b-d72404b9eb92" + System.Environment.NewLine);
                return (int)BitConverter.ToUInt64(source, 0);
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e400c763-5d0a-4c42-b86d-2d1ae21d5f2c" + System.Environment.NewLine);
            throw new ArgumentException("Unsupported Size");
        }
    }
}