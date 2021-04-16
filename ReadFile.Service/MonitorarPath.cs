using ReadFile.Domain.Interfaces;
using System;
using System.IO;

namespace ReadFile.Service
{
    public class MonitorarPath : IMonitorarPath
    {
        private readonly ILerArquivoRepository _lerArquivo;
        private readonly IEscreverArquivoRepository _escreverArquivo;
        private string _caminhoSaida;
        public MonitorarPath(ILerArquivoRepository lerArquivo, IEscreverArquivoRepository escreverArquivo, string caminhoSaida)
        {
            _lerArquivo = lerArquivo;
            _escreverArquivo = escreverArquivo;
            _caminhoSaida = caminhoSaida;
        }

        public void OnCreated(object sender, FileSystemEventArgs file)
        {
            if (file.ChangeType != WatcherChangeTypes.Created)
            {
                return;
            }

            Console.WriteLine($"Arquivo adicionado: {file.FullPath}");
            Console.WriteLine("Iniciado a leitura/interpretação.");
            var dadosDoArquivo = _lerArquivo.InterpretarArquivo(file.FullPath);
            Console.WriteLine("Iniciado a escrita dos dados.");
            _escreverArquivo.EscreverArquivo(dadosDoArquivo, _caminhoSaida, file.Name);
            Console.WriteLine($"Escrita finalizada, é possível acessar o arquivo em {_caminhoSaida + file.Name}");
            Console.WriteLine("\n\n\n");
            Console.WriteLine($"Esperando novo arquivo...");
        }
    }
}
