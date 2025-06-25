namespace Task2
{
    public static class Server
    {
        private static int _сount = 0;
        private static readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            _lock.EnterReadLock();
            try
            {
                return _сount;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            _lock.EnterWriteLock();
            try
            {
                _сount += value;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}
