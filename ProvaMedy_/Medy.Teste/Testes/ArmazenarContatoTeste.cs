using Moq;
using System;
using Xunit;
using Medy.Dominio;

namespace Medy.Teste.Testes
{
    public class ArmazenarContatoTeste
    {

        [Fact]
        public void TesteDeArmazenamentoDeContato()
        {

            var ContatoDTO = new ContatoDTO
            {
                Id = 0,
                Nome = "Contato A",
                DataNascimento = Convert.ToDateTime("01/01/1980")
            };

            var ContatoRepositorioMock = new Mock<IContatoRepositorio>();

            var _ArmazenadorDeContato = new ArmazenadorDeContato(ContatoRepositorioMock.Object);

            _ArmazenadorDeContato.Armazenar(ContatoDTO);

            ContatoRepositorioMock.Verify(r => r.Adicionar(
                It.Is<Contato>(c =>
                c.Nome == ContatoDTO.Nome &&
                c.Id == ContatoDTO.Id &&
                c.DataNascimento == ContatoDTO.DataNascimento
                )
                ), Times.AtLeast(1));

            
        }
    }


    public interface IContatoRepositorio
    {
        void Adicionar(Contato contato);
    }

    internal class ArmazenadorDeContato
    {
        private readonly IContatoRepositorio _ContatoRepositorio;

        public ArmazenadorDeContato(IContatoRepositorio ContatoRepositorio)
        {
            _ContatoRepositorio = ContatoRepositorio;
        }

        internal void Armazenar(ContatoDTO ContatoDTO)
        {
            var Contato = new Contato
            {
                Nome = ContatoDTO.Nome,
                Id = ContatoDTO.Id,
                DataNascimento = ContatoDTO.DataNascimento,
                Idade = 0
            };
            _ContatoRepositorio.Adicionar(Contato);
        }
    }


}