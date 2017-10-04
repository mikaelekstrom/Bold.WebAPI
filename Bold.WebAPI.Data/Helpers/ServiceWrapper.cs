using System;
using System.Configuration;
using System.ServiceModel;

namespace Bold.WebAPI.Data.Helpers
{
    internal class ServiceWrapper<T> : IDisposable where T : class
    {
        private ChannelFactory<T> _factory;
        private T _channel;

        private readonly BasicHttpBinding _binding;
        private readonly EndpointAddress _endpoint;

        private readonly object _lockObject = new object();
        private bool _disposed;

        internal ServiceWrapper(string configName)
        {
            if (ConfigurationManager.AppSettings[configName] == null)
            {
                throw new ConfigurationErrorsException(configName + " is not present in the config file");
            }

            _binding = new BasicHttpBinding();
            _endpoint = new EndpointAddress(ConfigurationManager.AppSettings[configName]);
            _disposed = false;
        }

        public T Channel
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Resource ServiceWrapper<" + typeof(T) + "> has been disposed");
                }

                lock (_lockObject)
                {
                    if (_factory != null) return _channel;
                    _factory = new ChannelFactory<T>(_binding, _endpoint);
                    _channel = _factory.CreateChannel();
                }
                return _channel;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (!disposing) return;
            lock (_lockObject)
            {
                ((IClientChannel) _channel)?.Close();
                _factory?.Close();
            }

            _channel = null;
            _factory = null;
            _disposed = true;
        }
    }
}
