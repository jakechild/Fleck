using System;
using System.Linq;
using System.Collections.Generic;

namespace Fleck
{
    public static class SubProtocolNegotiator
    {
        public static string Negotiate(IEnumerable<string> server, IEnumerable<string> client)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1a8b3ace-ea2b-487f-a6da-f911f597ffbc" + System.Environment.NewLine);
            if (!server.Any() || !client.Any())
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f532043d-8ecf-4504-9004-5bcef7526577" + System.Environment.NewLine);
                return null;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cfc48b49-c4bd-40dd-b855-1452c7f47f55" + System.Environment.NewLine);
            var matches = client.Intersect(server);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "77fb8bcd-c937-40d3-8c02-b27614152da8" + System.Environment.NewLine);
            if (!matches.Any())
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "df9b6abe-3886-4e2e-9451-b61155fe0a64" + System.Environment.NewLine);
                throw new SubProtocolNegotiationFailureException("Unable to negotiate a subprotocol");
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "22494a57-a707-4ab1-83eb-652d608c717d" + System.Environment.NewLine);
            return matches.First();
        }
    }
}