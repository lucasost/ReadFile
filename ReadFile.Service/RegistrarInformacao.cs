using ReadFile.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Service
{
    public class RegistrarInformacao : IRegistro
    {
        private readonly IRegistro _registro;

        public RegistrarInformacao(IRegistro registro)
        {
            _registro = registro;
        }

        public void RegistrarInfo(string mensagem)
        {
            _registro.RegistrarInfo($"{mensagem}:{DateTime.Now}");
        }
    }
}
