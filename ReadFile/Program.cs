using FileHelpers;
using ReadFile.Domain.Interfaces;
using ReadFile.Domain.Uteis;
using ReadFile.Domain.ViewModel;
using ReadFile.Service;
using System;
using System.IO;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gerenciado de leitura de arquivos e interpretador de vendas.");

            string caminhoHomePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var diretorioCompletoOut = caminhoHomePath + "\\data\\out\\";
            var diretorioCompletoIn = caminhoHomePath + "\\data\\in\\";

            IGerenciarArquivo gerenciarArquivo = new GerenciarArquivo();
            ILerArquivoRepository lerArquivo = new LerArquivo();
            IRegistro registro = new RegistrarNoArquivo();
            IEscreverArquivoRepository escrecerArquivo = new EscreverArquivo(registro);
            IMonitorarPath monitorarPath = new MonitorarPath(lerArquivo, escrecerArquivo, diretorioCompletoOut);

            gerenciarArquivo.CriarCaminho(diretorioCompletoIn);
            gerenciarArquivo.CriarCaminho(diretorioCompletoOut);

            Console.WriteLine("\n \n");
            Console.WriteLine("Monitorando para ler arquivos.");

            using var monitorar = new FileSystemWatcher(diretorioCompletoIn);

            monitorar.NotifyFilter = NotifyFilters.Attributes
                              | NotifyFilters.CreationTime
                              | NotifyFilters.DirectoryName
                              | NotifyFilters.FileName;
            monitorar.Created += monitorarPath.OnCreated;
            monitorar.Filter = "*.txt";
            monitorar.EnableRaisingEvents = true;

            Console.ReadLine();
        }

        private static Type CustomSelector(MultiRecordEngine engine, string recordString)
        {
            if (recordString.Length == 0)
                return null;

            if (recordString.StartsWith(Constantes.TypeVendedor))
                return typeof(VendedorViewModel);
            else if (recordString.StartsWith(Constantes.TypeCliente))
                return typeof(ClienteViewModel);
            else if (recordString.StartsWith(Constantes.TypeVenda))
                return typeof(VendaViewModel);
            else
                return null;
        }
    }
}
