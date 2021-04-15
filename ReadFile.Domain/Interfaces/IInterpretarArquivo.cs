using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Domain.Interfaces
{
    public interface IInterpretarArquivo
    {
        void LerArquivo(string caminhoArquivo, string nomeDoArquivo);
    }
}
