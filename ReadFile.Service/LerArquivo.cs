using FileHelpers;
using ReadFile.Domain.Entity;
using ReadFile.Domain.Interfaces;
using ReadFile.Domain.Uteis;
using ReadFile.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ReadFile.Service
{
    public class LerArquivo : ILerArquivoRepository
    {
        public DadosRetornoArquivoModel InterpretarArquivo(string caminhoArquivo)
        {
            var engine = new MultiRecordEngine(typeof(VendedorViewModel), typeof(ClienteViewModel), typeof(VendaViewModel));

            engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            var objetos = engine.ReadFile(caminhoArquivo);

            var vendedores = new List<Vendedor>();
            var clientes = new List<Cliente>();
            var vendas = new List<Venda>();

            foreach (var objeto in objetos)
            {
                if (objeto is VendedorViewModel)
                {
                    var objetoTipado = (VendedorViewModel)objeto;

                    var vendedor = new Vendedor(objetoTipado.Type, objetoTipado.Cpf, objetoTipado.Name, objetoTipado.Salary);
                    vendedores.Add(vendedor);
                }
                else if (objeto is ClienteViewModel)
                {
                    var objetoTipado = (ClienteViewModel)objeto;
                    var cliente = new Cliente(objetoTipado.Type, objetoTipado.Cnpj, objetoTipado.Name, objetoTipado.BusinessArea);
                    clientes.Add(cliente);
                }
                if (objeto is VendaViewModel)
                {
                    var vendaTipada = (VendaViewModel)objeto;
                    var venda = new Venda(vendaTipada.Type, vendaTipada.SaleId, vendaTipada.Salesman);
                    InserirItensDaVenda(vendaTipada, venda);
                    vendas.Add(venda);
                }
            }

            return new DadosRetornoArquivoModel
            {
                Vendas = vendas,
                Clientes = clientes,
                Vendedores = vendedores,
            };
        }

        private static void InserirItensDaVenda(VendaViewModel vendaTipada, Venda venda)
        {
            var itensDaVenda = vendaTipada.ItensVendas.Replace("[", "").Replace("]", "").Split(",");
            CultureInfo cultures = new CultureInfo("en-US");

            foreach (var itemDaVenda in itensDaVenda)
            {
                var dadosDoItem = itemDaVenda.Split("-");
                var item = new VendaItem(int.Parse(dadosDoItem[0]), int.Parse(dadosDoItem[1]), Convert.ToDecimal(dadosDoItem[2], cultures));
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
