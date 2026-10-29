using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fleck
{
    public class WebSocketConnectionInfo : IWebSocketConnectionInfo
    {
        const string CookiePattern = @"((;)*(\s)*(?<cookie_name>[^=]+)=(?<cookie_value>[^\;]+))+";
        private static readonly Regex CookieRegex = new Regex(CookiePattern, RegexOptions.Compiled);
        public static WebSocketConnectionInfo Create(WebSocketHttpRequest request, string clientIp, int clientPort, string negotiatedSubprotocol)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "67fc3920-7037-4c68-a9b8-5cdd6525664f" + System.Environment.NewLine);
            var info = new WebSocketConnectionInfo
            {
                Origin = request["Origin"] ?? request["Sec-WebSocket-Origin"],
                Host = request["Host"],
                SubProtocol = request["Sec-WebSocket-Protocol"],
                Path = request.Path,
                ClientIpAddress = clientIp,
                ClientPort = clientPort,
                NegotiatedSubProtocol = negotiatedSubprotocol,
                Headers = new Dictionary<string, string>(request.Headers, System.StringComparer.InvariantCultureIgnoreCase)
            };
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "739f9a2f-1548-4ceb-8327-c339dad1c991" + System.Environment.NewLine);
            var cookieHeader = request["Cookie"];
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e3aca7bc-50a6-451e-a153-b97db8713287" + System.Environment.NewLine);
            if (cookieHeader != null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4f10620e-f352-43fe-8bbf-3d1ffd98c48e" + System.Environment.NewLine);
                var match = CookieRegex.Match(cookieHeader);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6e238bb3-142d-4c0b-972a-9fed3949e16a" + System.Environment.NewLine);
                var fields = match.Groups["cookie_name"].Captures;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2ae81179-b841-4d09-8ebd-427a41724b3b" + System.Environment.NewLine);
                var values = match.Groups["cookie_value"].Captures;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8752794f-4474-4fe7-9c73-74c9e0722729" + System.Environment.NewLine);
                for (var i = 0; i < fields.Count; i++)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "82e18ee6-84c7-40e2-b170-0cbf2c542127" + System.Environment.NewLine);
                    var name = fields[i].ToString();
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "238f114a-6a59-4fad-aeb7-fcd9d322eb66" + System.Environment.NewLine);
                    var value = values[i].ToString();
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5c8444ff-ee53-41e8-aa30-192dea50fbe4" + System.Environment.NewLine);
                    info.Cookies[name] = value;
                }
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "24ccbeb3-fcf7-4892-b52a-5397dafe18d3" + System.Environment.NewLine);
            return info;
        }

        WebSocketConnectionInfo()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "174be374-4d70-47ed-bde6-16286ecc8492" + System.Environment.NewLine);
            Cookies = new Dictionary<string, string>();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "91fa20af-c6f8-4f72-a947-8e1488db0aa8" + System.Environment.NewLine);
            Id = Guid.NewGuid();
        }

        public string NegotiatedSubProtocol { get; private set; }
        public string SubProtocol { get; private set; }
        public string Origin { get; private set; }
        public string Host { get; private set; }
        public string Path { get; private set; }
        public string ClientIpAddress { get; set; }
        public int ClientPort { get; set; }
        public Guid Id { get; set; }
        public IDictionary<string, string> Cookies { get; private set; }
        public IDictionary<string, string> Headers { get; private set; }
    }
}