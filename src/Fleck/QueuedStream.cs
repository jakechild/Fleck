using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Fleck
{
    /// <summary>
    /// Wraps a stream and queues multiple write operations.
    /// Useful for wrapping SslStream as it does not support multiple simultaneous write operations.
    /// </summary>
    public class QueuedStream : Stream
    {
        readonly Stream _stream;
        readonly Queue<WriteData> _queue = new Queue<WriteData>();
        int _pendingWrite;
        bool _disposed;
        public QueuedStream(Stream stream)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b2d60f0f-7174-4ed3-8daa-25bb81e2accb" + System.Environment.NewLine);
            _stream = stream;
        }

        public override bool CanRead
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d17fe877-64b2-45a1-8dfd-e8c4df708e01" + System.Environment.NewLine);
                return _stream.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f45cf764-1cc9-4575-90bc-8897c51f17e8" + System.Environment.NewLine);
                return _stream.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "88d770f8-006c-4875-bddd-96c7260117fe" + System.Environment.NewLine);
                return _stream.CanWrite;
            }
        }

        public override long Length
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "313d250f-554a-4473-b7f0-0797ab246a12" + System.Environment.NewLine);
                return _stream.Length;
            }
        }

        public override long Position
        {
            get
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b7d43b7d-57b1-4b04-a901-5aa20d43630b" + System.Environment.NewLine);
                return _stream.Position;
            }

            set
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "438cf3aa-1fd7-4ee7-81db-3730f12042ca" + System.Environment.NewLine);
                _stream.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "491a2777-814a-49b8-b21b-bcff3896bc5d" + System.Environment.NewLine);
            return _stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "78a6daf6-865c-40cb-8130-a267183239f9" + System.Environment.NewLine);
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3a9aac17-4a60-4b4c-90c9-b54d24edc62a" + System.Environment.NewLine);
            _stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9eb9a3bf-148a-49cf-a80b-0c6ff79f19be" + System.Environment.NewLine);
            throw new NotSupportedException("QueuedStream does not support synchronous write operations yet.");
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "63f5a79f-7a1c-48d9-a480-18ddfb4c696e" + System.Environment.NewLine);
            return _stream.BeginRead(buffer, offset, count, callback, state);
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "aa08e094-24bb-4211-92e3-3947e05494e3" + System.Environment.NewLine);
            lock (_queue)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "25e4aac8-dce8-4b24-a284-1879afe8915a" + System.Environment.NewLine);
                var data = new WriteData(buffer, offset, count, callback, state);
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4a88d64b-c735-405b-8b95-3732ce2f3df8" + System.Environment.NewLine);
                if (_pendingWrite > 0)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "40bc1c72-7a3f-4f71-b254-190b8ffab1d9" + System.Environment.NewLine);
                    _queue.Enqueue(data);
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "beb3afef-8c8e-4853-afad-1f00531a8086" + System.Environment.NewLine);
                    return data.AsyncResult;
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e9ec8dc6-a835-4597-9c83-ccee6a53e618" + System.Environment.NewLine);
                return BeginWriteInternal(buffer, offset, count, callback, state, data);
            }
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "110f8f66-d7a2-4a06-b84a-318c028bcf57" + System.Environment.NewLine);
            return _stream.EndRead(asyncResult);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7c7d1644-18df-4d9d-89c8-53404fd5b9b9" + System.Environment.NewLine);
            if (asyncResult is QueuedWriteResult)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "baf5ea06-f363-467c-a3ce-cfb0ea13f90d" + System.Environment.NewLine);
                var queuedResult = asyncResult as QueuedWriteResult;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2d7ad2d4-e4ea-4953-a29d-aa44f95be36e" + System.Environment.NewLine);
                if (queuedResult.Exception != null)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b231c3ba-4286-492e-a1a8-6171ec265fa9" + System.Environment.NewLine);
                    throw queuedResult.Exception;
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3edaf4e2-ecc6-42a1-b670-9a544a8e9540" + System.Environment.NewLine);
                var ar = queuedResult.ActualResult;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4b39f859-feab-49b0-be85-7bf7d237329d" + System.Environment.NewLine);
                if (ar == null)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "93302635-6d52-438f-a978-ac7ea04d42fc" + System.Environment.NewLine);
                    throw new NotSupportedException("QueuedStream does not support synchronous write operations. Please wait for callback to be invoked before calling EndWrite.");
                }
            // EndWrite on actual stream should already be invoked.
            }
            else
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6e1e3580-a71b-45a0-8579-a592c6213fb2" + System.Environment.NewLine);
                throw new ArgumentException();
            }
        }

        public override void Flush()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b005418a-a073-4c91-82a2-2908624c6791" + System.Environment.NewLine);
            _stream.Flush();
        }

        public override void Close()
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cb96c86b-3a6c-40d0-a5c6-091fc8631616" + System.Environment.NewLine);
            _stream.Close();
        }

        protected override void Dispose(bool disposing)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "71a006b4-d039-449f-acb8-d4e185bf74de" + System.Environment.NewLine);
            if (!_disposed)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f6a2d054-051c-4cbc-b2cf-0473cc457570" + System.Environment.NewLine);
                if (disposing)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b15d2a44-38ad-4c27-bc4c-2a5c5c6b512e" + System.Environment.NewLine);
                    _stream.Dispose();
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4d3b8797-e48c-4481-a142-f9833e0981b2" + System.Environment.NewLine);
                _disposed = true;
            }

            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cdbaabd9-e164-48bc-b5e9-828ca02bf771" + System.Environment.NewLine);
            base.Dispose(disposing);
        }

        IAsyncResult BeginWriteInternal(byte[] buffer, int offset, int count, AsyncCallback callback, object state, WriteData queued)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9b88113c-7471-4f38-be21-7d34a411b729" + System.Environment.NewLine);
            _pendingWrite++;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "69242f27-6dda-41dc-9b16-809d07801fd4" + System.Environment.NewLine);
            var result = _stream.BeginWrite(buffer, offset, count, ar =>
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "11eacf22-e875-416a-8e00-4e8b586dd532" + System.Environment.NewLine);
                // callback can be executed even before return value of BeginWriteInternal is set to this property
                queued.AsyncResult.ActualResult = ar;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "519f7270-884e-475d-8bd9-f2fd9a9e21da" + System.Environment.NewLine);
                try
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2c07b849-eeae-40b4-bb75-84efa28f258f" + System.Environment.NewLine);
                    // so that we can call BeginWrite again
                    _stream.EndWrite(ar);
                }
                catch (Exception exc)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4d8497c1-ca8e-494d-bd6b-f535d9b0d6d3" + System.Environment.NewLine);
                    queued.AsyncResult.Exception = exc;
                }

                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "50a8ac68-82e8-48e9-9abc-3ba42c68aeba" + System.Environment.NewLine);
                // one down, another is good to go
                lock (_queue)
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ca6d12f6-0699-483c-9676-9baf7f26bd58" + System.Environment.NewLine);
                    _pendingWrite--;
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8e48b7c6-bcf4-4a50-a367-bf08c7134080" + System.Environment.NewLine);
                    while (_queue.Count > 0)
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "19e8843e-773d-4af8-a430-4b8aa63b5232" + System.Environment.NewLine);
                        var data = _queue.Dequeue();
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8835a1e5-7400-4ed6-95e1-e8552f9e4136" + System.Environment.NewLine);
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "31e9ee3b-68c0-4731-9173-cc598819c103" + System.Environment.NewLine);
                            data.AsyncResult.ActualResult = BeginWriteInternal(data.Buffer, data.Offset, data.Count, data.Callback, data.State, data);
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4f0cabe3-75af-4cb5-b734-73fc0550885f" + System.Environment.NewLine);
                            break;
                        }
                        catch (Exception exc)
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c0f8193d-a33b-40ea-a335-0e4040756beb" + System.Environment.NewLine);
                            _pendingWrite--;
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2468f953-a0de-4901-b259-7137ac858c09" + System.Environment.NewLine);
                            data.AsyncResult.Exception = exc;
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7e7f0929-9acc-4b4b-afd6-d9b1eb072d32" + System.Environment.NewLine);
                            data.Callback(data.AsyncResult);
                        }
                    }

                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d808335a-f0ff-421c-957b-541d36b0520a" + System.Environment.NewLine);
                    callback(queued.AsyncResult);
                }
            }, state);
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d5819b03-7e35-4c98-9c0c-409b79559e21" + System.Environment.NewLine);
            // always return the wrapped async result.
            // this is especially important if the underlying stream completed the operation synchronously (hence "result.CompletedSynchronously" is true!)
            queued.AsyncResult.ActualResult = result;
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a814b712-1794-4a1e-a468-3dd04bc9534f" + System.Environment.NewLine);
            return queued.AsyncResult;
        }

