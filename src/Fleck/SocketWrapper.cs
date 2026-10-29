using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Threading;
using Fleck.Helpers;

namespace Fleck
{
    public class SocketWrapper : ISocket
    {
        public const UInt32 KeepAliveInterval = 60000;
        public const UInt32 RetryInterval = 10000;
        private readonly Socket _socket;
        private Stream _stream;
        private CancellationTokenSource _tokenSource;
        private TaskFactory _taskFactory;
        public string RemoteIpAddress
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "68cfce03-d153-4309-bc71-74df302df5e4" + System.Environment.NewLine);
                var endpoint = _socket.RemoteEndPoint as IPEndPoint;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bc35fe70-b4d3-4940-b3d8-c99a472c031e" + System.Environment.NewLine);
                return endpoint != null ? endpoint.Address.ToString() : null;
            }
        }

        public int RemotePort
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f515fdea-849d-4925-80a3-e54a7518bcf0" + System.Environment.NewLine);
                var endpoint = _socket.RemoteEndPoint as IPEndPoint;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8be9e76f-f4e4-42a2-b4bd-ea4b683c417e" + System.Environment.NewLine);
                return endpoint != null ? endpoint.Port : -1;
            }
        }

        public void SetKeepAlive(Socket socket, UInt32 keepAliveInterval, UInt32 retryInterval)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6feb52bd-a59e-49c0-a481-6b3c7cfc6786" + System.Environment.NewLine);
            int size = sizeof(UInt32);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "db5ba9a6-d9b7-4471-bc79-cff18e2708f1" + System.Environment.NewLine);
            UInt32 on = 1;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "525ab25e-2c95-4575-9f8f-52062dfc998f" + System.Environment.NewLine);
            byte[] inArray = new byte[size * 3];
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8e392e56-dd7f-42bd-9374-79cce967a795" + System.Environment.NewLine);
            Array.Copy(BitConverter.GetBytes(on), 0, inArray, 0, size);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "37ce5f14-db0e-4d36-baf8-7a96e5730572" + System.Environment.NewLine);
            Array.Copy(BitConverter.GetBytes(keepAliveInterval), 0, inArray, size, size);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "170f7277-54ec-4439-a697-48a11163cd64" + System.Environment.NewLine);
            Array.Copy(BitConverter.GetBytes(retryInterval), 0, inArray, size * 2, size);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cbc8ca55-007b-461c-83cb-fdbd4beda179" + System.Environment.NewLine);
            socket.IOControl(IOControlCode.KeepAliveValues, inArray, null);
        }

        public SocketWrapper(Socket socket)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "68825726-c85f-4000-a67e-df77f9a73556" + System.Environment.NewLine);
            _tokenSource = new CancellationTokenSource();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bc8d958f-9061-457f-a7d9-2aa05acb9ec4" + System.Environment.NewLine);
            _taskFactory = new TaskFactory(_tokenSource.Token);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9e9de498-867f-4ded-b01a-0bec4c19756c" + System.Environment.NewLine);
            _socket = socket;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c4e12784-84e9-41b4-a933-803265f443df" + System.Environment.NewLine);
            if (_socket.Connected)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a1a48962-6292-4245-8b47-b97dcf7231fa" + System.Environment.NewLine);
                _stream = new NetworkStream(_socket);
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f0823664-6f32-450c-a9a7-3b275d8900e8" + System.Environment.NewLine);
            // The tcp keepalive default values on most systems
            // are huge (~7200s). Set them to something more reasonable.
            if (FleckRuntime.IsRunningOnWindows())
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "35ce5483-53b8-41a3-8784-08cf5573fddb" + System.Environment.NewLine);
                SetKeepAlive(socket, KeepAliveInterval, RetryInterval);
            }
        }

        public Task Authenticate(X509Certificate2 certificate, SslProtocols enabledSslProtocols, Action callback, Action<Exception> error)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "aecfc846-1124-4867-bbee-45c81c72df14" + System.Environment.NewLine);
            var ssl = new SslStream(_stream, false);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2ac8687f-8692-412a-b8f1-1485b7d14887" + System.Environment.NewLine);
            _stream = new QueuedStream(ssl);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "02fe18e9-37d0-475e-9a47-36961ac320fa" + System.Environment.NewLine);
            Func<AsyncCallback, object, IAsyncResult> begin = (cb, s) => ssl.BeginAuthenticateAsServer(certificate, false, enabledSslProtocols, false, cb, s);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "eb5b23c1-3a14-4b9e-ad69-fbd2b0e808c9" + System.Environment.NewLine);
            Task task = Task.Factory.FromAsync(begin, ssl.EndAuthenticateAsServer, null);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "97d52ad0-847a-457b-b29c-0507be886f31" + System.Environment.NewLine);
            task.ContinueWith(t => callback(), TaskContinuationOptions.NotOnFaulted).ContinueWith(t => error(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "53d2571c-528f-4c5c-b610-c789998855cf" + System.Environment.NewLine);
            task.ContinueWith(t => error(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "27f0b168-c8a6-4136-8122-5cda70c95288" + System.Environment.NewLine);
            return task;
        }

        public void Listen(int backlog)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2219211c-cf68-494c-a04e-1b3c53119e77" + System.Environment.NewLine);
            _socket.Listen(backlog);
        }

        public void Bind(EndPoint endPoint)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3b22b133-aa15-453c-b035-47734e1c8625" + System.Environment.NewLine);
            _socket.Bind(endPoint);
        }

        public bool Connected
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ca2318cc-1a6b-4dc5-8dc7-704daea6107d" + System.Environment.NewLine);
                return _socket.Connected;
            }
        }

        public Stream Stream
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "755df6ba-57b8-4e34-a82e-f64d93d962ef" + System.Environment.NewLine);
                return _stream;
            }
        }

        public bool NoDelay
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cbf042e1-073c-45af-9d45-a10a0bf75579" + System.Environment.NewLine);
                return _socket.NoDelay;
            }

            set
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fde34986-ad90-45f7-8a01-69a9ce26c935" + System.Environment.NewLine);
                _socket.NoDelay = value;
            }
        }

        public EndPoint LocalEndPoint
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "27ca0ee2-6595-4659-9595-e9ef3c27e69e" + System.Environment.NewLine);
                return _socket.LocalEndPoint;
            }
        }

        public Task<int> Receive(byte[] buffer, Action<int> callback, Action<Exception> error, int offset)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "36bc470d-daa3-4f5b-9273-07cf2c64ce3a" + System.Environment.NewLine);
            try
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "16438b25-bc0b-4cd9-924b-e665f1273dce" + System.Environment.NewLine);
                Func<AsyncCallback, object, IAsyncResult> begin = (cb, s) => _stream.BeginRead(buffer, offset, buffer.Length, cb, s);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "27a2a6fa-5690-4865-b99c-c6b7469d2a91" + System.Environment.NewLine);
                Task<int> task = Task.Factory.FromAsync<int>(begin, _stream.EndRead, null);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "316e1baf-c5ab-4aca-8c2c-ec3abda2bb0f" + System.Environment.NewLine);
                task.ContinueWith(t => callback(t.Result), TaskContinuationOptions.NotOnFaulted).ContinueWith(t => error(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b78517a5-78af-496c-8cdf-73790dd936f2" + System.Environment.NewLine);
                task.ContinueWith(t => error(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e32befcd-b835-4048-b388-b4c7cb2627c0" + System.Environment.NewLine);
                return task;
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c0d6d788-88cd-462b-89a4-01ac805df249" + System.Environment.NewLine);
                error(e);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "29fcc336-acc6-4cf7-9ae9-37b366aa5677" + System.Environment.NewLine);
                return null;
            }
        }

        public Task<ISocket> Accept(Action<ISocket> callback, Action<Exception> error)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ab813156-87bd-40a4-af44-8df912243ab9" + System.Environment.NewLine);
            Func<IAsyncResult, ISocket> end = r => _tokenSource.Token.IsCancellationRequested ? null : new SocketWrapper(_socket.EndAccept(r));
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7debf32a-17fc-4133-b022-e25c2820b40e" + System.Environment.NewLine);
            var task = _taskFactory.FromAsync(_socket.BeginAccept, end, null);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7309cdaa-6b23-4b0c-b96d-ab9d7eedfb95" + System.Environment.NewLine);
            task.ContinueWith(t => callback(t.Result), TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(t => error(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "242aad8a-b960-4d47-a0dd-d1682daf2572" + System.Environment.NewLine);
            task.ContinueWith(t => error(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "28cbd658-b9d7-46ee-888a-8e04e5029024" + System.Environment.NewLine);
            return task;
        }

        public void Dispose()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "40c4ff36-1a6f-49d3-ad22-e850aaa8eb30" + System.Environment.NewLine);
            _tokenSource.Cancel();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7b1bf69c-56ad-4981-b2c7-768674ae2c7b" + System.Environment.NewLine);
            if (_stream != null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cda3c042-a4fc-413c-be8b-8d0d83a30d3a" + System.Environment.NewLine);
                _stream.Dispose();
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "aea7b86c-7742-4f46-b0b8-0c7120f9f626" + System.Environment.NewLine);
            if (_socket != null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2e17568a-d606-425b-9c3d-6956df7bf0ad" + System.Environment.NewLine);
                _socket.Dispose();
            }
        }

        public void Close()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3d846805-8710-48a7-801c-b658aac88496" + System.Environment.NewLine);
            _tokenSource.Cancel();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0d2ba392-319e-454a-bccf-02a67b2029b8" + System.Environment.NewLine);
            if (_stream != null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3b61b227-f130-4de8-b4c3-7c5ea47c4939" + System.Environment.NewLine);
                _stream.Close();
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f1c5fc30-ea8c-46bb-bbdc-b72e951a0664" + System.Environment.NewLine);
            if (_socket != null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "aec9df37-23b9-405d-88f8-348f4bc8ffde" + System.Environment.NewLine);
                _socket.Close();
            }
        }

        public int EndSend(IAsyncResult asyncResult)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7da90e6f-0241-48c8-82c8-8411a551b09f" + System.Environment.NewLine);
            _stream.EndWrite(asyncResult);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "eeee4eed-82fb-435c-92fa-0975426bdffe" + System.Environment.NewLine);
            return 0;
        }

        public Task Send(byte[] buffer, Action callback, Action<Exception> error)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e69e6a99-6ccc-4ae4-b6c0-1aa3f1fc2ef4" + System.Environment.NewLine);
            if (_tokenSource.IsCancellationRequested)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5a1e7a63-e205-449a-a424-3d173dabe608" + System.Environment.NewLine);
                return null;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "14dfb9c3-651e-4962-96a5-3b11c937a04b" + System.Environment.NewLine);
            try
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "404a30fd-353c-4b5e-b31d-720144b27a6d" + System.Environment.NewLine);
                Func<AsyncCallback, object, IAsyncResult> begin = (cb, s) => _stream.BeginWrite(buffer, 0, buffer.Length, cb, s);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8bf5700b-ea45-49ff-a3cf-1bf8c73bc51b" + System.Environment.NewLine);
                Task task = Task.Factory.FromAsync(begin, _stream.EndWrite, null);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a6b47f04-4853-475e-ba0f-bcc97cee4334" + System.Environment.NewLine);
                task.ContinueWith(t => callback(), TaskContinuationOptions.NotOnFaulted).ContinueWith(t => error(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "13324ddd-c226-477e-8b62-2e462498ad7a" + System.Environment.NewLine);
                task.ContinueWith(t => error(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "38c097c3-2123-4c6c-a4ba-e649bd6c5ba2" + System.Environment.NewLine);
                return task;
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d14c74eb-a05c-4842-8911-908a6bfa49d5" + System.Environment.NewLine);
                error(e);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "efe5097a-7896-4ab1-b594-15685366620a" + System.Environment.NewLine);
                return null;
            }
        }
    }
}