using FileHelpers;
using ReadFile.Domain.Interfaces;
using ReadFile.Domain.Repository;
using ReadFile.Domain.Uteis;
using ReadFile.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Service
{
    public class InterpretarArquivo : IInterpretarArquivo
    {
        public void LerArquivo(string caminhoArquivo, string nomeDoArquivo)
        {
            var engine = new MultiRecordEngine(typeof(VendedorDesempenhoViewModel), typeof(ClienteViewModel), typeof(VendaViewModel));

            engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            var objetos = engine.ReadFile(caminhoArquivo);

            var vendedores = new List<Vendedor> { };
            var clientes = new List<Cliente> { };
            var vendas = new List<Venda> { };
            var itens = new List<VendaItem> { };

            foreach (var objeto in objetos)
            {
                if (objeto is Vendedor)
                {
                    vendedores.Add((Vendedor)objeto);
                }
                else if (objeto is ClienteViewModel)
                {
                    clientes.Add((Cliente)objeto);
                }
                if (objeto is VendaViewModel)
                {
                    var vendaTipada = (VendaViewModel)objeto;
                    var venda = new Venda()
                    {
                        SaleId = vendaTipada.SaleId,
                        Salesman = vendaTipada.Salesman,
                        Type = vendaTipada.Type,
                        Itens = new List<VendaItem> { }
                    };
                    InserirItensDaVenda(vendaTipada, venda);
                    vendas.Add(venda);
                }
            }
        }

        private static void InserirItensDaVenda(VendaViewModel vendaTipada, Venda venda)
        {
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
