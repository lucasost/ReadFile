using ReadFile.Domain.Interfaces;

namespace ReadFile.Service
{
    public class RegistrarNoArquivo : IRegistro
    {
        public void RegistrarInfo(string mensagem, string path)
        {
            using (var streamWriter = new System.IO.StreamWriter(path, true))
            {
                streamWriter.WriteLine(mensagem);
            }
        }
    }
}
