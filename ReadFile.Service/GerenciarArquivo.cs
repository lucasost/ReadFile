using ReadFile.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile.Service
{
    public class GerenciarArquivo : IGerenciarArquivo
    {
        public void CriarCaminho(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine("Caminho já exite!");
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine($"Diretório criado com sucesso {Directory.GetCreationTime(path)}.");
            }
        }

    }
}
