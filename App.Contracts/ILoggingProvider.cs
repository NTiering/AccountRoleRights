namespace App.Contracts
{
    using System;

    public interface ILogProvider
    {

        void Trace(string name, string message);
        void Debug(string name, string message);
        void Info(string name, string message);
        void Warn(string name, string message);
        void Error(string name, string message);
        void Fatal(string name, string message);
        void Exception(string name, Exception ex);
    }
}
