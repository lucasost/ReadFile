using ReadFile.Service;
using Xunit;

namespace ReadFile.Test
{
    public class LerArquivoTest
    {
        [Fact]
        public void TesteLeituraVendedor()
        {
            var lerArquivo = new LerArquivo();
            var retorno = lerArquivo.InterpretarArquivo(@"Arquivos/TesteVendedor.txt");
            Assert.Collection(retorno.Vendedores, itens =>
            {
                Assert.Equal("001", itens.Type);
                Assert.Equal("1234567891234", itens.Cpf);
                Assert.Equal(5000M, itens.Salary);
                Assert.Equal("Pedro", itens.Name);
            },
            itens =>
            {
                Assert.Equal("001", itens.Type);
                Assert.Equal("3245678865434", itens.Cpf);
                Assert.Equal(4000.99M, itens.Salary);
                Assert.Equal("Paulo", itens.Name);
            });
        }

        [Fact]
        public void TesteLeituraCliente()
        {
            var lerArquivo = new LerArquivo();
            var retorno = lerArquivo.InterpretarArquivo(@"Arquivos/TesteCliente.txt");
            Assert.Collection(retorno.Clientes, itens =>
            {
                Assert.Equal("002", itens.Type);
                Assert.Equal("2345675434544345", itens.Cnpj);
                Assert.Equal("Jose da Silva", itens.Name);
                Assert.Equal("Rural", itens.BusinessArea);
            },
            itens =>
            {
                Assert.Equal("002", itens.Type);
                Assert.Equal("2345675433444345", itens.Cnpj);
                Assert.Equal("Eduardo Pereira", itens.Name);
                Assert.Equal("Rural", itens.BusinessArea);
            });
        }

        [Fact]
        public void TesteLeituraVenda()
        {
            var lerArquivo = new LerArquivo();
            var retorno = lerArquivo.InterpretarArquivo(@"Arquivos/TesteVenda.txt");
            Assert.Collection(retorno.Vendas, itens =>
            {
                Assert.Equal("003", itens.Type);
                Assert.Equal(15, itens.SaleId);
                Assert.Equal("Pedro", itens.Salesman);
                Assert.Collection(itens.Itens, itensDavenda =>
                {
                    Assert.Equal(1, itensDavenda.ItemId);
                    Assert.Equal(10, itensDavenda.ItemQuantity);
                    Assert.Equal(150M, itensDavenda.ItemPrice);
                },
                itensDavenda =>
                {
                    Assert.Equal(2, itensDavenda.ItemId);
                    Assert.Equal(30, itensDavenda.ItemQuantity);
                    Assert.Equal(2.5M, itensDavenda.ItemPrice);
                },
                itensDavenda =>
                {
                    Assert.Equal(3, itensDavenda.ItemId);
                    Assert.Equal(40, itensDavenda.ItemQuantity);
                    Assert.Equal(3.1M, itensDavenda.ItemPrice);
                }
                );
            },
            itens =>
            {
                Assert.Equal("003", itens.Type);
                Assert.Equal(48, itens.SaleId);
                Assert.Equal("Paulo Ricardo", itens.Salesman);
                Assert.Collection(itens.Itens, itensDavenda =>
                {
                    Assert.Equal(1, itensDavenda.ItemId);
                    Assert.Equal(34, itensDavenda.ItemQuantity);
                    Assert.Equal(130M, itensDavenda.ItemPrice);
                },
              itensDavenda =>
              {
                  Assert.Equal(2, itensDavenda.ItemId);
                  Assert.Equal(33, itensDavenda.ItemQuantity);
                  Assert.Equal(1.5M, itensDavenda.ItemPrice);
              },
              itensDavenda =>
              {
                  Assert.Equal(3, itensDavenda.ItemId);
                  Assert.Equal(40, itensDavenda.ItemQuantity);
                  Assert.Equal(0.10M, itensDavenda.ItemPrice);
              }
              );
            });
        }

        [Fact]
        public void TesteLeituraCompleta()
        {
            var lerArquivo = new LerArquivo();
            var retorno = lerArquivo.InterpretarArquivo(@"Arquivos/TesteCompleto.txt");

            Assert.Collection(retorno.Vendedores, itens =>
            {
                Assert.Equal("001", itens.Type);
                Assert.Equal("1234567891234", itens.Cpf);
                Assert.Equal(5000M, itens.Salary);
                Assert.Equal("Pedro", itens.Name);
            },
          itens =>
          {
              Assert.Equal("001", itens.Type);
              Assert.Equal("3245678865434", itens.Cpf);
              Assert.Equal(4000.99M, itens.Salary);
              Assert.Equal("Paulo", itens.Name);
          });

            Assert.Collection(retorno.Clientes, itens =>
            {
                Assert.Equal("002", itens.Type);
                Assert.Equal("2345675434544345", itens.Cnpj);
                Assert.Equal("Jose da Silva", itens.Name);
                Assert.Equal("Rural", itens.BusinessArea);
            },
          itens =>
          {
              Assert.Equal("002", itens.Type);
              Assert.Equal("2345675433444345", itens.Cnpj);
              Assert.Equal("Eduardo Pereira", itens.Name);
              Assert.Equal("Rural", itens.BusinessArea);
          });

            Assert.Collection(retorno.Vendas, itens =>
            {
                Assert.Equal("003", itens.Type);
                Assert.Equal(15, itens.SaleId);
                Assert.Equal("Pedro", itens.Salesman);
                Assert.Collection(itens.Itens, itensDavenda =>
                {
                    Assert.Equal(1, itensDavenda.ItemId);
                    Assert.Equal(10, itensDavenda.ItemQuantity);
                    Assert.Equal(150M, itensDavenda.ItemPrice);
                },
                itensDavenda =>
                {
                    Assert.Equal(2, itensDavenda.ItemId);
                    Assert.Equal(30, itensDavenda.ItemQuantity);
                    Assert.Equal(2.5M, itensDavenda.ItemPrice);
                },
                itensDavenda =>
                {
                    Assert.Equal(3, itensDavenda.ItemId);
                    Assert.Equal(40, itensDavenda.ItemQuantity);
                    Assert.Equal(3.1M, itensDavenda.ItemPrice);
                }
                );
            },
            itens =>
            {
                Assert.Equal("003", itens.Type);
                Assert.Equal(48, itens.SaleId);
                Assert.Equal("Paulo Ricardo", itens.Salesman);
                Assert.Collection(itens.Itens, itensDavenda =>
                {
                    Assert.Equal(1, itensDavenda.ItemId);
                    Assert.Equal(34, itensDavenda.ItemQuantity);
                    Assert.Equal(130M, itensDavenda.ItemPrice);
                },
              itensDavenda =>
              {
                  Assert.Equal(2, itensDavenda.ItemId);
                  Assert.Equal(33, itensDavenda.ItemQuantity);
                  Assert.Equal(1.5M, itensDavenda.ItemPrice);
              },
              itensDavenda =>
              {
                  Assert.Equal(3, itensDavenda.ItemId);
                  Assert.Equal(40, itensDavenda.ItemQuantity);
                  Assert.Equal(0.10M, itensDavenda.ItemPrice);
              }
              );
            });
        }
    }
}
