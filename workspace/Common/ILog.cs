using System;

namespace Common
{
    public interface ILog
    {
        void Info(string message);
        void Info(string message, Exception e);
        void Warn(string message);
        void Warn(string message, Exception e);
        void Debug(string message);
        void Debug(string message, Exception e);
        void Error(string message);
        void Error(string message, Exception e);
    }
}
