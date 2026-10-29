using System;
using System.Collections.Generic;
using System.Text;

namespace Fleck.Handlers
{
    public class FlashSocketPolicyRequestHandler
    {
        public static string PolicyResponse = "<?xml version=\"1.0\"?>\n" + "<cross-domain-policy>\n" + "   <allow-access-from domain=\"*\" to-ports=\"*\"/>\n" + "   <site-control permitted-cross-domain-policies=\"all\"/>\n" + "</cross-domain-policy>\n" + "\0";
        public static IHandler Create(WebSocketHttpRequest request)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fd1d7fad-5d96-4f48-b17c-87ba9891eaa6" + System.Environment.NewLine);
            return new ComposableHandler
            {
                Handshake = sub => FlashSocketPolicyRequestHandler.Handshake(request, sub),
            };
        }

        public static byte[] Handshake(WebSocketHttpRequest request, string subProtocol)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cbabef00-91e6-41b4-adaf-565b3836ce5b" + System.Environment.NewLine);
            FleckLog.Debug("Building Flash Socket Policy Response");
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5fbba925-1edb-409b-8729-740456af951a" + System.Environment.NewLine);
            return Encoding.UTF8.GetBytes(PolicyResponse);
        }
    }
}