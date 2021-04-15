using FileHelpers;
using ReadFile.Domain.Interfaces;
using ReadFile.Service;
using ReadFile.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadFile
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Gerenciado de leitura de arquivos e interpretador de vendas.");

            IGerenciarArquivo gerenciarArquivo = new GerenciarArquivo();

            string caminhoHomePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var diretorioCompletoOut = caminhoHomePath + "\\data\\out\\";
            var diretorioCompletoIn = caminhoHomePath + "\\data\\in\\";

            gerenciarArquivo.CriarCaminho(diretorioCompletoOut);
            gerenciarArquivo.CriarCaminho(diretorioCompletoIn);

            Console.WriteLine("\n \n \n");
            Console.WriteLine("Monitorando para ler arquivos.");

            //Monitorar pasta

        }
    }
}
