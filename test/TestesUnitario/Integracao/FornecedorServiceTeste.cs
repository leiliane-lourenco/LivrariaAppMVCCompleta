using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestesUnitario.Collections;
using Xunit;

namespace TestesUnitario.Integracao
{
    [Collection(nameof(FornecedorServiceCollection))]
    public class FornecedorServiceTeste
    {
        private FornecedorServiceFixture _fornecedorServiceFixture;
        public FornecedorServiceTeste(FornecedorServiceFixture fornecedorServiceFixture)
        {
            _fornecedorServiceFixture = fornecedorServiceFixture;
        }

        [Fact(DisplayName = "FornecedorServiceTeste - Adicionar com sucesso")]
        [Trait("Service", "FornecedorService")]

        public async Task FornecedorService_DadoQueClForncedorValido_AdicionarComSucesso()
        {
            //Arrange
            var fornecedor = _fornecedorServiceFixture.ObterFornecedorValido();

            var fornecedorService =  _fornecedorServiceFixture.SetupFornecedorServiceComSucesso();

            //Act
            var resultado =  fornecedorService.Adicionar(fornecedor);

            //Assert
            _fornecedorServiceFixture.FornecedorRepositoryMock
                .Verify(f => f.Buscar(f => f.Documento == fornecedor.Documento), Times.Exactly(1));

            _fornecedorServiceFixture.FornecedorRepositoryMock
                .Verify(f => f.Adicionar(fornecedor), Times.Exactly(1));
        }

        [Fact(DisplayName = "FornecedorServiceTeste - Retornar que o Fornecedor já existe  e não inserir")]
        [Trait("Service", "FornecedorService")]
        public async Task FornecedorService_DadoQueClForncedorValido_AdicionarSucesso()
        {
            //Arrange
            var fornecedor = _fornecedorServiceFixture.ObterFornecedorValido();


            var fornecedorService = _fornecedorServiceFixture.SetupFornecedorServiceSemSucesso();

            //Act
            var resultado = fornecedorService.Adicionar(fornecedor);

            //Assert
            _fornecedorServiceFixture.FornecedorRepositoryMock
                .Verify(f => f.Buscar(f => f.Documento == fornecedor.Documento), Times.Exactly(1));

            _fornecedorServiceFixture.FornecedorRepositoryMock
                .Verify(f => f.Adicionar(fornecedor), Times.Never);
        }


    }
}
