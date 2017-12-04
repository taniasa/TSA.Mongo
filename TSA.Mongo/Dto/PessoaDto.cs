using System;
using System.Collections.Generic;
using System.Text;
using TSA.Mongo.Entities;

namespace TSA.Mongo.Dto
{
    public class PessoaDto : IEntityIdentity, IDto
    {
        public string IdDto { get; set; }
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Observacao { get; set; }
        public string NomeSoundex { get; set; }
        public int Situacao { get; set; }
        public IEnumerable<TelefoneDto> Telefones { get; set; }
        public string Key { get; set; }






        public PessoaDto()
        {
            Telefones = new List<TelefoneDto>();
        }
    }
}
