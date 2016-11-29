using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Common.LogNet
{
    /// <summary>
    /// 日志记录类
    /// </summary>
    public class MyLog
    {
        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message"></param>
        public static void debug(string message)
        {
            ILog log = log4net.LogManager.GetLogger("MyLog");
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
            log = null;
        }
        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception">异常</param>
        public static void debug(string message, Exception exception)
        {
            ILog log = log4net.LogManager.GetLogger("MyLog");
            if (log.IsDebugEnabled)
            //{
                log.Debug(message, exception);
            //}
            log = null;
        }
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        public static void error(string message, Exception exception)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("MyLog");
            //if (log.IsErrorEnabled)
            //{
                log.Error(message, exception);
            //}
            log = null;
        }
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        public static void error(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("MyLog");
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
            log = null;
        }
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message"></param>
        public static void fatal(string message)
        {

            log4net.ILog log = log4net.LogManager.GetLogger("MyLog");
            if (log.IsFatalEnabled)
            {
                log.Fatal(message);
            }
            log = null;
        }
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message"></param>
        public static void fatal(string message, Exception exception)
        {

            log4net.ILog log = log4net.LogManager.GetLogger("MyLog");
            if (log.IsFatalEnabled)
            {
                log.Fatal(message, exception);
            }
            log = null;
        }
        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="message"></param>
        public static void info(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("MyLog");
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
            log = null;
        }
        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="message"></param>
        public static void info(string message, Exception exception)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("MyLog");
            if (log.IsInfoEnabled)
            {
                log.Info(message, exception);
            }
            log = null;
        }
        /// <summary>p
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        public static void warn(string message, Exception exception)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("MyLog");
            if (log.IsWarnEnabled)
            {
                log.Warn(message, exception);
            }
            log = null;
        }
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        public static void warn(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("MyLog");
            if (log.IsWarnEnabled)
            {
                log.Warn(message);
            }
            log = null;
        }
    }
}
