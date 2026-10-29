using System;
using Fleck.Handlers;

namespace Fleck
{
    public class HandlerFactory
    {
        public static IHandler BuildHandler(WebSocketHttpRequest request, Action<string> onMessage, Action onClose, Action<byte[]> onBinary, Action<byte[]> onPing, Action<byte[]> onPong)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4f0a9692-b903-4a6f-8d1d-29aa8e229b7a" + System.Environment.NewLine);
            var version = GetVersion(request);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1d6a508e-e7e6-43e8-bc6e-00e230bfd5a6" + System.Environment.NewLine);
            switch (version)
            {
                case "76":
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "929ac5da-b0de-4e06-b3f0-86933d28577b" + System.Environment.NewLine);
                    return Draft76Handler.Create(request, onMessage);
                case "7":
                case "8":
                case "13":
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0b95c7ac-7c2e-48ce-b9a8-31718fa66acc" + System.Environment.NewLine);
                    return Hybi13Handler.Create(request, onMessage, onClose, onBinary, onPing, onPong);
                case "policy-file-request":
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "32d47882-0ace-450a-85bd-9b65d0bf451a" + System.Environment.NewLine);
                    return FlashSocketPolicyRequestHandler.Create(request);
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1e113dbc-29b9-43e5-85e0-eebf98b19d04" + System.Environment.NewLine);
            throw new WebSocketException(WebSocketStatusCodes.UnsupportedDataType);
        }

        public static string GetVersion(WebSocketHttpRequest request)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6a98d3d2-7484-48ab-9172-763a655e21ee" + System.Environment.NewLine);
            string version;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9d110e7e-c47f-4abc-8d60-e31bc4f90fa3" + System.Environment.NewLine);
            if (request.Headers.TryGetValue("Sec-WebSocket-Version", out version))
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ee692398-f0d4-437c-a638-4906f4abd60f" + System.Environment.NewLine);
                return version;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1b67174b-116b-4c72-90f5-55449b35f02e" + System.Environment.NewLine);
            if (request.Headers.TryGetValue("Sec-WebSocket-Draft", out version))
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "236952c2-11b2-4312-a824-73c105369920" + System.Environment.NewLine);
                return version;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c19bc9c6-842e-4b46-9ccd-6fdaabd295b3" + System.Environment.NewLine);
            if (request.Headers.ContainsKey("Sec-WebSocket-Key1"))
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7874cbb3-050b-4cf8-8e92-8b5dd55bb9b3" + System.Environment.NewLine);
                return "76";
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "02e17c4e-90ef-4598-b224-ff9c4eceb714" + System.Environment.NewLine);
            if ((request.Body != null) && request.Body.ToLower().Contains("policy-file-request"))
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4dca113f-41ef-4e87-944c-098bca107b65" + System.Environment.NewLine);
                return "policy-file-request";
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fe404642-bf11-4ffd-988b-13148cab385e" + System.Environment.NewLine);
            return "75";
        }
    }
}