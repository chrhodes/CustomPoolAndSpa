using System;

namespace CustomPoolAndSpa.Core
{
    public class ServiceResult<T> : EventArgs
    {
        public T Object { get; private set; }

        public ServiceResult(T obj)
        {
            Object = obj;
        }
    }
}
