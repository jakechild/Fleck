using System.Collections.Generic;
using System;

namespace Fleck
{
    public class WebSocketHttpRequest
    {
        private readonly IDictionary<string, string> _headers = new Dictionary<string, string>(System.StringComparer.InvariantCultureIgnoreCase);
        public string Method { get; set; }
        public string Path { get; set; }
        public string Body { get; set; }
        public string Scheme { get; set; }
        public byte[] Bytes { get; set; }

        public string this[string name]
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "215ce2b3-7a8d-448a-8717-50d361d7b8a0" + System.Environment.NewLine);
                string value;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "840e4364-71f4-4099-bf7b-e2b6a3a233a5" + System.Environment.NewLine);
                return _headers.TryGetValue(name, out value) ? value : default(string);
            }
        }

        public IDictionary<string, string> Headers
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e43345eb-2acb-48c2-8677-6c7e0336add0" + System.Environment.NewLine);
                return _headers;
            }
        }

        public string[] SubProtocols
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "964b9d27-8324-471d-ad07-f6740620bc70" + System.Environment.NewLine);
                string value;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cc484539-ef55-40d4-a276-88e00c4dc924" + System.Environment.NewLine);
                return _headers.TryGetValue("Sec-WebSocket-Protocol", out value) ? value.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries) : new string[0];
            }
        }
    }
}