#region Nested type: WriteData
        class WriteData
        {
            public readonly byte[] Buffer;
            public readonly int Offset;
            public readonly int Count;
            public readonly AsyncCallback Callback;
            public readonly object State;
            public readonly QueuedWriteResult AsyncResult;
            public WriteData(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "13065c0a-bef5-4431-a54f-d4e33f781d31" + System.Environment.NewLine);
                Buffer = buffer;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "099293e2-5db9-4741-babc-2c456da0bcf9" + System.Environment.NewLine);
                Offset = offset;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e396c096-025d-45b1-ad50-f42a0981fefb" + System.Environment.NewLine);
                Count = count;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b98fb936-4355-4045-9e96-8f0fa9fec154" + System.Environment.NewLine);
                Callback = callback;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d34b4ac1-99bc-4948-abbb-497ab537ba53" + System.Environment.NewLine);
                State = state;
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0c412353-62ab-44ca-a70b-db241981bec3" + System.Environment.NewLine);
                AsyncResult = new QueuedWriteResult(state);
            }
        }

#endregion
#region Nested type: QueuedWriteResult
        class QueuedWriteResult : IAsyncResult
        {
            readonly object _state;
            public QueuedWriteResult(object state)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "55abc941-955d-437f-ad73-e08b78d8faad" + System.Environment.NewLine);
                _state = state;
            }

            public Exception Exception { get; set; }
            public IAsyncResult ActualResult { get; set; }

            public object AsyncState
            {
                get
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c918c582-73a3-4582-b101-2a5a45018e64" + System.Environment.NewLine);
                    return _state;
                }
            }

            public WaitHandle AsyncWaitHandle
            {
                get
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "841dc3f4-4bb5-4f9e-8287-f8bb900a3479" + System.Environment.NewLine);
                    throw new NotSupportedException("Queued write operations do not support wait handle.");
                }
            }

            public bool CompletedSynchronously
            {
                get
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "134825a2-f483-414c-a47b-09b1363e7701" + System.Environment.NewLine);
                    return false;
                }
            }

            public bool IsCompleted
            {
                get
                {
                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8b649800-50e6-4b36-9dc3-4c09555ddee7" + System.Environment.NewLine);
                    return ActualResult != null && ActualResult.IsCompleted;
                }
            }
        }
#endregion
    }
}