using System;
using System.Collections.Generic;
using System.Text;
using TSA.Mongo.Entities;

namespace TSA.Mongo.Dto
{
    public class TelefoneDto : IEntityIdentity
    {
        public Int64 Id { get; set; }
        public Int64 PessoaId { get; set; }
        public string NumeroTelefone { get; set; }
        public string Descricao { get; set; }
        public int Tipo { get; set; }
        public int Operadora { get; set; }
        public int FlPrincipal { get; set; }
        public bool NumeroWhats { get; set; }
    }
}
