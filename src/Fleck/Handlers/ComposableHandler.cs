using System;
using System.Collections.Generic;

namespace Fleck.Handlers
{
    public class ComposableHandler : IHandler
    {
        public Func<string, byte[]> Handshake = s => new byte[0];
        public Func<string, byte[]> TextFrame = x => new byte[0];
        public Func<byte[], byte[]> BinaryFrame = x => new byte[0];
        public Action<List<byte>> ReceiveData = delegate
        {
        };
        public Func<byte[], byte[]> PingFrame = i => new byte[0];
        public Func<byte[], byte[]> PongFrame = i => new byte[0];
        public Func<int, byte[]> CloseFrame = i => new byte[0];
        private readonly List<byte> _data = new List<byte>();
        public byte[] CreateHandshake(string subProtocol = null)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "83c59da3-4dc7-4f4c-a5d7-960fc57641d7" + System.Environment.NewLine);
            return Handshake(subProtocol);
        }

        public void Receive(IEnumerable<byte> data)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "687478f0-ee58-444d-a053-170de0895114" + System.Environment.NewLine);
            _data.AddRange(data);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "049fa6e2-6aea-4065-843c-2d58cd79e308" + System.Environment.NewLine);
            ReceiveData(_data);
        }

        public byte[] FrameText(string text)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4d4deb8d-d237-4fda-b58b-c310f99f3e1b" + System.Environment.NewLine);
            return TextFrame(text);
        }

        public byte[] FrameBinary(byte[] bytes)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ca6690f0-066d-42c2-b677-6e0fa1d32832" + System.Environment.NewLine);
            return BinaryFrame(bytes);
        }

        public byte[] FramePing(byte[] bytes)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "65b6b57a-ec0c-4195-8941-b1499c3d6b7d" + System.Environment.NewLine);
            return PingFrame(bytes);
        }

        public byte[] FramePong(byte[] bytes)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c7d1ce40-8771-42d2-a5e5-7b0cdf8a0556" + System.Environment.NewLine);
            return PongFrame(bytes);
        }

        public byte[] FrameClose(int code)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6c564732-2d25-4882-80b2-4008cd622dc4" + System.Environment.NewLine);
            return CloseFrame(code);
        }
    }
}