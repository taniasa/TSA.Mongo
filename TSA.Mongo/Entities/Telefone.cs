using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TSA.Mongo.Entities
{
    public class Telefone : IEntityIdentity
    {
        public Int64 Id { get; set; }
        public Int64 PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public string NumeroTelefone { get; set; }
        public string Descricao { get; set; }
        public int Tipo { get; set; }
        public int Operadora { get; set; }
        public int FlPrincipal { get; set; }
        public bool NumeroWhats { get; set; }
    }
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(s => s.Id);
            builder.ToTable("Telefone");
            builder.HasOne(s => s.Pessoa).WithMany(l => l.Telefones).HasForeignKey(f => f.PessoaId);
        }
    }
}
