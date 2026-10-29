using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Fleck.Handlers
{
    public static class Hybi13Handler
    {
        public static IHandler Create(WebSocketHttpRequest request, Action<string> onMessage, Action onClose, Action<byte[]> onBinary, Action<byte[]> onPing, Action<byte[]> onPong)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "85767901-7257-4b28-bc54-580d90ff57ac" + System.Environment.NewLine);
            var readState = new ReadState();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "888a9e22-199f-4aa2-80e8-221402c9f631" + System.Environment.NewLine);
            return new ComposableHandler
            {
                Handshake = sub => Hybi13Handler.BuildHandshake(request, sub),
                TextFrame = s => Hybi13Handler.FrameData(Encoding.UTF8.GetBytes(s), FrameType.Text),
                BinaryFrame = s => Hybi13Handler.FrameData(s, FrameType.Binary),
                PingFrame = s => Hybi13Handler.FrameData(s, FrameType.Ping),
                PongFrame = s => Hybi13Handler.FrameData(s, FrameType.Pong),
                CloseFrame = i => Hybi13Handler.FrameData(i.ToBigEndianBytes<ushort>(), FrameType.Close),
                ReceiveData = d => Hybi13Handler.ReceiveData(d, readState, (op, data) => Hybi13Handler.ProcessFrame(op, data, onMessage, onClose, onBinary, onPing, onPong))
            };
        }

        public static byte[] FrameData(byte[] payload, FrameType frameType)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "88532036-dce1-4eef-92bb-b5e4c3215215" + System.Environment.NewLine);
            var memoryStream = new MemoryStream();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "14561eac-4a70-438e-a0f2-2ab2f81e1504" + System.Environment.NewLine);
            byte op = (byte)((byte)frameType + 128);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "25eef156-1fa9-443e-9106-348a048d8a9c" + System.Environment.NewLine);
            memoryStream.WriteByte(op);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9eb10476-796c-4b5c-a0e0-1163c45b005d" + System.Environment.NewLine);
            if (payload.Length > UInt16.MaxValue)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "26320db8-1c0d-47ce-86cb-6f7061a062aa" + System.Environment.NewLine);
                memoryStream.WriteByte(127);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2ebb78fb-677d-46c5-97c8-2c0fb5273811" + System.Environment.NewLine);
                var lengthBytes = payload.Length.ToBigEndianBytes<ulong>();
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "23ed3e52-fb19-4699-9280-6f2317f040b2" + System.Environment.NewLine);
                memoryStream.Write(lengthBytes, 0, lengthBytes.Length);
            }
            else if (payload.Length > 125)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d8ffc82d-2498-453b-b857-4c4e5b07a71a" + System.Environment.NewLine);
                memoryStream.WriteByte(126);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "35d900f6-3a1c-457e-8ae3-0df8b8f1c2f4" + System.Environment.NewLine);
                var lengthBytes = payload.Length.ToBigEndianBytes<ushort>();
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "717f1a2f-26ee-4df9-8ae4-4bd0eb2cadb1" + System.Environment.NewLine);
                memoryStream.Write(lengthBytes, 0, lengthBytes.Length);
            }
            else
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5561e677-0fb6-4cc9-bf38-4ca639da1e51" + System.Environment.NewLine);
                memoryStream.WriteByte((byte)payload.Length);
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "507ecaf5-3eae-4d35-b0f7-5c734e6f3a49" + System.Environment.NewLine);
            memoryStream.Write(payload, 0, payload.Length);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "38d200ba-ad35-4549-979e-b4007506ef1d" + System.Environment.NewLine);
            return memoryStream.ToArray();
        }

        public static void ReceiveData(List<byte> data, ReadState readState, Action<FrameType, byte[]> processFrame)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a00eed68-d79a-4a4e-86c8-1d55c0180e62" + System.Environment.NewLine);
            while (data.Count >= 2)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a4f7b628-d5ca-4d25-8921-76bf4774a590" + System.Environment.NewLine);
                var isFinal = (data[0] & 128) != 0;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fddd83e0-0ad8-46b7-925e-8cf44e3ee42e" + System.Environment.NewLine);
                var reservedBits = (data[0] & 112);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "792334d0-8fe4-4f32-9fed-2fed96bd8784" + System.Environment.NewLine);
                var frameType = (FrameType)(data[0] & 15);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "00eef400-b958-47aa-91af-285b504c6bc1" + System.Environment.NewLine);
                var isMasked = (data[1] & 128) != 0;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a07ca1a2-a843-48c9-9372-1ed4ca2d4465" + System.Environment.NewLine);
                var length = (data[1] & 127);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1f626bcc-a7f4-42e2-a565-3fae6ed084fa" + System.Environment.NewLine);
                if (!isMasked || !Enum.IsDefined(typeof(FrameType), frameType) || reservedBits != 0 //Must be zero per spec 5.2
 || (frameType == FrameType.Continuation && !readState.FrameType.HasValue))
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4113b07a-e07e-4cac-a025-fc121b67a5ff" + System.Environment.NewLine);
                    throw new WebSocketException(WebSocketStatusCodes.ProtocolError);
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1c8abbd0-73c2-46bb-aed7-37918b41f4a9" + System.Environment.NewLine);
                var index = 2;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0716b3d1-f095-4193-896a-4078f1b48757" + System.Environment.NewLine);
                int payloadLength;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4575d459-4d04-493c-b5ba-678e8caf08c6" + System.Environment.NewLine);
                if (length == 127)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "66c7e3b6-1824-4dde-beeb-6d2cb1f0ea67" + System.Environment.NewLine);
                    if (data.Count < index + 8)
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "97e5a4f0-5e3c-4c56-8da8-ca33df61f6ab" + System.Environment.NewLine);
                        return; //Not complete
                    }

                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0ded4b1d-093a-4c01-8dbf-1dbb5f48cfc5" + System.Environment.NewLine);
                    payloadLength = data.Skip(index).Take(8).ToArray().ToLittleEndianInt();
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e1009c6d-60bf-47f3-a132-6017041b360f" + System.Environment.NewLine);
                    index += 8;
                }
                else if (length == 126)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5c09009e-654d-4b3f-aab6-ad6b4331f256" + System.Environment.NewLine);
                    if (data.Count < index + 2)
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bdc898b2-6583-4a55-a0e7-4120ef7b4b64" + System.Environment.NewLine);
                        return; //Not complete
                    }

                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7398d2a3-7671-4bd1-97a7-2c21d2c291e3" + System.Environment.NewLine);
                    payloadLength = data.Skip(index).Take(2).ToArray().ToLittleEndianInt();
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ae3c8dd7-8c66-43b8-91fa-b9965759d214" + System.Environment.NewLine);
                    index += 2;
                }
                else
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2f321017-1e82-4411-8153-9df8e51abb4c" + System.Environment.NewLine);
                    payloadLength = length;
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ee3254cc-dd85-4054-9e98-842b29e5d802" + System.Environment.NewLine);
                if (data.Count < index + 4)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2b956f15-dd6f-4852-ae91-f4782c79a0fe" + System.Environment.NewLine);
                    return; //Not complete
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3df04bd2-c7d5-43b4-bade-64a4b9c17d91" + System.Environment.NewLine);
                var maskBytes = data.Skip(index).Take(4).ToArray();
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "49a109a0-50cf-4f28-8679-cb6e8d939b56" + System.Environment.NewLine);
                index += 4;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c560a67c-ba2f-4f47-8062-62e516928e69" + System.Environment.NewLine);
                if (data.Count < index + payloadLength)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "26c62a2e-690a-4a68-9841-b890cd2c688f" + System.Environment.NewLine);
                    return; //Not complete
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f88cb958-18c1-4926-ae81-4523b89f06b5" + System.Environment.NewLine);
                byte[] payloadData = new byte[payloadLength];
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0e724032-7683-46b4-aae4-0b713db06aa8" + System.Environment.NewLine);
                for (int i = 0; i < payloadLength; i++)
                    payloadData[i] = (byte)(data[index + i] ^ maskBytes[i % 4]);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "de66d5ab-ca6c-438f-b631-2943f139f157" + System.Environment.NewLine);
                readState.Data.AddRange(payloadData);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b0b771a4-1137-4112-99d0-56b5a852a266" + System.Environment.NewLine);
                data.RemoveRange(0, index + payloadLength);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bdac8ac0-9330-4232-9592-7df91f3b9d98" + System.Environment.NewLine);
                if (frameType != FrameType.Continuation)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c9b23787-293a-4dff-9780-45b072608919" + System.Environment.NewLine);
                    readState.FrameType = frameType;
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4b464da1-ed78-479a-87e0-0d4583880fab" + System.Environment.NewLine);
                if (isFinal && readState.FrameType.HasValue)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b5b88d4b-2aa8-4257-9760-e66f5685ff26" + System.Environment.NewLine);
                    var stateData = readState.Data.ToArray();
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "82e7d60e-560b-42dc-bf8d-250b96b38d40" + System.Environment.NewLine);
                    var stateFrameType = readState.FrameType;
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b2388b91-b6d6-492c-9800-63034b03038a" + System.Environment.NewLine);
                    readState.Clear();
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "83d5bcc0-2d72-495a-9ad6-e635fbacd963" + System.Environment.NewLine);
                    processFrame(stateFrameType.Value, stateData);
                }
            }
        }

        public static void ProcessFrame(FrameType frameType, byte[] data, Action<string> onMessage, Action onClose, Action<byte[]> onBinary, Action<byte[]> onPing, Action<byte[]> onPong)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "65865fe1-afe8-4cb0-a839-e22c63cbe49c" + System.Environment.NewLine);
            switch (frameType)
            {
                case FrameType.Close:
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "73aef360-f772-4170-8ee0-21ae9643e2da" + System.Environment.NewLine);
                    if (data.Length == 1 || data.Length > 125)
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6b8b21bb-bc1e-44bd-9999-3a12e9270ce8" + System.Environment.NewLine);
                        throw new WebSocketException(WebSocketStatusCodes.ProtocolError);
                    }

                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2a445d01-8e75-421d-b09d-124a89f2339c" + System.Environment.NewLine);
                    if (data.Length >= 2)
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6bea08c7-116a-455a-93f6-0fda6e2e6547" + System.Environment.NewLine);
                        var closeCode = (ushort)data.Take(2).ToArray().ToLittleEndianInt();
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "34eaf475-7611-4860-967d-327f3dfa29a2" + System.Environment.NewLine);
                        if (!WebSocketStatusCodes.ValidCloseCodes.Contains(closeCode) && (closeCode < 3000 || closeCode > 4999))
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "32cb497f-61d7-414c-afc2-245f2a9e1a6b" + System.Environment.NewLine);
                            throw new WebSocketException(WebSocketStatusCodes.ProtocolError);
                        }
                    }

                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5ca26b57-e04b-4100-b396-b99e0e498ec3" + System.Environment.NewLine);
                    if (data.Length > 2)
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "203eba71-6770-49b7-80c2-61f3aca5da3b" + System.Environment.NewLine);
                        ReadUTF8PayloadData(data.Skip(2).ToArray());
                    }

                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1991334d-2570-4861-95c5-ccdba57d053d" + System.Environment.NewLine);
                    onClose();
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "20d5a036-40e7-44f4-852c-568f653c36f0" + System.Environment.NewLine);
                    break;
                case FrameType.Binary:
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4dfb2de3-c7be-4025-865c-c265d8e12b33" + System.Environment.NewLine);
                    onBinary(data);
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3e6c6acd-423d-4afb-8b18-971059da60b7" + System.Environment.NewLine);
                    break;
                case FrameType.Ping:
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5e65f5a5-a7c1-4bba-8feb-e164ac614180" + System.Environment.NewLine);
                    onPing(data);
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7879c013-78b6-4603-8311-c99a8096f1ce" + System.Environment.NewLine);
                    break;
                case FrameType.Pong:
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "35fa2757-1abc-4325-809b-0fc9f602956f" + System.Environment.NewLine);
                    //onPong(data);
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "65af934c-496c-404f-aaa6-f602e960b590" + System.Environment.NewLine);
                    break;
                case FrameType.Text:
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "67fc846a-eb7a-42d3-8aad-a6e83e7e5d58" + System.Environment.NewLine);
                    onMessage(ReadUTF8PayloadData(data));
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "51d49132-a6e4-48f3-86b9-ddec8b56d48e" + System.Environment.NewLine);
                    break;
                default:
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "80c5c3a0-8684-47e9-acfa-cece7802a4ae" + System.Environment.NewLine);
                    FleckLog.Debug("Received unhandled " + frameType);
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4e025153-63cd-42da-99cf-c4d6b9a633fd" + System.Environment.NewLine);
                    break;
            }
        }

        public static byte[] BuildHandshake(WebSocketHttpRequest request, string subProtocol)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c10b0248-17c4-4240-abcb-5a4b6571f973" + System.Environment.NewLine);
            FleckLog.Debug("Building Hybi-14 Response");
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c0732cff-cff2-4912-8601-83b25e7adbb6" + System.Environment.NewLine);
            var builder = new StringBuilder();
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6464d8a1-70fd-47e2-b7b3-574c06505b81" + System.Environment.NewLine);
            builder.Append("HTTP/1.1 101 Switching Protocols\r\n");
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f69a13f2-ff46-4a12-8f53-6e804371fd26" + System.Environment.NewLine);
            builder.Append("Upgrade: websocket\r\n");
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "600f00b3-a085-40c7-ba3b-644154708c23" + System.Environment.NewLine);
            builder.Append("Connection: Upgrade\r\n");
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2427ec79-8b6d-4de8-a9f8-22e0372d571d" + System.Environment.NewLine);
            if (subProtocol != null)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9d0712ca-e4d1-449a-b0e4-a496c168adad" + System.Environment.NewLine);
                builder.AppendFormat("Sec-WebSocket-Protocol: {0}\r\n", subProtocol);
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "40ad4d99-79c0-40c6-91da-40122a6265c3" + System.Environment.NewLine);
            var responseKey = CreateResponseKey(request["Sec-WebSocket-Key"]);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a262d0cb-a607-4f5a-a9fd-27e2d88302fd" + System.Environment.NewLine);
            builder.AppendFormat("Sec-WebSocket-Accept: {0}\r\n", responseKey);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ba91215e-c9c6-4e49-8205-5708917adb7e" + System.Environment.NewLine);
            builder.Append("\r\n");
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7cc95cc9-92ea-40c4-94ce-e44a4a36f6e3" + System.Environment.NewLine);
            return Encoding.ASCII.GetBytes(builder.ToString());
        }

        private const string WebSocketResponseGuid = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
        public static string CreateResponseKey(string requestKey)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f13751e2-8dff-4791-ae1f-c80b3ecdb290" + System.Environment.NewLine);
            var combined = requestKey + WebSocketResponseGuid;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d077795b-99ef-4a5a-85a7-a82ec7a1801c" + System.Environment.NewLine);
            var bytes = SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(combined));
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "393dd6a9-9ba0-46c3-8656-8e7164c6b4d8" + System.Environment.NewLine);
            return Convert.ToBase64String(bytes);
        }

        private static string ReadUTF8PayloadData(byte[] bytes)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "abf57788-a480-439b-8146-8e1b4b85b4a1" + System.Environment.NewLine);
            var encoding = new UTF8Encoding(false, true);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "49d3fd5f-aeb2-468a-834f-3e8530c8798d" + System.Environment.NewLine);
            try
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8767203c-d8ba-4f6f-8fff-dd1fe3cd037a" + System.Environment.NewLine);
                return encoding.GetString(bytes);
            }
            catch (ArgumentException)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b92dbf06-de01-4945-8b5b-8cdc6973cbb7" + System.Environment.NewLine);
                throw new WebSocketException(WebSocketStatusCodes.InvalidFramePayloadData);
            }
        }
    }
}