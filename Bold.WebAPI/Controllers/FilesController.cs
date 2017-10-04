using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Bold.WebAPI.Data.Files;

namespace Bold.WebAPI.Controllers
{
    public class FilesController : ApiController
    {
        private readonly IFileManager _fileManager;

        public FilesController() : this(new FileManager()) {}

        public FilesController(IFileManager fileManager)
        {
            if (fileManager == null) throw new ArgumentNullException(nameof(fileManager));
            _fileManager = fileManager;
        }

        public HttpResponseMessage GetFile(int fileId)
        {
            var dataStream = _fileManager.GetDataStream(fileId);
            Action<Stream, HttpContent, TransportContext> writeToStream = dataStream.GetStream;
            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(writeToStream, new MediaTypeHeaderValue("application/octet-stream"));
            return response;
        }
    }
}