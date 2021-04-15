using ReadFile.Domain.Interfaces;

namespace ReadFile.Service
{
   public class RegistrarNoArquivo : IRegistro
    {
        private readonly string _caminhoNomeDoArquivo;

        public RegistrarNoArquivo(string path)
        {
            _caminhoNomeDoArquivo = path;
        }

        public void RegistrarInfo(string mensagem)
        {
            Log(mensagem);
        }

        private void Log(string mensagem)
        {
            using (var streamWriter = new System.IO.StreamWriter(_caminhoNomeDoArquivo, true))
            {
                streamWriter.WriteLine(mensagem);
            }
        }
    }
}
