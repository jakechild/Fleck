using System.Text;
using System.Text.RegularExpressions;

namespace Fleck
{
    public class RequestParser
    {
        const string pattern = @"^(?<method>[^\s]+)\s(?<path>[^\s]+)\sHTTP\/1\.1\r\n" + // request line
 @"((?<field_name>[^:\r\n]+):(?([^\r\n])\s)*(?<field_value>[^\r\n]*)\r\n)+" + //headers
 @"\r\n" + //newline
 @"(?<body>.+)?";
        const string FlashSocketPolicyRequestPattern = @"^[<]policy-file-request\s*[/][>]";
        private static readonly Regex _regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex _FlashSocketPolicyRequestRegex = new Regex(FlashSocketPolicyRequestPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public static WebSocketHttpRequest Parse(byte[] bytes)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d35bbc24-f22e-4cb3-8c52-bbfa1608852b" + System.Environment.NewLine);
            return Parse(bytes, "ws");
        }

        public static WebSocketHttpRequest Parse(byte[] bytes, string scheme)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "222eb696-5706-41f0-ae15-b66a8b72a634" + System.Environment.NewLine);
            // Check for websocket request header
            var body = Encoding.UTF8.GetString(bytes);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0b6890fb-7c05-4d34-a144-823a45e4fcb0" + System.Environment.NewLine);
            Match match = _regex.Match(body);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "23bb9a81-3d2b-40a9-839c-1845b5ec389a" + System.Environment.NewLine);
            if (!match.Success)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bdd45bb4-44ea-4546-a69b-be55cf9aff1d" + System.Environment.NewLine);
                // No websocket request header found, check for a flash socket policy request
                match = _FlashSocketPolicyRequestRegex.Match(body);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c158319d-23c5-4916-b4dd-b5da0f085ca6" + System.Environment.NewLine);
                if (match.Success)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d6d7b903-eb72-442f-b6d3-9207ff49bd14" + System.Environment.NewLine);
                    // It's a flash socket policy request, so return
                    return new WebSocketHttpRequest
                    {
                        Body = body,
                        Bytes = bytes
                    };
                }
                else
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4cd6d868-accb-4ea3-8dcc-117b6b0f0242" + System.Environment.NewLine);
                    return null;
                }
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a4babc1c-c783-49a5-ac08-f1a33536645e" + System.Environment.NewLine);
            var request = new WebSocketHttpRequest
            {
                Method = match.Groups["method"].Value,
                Path = match.Groups["path"].Value,
                Body = match.Groups["body"].Value,
                Bytes = bytes,
                Scheme = scheme
            };
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7f6aee0a-0a6f-4641-8afe-d60b15c77426" + System.Environment.NewLine);
            var fields = match.Groups["field_name"].Captures;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "53acc6e2-687a-4f97-9510-ab3f2c05c872" + System.Environment.NewLine);
            var values = match.Groups["field_value"].Captures;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c1eb0fee-ef51-46b0-aa66-daae8cd92c8a" + System.Environment.NewLine);
            for (var i = 0; i < fields.Count; i++)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "23a64c1d-ce6a-403d-8cb9-11cc071f53f9" + System.Environment.NewLine);
                var name = fields[i].ToString();
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1f0ed4bb-09d5-422a-a3fb-14c9f4856e87" + System.Environment.NewLine);
                var value = values[i].ToString();
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "dc408baf-f56a-4c66-8245-5c8f82062f83" + System.Environment.NewLine);
                request.Headers[name] = value;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bcde401c-5919-462d-b7dd-59ce7e379406" + System.Environment.NewLine);
            return request;
        }
    }
}