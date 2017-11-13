using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TSA.Mongo.Entities
{
    public class Pessoa : IEntityIdentity
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Observacao { get; set; }
        public string NomeSoundex { get; set; }
        public int Situacao { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public Pessoa()
        {
            Telefones = new List<Telefone>();
        }
    }

    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(s => s.Id);
            builder.ToTable("Pessoa");
        }
    }

    public interface IEntityIdentity
    {
        long Id { get; set; }
    }
}
