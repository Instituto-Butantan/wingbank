using MosquitoLab.Shared.Commands;

namespace MosquitoLab.Domain.Individuals.Commands.Output
{
    public class DownloadWingCommandResult :  ICommandResult
    {
        public DownloadWingCommandResult()
        {
        }

        public DownloadWingCommandResult(string fileName, string contentType, string downloadFileName)
        {
            FileName = fileName;
            DownloadFileName = downloadFileName;
            ContentType = contentType;
        }

        public string FileName { get; private set; }
        public string DownloadFileName { get; private set; }
        public string ContentType { get; private set; }

    }
}
