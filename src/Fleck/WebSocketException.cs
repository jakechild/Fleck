using System;

namespace Fleck
{
    public class WebSocketException : Exception
    {
        public WebSocketException(ushort statusCode) : base()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fa7a8732-1c48-459f-ac7a-fc3862a82bc8" + System.Environment.NewLine);
            StatusCode = statusCode;
        }

        public WebSocketException(ushort statusCode, string message) : base(message)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "da210f31-616d-49c6-a974-9319d820f2fa" + System.Environment.NewLine);
            StatusCode = statusCode;
        }

        public WebSocketException(ushort statusCode, string message, Exception innerException) : base(message, innerException)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "baf7faa4-7226-4a16-a663-064b3843a7f0" + System.Environment.NewLine);
            StatusCode = statusCode;
        }

        public ushort StatusCode { get; private set; }
    }
}