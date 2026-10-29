using System;

namespace Fleck
{
    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error
    }

    public class FleckLog
    {
        public static LogLevel Level = LogLevel.Info;
        public static Action<LogLevel, string, Exception> LogAction = (level, message, ex) =>
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "22f3d0e3-e123-473d-8d73-838334f9a21f" + System.Environment.NewLine);
            if (level >= Level)
            {
                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7332217f-a7b9-4979-9f9d-487ee5a355c1" + System.Environment.NewLine);
                Console.WriteLine("{0} [{1}] {2} {3}", DateTime.Now, level, message, ex);
            }
        };
        public static void Warn(string message, Exception ex = null)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c6b4d8c0-b80c-4fd9-930b-08e02f44c9d7" + System.Environment.NewLine);
            LogAction(LogLevel.Warn, message, ex);
        }

        public static void Error(string message, Exception ex = null)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "54d40950-86d4-4a32-b572-9b579196af5b" + System.Environment.NewLine);
            LogAction(LogLevel.Error, message, ex);
        }

        public static void Debug(string message, Exception ex = null)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4ec63e4f-72d4-47cd-b5a6-ba5964fb5479" + System.Environment.NewLine);
            LogAction(LogLevel.Debug, message, ex);
        }

        public static void Info(string message, Exception ex = null)
        {
            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4f84d5fa-8c8b-4bb9-8dbe-d41f320ebaa9" + System.Environment.NewLine);
            LogAction(LogLevel.Info, message, ex);
        }
    }
}