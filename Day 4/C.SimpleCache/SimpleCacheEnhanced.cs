using System.Collections.Generic;
using System.Threading;

namespace C.SimpleCache
{
    class SimpleCacheEnhanced
    {
        private Dictionary<string, string> cache;

        private ReaderWriterLockSlim rwLock;

        public SimpleCacheEnhanced()
        {
            cache = new Dictionary<string, string>();
            rwLock = new ReaderWriterLockSlim();
        }

        public string GetValue(string key)
        {
            rwLock.EnterUpgradeableReadLock();
            try
            {
                if (cache.ContainsKey(key))
                {
                    return cache[key];
                }
                else
                {
                    string value;
                    rwLock.EnterWriteLock();
                    try
                    {
                        if (!cache.ContainsKey(key))
                        {
                            //Simulate that we get the value from somewhere...
                            value = key + ": some value...";
                            Thread.Sleep(1000);
                            //...simulation ends.
                            cache.Add(key, value);
                        }
                        else
                        {
                            value = cache[key];
                        }
                    }
                    finally
                    {
                        rwLock.ExitWriteLock();
                    }
                    return value;
                }
            }
            finally
            {
                rwLock.ExitUpgradeableReadLock();
            }
        }
    }
}

