using ReadFile.Domain.Interfaces;

namespace ReadFile.Service
{
    public class RegistrarInformacao : IRegistro
    {
        private readonly IRegistro _registro;

        public RegistrarInformacao(IRegistro registro)
        {
            _registro = registro;
        }

        public void RegistrarInfo(string mensagem, string path)
        {
            _registro.RegistrarInfo($"{mensagem}", path);
        }
    }
}
