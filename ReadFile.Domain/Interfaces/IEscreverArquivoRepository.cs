using ReadFile.Domain.ViewModel;

namespace ReadFile.Domain.Interfaces
{
    public interface IEscreverArquivoRepository
    {
        void EscreverArquivo(DadosRetornoArquivoModel dadosDoArquivo, string caminhoSaida, string nomeArquivoSaida);
    }
}
