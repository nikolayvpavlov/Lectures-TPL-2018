using System.Collections.Generic;
using System.Threading;

namespace C.SimpleCache
{
    class SimpleCache
    {
        private object objLock = new object();

        private Dictionary<string, string> cache;

        private ManualResetEvent readLockEvent = new ManualResetEvent(false);
        private ManualResetEvent writeLockEvent = new ManualResetEvent(false);

        public SimpleCache()
        {
            cache = new Dictionary<string, string>();
            readLockEvent.Set();
            writeLockEvent.Set();
        }

        public string GetValue(string key)
        {
            readLockEvent.WaitOne();
            if (cache.ContainsKey(key))
            {
                writeLockEvent.Reset(); //This is still a bug - ContainsKey should also be covered.
                var s = cache[key];
                writeLockEvent.Set();
                return s;
            }
            else
            {
                lock (objLock)
                {
                    string value;
                    readLockEvent.Reset();
                    if (!cache.ContainsKey(key))
                    {
                        //Simulate that we get the value from somewhere...
                        value = key + ": some value...";
                        Thread.Sleep(1000);
                        //...simulation ends.
                        writeLockEvent.WaitOne();
                        cache.Add(key, value);
                    }
                    else
                    {
                        value = cache[key];
                    }
                    readLockEvent.Set();
                    return value;
                }
            }

        }
    }
}
