namespace App.Services
{
    using Contracts;
    using NLog;
    using System;
    using System.Collections.Generic;

    class LogProvider : ILogProvider
    {
        private static Dictionary<string, Logger> loggers = new Dictionary<string, Logger>();

        public void Debug(string name, string message)
        {
            GetLogger(name).Debug(message);
        }

        public void Error(string name, string message)
        {
            GetLogger(name).Error(message);
        }

        public void Exception(string name, Exception message)
        {
            GetLogger(name).Fatal(message);
        }

        public void Fatal(string name, string message)
        {
            GetLogger(name).Fatal(message);
        }

        public void Info(string name, string message)
        {
            GetLogger(name).Info(message);
        }

        public void Trace(string name, string message)
        {
            GetLogger(name).Trace(message);
        }

        public void Warn(string name, string message)
        {
            GetLogger(name).Warn(message);
        }

        private static Logger GetLogger(string name)
        {
            if (loggers.ContainsKey(name) == false)
            {
                loggers[name] = LogManager.GetLogger(name);
            }

            return loggers[name];
        }
    }
}
