# ReadFile
***Biblioteca utilizada:***

- FileHelpers

***Ferramentas utilizadas***
- Visual Studio / Visual Studio Code
- Docker

***Extension utilizada (opcional)***
- Sonar

Sobre o Funcionamento:
----
Ao rodar o programa, serão criados duas pastas.

*%homepath%/data/in* - Local aonde será necessário adicionar os arquivos.

*%homepath%/data/out* - Local aonde os arquivos inseridos em *data/in* serão criados com a interpretação. 



Formatação do arquivo:
-----

***Dados do vendedor***

Os dados do vendedor possuem o identificador 001 e seguem o seguinte formato:
001çCPFçNameçSalary

***Dados do cliente***

Os dados do cliente possuem o identificador 002 e seguem o seguinte formato:
002çCNPJçNameçBusiness Area

***Dados de venda***

Os dados de venda possuem o identificador 003 e seguem o seguinte formato:
003çSale IDç[Item ID-Item Quantity-Item Price]çSalesman name

Interpretações implementadas:
-----
O sistema ao ler o arquivo e posteriormente salvar em na pasta *data/out* exibirá as seguintes informações:

- Quantidade de clientes no arquivo de entrada;
- Quantidade de vendedores no arquivo de entrada;
- ID da venda mais cara;
- O pior vendedor.

Exemplo de conteúdo do arquivo
---
```
001ç1234567891234çPedroç5000
001ç3245678865434çPauloç4000.99
002ç2345675434544345çJose da SilvaçRural
002ç2345675433444345çEduardo PereiraçRural
003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro
003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çPaulo Ricardo
```
