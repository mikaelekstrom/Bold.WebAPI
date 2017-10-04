using System;
using Bold.WebAPI.Data.Helpers;
using Dacsa.Framework.Shared.Interfaces;
using DataService.Services;

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

        public DataStream GetDataStream(int fileId)
        {
            return new DataStream(fileId, _server);
        }
    }
}