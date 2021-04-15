using System.IO;

namespace ReadFile.Domain.Interfaces
{
    public interface IMonitorarPath
    {
        void OnCreated(object sender, FileSystemEventArgs e);

    }
}
