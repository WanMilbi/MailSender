using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Threading.Tasks
{
    static class YieldAwaitableExtensions
    {
        public static YieldAsyncAwaitable ConfigureAwait(this YieldAwaitable _, bool LockContext)
        {
            return new YieldAsyncAwaitable(LockContext);
        }
    }

    internal struct YieldAsyncAwaitable
    {
        private readonly bool _LockContext;
        public YieldAsyncAwaitable(bool LockContext) => _LockContext = LockContext;

        public YieldAsyncAwaiter GetAwaiter() => new YieldAsyncAwaiter(_LockContext);

        public struct YieldAsyncAwaiter : ICriticalNotifyCompletion, INotifyCompletion
        {
            private readonly bool _LockContext;
            public bool IsCompleted => false;

            public YieldAsyncAwaiter(in bool LockContext)
            {
                _LockContext = LockContext;

            }

            public void OnCompleted(Action continuation)
            {
                throw new NotImplementedException();
            }

            public void UnsafeOnCompleted(Action continuation)
            {
                throw new NotImplementedException();
            }

            public void GetResult() { }
        }
    }
}
