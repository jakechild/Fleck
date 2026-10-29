using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Fleck
{
    public class WebSocketConnection : IWebSocketConnection
    {
        public WebSocketConnection(ISocket socket, Action<IWebSocketConnection> initialize, Func<byte[], WebSocketHttpRequest> parseRequest, Func<WebSocketHttpRequest, IHandler> handlerFactory, Func<IEnumerable<string>, string> negotiateSubProtocol)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4af3fdf5-2083-4d54-a215-d4bfd286f729" + System.Environment.NewLine);
            Socket = socket;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "160b2c78-2934-4a56-a4c8-af622330144a" + System.Environment.NewLine);
            OnOpen = () =>
            {
            };
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "dd2953f0-906f-4144-8385-4fa3ac8633de" + System.Environment.NewLine);
            OnClose = () =>
            {
            };
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d1e6c87b-d74b-40cf-9998-2a13b8e1f379" + System.Environment.NewLine);
            OnMessage = x =>
            {
            };
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "94a9221a-9f30-46b9-8e40-93639cdd6be9" + System.Environment.NewLine);
            OnBinary = x =>
            {
            };
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "523d14b5-bd8a-4233-98bc-d9afee1a2d3d" + System.Environment.NewLine);
            OnPing = x => SendPong(x);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "237cf5d2-230f-4daa-ade9-0f2b43cf867b" + System.Environment.NewLine);
            OnPong = x =>
            {
            };
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6063db02-ceef-4cf0-896d-2814868c7d63" + System.Environment.NewLine);
            OnError = x =>
            {
            };
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f44eb076-9a26-4d3c-86b4-c8b5bd3953d7" + System.Environment.NewLine);
            _initialize = initialize;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "97cd0562-e1c6-4150-b0a4-8064962fb4c4" + System.Environment.NewLine);
            _handlerFactory = handlerFactory;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7e0d024c-1d69-46c5-b244-e4895d8fbc3d" + System.Environment.NewLine);
            _parseRequest = parseRequest;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a542726a-15da-4704-832f-683ab5d6e27e" + System.Environment.NewLine);
            _negotiateSubProtocol = negotiateSubProtocol;
        }

        public ISocket Socket { get; set; }

        private readonly Action<IWebSocketConnection> _initialize;
        private readonly Func<WebSocketHttpRequest, IHandler> _handlerFactory;
        private readonly Func<IEnumerable<string>, string> _negotiateSubProtocol;
        readonly Func<byte[], WebSocketHttpRequest> _parseRequest;
        public IHandler Handler { get; set; }

        private bool _closing;
        private bool _closed;
        private const int ReadSize = 1024 * 4;
        public Action OnOpen { get; set; }
        public Action OnClose { get; set; }
        public Action<string> OnMessage { get; set; }
        public Action<byte[]> OnBinary { get; set; }
        public Action<byte[]> OnPing { get; set; }
        public Action<byte[]> OnPong { get; set; }
        public Action<Exception> OnError { get; set; }
        public IWebSocketConnectionInfo ConnectionInfo { get; private set; }

        public bool IsAvailable
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "42d92659-e78c-42b5-9486-3e9e9fce5ede" + System.Environment.NewLine);
                return !_closing && !_closed && Socket.Connected;
            }
        }

        public Task Send(string message)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e8287d7d-c22d-4c95-8c3a-1f555d748523" + System.Environment.NewLine);
            return Send(message, Handler.FrameText);
        }

        public Task Send(byte[] message)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "241b0f7e-2622-4b77-a6e6-8f14248fc115" + System.Environment.NewLine);
            return Send(message, Handler.FrameBinary);
        }

        public Task SendPing(byte[] message)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "88d7db48-da85-40a7-91dd-8a9d6cbec64a" + System.Environment.NewLine);
            return Send(message, Handler.FramePing);
        }

        public Task SendPong(byte[] message)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9f69cfbb-fde0-41e6-ace4-ff3ddd1e273e" + System.Environment.NewLine);
            return Send(message, Handler.FramePong);
        }

        private Task Send<T>(T message, Func<T, byte[]> createFrame)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "422c921e-3867-4784-9db0-3925677676eb" + System.Environment.NewLine);
            if (Handler == null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f51ed2e9-8082-450b-91cd-ecdac93657d5" + System.Environment.NewLine);
                throw new InvalidOperationException("Cannot send before handshake");
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a1aa0a77-db9a-4efa-954c-bb80d5126219" + System.Environment.NewLine);
            if (!IsAvailable)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cd347e13-12c2-48b1-a13f-96927c58caeb" + System.Environment.NewLine);
                const string errorMessage = "Data sent while closing or after close. Ignoring.";
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f0f0cedc-81a8-4b74-af2b-b04f23e024c1" + System.Environment.NewLine);
                FleckLog.Warn(errorMessage);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "da5e5c4d-e80b-4abc-81db-9df3f9a9ef11" + System.Environment.NewLine);
                var taskForException = new TaskCompletionSource<object>();
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cf7bec33-d70a-4f96-b5a1-e756a17ee8ce" + System.Environment.NewLine);
                taskForException.SetException(new ConnectionNotAvailableException(errorMessage));
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "eb12098c-b912-41b5-8ef2-bae1bb5523df" + System.Environment.NewLine);
                return taskForException.Task;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a712f651-95d0-4fb6-9b0d-8231318e9c20" + System.Environment.NewLine);
            var bytes = createFrame(message);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d5528320-135e-4450-851c-5f15ecffe8cf" + System.Environment.NewLine);
            return SendBytes(bytes);
        }

        public void StartReceiving()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1cd844ec-c9d2-4919-a717-8ce9924e18b2" + System.Environment.NewLine);
            var data = new List<byte>(ReadSize);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "926d26c5-8f15-4b69-87c3-9bbd9394785c" + System.Environment.NewLine);
            var buffer = new byte[ReadSize];
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9b4c0e8f-4b03-4aba-b04e-d886f633844c" + System.Environment.NewLine);
            Read(data, buffer);
        }

        public void Close()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ea2dfc1f-3c9a-4791-83fb-0828d04e932d" + System.Environment.NewLine);
            Close(WebSocketStatusCodes.NormalClosure);
        }

        public void Close(int code)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ca735dca-fb4e-4e25-82b8-2d9473b392e7" + System.Environment.NewLine);
            if (!IsAvailable)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "de253d1d-e3d4-4574-bd26-7575165e59bc" + System.Environment.NewLine);
                return;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c114693d-f36d-4786-8981-dd4b13abd3f7" + System.Environment.NewLine);
            _closing = true;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6d28ca66-21d7-41d0-ba62-287822a5a79f" + System.Environment.NewLine);
            if (Handler == null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "525634d2-7c17-4898-a888-1fe618791edc" + System.Environment.NewLine);
                CloseSocket();
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d8f80cb2-f4a8-440c-9140-e7d1656db154" + System.Environment.NewLine);
                return;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1515b62d-f42f-415d-bde3-85ccec170e0f" + System.Environment.NewLine);
            var bytes = Handler.FrameClose(code);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b32ee174-2af5-47cf-b562-a9f66e6d4267" + System.Environment.NewLine);
            if (bytes.Length == 0)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "069bf750-d0a6-44eb-a2d8-7ab3f1c1ed51" + System.Environment.NewLine);
                CloseSocket();
            }
            else
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "eb2455ef-9603-4a87-805f-04df77a7c4c8" + System.Environment.NewLine);
                SendBytes(bytes, CloseSocket);
            }
        }

        public void CreateHandler(IEnumerable<byte> data)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0584bbac-02a0-4bd6-8be4-abb35b09e315" + System.Environment.NewLine);
            var request = _parseRequest(data.ToArray());
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bda72d25-fe22-4c2b-9a72-012ee80f2339" + System.Environment.NewLine);
            if (request == null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d35c9530-de8f-4306-843c-4dd84b1b9822" + System.Environment.NewLine);
                return;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9ec9a53a-1a2c-4889-b1ca-9faa59574fa2" + System.Environment.NewLine);
            Handler = _handlerFactory(request);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "00c51cea-8d38-41ef-a002-1888f03bf6e6" + System.Environment.NewLine);
            if (Handler == null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4dc1fb32-e1ce-4b4d-a151-045da554adf0" + System.Environment.NewLine);
                return;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "329740fc-2212-4106-812c-8d95c1d1222b" + System.Environment.NewLine);
            var subProtocol = _negotiateSubProtocol(request.SubProtocols);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4536add6-aaca-4aa7-8b51-b2cb8089f264" + System.Environment.NewLine);
            ConnectionInfo = WebSocketConnectionInfo.Create(request, Socket.RemoteIpAddress, Socket.RemotePort, subProtocol);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e2a4c6c0-d7ca-41b6-afb8-e588d27e70e1" + System.Environment.NewLine);
            _initialize(this);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d5434196-f9a2-4149-8476-ea58cc821519" + System.Environment.NewLine);
            var handshake = Handler.CreateHandshake(subProtocol);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9f22e684-2b53-4306-8b71-640d86cd0e83" + System.Environment.NewLine);
            SendBytes(handshake, OnOpen);
        }

        private void Read(List<byte> data, byte[] buffer)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ef3e830a-8326-4ed6-8e99-bcbcf4c320fe" + System.Environment.NewLine);
            if (!IsAvailable)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f597380a-20f9-40ed-9418-e8d79642c053" + System.Environment.NewLine);
                return;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0979d54b-1650-44ef-8b97-2773f62cc144" + System.Environment.NewLine);
            Socket.Receive(buffer, r =>
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d633bc93-fd0a-4807-9a89-751aacf889a1" + System.Environment.NewLine);
                if (r <= 0)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "100c57ae-6c90-484b-a4dd-9be460599627" + System.Environment.NewLine);
                    FleckLog.Debug("0 bytes read. Closing.");
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f11becbb-92bf-4c61-8b55-73c0cf9204ab" + System.Environment.NewLine);
                    CloseSocket();
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d1ed7b64-8552-4ed4-9da9-8d0294586076" + System.Environment.NewLine);
                    return;
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "723d4c2d-6b26-4cd7-b2fd-c8225a00f1fd" + System.Environment.NewLine);
                FleckLog.Debug(r + " bytes read");
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "13055a56-0d1a-4ec2-b18b-3d5b8fd164bc" + System.Environment.NewLine);
                var readBytes = buffer.Take(r);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5c94c1ce-d7ff-4f9f-8644-8442385b778e" + System.Environment.NewLine);
                if (Handler != null)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "18f5c2c1-a740-4988-a393-442fc01e76d0" + System.Environment.NewLine);
                    Handler.Receive(readBytes);
                }
                else
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "edfb707d-fd51-4bb7-9f60-52bcbca46ad6" + System.Environment.NewLine);
                    data.AddRange(readBytes);
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9a1eaeb5-7fa7-4de7-b0cf-4bcf6855fdf2" + System.Environment.NewLine);
                    CreateHandler(data);
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "11019d9b-a854-405a-a000-1e2f4287233f" + System.Environment.NewLine);
                Read(data, buffer);
            }, HandleReadError);
        }

        private void HandleReadError(Exception e)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c8752734-d6cc-41b3-acb4-eedcc41e64ec" + System.Environment.NewLine);
            if (e is AggregateException)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c462199f-86a1-421e-b520-844b8836e49e" + System.Environment.NewLine);
                var agg = e as AggregateException;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "898cd0ef-1af7-49d2-8e1e-bd6bc4b8cea5" + System.Environment.NewLine);
                HandleReadError(agg.InnerException);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e7c09cad-fd10-490a-8d44-0ee0389bf817" + System.Environment.NewLine);
                return;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c0740852-f3fc-4a2d-9fa2-15a6a5332a50" + System.Environment.NewLine);
            if (e is ObjectDisposedException)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3d37924d-b14e-4cb3-99cf-540b20f55164" + System.Environment.NewLine);
                FleckLog.Debug("Swallowing ObjectDisposedException", e);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f44139fc-2e9d-412f-9fd8-2dd80bbf99aa" + System.Environment.NewLine);
                return;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0399aa79-7832-4a93-8859-51a4431b1c79" + System.Environment.NewLine);
            OnError(e);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8ebf666f-4474-48df-bcc4-552841126fd2" + System.Environment.NewLine);
            if (e is WebSocketException)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6069b60a-8860-4b22-97db-63710c21fb4c" + System.Environment.NewLine);
                FleckLog.Debug("Error while reading", e);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e846b2aa-d9c3-476f-a3fa-9a464a280406" + System.Environment.NewLine);
                Close(((WebSocketException)e).StatusCode);
            }
            else if (e is SubProtocolNegotiationFailureException)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7faf21a2-21e0-440f-8a3a-744d296de6db" + System.Environment.NewLine);
                FleckLog.Debug(e.Message);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "864247f6-2d01-4847-bb04-5fef585137f4" + System.Environment.NewLine);
                Close(WebSocketStatusCodes.ProtocolError);
            }
            else if (e is IOException)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8bff0d35-1576-4c04-9f70-9302c66fb05b" + System.Environment.NewLine);
                FleckLog.Debug("Error while reading", e);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0dbde8d2-c567-49ff-81cb-082d5ce1f39c" + System.Environment.NewLine);
                Close(WebSocketStatusCodes.AbnormalClosure);
            }
            else
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4c83f968-9337-47a8-86b0-3e39b21f8fbe" + System.Environment.NewLine);
                FleckLog.Error("Application Error", e);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ae883c79-7b23-4915-94b3-44f279d87f74" + System.Environment.NewLine);
                Close(WebSocketStatusCodes.InternalServerError);
            }
        }

        private Task SendBytes(byte[] bytes, Action callback = null)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "65b757b8-6bed-4a41-ac36-aa311130bc5a" + System.Environment.NewLine);
            return Socket.Send(bytes, () =>
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "30b60cc1-3cee-462f-afde-255c81adea74" + System.Environment.NewLine);
                FleckLog.Debug("Sent " + bytes.Length + " bytes");
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "52b13ffd-a4a3-45f0-a9fe-b760d2a82c2e" + System.Environment.NewLine);
                if (callback != null)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "42ea8e16-c3cb-41eb-8e16-a1fed76006c0" + System.Environment.NewLine);
                    callback();
                }
            }, e =>
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5ac05196-c931-4202-8c70-6cf6943c397b" + System.Environment.NewLine);
                if (e is IOException)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "65665484-4977-41aa-8562-a58add0b93d9" + System.Environment.NewLine);
                    FleckLog.Debug("Failed to send. Disconnecting.", e);
                }
                else
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a574efad-2ea1-47d1-832a-c64f2ccd81ba" + System.Environment.NewLine);
                    FleckLog.Info("Failed to send. Disconnecting.", e);
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bda8cb8d-5fb0-418a-9b27-fc3988bda8a2" + System.Environment.NewLine);
                CloseSocket();
            });
        }

        private void CloseSocket()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "296dce55-16a3-4ac7-87cb-38e0a1822fc6" + System.Environment.NewLine);
            _closing = true;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "afa27902-fe36-417b-a949-f0985fc40663" + System.Environment.NewLine);
            OnClose();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4d55cdce-9916-4397-8ca6-706565d3af1d" + System.Environment.NewLine);
            _closed = true;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "afc8585d-c061-4b70-a731-6ecd6765751b" + System.Environment.NewLine);
            Socket.Close();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b3dc912a-f4c3-436a-9a7f-0c413ca3bdb4" + System.Environment.NewLine);
            Socket.Dispose();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "94ddb543-0600-4d81-875f-87f9c30d2e36" + System.Environment.NewLine);
            _closing = false;
        }
    }
}