using System.Diagnostics;

namespace IntegrationDelete
{
    public class Log
    {
        public static void Add(string err, EventLogEntryType type)
        {
            if (!EventLog.SourceExists("Prospot Integration Delete"))
            {
                EventLog.CreateEventSource("Prospot Integration Delete", "Log Delete");
            }

            EventLog log = new EventLog
            {
                Source = "Prospot Integration Delete",
                Log = "Log Delete"
            };

            log.WriteEntry(err, type);
        }
    }
}