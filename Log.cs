using System;
using System.Threading;
using System.Diagnostics;


namespace GalaxySmash
{
    public static class Log
    {
        public static string LogSource = "Generic Name";

        public static void EpicFail()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exc"></param>
        public static void Error(Exception exc)
        {
            try
            {
                Event(EventLogEntryType.Error, exc.ToPrettyString());
            }
            catch (Exception)
            {
                EpicFail();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Error(string message, params object[] args)
        {
            try
            {
                Event(EventLogEntryType.Error, string.Format(message, args));
            }
            catch (Exception)
            {
                EpicFail();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="exc"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Error(Exception exc, string message, params object[] args)
        {
            try
            {
                Event(EventLogEntryType.Error, string.Format(message, args) + exc.ToPrettyString());
            }
            catch (Exception)
            {
                EpicFail();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Info(string message, params object[] args)
        {
            try
            {
                Event(EventLogEntryType.Information, string.Format(message, args));
            }
            catch (Exception)
            {
                EpicFail();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Warning(string message, params object[] args)
        {
            try
            {
                Event(EventLogEntryType.Warning, string.Format(message, args));
            }
            catch (Exception)
            {
                EpicFail();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="exc"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Warning(Exception exc, string message, params object[] args)
        {
            try
            {
                Event(EventLogEntryType.Warning, string.Format(message, args) + exc.ToPrettyString());
            }
            catch (Exception)
            {
                EpicFail();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        private static void Event(EventLogEntryType type, string message, int eventId)
        {
            try
            {
                if (!EventLog.SourceExists(LogSource))
                {
                    EventLog.CreateEventSource(LogSource, "Application");
                    Thread.Sleep(2500);
                }

                using (var log = new EventLog())
                {
                    log.Source = LogSource;
                    log.WriteEntry(message, type, eventId);
                }
            }
            catch (Exception)
            {
                EpicFail();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static void Event(EventLogEntryType type, string message)
        {
            try
            {
                Event(type, message, 1000);
            }
            catch (Exception)
            {
                EpicFail();
            }
        }
    }
}
