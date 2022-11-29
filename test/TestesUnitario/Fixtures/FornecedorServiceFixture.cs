using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Services;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestesUnitario.Collections
{
    public class FornecedorServiceFixture
    {
        public Mock<IFornecedorRepository> FornecedorRepositoryMock { get; set; }
        public Mock<IEnderecoRepository> EnderecoRepositoryMock { get; set; }
        public Mock<INotificador> NotificadorMock { get; set; }

        public FornecedorService SetupFornecedorServiceComSucesso()
        {
            CarregarMocks();

            return new FornecedorService(
                FornecedorRepositoryMock.Object,
                EnderecoRepositoryMock.Object,
                NotificadorMock.Object);
        }

        public FornecedorService SetupFornecedorServiceSemSucesso()
        {
            CarregarMocks();

            FornecedorRepositoryMock
               .Setup(f => f.Buscar(It.IsAny<Expression<Func<Fornecedor, bool>>>()))
               .ReturnsAsync(BuscarSucesso());

            return new FornecedorService(
                FornecedorRepositoryMock.Object,
                EnderecoRepositoryMock.Object,
                NotificadorMock.Object);
        }
        

        private void CarregarMocks()
        {
            FornecedorRepositoryMock = new Mock<IFornecedorRepository>();
            EnderecoRepositoryMock = new Mock<IEnderecoRepository>();
            NotificadorMock = new Mock<INotificador>();
        }

        public Fornecedor ObterFornecedorValido()
        {
            var fornecedorJson = System.IO.File.ReadAllText("Json/FornecedorTest.json");

            var fornecedor = JsonConvert.DeserializeObject<Fornecedor>(fornecedorJson);

            return fornecedor;
        }

        public IEnumerable<Fornecedor> BuscarSucesso()
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();
            fornecedores.Add(new Fornecedor("69392289000138"));            
            fornecedores.Add(new Fornecedor("69392289000138"));            

            return fornecedores;
        }
    }
}