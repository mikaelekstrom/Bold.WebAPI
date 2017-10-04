namespace Bold.WebAPI.Data.Files
{
    public interface IFileManager
    {
        DataStream GetDataStream(int fileId);
    }
}
