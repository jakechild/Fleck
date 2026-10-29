using System;
using System.Collections.Generic;

namespace Fleck
{
    public class ReadState
    {
        public ReadState()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "810d0b10-8a33-4548-8a1a-f1e372ec8310" + System.Environment.NewLine);
            Data = new List<byte>();
        }

        public List<byte> Data { get; private set; }
        public FrameType? FrameType { get; set; }

        public void Clear()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "aad9aa41-af7a-4a22-a04d-d6c46795cf3a" + System.Environment.NewLine);
            Data.Clear();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "abf90f7f-1121-45ed-9e0e-0d3dcafd5460" + System.Environment.NewLine);
            FrameType = null;
        }
    }
}