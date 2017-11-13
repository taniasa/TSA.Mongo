using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TSA.Mongo.Dto;
using Microsoft.EntityFrameworkCore;

namespace TSA.Mongo.Entities
{
    public class PessoaRepository
    {
        private Context _context;
        public PessoaRepository()
        {
            _context = new Context();
        }

        public List<PessoaDto> BuscarPessoas()
        {
            var dados = from pessoa in _context.Set<Pessoa>().Include(s=>s.Telefones)
                        select new PessoaDto()
                        {
                            Id = pessoa.Id,
                            Nome = pessoa.Nome,
                            NomeSoundex = pessoa.NomeSoundex,
                            Observacao = pessoa.Observacao,
                            DataCadastro = pessoa.DataCadastro,
                            Situacao = pessoa.Situacao,
                            Telefones = (from tel in pessoa.Telefones
                                         select new TelefoneDto()
                                         {
                                             Id = tel.Id,
                                             Descricao = tel.Descricao,
                                             NumeroTelefone = tel.NumeroTelefone,
                                             FlPrincipal = tel.FlPrincipal,
                                             NumeroWhats = tel.NumeroWhats,
                                             Operadora = tel.Operadora,
                                             PessoaId = tel.PessoaId,
                                             Tipo = tel.Tipo
                                         })
                        };
            var retorno = dados.ToList();
            return retorno;
        }           
    }
}
