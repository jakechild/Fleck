using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Fleck.Handlers
{
    public static class Draft76Handler
    {
        private const byte End = 255;
        private const byte Start = 0;
        private const int MaxSize = 1024 * 1024 * 5;
        public static IHandler Create(WebSocketHttpRequest request, Action<string> onMessage)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "036d0bd8-785f-4e61-bee6-d6dd760acb7d" + System.Environment.NewLine);
            return new ComposableHandler
            {
                TextFrame = Draft76Handler.FrameText,
                Handshake = sub => Draft76Handler.Handshake(request, sub),
                ReceiveData = data => ReceiveData(onMessage, data)
            };
        }

        public static void ReceiveData(Action<string> onMessage, List<byte> data)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "866b550d-8b6b-4d0c-833d-708b153d70cd" + System.Environment.NewLine);
            while (data.Count > 0)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "620ff562-075d-4ab1-bafb-1d9032ebc882" + System.Environment.NewLine);
                if (data[0] != Start)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0abb6066-65d6-4d0c-b67c-f30fbbbc7038" + System.Environment.NewLine);
                    throw new WebSocketException(WebSocketStatusCodes.InvalidFramePayloadData);
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "565e71e4-fcd9-4bbf-86f4-3b654ac530f2" + System.Environment.NewLine);
                var endIndex = data.IndexOf(End);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7dda81fe-d1eb-44ff-bdba-c69242e5cdc4" + System.Environment.NewLine);
                if (endIndex < 0)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "53ef4254-6cec-46dc-9cb4-8a7ec4530cbe" + System.Environment.NewLine);
                    return;
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "48e7aa17-aa10-4651-9cfa-2216c24782cb" + System.Environment.NewLine);
                if (endIndex > MaxSize)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "46a633e5-97ef-4566-90e1-530bd7fc606a" + System.Environment.NewLine);
                    throw new WebSocketException(WebSocketStatusCodes.MessageTooBig);
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c86743d9-80be-4d5b-afef-ca0ea386eebb" + System.Environment.NewLine);
                var bytes = data.Skip(1).Take(endIndex - 1).ToArray();
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "113fd69a-c08b-4d01-ac45-f50551a607ab" + System.Environment.NewLine);
                data.RemoveRange(0, endIndex + 1);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7711c00f-a8fd-4a80-af10-1e87d83969e6" + System.Environment.NewLine);
                var message = Encoding.UTF8.GetString(bytes);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a573ab7b-bb3f-4182-b6ed-adf26e41cc55" + System.Environment.NewLine);
                onMessage(message);
            }
        }

        public static byte[] FrameText(string data)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2fcfdb1c-90cf-4c58-bc15-687d80b4cd87" + System.Environment.NewLine);
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0279a32d-6ff8-46db-957b-7d46ecda6483" + System.Environment.NewLine);
            // wrap the array with the wrapper bytes
            var wrappedBytes = new byte[bytes.Length + 2];
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9dc49b02-9f4d-4474-9206-9b4346e1ebcf" + System.Environment.NewLine);
            wrappedBytes[0] = Start;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a4affd77-48d9-4b00-90f7-0420fe6bc7e8" + System.Environment.NewLine);
            wrappedBytes[wrappedBytes.Length - 1] = End;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4bd6e3dd-a88f-4cc2-9689-e26110892147" + System.Environment.NewLine);
            Array.Copy(bytes, 0, wrappedBytes, 1, bytes.Length);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "92cb1efd-a7a2-45c9-af52-118ec290d428" + System.Environment.NewLine);
            return wrappedBytes;
        }

        public static byte[] Handshake(WebSocketHttpRequest request, string subProtocol)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c8e3edd8-0dfb-4a11-88d1-7186225f8bff" + System.Environment.NewLine);
            FleckLog.Debug("Building Draft76 Response");
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "afe4d1e1-ea71-4f18-997b-43c731574066" + System.Environment.NewLine);
            var builder = new StringBuilder();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fe3eaa43-0548-421d-9673-28da8aa64d52" + System.Environment.NewLine);
            builder.Append("HTTP/1.1 101 WebSocket Protocol Handshake\r\n");
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ec688862-f681-4ec7-be83-db3d00815047" + System.Environment.NewLine);
            builder.Append("Upgrade: WebSocket\r\n");
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f40be58a-115f-41b5-b008-76962c451351" + System.Environment.NewLine);
            builder.Append("Connection: Upgrade\r\n");
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a00dba0c-4c06-486b-ae16-c0b235f15968" + System.Environment.NewLine);
            builder.AppendFormat("Sec-WebSocket-Origin: {0}\r\n", request["Origin"]);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8b01253a-403b-468e-807c-f6b8dbe6a74e" + System.Environment.NewLine);
            builder.AppendFormat("Sec-WebSocket-Location: {0}://{1}{2}\r\n", request.Scheme, request["Host"], request.Path);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ef416a7c-68eb-41e8-9826-b6b6689cd5dd" + System.Environment.NewLine);
            if (subProtocol != null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bf229904-a61d-4848-8c6e-9a2064fa0734" + System.Environment.NewLine);
                builder.AppendFormat("Sec-WebSocket-Protocol: {0}\r\n", subProtocol);
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "13e4e9cd-5dce-4bd9-9093-9d64f8bbe83b" + System.Environment.NewLine);
            builder.Append("\r\n");
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e7cd3248-2d6f-4eab-85bd-52461b053c4f" + System.Environment.NewLine);
            var key1 = request["Sec-WebSocket-Key1"];
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "aff8d1a7-dc24-46fc-8554-03b24619df55" + System.Environment.NewLine);
            var key2 = request["Sec-WebSocket-Key2"];
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2a021ae7-4e69-48d8-a992-19717cf57d2a" + System.Environment.NewLine);
            var challenge = new ArraySegment<byte>(request.Bytes, request.Bytes.Length - 8, 8);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5e75b710-3a28-46bc-a70e-1bd895204704" + System.Environment.NewLine);
            var answerBytes = CalculateAnswerBytes(key1, key2, challenge);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "981506f1-510e-4c73-93c4-f36c8107b5e2" + System.Environment.NewLine);
            byte[] byteResponse = Encoding.ASCII.GetBytes(builder.ToString());
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a4241e97-7446-463e-bc9c-8ff679bf37f4" + System.Environment.NewLine);
            int byteResponseLength = byteResponse.Length;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a086d299-210e-4951-9d01-f9af6135a95c" + System.Environment.NewLine);
            Array.Resize(ref byteResponse, byteResponseLength + answerBytes.Length);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3aabc1d8-3cee-4e3a-a20b-8bf3a038b5e9" + System.Environment.NewLine);
            Array.Copy(answerBytes, 0, byteResponse, byteResponseLength, answerBytes.Length);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a13c8ecd-040a-40f0-8a35-29ea6c682c26" + System.Environment.NewLine);
            return byteResponse;
        }

        public static byte[] CalculateAnswerBytes(string key1, string key2, ArraySegment<byte> challenge)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e1f98f58-547e-438f-b17c-3811c2056843" + System.Environment.NewLine);
            byte[] result1Bytes = ParseKey(key1);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c14af69b-15b1-41ce-aa26-6b14eab63273" + System.Environment.NewLine);
            byte[] result2Bytes = ParseKey(key2);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e04e4723-87e4-4e45-9496-0f0ef1d5b206" + System.Environment.NewLine);
            var rawAnswer = new byte[16];
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "45fd206a-1dce-4c58-ab5a-6346ea387113" + System.Environment.NewLine);
            Array.Copy(result1Bytes, 0, rawAnswer, 0, 4);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6093d477-89cb-4e47-a51c-150883808782" + System.Environment.NewLine);
            Array.Copy(result2Bytes, 0, rawAnswer, 4, 4);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "28890179-ad2e-40a5-8f4a-378547c148b1" + System.Environment.NewLine);
            Array.Copy(challenge.Array, challenge.Offset, rawAnswer, 8, 8);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bcdc0c4d-890c-4379-8d6c-c3f36a2847f2" + System.Environment.NewLine);
            return MD5.Create().ComputeHash(rawAnswer);
        }

        private static byte[] ParseKey(string key)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3ec73187-387e-4ff8-a3aa-f7bd71e946fe" + System.Environment.NewLine);
            int spaces = key.Count(x => x == ' ');
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "42660f98-7837-4c71-945e-d4c40ef9451a" + System.Environment.NewLine);
            var digits = new String(key.Where(Char.IsDigit).ToArray());
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "593fe9e8-dcb7-4f49-a86c-c1608744cdc3" + System.Environment.NewLine);
            var value = (Int32)(Int64.Parse(digits) / spaces);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b409b380-6f6c-4972-8ee8-2413634e1fac" + System.Environment.NewLine);
            byte[] result = BitConverter.GetBytes(value);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "09c78672-38ee-4a5c-8faa-5478e073095a" + System.Environment.NewLine);
            if (BitConverter.IsLittleEndian)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2e76255f-bffe-4efa-969c-fe42e8a13ef6" + System.Environment.NewLine);
                Array.Reverse(result);
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "42530023-356c-491e-9e56-cae2161b1eaa" + System.Environment.NewLine);
            return result;
        }
    }
}