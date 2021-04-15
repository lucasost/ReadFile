//using FileHelpers;
//using ReadFile.Domain.Interfaces;
//using ReadFile.Model;
//using ReadFile.ViewModel;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace ReadFile
//{
//    class Program
//    {
        
//        static void Main(string[] args)
//        {
//            private IGerenciarArquivo _gerenciarArquivo; 
//            string caminhoHomePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


//            //criar arquivo





//            using (var streamWriter = new StreamWriter(Path.Combine(diretorioCompletoOut, "arquivo2.txt"), true))
//            {
//                streamWriter.WriteLine($"Relatório {nomeDoArquivo}");
//                streamWriter.WriteLine($"Quantidade de clientes: {clientes.Count}");
//                streamWriter.WriteLine($"Quantidade de Vendedores: {vendedores.Count}");

//                var melhorVenda = vendas.GroupBy(a => a.SaleId).Select(g => new MelhorVendaViewModel
//                {
//                    SaleId = g.Key,
//                    ValorVenda = g.SelectMany(b => b.Itens).Sum(c => c.ItemPrice)
//                }).OrderByDescending(a => a.ValorVenda).FirstOrDefault();

//                streamWriter.WriteLine($"Melhor venda: {melhorVenda.SaleId} no valor de R$ {melhorVenda.ValorVenda}");

//                var piorvendedor = vendas.GroupBy(a => a.Salesman).Select(g => new VendedorDesempenhoViewModel
//                {
//                    Vendedor = g.Key,
//                    ValorVenda = g.SelectMany(b => b.Itens).Sum(c => c.ItemPrice)
//                }).OrderBy(a => a.ValorVenda).FirstOrDefault();

//                streamWriter.WriteLine($"Vendedor com pior desempenho: {piorvendedor.Vendedor}, vendendo apenas R$ {piorvendedor.ValorVenda}");
//            }


//            Console.WriteLine("Press enter to exit.");
//            Console.ReadLine();

//        }

//        private static Type CustomSelector(MultiRecordEngine engine, string recordString)
//        {
//implementar as contanstes
//            if (recordString.Length == 0)
//                return null;

//            if (recordString.StartsWith("001"))
//                return typeof(Vendedor);
//            else if (recordString.StartsWith("002"))
//                return typeof(Cliente);
//            else if (recordString.StartsWith("003"))
//            {
//                return typeof(VendaViewModel);
//            }
//            else
//                return null;
//        }


//        //private Type CustomSelector(MultiRecordEngine engine, string recordLine)
//        //{
//        //    if (recordLine.Length == 0)
//        //        return null;

//        //    if (recordLine.StartsWith("001"))
//        //        return typeof(Vendedor);
//        //    else if (recordLine.StartsWith("002"))
//        //        return typeof(Cliente);
//        //    //else if (recordLine.StartsWith("003"))
//        //    //    return typeof(Venda);
//        //    else
//        //        return null;
//        //}
//    }
//}



////%HOMEPATH% - data - in
////%HOMEPATH% - data - out