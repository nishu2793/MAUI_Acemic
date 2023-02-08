using System.Collections.Concurrent;

namespace AceMicEV
{
    public static class ConcurrentDicSignalR
    {
        public static ConcurrentDictionary<string, object> _dictionary = new ConcurrentDictionary<string, object>();

    }
}