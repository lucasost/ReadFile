using ReadFile.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReadFile.Service
{
    public class MonitorarPath : IMonitorarPath
    {
        private readonly IInterpretarArquivo _interpretarArquivo;

        public MonitorarPath(IInterpretarArquivo interpretarArquivo)
        {
            _interpretarArquivo = interpretarArquivo;
        }

        public void Monitorar(string path)
        {
            using var watcher = new FileSystemWatcher(path);

            watcher.NotifyFilter = NotifyFilters.Attributes
                              | NotifyFilters.CreationTime
                              | NotifyFilters.DirectoryName
                              | NotifyFilters.FileName;
            watcher.Created += OnCreated;
            watcher.Filter = "*.txt";
            watcher.EnableRaisingEvents = true;
        }

        public void OnCreated(object sender, FileSystemEventArgs file)
        {
            if (file.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }

            Console.WriteLine($"Arquivo adicionado: {file.FullPath}");
            Console.WriteLine("Iniciado a leitura/interpretação.");
            _interpretarArquivo.LerArquivo(file.FullPath, file.Name);
        }
    }
}
