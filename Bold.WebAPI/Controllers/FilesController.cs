using System;
using System.Net.Http;
using System.Web.Http;
using Bold.WebAPI.Commons.Constants;
using Bold.WebAPI.Data.Files;
using Microsoft.Web.Http;

namespace Bold.WebAPI.Controllers
{
    [ApiVersion("1")]
    [RoutePrefix(Constants.RoutePrefixes.FilesPrefix)]
    public class FilesController : ApiController
    {
        private readonly IFileManager _fileManager;

        public FilesController() : this(new FileManager()) {}

        public FilesController(IFileManager fileManager)
        {
            _fileManager = fileManager ?? throw new ArgumentNullException(nameof(fileManager));
        }

        [Route("{fileId}")]
        public HttpResponseMessage GetFile(int fileId)
        {
            var response = Request.CreateResponse();
            _fileManager.GetDataAsStream(fileId, response);
            return response;
        }
    }
}