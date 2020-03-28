using Xunit;
using Medy.Dominio;

namespace Medy.Teste.Testes
{
    public class ValidaPrimeiraLetraMaiusculaTeste
    {
        
        [Theory]
        [InlineData("Alfredo")]
        [InlineData("João")]
        [InlineData("Denise")]
        [InlineData("elma")]
        public void ValidaSePrimeiraLetraEhMaiuscula(string Valor)
        {       
            PrimeiraLetraMaiusculaAttribute primeiraLMaiuscula = new PrimeiraLetraMaiusculaAttribute();
            var SeMaiusculo = primeiraLMaiuscula.BoolSePrimeiraLetraMaiuscula(Valor); 
            Assert.Equal(SeMaiusculo, true); 

        }

    }
}