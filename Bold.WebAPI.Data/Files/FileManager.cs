using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Bold.WebAPI.Commons.Constants;
using Bold.WebAPI.Commons.Helpers;
using Dacsa.Framework.Shared.Interfaces;

namespace Bold.WebAPI.Data.Files
{
    public class FileManager : IFileManager
    {
        private readonly IServer _server;
        public FileManager() : this(ServiceHelper.GetIServerServiceWrapper()) {}

        public FileManager(IServer server)
        {
            _server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public HttpResponseMessage GetDataAsStream(int fileId, HttpResponseMessage response)
        {
            var dataStream = new DataStream(fileId, _server);
            Action<Stream, HttpContent, TransportContext> writeToStream = dataStream.GetStream;
            response.Content = new PushStreamContent(writeToStream, new MediaTypeHeaderValue(Constants.MediaTypes.ApplicationOctet));
            return response;
        }
    }
}