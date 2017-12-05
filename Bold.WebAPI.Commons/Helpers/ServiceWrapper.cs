using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Bold.WebAPI.Commons.Helpers
{
    internal class ServiceWrapper<T> : IDisposable where T : class
    {
        private readonly ClientCredentials _clientCredentials;
        private ChannelFactory<T> _factory;
        private T _channel;

        private readonly WSHttpBinding _binding;
        private readonly EndpointAddress _endpoint;

        private readonly object _lockObject = new object();
        private bool _disposed;

        internal ServiceWrapper(string configName, SecurityMode securityMode = SecurityMode.None,
            WSMessageEncoding messageEncoding = WSMessageEncoding.Mtom, ClientCredentials clientCredentials = null)
        {
            
            if (ConfigurationManager.AppSettings[configName] == null)
            {
                throw new ConfigurationErrorsException(configName + " is not present in the config file");
            }
            _binding = new WSHttpBinding(securityMode) { MessageEncoding = messageEncoding };
            _endpoint = new EndpointAddress(ConfigurationManager.AppSettings[configName]);
            _clientCredentials = clientCredentials;
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
                    if (_clientCredentials != null)
                        SetCredentials();
                    _channel = _factory.CreateChannel();
                }
                return _channel;
            }
        }

        private void SetCredentials()
        {
            var credentialBehaviour = _factory.Endpoint.Behaviors.Find<ClientCredentials>();
            credentialBehaviour.UserName.UserName = _clientCredentials.UserName.UserName;
            credentialBehaviour.UserName.Password = _clientCredentials.UserName.Password;
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
