using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using Prism.Logging;

namespace LoggerUtility
{
    public class Logger : ILoggerFacade
    {
        private readonly ILog m_logger = null;

        public Logger()
        {
            m_logger = LogManager.GetLogger(typeof(Logger));
        }
        public void Initialize()
        {
            SetFileName();
        }

        private void SetFileName()
        {
            XmlConfigurator.Configure();
            log4net.Repository.Hierarchy.Hierarchy _hierarchy = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();
            foreach (IAppender _appender in _hierarchy.Root.Appenders)
            {
                if (_appender is FileAppender)
                {
                    FileAppender _fileAppender = (FileAppender)_appender;
                    string _logFileLocation = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                    _logFileLocation = System.IO.Path.GetDirectoryName(_logFileLocation);
                    _fileAppender.File = _fileAppender.File + "Logger.log";
                    _fileAppender.ActivateOptions(); //for additional options
                    break;
                }
            }
        }

        public void Log(string message, Category category, Priority priority)
        {
            try
            {
                switch (category)
                {
                    case Category.Debug:
                        m_logger.Debug(message);
                        break;
                    case Category.Warn:
                        m_logger.Warn(message);
                        break;
                    case Category.Exception:
                        m_logger.Error(message);
                        break;
                    case Category.Info:
                        m_logger.Info(message);
                        break;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }
        }
    }
}
