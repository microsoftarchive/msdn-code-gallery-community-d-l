using System;
using Repository.Domain;
using Repository.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Repository.UnitTest
{
    [TestClass]
    public class ClienteUnitTest
    {
        UnitOfWork _unitOfWork = new UnitOfWork();   

        [TestMethod]
        public void Adicionar()
        {
            Cliente novoCliente = new Cliente();

            novoCliente.nome = "John Doel";
            novoCliente.email = "john.doel@hotmail.com";
            novoCliente.endereco = "Avenue: 7th Rummel Pax 289";
            novoCliente.bairro = "St Pitsburg";
            novoCliente.cidade = "Austin";
            novoCliente.uf = "TX";

            _unitOfWork.ClienteRepository.Add(novoCliente);
        }

        [TestMethod]
        public void Editar()
        {
            Cliente editarCliente = _unitOfWork.ClienteRepository.Get(x => x.id == 1000)[0];

            editarCliente.nome = "John Doel Gates";
            editarCliente.email = "john.doel.gates@msn.com";
            editarCliente.endereco = "Street: Philadelph 289";

            _unitOfWork.ClienteRepository.Add(editarCliente);
        }

        [TestMethod]
        public void Deletar()
        {
            Cliente deletarCliente = _unitOfWork.ClienteRepository.Get(x => x.id == 1000)[0];
            _unitOfWork.ClienteRepository.Delete(deletarCliente);
        }
    }
}
