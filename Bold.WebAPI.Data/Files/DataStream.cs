using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using Dacsa.Framework.Shared.Interfaces;
using Dacsa.Framework.Shared.Misc;
using DataService.Services;

namespace Bold.WebAPI.Data.Files
{
    public class DataStream
    {
        private readonly int _fileId;
        private readonly IServer _server;

        public DataStream(int fileId) : this(fileId, new Server()) {}

        public DataStream(int fileId, IServer server)
        {
            _fileId = fileId;
            _server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public async void GetStream(Stream outputStream, HttpContent content, TransportContext context)
        {
            try
            {
                var bytes = new byte[0];
                var index = 0;
                do
                {
                    bytes = _server.ResourceBinaryDataSelectChunk(_fileId, index, FileTransfer.FileChunkSize);
                    await outputStream.WriteAsync(bytes, index, FileTransfer.FileChunkSize);
                    index += FileTransfer.FileChunkSize;
                } while (!bytes.Length.Equals(0));
            }
            catch (HttpException ex)
            {
                return;
            }
            finally
            {
                outputStream.Close();
            }
        }
    }
}
