using Xunit;
using Medy.Util;
using System;

namespace Medy.Teste.Testes
{
    public class CalculoIdadeTesta
    {
        
        [Theory]
        [InlineData("23/01/1988", 32)]
        [InlineData("05/02/1998", 22)]
        [InlineData("01/05/2001", 18)]
        [InlineData("10/03/1971", 49)]
        public void TestaRetornoDaIdadeEnviandoUmaDataDeNascimento(string DataNascimento, int IdadeEsperada)
        {       
            RetornaIdade _retornaIdade = new RetornaIdade();
            Assert.Equal(_retornaIdade.Idade(Convert.ToDateTime(DataNascimento)), IdadeEsperada);
        }


    }
}