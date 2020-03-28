using Microsoft.AspNetCore.Mvc;
using Medy.Dominio;
using System.Collections.Generic;
using Medy.Contexto;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Medy.Util;

namespace Medy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatosController : ControllerBase
    {
        private readonly AppDbContext _contexto;
        private readonly IMapper _mapper;
        private readonly IRetornaIdade _RetornaIdade;

        public ContatosController(AppDbContext contexto, IMapper mapper, IRetornaIdade retornaIdade)
        {
            _contexto = contexto;
            _mapper = mapper;
            _RetornaIdade = retornaIdade;
        }

        [HttpGet("Teste")]
        public string Get2()
        {
            return "Thiago:";
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contato>> Get(int Id, int PagInicio = 0, int QuantPag = 10)
        {

            if (QuantPag > 50)
                QuantPag = 50;

            if (PagInicio < 0)
                PagInicio = 0;

            IEnumerable<Contato> contato;

            if (Id != 0)
            {
                contato = _contexto.Contato.Where(x => x.Id == Id).Skip(PagInicio).Take(QuantPag).ToList();
                goto Fim;
            }

            contato = _contexto.Contato.Skip(PagInicio).Take(QuantPag).ToList();

        Fim:
            return Ok(contato);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ContatoDTO contato)
        {
            var ContatoNovo = _mapper.Map<Contato>(contato);
            ContatoNovo.Idade = _RetornaIdade.Idade(contato.DataNascimento);
            ContatoNovo.Id = 0;

            _contexto.Contato.Add(ContatoNovo);
            _contexto.SaveChanges();

            return new CreatedAtRouteResult($"/{ContatoNovo.Id}", ContatoNovo);
        }


        [HttpPut]
        public ActionResult Put([FromBody] ContatoDTO contato)
        {
            var ContatoNovo = _mapper.Map<Contato>(contato);
            ContatoNovo.Idade = _RetornaIdade.Idade(contato.DataNascimento);

            _contexto.Entry(ContatoNovo).State = EntityState.Modified;
            _contexto.SaveChanges();

            return new CreatedAtRouteResult($"/{ContatoNovo.Id}", ContatoNovo);
        }

        [HttpGet]


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Contato contato = _contexto.Contato.FirstOrDefault(x => x.Id == id);

            if (contato == null)
                return BadRequest();

            _contexto.Contato.Remove(contato);
            _contexto.SaveChanges(); 
            
            return Ok();
        }

    }
}