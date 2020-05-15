using System;
using System.IO;
using Serilog;

namespace Bound.Utilities.Logging
{
    public class BoundLogger : IBoundLogger
    {
        private LoggerType _loggerType;

        public BoundLogger(bool debugging)
        {
            if(debugging)
                _loggerType = LoggerType.Console;
            else
                _loggerType = LoggerType.File;

            Log.Logger = CreateLoggerFromType();
        }

        private Serilog.Core.Logger CreateLoggerFromType()
        {
            var directory = System.IO.Path.GetDirectoryName( 
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            var path = Path.Combine(directory, "logs.txt");

            // removes "file:\"
            path = path.Substring(6);

            var configuration = _loggerType switch
            {
                LoggerType.Console  => new LoggerConfiguration().WriteTo.Console(),
                LoggerType.File     => new LoggerConfiguration().WriteTo.File(path),
                _                   => throw new ArgumentException("Invalid enum value")
            };

            return configuration.CreateLogger();
        }
    }
}