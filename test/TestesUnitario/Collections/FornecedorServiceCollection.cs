using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestesUnitario.Collections
{
    [CollectionDefinition(nameof(FornecedorServiceCollection))]
    public class FornecedorServiceCollection :
        ICollectionFixture<FornecedorServiceFixture>
    {
    }
}
