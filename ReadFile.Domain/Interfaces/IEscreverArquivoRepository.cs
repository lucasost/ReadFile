using ReadFile.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Domain.Interfaces
{
    public interface IEscreverArquivoRepository
    {
        void EscreverArquivo(DadosRetornoArquivoModel dadosDoArquivo, string caminhoSaida);
    }
}
