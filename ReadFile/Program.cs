using FileHelpers;
using ReadFile.Model;
using ReadFile.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadFile
{
    class Program
    {
        
        static void Main(string[] args)
        {
           

            string docs = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var diretorioCompletoOut = docs + "\\data\\out\\";

            if (Directory.Exists(diretorioCompletoOut))
            {
                Console.WriteLine("Caminho de saída já exite!");
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(diretorioCompletoOut);
                Console.WriteLine("Diretório data/out criado com sucesso {0}.", Directory.GetCreationTime(diretorioCompletoOut));
            }

            var diretorioCompletoIn = docs + "\\data\\in\\";

            if (Directory.Exists(diretorioCompletoIn))
            {
                Console.WriteLine("Caminho de entrada já exite!");
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(diretorioCompletoIn);
                Console.WriteLine("Diretório data/in criado com sucesso {0}.", Directory.GetCreationTime(diretorioCompletoOut));
            }


            using var watcher = new FileSystemWatcher(diretorioCompletoIn);

            watcher.NotifyFilter = NotifyFilters.Attributes
                              | NotifyFilters.CreationTime
                              | NotifyFilters.DirectoryName
                              | NotifyFilters.FileName;
            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Filter = "*.txt";
            watcher.EnableRaisingEvents = true;



            var engine = new MultiRecordEngine(typeof(Vendedor), typeof(Cliente), typeof(VendaViewModel));

            engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            var res = engine.ReadFile(diretorioCompletoIn + "FileIn.txt");

            var nomeDoArquivo = $"{Guid.NewGuid()}";

            var vendedores = new List<Vendedor> { };
            var clientes = new List<Cliente> { };
            var vendas = new List<Venda> { };
            var itens = new List<VendaItem> { };

            foreach (var rec in res)
            {
                if (rec is Vendedor)
                {
                    vendedores.Add((Vendedor)rec);
                }
                else if (rec is Cliente)
                {
                    clientes.Add((Cliente)rec);
                }
                if (rec is VendaViewModel)
                {
                    var vendaTipada = (VendaViewModel)rec;
                    var venda = new Venda()
                    {
                        SaleId = vendaTipada.SaleId,
                        Salesman = vendaTipada.Salesman,
                        Type = vendaTipada.Type,
                        Itens = new List<VendaItem> { }
                    };
                    var itensDaVenda = vendaTipada.ItensVendas.Replace("[", "").Replace("]", "").Split(",");

                    foreach (var itemDaVenda in itensDaVenda)
                    {
                        var item = new VendaItem() { };
                        var a = itemDaVenda.Split("-");
                        item.ItemId = int.Parse(a[0]);
                        item.ItemQuantity = int.Parse(a[1]);
                        item.ItemPrice = Convert.ToDecimal(a[2]);
                        venda.Itens.Add(item);
                    }
                    vendas.Add(venda);
                }

                string linha = rec.ToString();
                Console.WriteLine($"{rec}");
            }



            using (var streamWriter = new StreamWriter(Path.Combine(diretorioCompletoOut, "arquivo2.txt"), true))
            {
                streamWriter.WriteLine($"Relatório {nomeDoArquivo}");
                streamWriter.WriteLine($"Quantidade de clientes: {clientes.Count}");
                streamWriter.WriteLine($"Quantidade de Vendedores: {vendedores.Count}");

                var melhorVenda = vendas.GroupBy(a => a.SaleId).Select(g => new MelhorVendaViewModel
                {
                    SaleId = g.Key,
                    ValorVenda = g.SelectMany(b => b.Itens).Sum(c => c.ItemPrice)
                }).OrderByDescending(a => a.ValorVenda).FirstOrDefault();

                streamWriter.WriteLine($"Melhor venda: {melhorVenda.SaleId} no valor de R$ {melhorVenda.ValorVenda}");

                var piorvendedor = vendas.GroupBy(a => a.Salesman).Select(g => new VendedorDesempenhoViewModel
                {
                    Vendedor = g.Key,
                    ValorVenda = g.SelectMany(b => b.Itens).Sum(c => c.ItemPrice)
                }).OrderBy(a => a.ValorVenda).FirstOrDefault();

                streamWriter.WriteLine($"Vendedor com pior desempenho: {piorvendedor.Vendedor}, vendendo apenas R$ {piorvendedor.ValorVenda}");
            }


            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();

        }

        private static Type CustomSelector(MultiRecordEngine engine, string recordString)
        {

            if (recordString.Length == 0)
                return null;

            if (recordString.StartsWith("001"))
                return typeof(Vendedor);
            else if (recordString.StartsWith("002"))
                return typeof(Cliente);
            else if (recordString.StartsWith("003"))
            {
                return typeof(VendaViewModel);
            }
            else
                return null;
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"Deleted: {e.FullPath}");

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:");
            Console.WriteLine($"    Old: {e.OldFullPath}");
            Console.WriteLine($"    New: {e.FullPath}");
        }

        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private static void PrintException(Exception? ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }

        //private Type CustomSelector(MultiRecordEngine engine, string recordLine)
        //{
        //    if (recordLine.Length == 0)
        //        return null;

        //    if (recordLine.StartsWith("001"))
        //        return typeof(Vendedor);
        //    else if (recordLine.StartsWith("002"))
        //        return typeof(Cliente);
        //    //else if (recordLine.StartsWith("003"))
        //    //    return typeof(Venda);
        //    else
        //        return null;
        //}
    }
}



//%HOMEPATH% - data - in
//%HOMEPATH% - data - out