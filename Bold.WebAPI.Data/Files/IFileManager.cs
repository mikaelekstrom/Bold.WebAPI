using System.Net.Http;

namespace Bold.WebAPI.Data.Files
{
    public interface IFileManager
    {
        HttpResponseMessage GetDataAsStream(int fileId, HttpResponseMessage response);
    }
}
