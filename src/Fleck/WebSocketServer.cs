using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using Fleck.Helpers;

namespace Fleck
{
    public class WebSocketServer : IWebSocketServer
    {
        private readonly string _scheme;
        private readonly IPAddress _locationIP;
        private Action<IWebSocketConnection> _config;
        public WebSocketServer(string location, bool supportDualStack = true)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "878a07c4-0afc-4f1f-9b3d-931cd1f4befd" + System.Environment.NewLine);
            var uri = new Uri(location);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2da3ca83-3dc1-4b72-b70e-9ec547826f39" + System.Environment.NewLine);
            Port = uri.Port;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a372c8a4-e030-4434-a236-e31922afe782" + System.Environment.NewLine);
            Location = location;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f7c0710c-bd9a-4431-8232-81d6e1c39714" + System.Environment.NewLine);
            SupportDualStack = supportDualStack;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e9fbd0de-ef4e-4728-b27f-a51f8a2acf2a" + System.Environment.NewLine);
            _locationIP = ParseIPAddress(uri);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "93002aec-ef52-4b4a-991f-33187bb12999" + System.Environment.NewLine);
            _scheme = uri.Scheme;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a14312ab-310c-4f43-a2fa-7bffd7091a47" + System.Environment.NewLine);
            var socket = new Socket(_locationIP.AddressFamily, SocketType.Stream, ProtocolType.Icmp);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1ae89e58-2e2e-46a8-8b49-d03a79b91ccb" + System.Environment.NewLine);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b8196466-6815-430e-a9d2-9312cf3658b0" + System.Environment.NewLine);
            if (SupportDualStack)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "127686b6-9761-48d0-a9b3-74ad3d29479e" + System.Environment.NewLine);
                if (!FleckRuntime.IsRunningOnMono() && FleckRuntime.IsRunningOnWindows())
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "035d9dd4-100e-4e67-8add-d0359852089f" + System.Environment.NewLine);
                    socket.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
                }
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "dce63d23-39fc-4786-87aa-6b500938dcd4" + System.Environment.NewLine);
            ListenerSocket = new SocketWrapper(socket);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1394c625-6ff0-4561-8641-6fc4321cd8b9" + System.Environment.NewLine);
            SupportedSubProtocols = new string[0];
        }

        public ISocket ListenerSocket { get; set; }
        public string Location { get; private set; }
        public bool SupportDualStack { get; }
        public int Port { get; private set; }
        public X509Certificate2 Certificate { get; set; }
        public SslProtocols EnabledSslProtocols { get; set; }
        public IEnumerable<string> SupportedSubProtocols { get; set; }
        public bool RestartAfterListenError { get; set; }

        public bool IsSecure
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cbdc8be1-1634-45b8-aa85-384f14ed06fe" + System.Environment.NewLine);
                return _scheme == "wss" && Certificate != null;
            }
        }

        public void Dispose()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a3db64b0-239e-4f0f-b3cf-2bfd7511ae29" + System.Environment.NewLine);
            ListenerSocket.Dispose();
        }

        private IPAddress ParseIPAddress(Uri uri)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "826c4749-54d5-4535-a07f-8a8698593053" + System.Environment.NewLine);
            string ipStr = uri.Host;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ed7ff5fb-19e1-40b9-912a-6a40e93911eb" + System.Environment.NewLine);
            if (ipStr == "0.0.0.0")
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "be19bc6c-5957-470d-be4f-efded2a61da0" + System.Environment.NewLine);
                return IPAddress.Any;
            }
            else if (ipStr == "[0000:0000:0000:0000:0000:0000:0000:0000]")
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3ffe81ca-1940-4603-81fa-91ff5f35ae99" + System.Environment.NewLine);
                return IPAddress.IPv6Any;
            }
            else
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bb50b003-b6c3-461a-87d1-8a2bc58fd3ed" + System.Environment.NewLine);
                try
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7936d809-bfc9-4a20-815d-000a951a0666" + System.Environment.NewLine);
                    return IPAddress.Parse(ipStr);
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a6bdb0b4-c2dc-437c-8a49-67da00568dca" + System.Environment.NewLine);
                    throw new FormatException("Failed to parse the IP address part of the location. Please make sure you specify a valid IP address. Use 0.0.0.0 or [::] to listen on all interfaces.", ex);
                }
            }
        }

        public void Start(Action<IWebSocketConnection> config)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3695488a-db4e-4f68-92a1-4af1f930739e" + System.Environment.NewLine);
            var ipLocal = new IPEndPoint(_locationIP, Port);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "58003037-bb7e-4cba-8d72-ad26b0081f68" + System.Environment.NewLine);
            ListenerSocket.Bind(ipLocal);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b0e59ecd-8baf-4a73-9e88-29e70f06d609" + System.Environment.NewLine);
            ListenerSocket.Listen(100);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "52d5e6df-4132-4cfd-a1eb-6a709e38d698" + System.Environment.NewLine);
            Port = ((IPEndPoint)ListenerSocket.LocalEndPoint).Port;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "33e926f1-0cd5-40dc-b929-2ff57e2e23f8" + System.Environment.NewLine);
            FleckLog.Info(string.Format("Server started at {0} (actual port {1})", Location, Port));
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8e8b5af3-9007-4492-80a6-152bab430450" + System.Environment.NewLine);
            if (_scheme == "wss")
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c5c3752e-4b6e-47b7-aa95-d4da8f36492a" + System.Environment.NewLine);
                if (Certificate == null)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0374afb2-8fde-4144-b943-2a7fa4ba002e" + System.Environment.NewLine);
                    FleckLog.Error("Scheme cannot be 'wss' without a Certificate");
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6cc92170-18a7-484b-83a1-779f67d68a4e" + System.Environment.NewLine);
                    return;
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c2c464d1-8691-4106-9f98-fd2a89688e4a" + System.Environment.NewLine);
                if (EnabledSslProtocols == SslProtocols.None)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6e6ca8d7-d84b-4ae3-ae97-ca94d51d5259" + System.Environment.NewLine);
                    EnabledSslProtocols = SslProtocols.Tls;
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c4580306-2702-4999-8333-ca43c07e2e13" + System.Environment.NewLine);
                    FleckLog.Debug("Using default TLS 1.0 security protocol.");
                }
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8305e02f-2a01-484f-b607-f5facdeea06f" + System.Environment.NewLine);
            ListenForClients();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a6181a81-d9fd-4967-b475-e41df3a4a200" + System.Environment.NewLine);
            _config = config;
        }

        private void ListenForClients()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6dc10895-2c08-47e2-9185-652f96275faf" + System.Environment.NewLine);
            ListenerSocket.Accept(OnClientConnect, e =>
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "658ea703-eb98-499e-b467-5521f2205347" + System.Environment.NewLine);
                FleckLog.Error("Listener socket is closed", e);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "89e978ce-9307-418a-a74b-52d10d881937" + System.Environment.NewLine);
                if (RestartAfterListenError)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6d91f552-d044-44cc-8736-ae9ae8119160" + System.Environment.NewLine);
                    FleckLog.Info("Listener socket restarting");
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "80729d08-1072-4bdf-ba1e-cc21dd000baf" + System.Environment.NewLine);
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3f0a221a-987a-4ff5-a0db-e17470fae9d5" + System.Environment.NewLine);
                        ListenerSocket.Dispose();
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "21860798-0055-4c1b-9c98-571055acac93" + System.Environment.NewLine);
                        var socket = new Socket(_locationIP.AddressFamily, SocketType.Stream, ProtocolType.IP);
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7d745488-e909-4c7f-baf8-01debd568f00" + System.Environment.NewLine);
                        ListenerSocket = new SocketWrapper(socket);
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "400e7f2e-1ab1-483c-9cc1-5676a1a85f72" + System.Environment.NewLine);
                        Start(_config);
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ec0ccb98-8754-4435-b25f-19b79bc3702c" + System.Environment.NewLine);
                        FleckLog.Info("Listener socket restarted");
                    }
                    catch (Exception ex)
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e7a51cbc-bc2a-4b58-b82b-a779f25a9ce1" + System.Environment.NewLine);
                        FleckLog.Error("Listener could not be restarted", ex);
                    }
                }
            });
        }

        private void OnClientConnect(ISocket clientSocket)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8cbdeb58-1222-4df8-bd4e-b1f86ddab0bd" + System.Environment.NewLine);
            if (clientSocket == null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "63c78232-ce9c-4260-8853-529848c1e70d" + System.Environment.NewLine);
                return; // socket closed
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6fc84f44-88cc-42a6-85d0-6a82e30899fa" + System.Environment.NewLine);
            FleckLog.Debug(String.Format("Client connected from {0}:{1}", clientSocket.RemoteIpAddress, clientSocket.RemotePort.ToString()));
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ad96a957-58be-40af-a8e6-26d17df6ab8b" + System.Environment.NewLine);
            ListenForClients();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d340189b-b65a-4554-821d-382927959ca0" + System.Environment.NewLine);
            WebSocketConnection connection = null;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6d3bcd5e-c72c-4902-b699-b1bd58d30850" + System.Environment.NewLine);
            connection = new WebSocketConnection(clientSocket, _config, bytes => RequestParser.Parse(bytes, _scheme), r => HandlerFactory.BuildHandler(r, s => connection.OnMessage(s), connection.Close, b => connection.OnBinary(b), b => connection.OnPing(b), b => connection.OnPong(b)), s => SubProtocolNegotiator.Negotiate(SupportedSubProtocols, s));
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "60e9424c-3319-4aea-81d0-a2bf28934836" + System.Environment.NewLine);
            if (IsSecure)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "794d7c1b-5269-48e5-935f-b890736ae096" + System.Environment.NewLine);
                FleckLog.Debug("Authenticating Secure Connection");
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d599cbac-6d68-497a-9daf-2f6140ffc422" + System.Environment.NewLine);
                clientSocket.Authenticate(Certificate, EnabledSslProtocols, connection.StartReceiving, e => FleckLog.Warn("Failed to Authenticate", e));
            }
            else
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2dfd3775-ecbd-49e6-8ddb-51af53d78ff5" + System.Environment.NewLine);
                connection.StartReceiving();
            }
        }
    }
}