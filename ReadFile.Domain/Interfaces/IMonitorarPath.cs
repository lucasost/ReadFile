using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReadFile.Domain.Interfaces
{
    public interface IMonitorarPath
    {
        void Monitorar(string path);

        void OnCreated(object sender, FileSystemEventArgs e);

    }
}
