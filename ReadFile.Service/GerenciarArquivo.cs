using ReadFile.Domain.Interfaces;
using System;
using System.IO;

namespace ReadFile.Service
{
    public class GerenciarArquivo : IGerenciarArquivo
    {
        public void CriarCaminho(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine($"Caminho {Directory.GetCreationTime(path)} já exite!");
            }
            else
            {
                Directory.CreateDirectory(path);
                Console.WriteLine($"Diretório criado com sucesso {Directory.GetCreationTime(path)}.");
            }
        }
    }
}
