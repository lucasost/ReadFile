using ReadFile.Domain.ViewModel;

namespace ReadFile.Domain.Interfaces
{
    public interface ILerArquivoRepository
    {
        DadosRetornoArquivoModel InterpretarArquivo(string caminhoArquivo);
    }
}
